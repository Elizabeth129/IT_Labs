using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_IT
{
    public partial class DataBaseListViewForm : Form
    {
        public DataBaseListViewForm()
        {
            InitializeComponent();
            var source = new BindingSource(Program.databaseManager.Databases, null);
            DataBaseListDataGridView.DataSource = source;
        }

        private void ViewDataBase(string name)
        {
            DataBaseViewForm form = new DataBaseViewForm(name);
            form.ShowDialog();
        }
        private void DeleteDataBase(string name)
        {
            Program.databaseManager.DeleteDatabase(name);
        }

        private void DataBaseListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (senderGrid.Columns[e.ColumnIndex].Name)
                {
                    case "ViewButtonColumn":
                        ViewDataBase(senderGrid.Rows[e.RowIndex].Cells["DataBaseNameColumn"].Value.ToString());
                        break;
                    case "DeleteButtonColumn":
                        DeleteDataBase(senderGrid.Rows[e.RowIndex].Cells["DataBaseNameColumn"].Value.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
