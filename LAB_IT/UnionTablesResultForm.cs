using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAB_IT_SERVER;

namespace LAB_IT
{
    public partial class UnionTablesResultForm : Form
    {
        public UnionTablesResultForm(Table table1, Table table2)
        {
            InitializeComponent();
            foreach (var columnDefinition in table1.ColumnDefinitions)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = table1.Name + "." + columnDefinition.Name;
                col.HeaderText = table1.Name + "." + columnDefinition.Name;
                ResultDataGridView.Columns.Add(col);
            }

            List<List<object>> data = Table.UnionTables(table1, table2);
            foreach (var dataRow in data)
            {
                int n = ResultDataGridView.Rows.Add();
                var row = ResultDataGridView.Rows[n];
                for (int i = 0; i < dataRow.Count; i++)
                {
                    if (dataRow[i] is null)
                    {
                        row.Cells[i].Value = "";
                    }
                    else
                    {
                        row.Cells[i].Value = dataRow[i].ToString();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
