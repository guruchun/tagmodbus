using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TagModbusLib;

namespace TagModbus
{
    /// <summary>
    /// Tag data store managed by DataTable.
    /// Holds tag info loaded from Modbus Map and real-time values.
    /// </summary>
    public class TagStore
    {
        private static readonly Lazy<TagStore> _instance = new(() => new TagStore());
        public static TagStore Instance => _instance.Value;

        public DataTable Table { get; } = new();

        // Tag -> RegisterDef mapping (address, datatype, scale info)
        public Dictionary<string, RegisterDef> TagIndex { get; private set; } = new();

        // Address -> RegisterDef mapping
        public Dictionary<string, RegisterDef> AddrIndex { get; private set; } = new();

        private TagStore()
        {
            // Define DataTable columns: Tag, Value, Unit, Description, Updated
            Table.Columns.Add("Tag", typeof(string));
            Table.Columns.Add("Value", typeof(string));
            Table.Columns.Add("Unit", typeof(string));
            Table.Columns.Add("Description", typeof(string));
            Table.Columns.Add("Updated", typeof(DateTime));
            Table.PrimaryKey = new[] { Table.Columns["Tag"]! };
        }

        /// <summary>
        /// Loads a Modbus Map file and populates the tag table.
        /// </summary>
        public void LoadMap(string filePath)
        {
            var map = ModbusMapLoader.Load(filePath);
            TagIndex = ModbusMapLoader.BuildTagIndex(map);
            AddrIndex = ModbusMapLoader.BuildAddressIndex(map);

            Table.Rows.Clear();
            foreach (var kvp in TagIndex)
            {
                var reg = kvp.Value;
                string initValue = reg.GetRegisterCount() > 1
                    ? string.Join(",", new string[reg.GetRegisterCount()].Select(_ => "0"))
                    : "0";

                Table.Rows.Add(reg.Tag, initValue, reg.Unit, reg.Description, DateTime.Now);
            }
        }

        /// <summary>
        /// Updates a tag value.
        /// </summary>
        public void SetValue(string tag, string value)
        {
            var row = Table.Rows.Find(tag);
            if (row != null)
            {
                row["Value"] = value;
                row["Updated"] = DateTime.Now;
            }
        }

        /// <summary>
        /// Reads a tag value.
        /// </summary>
        public string GetValue(string tag)
        {
            var row = Table.Rows.Find(tag);
            return row != null ? $"{row["Value"]}" : "#TAG";
        }
    }
}
