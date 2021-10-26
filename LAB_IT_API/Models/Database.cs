using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB_IT_API.Models
{
    public class Database
    {
        public Database()
        {
            Tables = new HashSet<Table>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
