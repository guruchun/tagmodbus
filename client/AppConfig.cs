using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using log4net;

namespace TagModbus
{
    public class ModbusConfig
    {
        [JsonPropertyName("mapList")]
        public Dictionary<string, string> MapList { get; set; } = new();

        // Connection mode
        [JsonPropertyName("mode")]
        public string Mode { get; set; } = "TCP";

        // TCP settings
        [JsonPropertyName("ip")]
        public string Ip { get; set; } = "127.0.0.1";

        [JsonPropertyName("port")]
        public int Port { get; set; } = 502;

        // RTU settings
        [JsonPropertyName("comPort")]
        public string ComPort { get; set; } = "COM1";

        [JsonPropertyName("baudRate")]
        public int BaudRate { get; set; } = 9600;

        [JsonPropertyName("dataBits")]
        public int DataBits { get; set; } = 8;

        [JsonPropertyName("parity")]
        public string Parity { get; set; } = "None";

        [JsonPropertyName("stopBits")]
        public string StopBits { get; set; } = "One";

        // Common settings
        [JsonPropertyName("unitId")]
        public int UnitId { get; set; } = 1;

        [JsonPropertyName("connTimeout")]
        public int ConnTimeout { get; set; } = 1000;

        [JsonPropertyName("responseTimeout")]
        public int ResponseTimeout { get; set; } = 1000;

        [JsonPropertyName("monInterval")]
        public int MonInterval { get; set; } = 500;
    }

    public class WindowConfig
    {
        [JsonPropertyName("width")]
        public int Width { get; set; } = 1024;

        [JsonPropertyName("height")]
        public int Height { get; set; } = 768;
    }

    public class AppConfig
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AppConfig));
        private static AppConfig _instance;
        private static string _configPath;

        [JsonPropertyName("modbus")]
        public ModbusConfig ModbusConf { get; set; } = new();

        [JsonPropertyName("logView")]
        public List<string> LogViewList { get; set; } = new();

        [JsonPropertyName("window")]
        public WindowConfig WindowConf { get; set; } = new();

        // Static accessors
        public static ModbusConfig Modbus { get { _instance ??= Load(); return _instance.ModbusConf; } }
        public static List<string> LogView { get { _instance ??= Load(); return _instance.LogViewList; } }
        public static WindowConfig Window { get { _instance ??= Load(); return _instance.WindowConf; } }

        private static AppConfig Load()
        {
            _configPath = Path.Combine(Application.StartupPath, "config", "client-config.json");
            try
            {
                string json = File.ReadAllText(_configPath);
                return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
            }
            catch (Exception e)
            {
                log.Error($"config loading error: {e.Message}");
                return new AppConfig();
            }
        }

        /// <summary>
        /// Saves current config to client-config.json.
        /// </summary>
        public static void Save()
        {
            try
            {
                _configPath ??= Path.Combine(Application.StartupPath, "config", "client-config.json");
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(_instance ?? Load(), options);
                File.WriteAllText(_configPath, json);
            }
            catch (Exception e)
            {
                log.Error($"config saving error: {e.Message}");
            }
        }
    }
}
