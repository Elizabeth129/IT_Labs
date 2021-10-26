using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LAB_IT_API.Models
{
    public class Row
    {
        public Row()
        {
            Elements = new List<Element>();
        }
        public Row(int count)
        {
            Elements = new List<Element>(count);
        }
        public Row(ICollection<object> data)
        {
            Elements = new List<Element>();
            for (int i = 0; i < data.Count; i++)
            {
                Elements.Add(new Element()
                {
                    ValueString = data.ElementAt(i).ToString()
                });
            }
        }
        public int Id { get; set; }
        public int ParentId { get; set; }
        [JsonIgnore]
        public Table Parent { get; set; }
        public List<Element> Elements { get; set; }
    }
}
