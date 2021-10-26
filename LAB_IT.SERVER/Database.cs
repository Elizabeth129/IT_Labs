using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LAB_IT_SERVER
{
    public class Database
    {
        public string Name { get; set; }
        public BindingList<Table> Tables { get; set; }

        #region Constructors
        public Database()
        {
            this.Tables = new BindingList<Table>();
        }
        public Database(string name)
        {
            this.Name = name;
            this.Tables = new BindingList<Table>();
        }

        #endregion

        #region Main functions

        public void CreateTable(string name, List<Column> columnDefinitions)
        {
            if (Tables.Where(x => x.Name == name).Any())
            {
                throw new ArgumentException("Table with this name already exists in database");
            }
            Tables.Add(new Table(this, name, columnDefinitions));
        }

        public void DeleteTable(string name)
        {
            if (Tables.Where(x => x.Name == name).Any())
            {
                Tables.Remove(Tables.Where(x => x.Name == name).First());
            }
        }

        public Table GetTable(string name)
        {
            return Tables.Where(x => x.Name == name).First();
        }

        async public void Dump(string fileName)
        {
            File.Delete(fileName);
            using (FileStream fs = File.Create(fileName))
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                await JsonSerializer.SerializeAsync<Database>(fs, this, options);
            }
        }

        public bool ValidateDeserialization()
        {
            foreach (var table in Tables)
            {
                if (!table.ValidateDeserialization()) { return false; }
            }
            return true;
        }

        #endregion
    }
}
