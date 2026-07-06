using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using TagModbusLib;

namespace TagModbusSvr
{
    /// <summary>
    /// Tag data store managed by DataTable.
    /// Holds tag info loaded from Modbus Map and real-time values.
    /// Server-side equivalent of client's TagStore.
    /// </summary>
    public class TagStore
    {
        private static readonly Lazy<TagStore> _instance = new(() => new TagStore());
        public static TagStore Instance => _instance.Value;

        public DataTable Table { get; } = new();

        // Tag -> RegisterDef mapping (from ModbusMapLoader)
        public Dictionary<string, RegisterDef> TagIndex { get; private set; } = new();

        // Address -> RegisterDef mapping
        public Dictionary<string, RegisterDef> AddrIndex { get; private set; } = new();

        private TagStore()
        {
            // Define DataTable columns
            Table.Columns.Add("Tag", typeof(string));
            Table.Columns.Add("Address", typeof(string));
            Table.Columns.Add("Value", typeof(string));
            Table.Columns.Add("Unit", typeof(string));
            Table.Columns.Add("Description", typeof(string));
            Table.Columns.Add("Updated", typeof(DateTime));
            Table.PrimaryKey = new[] { Table.Columns["Tag"]! };
        }

        /// <summary>
        /// Loads a Modbus Map file (YAML/JSON) and populates the tag table.
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
                    ? string.Join(",", Enumerable.Repeat("0", reg.GetRegisterCount()))
                    : "0";

                Table.Rows.Add(reg.Tag, $"{reg.Address}", initValue, reg.Unit, reg.Description, DateTime.Now);
            }
        }

        /// <summary>
        /// Loads a legacy XML map via ModbusMapHelper and populates the tag table.
        /// </summary>
        public void LoadXmlMap(string filePath, ModbusMapHelper mapHelper)
        {
            mapHelper.Load(filePath, Table);
        }

        /// <summary>
        /// Updates a tag value.
        /// </summary>
        public void SetValue(string tag, string value)
        {
            try
            {
                var row = Table.Rows.Find(tag);
                if (row != null)
                {
                    row["Value"] = value;
                    row["Updated"] = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TagStore.SetValue error, tag={tag}, ex={ex.Message}");
            }
        }

        /// <summary>
        /// Reads a tag value. Returns "#TAG" if not found, "#NULL" if tag is empty.
        /// </summary>
        public string GetValue(string? tagName)
        {
            if (string.IsNullOrEmpty(tagName))
                return "#NULL";

            if (tagName.Contains(':'))
            {
                string arrName = tagName.Split(':')[0];
                int arrIdx = int.Parse(tagName.Split(':')[1]);

                var row = Table.Rows.Find(arrName);
                if (row == null) return "#TAG";

                var arr = row["Value"]?.ToString()?.Split(',');
                if (arr == null || arr.Length <= arrIdx) return "#TAG";
                return arr[arrIdx];
            }

            var found = Table.Rows.Find(tagName);
            return found != null ? $"{found["Value"]}" : "#TAG";
        }
    }
}
