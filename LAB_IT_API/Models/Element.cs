using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LAB_IT_API.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string ValueString { get; set; }
        [NotMapped]
        [JsonIgnore]
        public object Value { get; set; }
        public int ParentId { get; set; }
        [JsonIgnore]
        public Row Parent { get; set; }
    }
}
