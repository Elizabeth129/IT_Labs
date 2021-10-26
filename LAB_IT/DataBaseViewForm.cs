using LAB_IT.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_IT
{
    public partial class DataBaseViewForm : Form
    {
        Database ContextDb;
        public DataBaseViewForm(string name)
        {
            this.Text = "Database " + name;
            foreach (Database db in Program.databaseManager.Databases)
            {
                if (db.Name == name)
                {
                    this.ContextDb = db;
                    break;
                }
            }
            InitializeComponent();
            var source = new BindingSource(this.ContextDb.Tables, null);
            TablesDataGridView.DataSource = source;
        }

        private void CreateTableButton_Click(object sender, EventArgs e)
        {
            CreateTableForm form = new CreateTableForm(ContextDb);
            form.ShowDialog();
        }

        private void UnionTablesButton_Click(object sender, EventArgs e)
        {
            if (ContextDb.Tables.Count == 0)
            {
                MessageBox.Show("This database does not contain any tables");
                return;
            }
            var unionTablesForm = new UnionTablesForm(ContextDb);
            unionTablesForm.ShowDialog();
        }

        private void DumpDataBaseButton_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Program.databaseManager.DumpsDirectory, ContextDb.Name + ".json");
            ContextDb.Dump(fileName);
        }

        private void TablesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (senderGrid.Columns[e.ColumnIndex].Name)
                {
                    case "ViewContentsButtonColumn":
                        string tableName = senderGrid.Rows[e.RowIndex].Cells["TableNameColumn"].Value.ToString();
                        var form = new TableViewForm(ContextDb, tableName);
                        form.ShowDialog();
                        break;
                    case "DeleteTableButtonColumn":
                        ContextDb.DeleteTable(senderGrid.Rows[e.RowIndex].Cells["TableNameColumn"].Value.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
