using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAB_IT_SERVER_;

namespace LAB_IT_CLIENT
{
    public partial class CreateTableForm : Form
    {
        Database ParentDb;
        public CreateTableForm(Database db)
        {
            ParentDb = db;
            InitializeComponent();

            ColumnTypeColumn.DataSource = Enum.GetNames(typeof(ColumnType));
        }

        private void SaveCreateTableButton_Click(object sender, EventArgs e)
        {
            var tableName = TableNameTextBox.Text;
            var columnDefinitions = new List<Column>();
            foreach (DataGridViewRow row in ColumnsCreateTableDataGridView.Rows)
            {
                if (row.Cells["ColumnNameColumn"].Value is null)
                {
                    break;
                }
                columnDefinitions.Add(new Column
                {
                    Name = row.Cells["ColumnNameColumn"].Value.ToString(),
                    Type = (ColumnType)Enum.Parse(typeof(ColumnType), row.Cells["ColumnTypeColumn"].Value.ToString())
                });
            }
            try
            {
                ParentDb.CreateTable(tableName, columnDefinitions);
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ColumnsCreateTableDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["ColumnTypeColumn"].Value = "Int";
        }
    }
}
