using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LAB_IT_API.Models
{
    public enum ColumnType
    {
        Int,
        Double,
        Char,
        String,
        ComplexInteger,
        ComplexDouble,
    }

    public struct ComplexInt
    {
        public int a;
        public int b;

        public override string ToString()
        {
            return a.ToString() + " + " + b.ToString() + "i";
        }
    }

    public struct ComplexDouble
    {
        public double a;
        public double b;

        public override string ToString()
        {
            return a.ToString() + " + " + b.ToString() + "i";
        }
    }

    public class ColumnDefinition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public ColumnType Type { get; set; }
        [Display(Name = "Database")]
        [JsonIgnore]
        public Table Parent { get; set; }
    }

    public class Table
    {
        public Table()
        {
            ColumnDefinitions = new List<ColumnDefinition>();
            Data = new List<Row>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        [JsonIgnore]
        public Database Parent { get; set; }
        public List<ColumnDefinition> ColumnDefinitions { get; set; }
        public List<Row> Data { get; set; }

        public bool ValidateData()
        {
            foreach (var row in Data)
            {
                if (row.Elements.Count != ColumnDefinitions.Count)
                {
                    return false;
                }
                for (int i = 0; i < row.Elements.Count; i++)
                {
                    try
                    {
                        switch (ColumnDefinitions.ElementAt(i).Type)
                        {
                            case ColumnType.Int:
                                row.Elements[i].Value = Convert.ToInt32(row.Elements[i].Value);
                                break;
                            case ColumnType.Double:
                                row.Elements[i].Value = Convert.ToDouble(row.Elements[i].Value);
                                break;
                            case ColumnType.Char:
                                row.Elements[i].Value = Convert.ToChar(row.Elements[i].Value);
                                break;
                            case ColumnType.String:
                                row.Elements[i].Value = Convert.ToString(row.Elements[i].Value);
                                break;
                            case ColumnType.ComplexInteger:
                                string complexInt = Convert.ToString(row.Elements[i].Value);
                                row.Elements[i].Value = new ComplexInt
                                {
                                    a = Convert.ToInt32(complexInt.Substring(0, complexInt.IndexOf('+')).Trim()),
                                    b = Convert.ToInt32(complexInt.Substring(complexInt.IndexOf('+') + 1,
                                            complexInt.IndexOf('i') - complexInt.IndexOf('+') - 1).Trim()),
                                };
                                break;
                            case ColumnType.ComplexDouble:
                                string complexDouble = Convert.ToString(row.Elements[i].Value);
                                row.Elements[i].Value = new ComplexDouble
                                {
                                    a = Convert.ToDouble(complexDouble.Substring(0, complexDouble.IndexOf('+')).Trim()),
                                    b = Convert.ToDouble(complexDouble.Substring(complexDouble.IndexOf('+') + 1,
                                            complexDouble.IndexOf('i') - complexDouble.IndexOf('+') - 1).Trim()),
                                };
                                break;
                            default:
                                break;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public List<List<object>> DataAsObjects()
        {
            ValidateData();
            List<List<object>> res = new List<List<object>>();
            for (int i = 0; i < Data.Count; i++)
            {
                res.Add(new List<object>());
                for (int j = 0; j < Data.ElementAt(i).Elements.Count; j++)
                {
                    res[i].Add(Data.ElementAt(i).Elements.ElementAt(j).Value);
                }
            }
            return res;
        }
        public int GetColumnIdx(string name)
        {
            return ColumnDefinitions.IndexOf(ColumnDefinitions.Where(c => c.Name == name).First());
        }
    }
}
