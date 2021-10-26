using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LAB_IT_SERVER_
{
    public class DatabaseManager : MarshalByRefObject
    {
        public BindingList<Database> Databases { get; set; }
        public string DumpsDirectory { get; private set; }

        public void Init()
        {
            Databases = new BindingList<Database>();
            DumpsDirectory = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "dumps");
            Directory.CreateDirectory(DumpsDirectory);
        }

        #region Main functions

        public void CreateDatabase(string name)
        {
            if (Databases.Where(x => x.Name == name).Any())
            {
                throw new ArgumentException("Database with this name already exists");
            };
            Databases.Add(new Database(name));
        }

        public void DeleteDatabase(string name)
        {
            foreach (var database in Databases)
            {
                if (database.Name == name)
                {
                    Databases.Remove(database);
                    return;
                }
            }
        }

        async public void RestoreDatabase(Stream fileStream)
        {
            Database database = await JsonSerializer.DeserializeAsync<Database>(fileStream);
            CreateDatabase(database.Name);
            DeleteDatabase(database.Name);
            if (!database.ValidateDeserialization())
            {
                throw new ArgumentException("JSON is corrupted!");
            }
            Databases.Add(database);
        }

        #endregion
    }
}
