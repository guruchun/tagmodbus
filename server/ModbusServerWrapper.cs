/**
 * NModbus 3.x based Modbus TCP/RTU Server wrapper
 */
using log4net;
using NModbus;
using NModbus.Data;
using NModbus.Device;
using NModbus.Serial;
using System;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using TagModbusLib;

namespace TagModbusSvr
{
    public class DataChangedEventArgs : EventArgs
    {
        public string Address { get; }
        public string Value { get; }

        public DataChangedEventArgs(string address, string value)
        {
            Address = address;
            Value = value;
        }
    }

    /// <summary>
    /// NModbus 3.x based Modbus TCP/RTU Server (Slave).
    /// Uses SlaveDataStore with PointSource for data storage and write detection.
    /// </summary>
    public class ModbusServerWrapper
    {
        private static readonly ILog log = LogManager.GetLogger("Console");
        private TcpListener _listener;
        private IModbusSlaveNetwork _slaveNetwork;
        private IModbusSlave _slave;
        private CancellationTokenSource _cts;
        private bool _isRunning;
        private Task _listenTask;
        private SlaveDataStore _dataStore;

        // session changed event
        public delegate void NumberOfClientsChanged();
        public event NumberOfClientsChanged evtNumberOfClientsChanged;

        // Modbus server's RegisterChanged event
        public event EventHandler<DataChangedEventArgs> RegisterChanged;

        // function disabled properties
        public bool FunctionCode1Disabled { get; set; }
        public bool FunctionCode2Disabled { get; set; }
        public bool FunctionCode3Disabled { get; set; }
        public bool FunctionCode4Disabled { get; set; }
        public bool FunctionCode5Disabled { get; set; }
        public bool FunctionCode6Disabled { get; set; }
        public bool FunctionCode15Disabled { get; set; }
        public bool FunctionCode16Disabled { get; set; }
        public bool FunctionCode23Disabled { get; set; }

        // Modbus data models
        public int BaseAddrREG = 0;
        public int BaseAddrBIT = 0;
        public UInt16[] RegValues = new UInt16[65535];
        public bool[] BitValues = new bool[65535];

        // private members
        private ModbusMapHelper mapHelper = new();
        public ModbusMapHelper MbMapper { get => mapHelper; }

        // Server properties
        public int NumberOfConnections { get; set; }
        public int Port { get; set; }
        public byte UnitId { get; set; } = 1;

        // RTU properties
        public string ComPort { get; set; } = "COM1";
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public Parity RtuParity { get; set; } = Parity.None;
        public StopBits RtuStopBits { get; set; } = StopBits.One;

        private SerialPort _serialPort;
        private IModbusSlaveNetwork _rtuSlaveNetwork;

        // singleton
        private static ModbusServerWrapper _instance = null;
        private ModbusServerWrapper()
        {
        }

        public static ModbusServerWrapper getInstance()
        {
            _instance ??= new ModbusServerWrapper();
            return _instance;
        }

        public void Start()
        {
            StartTcp();
        }

        public void StartTcp()
        {
            try
            {
                IPAddress localAddr = IPAddress.Any;
                _listener = new TcpListener(localAddr, Port);
                _listener.Start();

                var factory = new ModbusFactory();
                _slaveNetwork = factory.CreateSlaveNetwork(_listener);

                _dataStore = CreateDataStore();
                _slave = factory.CreateSlave(UnitId, _dataStore);
                _slaveNetwork.AddSlave(_slave);

                _cts = new CancellationTokenSource();
                _listenTask = Task.Run(() => _slaveNetwork.ListenAsync(_cts.Token));
                _isRunning = true;
                log.Info($"Modbus TCP Server started on port {Port}, UnitId={UnitId}");
            }
            catch (Exception e1)
            {
                log.Error("fail to start TCP server, " + e1.Message);
            }
        }

        public void StartRtu()
        {
            try
            {
                _serialPort = new SerialPort(ComPort, BaudRate, RtuParity, DataBits, RtuStopBits);
                _serialPort.Open();

                var factory = new ModbusFactory();
                var adapter = new SerialPortAdapter(_serialPort);
                _rtuSlaveNetwork = factory.CreateRtuSlaveNetwork(adapter);

                _dataStore = CreateDataStore();
                _slave = factory.CreateSlave(UnitId, _dataStore);
                _rtuSlaveNetwork.AddSlave(_slave);

                _cts = new CancellationTokenSource();
                _listenTask = Task.Run(() => _rtuSlaveNetwork.ListenAsync(_cts.Token));
                _isRunning = true;
                log.Info($"Modbus RTU Server started on {ComPort}, {BaudRate}, UnitId={UnitId}");
            }
            catch (Exception e1)
            {
                log.Error("fail to start RTU server, " + e1.Message);
            }
        }

        public void Stop()
        {
            try
            {
                _cts?.Cancel();
                _listener?.Stop();
                _listener = null;
                _serialPort?.Close();
                _serialPort?.Dispose();
                _serialPort = null;
                _isRunning = false;
            }
            catch (Exception e1)
            {
                log.Debug("error stopping modbus server, " + e1.Message);
            }
            log.Debug("stopped modbus server");
        }

        public bool IsRunning()
        {
            return _isRunning;
        }

        public void SetValue(string tag, string values)
        {
            mapHelper.SetModbusValue(tag, values, ref RegValues);
            SyncRegValuesToDataStore();
        }

        /// <summary>
        /// Synchronizes internal RegValues array to the NModbus data store.
        /// </summary>
        public void SyncRegValuesToDataStore()
        {
            if (_dataStore == null) return;
            var holdingRegs = _dataStore.HoldingRegisters;
            for (ushort i = 0; i < RegValues.Length; i++)
            {
                holdingRegs.WritePoints(i, new ushort[] { RegValues[i] });
            }
        }

        /// <summary>
        /// Synchronizes internal BitValues array to the NModbus data store.
        /// </summary>
        public void SyncBitValuesToDataStore()
        {
            if (_dataStore == null) return;
            var coils = _dataStore.CoilDiscretes;
            for (ushort i = 0; i < BitValues.Length; i++)
            {
                coils.WritePoints(i, new bool[] { BitValues[i] });
            }
        }

        // -----------------------------------------------------------------
        // Private helpers
        // -----------------------------------------------------------------

        private SlaveDataStore CreateDataStore()
        {
            var dataStore = new SlaveDataStore();

            // Subscribe to AfterWrite events for external write detection
            dataStore.HoldingRegisters.AfterWrite += OnHoldingRegistersWritten;
            dataStore.CoilDiscretes.AfterWrite += OnCoilsWritten;

            // Initialize data store with current values
            SyncAllToDataStore(dataStore);

            return dataStore;
        }

        private void SyncAllToDataStore(SlaveDataStore dataStore)
        {
            // Bulk write holding registers
            for (ushort i = 0; i < RegValues.Length; i++)
            {
                if (RegValues[i] != 0)
                    dataStore.HoldingRegisters.WritePoints(i, new ushort[] { RegValues[i] });
            }
            // Bulk write coils
            for (ushort i = 0; i < BitValues.Length; i++)
            {
                if (BitValues[i])
                    dataStore.CoilDiscretes.WritePoints(i, new bool[] { BitValues[i] });
            }
        }

        private void OnHoldingRegistersWritten(object sender, PointEventArgs e)
        {
            // Sync written values back from data store to internal RegValues
            var regs = _dataStore.HoldingRegisters.ReadPoints(e.StartAddress, e.NumberOfPoints);
            for (int i = 0; i < regs.Length; i++)
            {
                int addr = e.StartAddress + i;
                if (addr < RegValues.Length)
                {
                    RegValues[addr] = regs[i];
                }
            }
            RegisterChanged?.Invoke(this, new DataChangedEventArgs(
                $"HREG:{e.StartAddress}", string.Join(",", regs)));
        }

        private void OnCoilsWritten(object sender, PointEventArgs e)
        {
            // Sync written values back from data store to internal BitValues
            var coils = _dataStore.CoilDiscretes.ReadPoints(e.StartAddress, e.NumberOfPoints);
            for (int i = 0; i < coils.Length; i++)
            {
                int addr = e.StartAddress + i;
                if (addr < BitValues.Length)
                {
                    BitValues[addr] = coils[i];
                }
            }
            RegisterChanged?.Invoke(this, new DataChangedEventArgs(
                $"COIL:{e.StartAddress}", string.Join(",", coils)));
        }
    }
}
