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
    public partial class TableViewForm : Form
    {
        Table ContextTable { get; }
        private List<List<object>> savedState;

        public TableViewForm(Database db, string tableName)
        {
            this.Text = "Table " + db.Name + "." + tableName;
            ContextTable = db.GetTable(tableName);
            savedState = new List<List<object>>(ContextTable.Data);
            InitializeComponent();

            foreach (var columnDefinition in ContextTable.ColumnDefinitions)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = columnDefinition.Name;
                col.HeaderText = columnDefinition.Name;
                TableDataGridView.Columns.Add(col);
            }
            foreach (var dataRow in ContextTable.Data)
            {
                int n = TableDataGridView.Rows.Add();
                var row = TableDataGridView.Rows[n];
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

        private void SaveTableButton_Click(object sender, EventArgs e)
        {
            savedState = new List<List<object>>(ContextTable.Data);
        }

        private void CloseTableButton_Click(object sender, EventArgs e)
        {
            ContextTable.Data = savedState;
            DialogResult = DialogResult.Cancel;
        }

        private void TableDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == TableDataGridView.Rows.Count - 1)
            {
                return;
            }
            var row = TableDataGridView.Rows[e.RowIndex];
            var list = new List<object>();
            foreach (DataGridViewCell cell in row.Cells)
            {
                list.Add(cell.Value);
            }
            try
            {
                this.ContextTable.UpdateRow(list, e.RowIndex);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
                e.Cancel = true;
            }
        }

        private void TableDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = TableDataGridView.HitTest(e.X, e.Y);
                TableDataGridView.ClearSelection();
                TableDataGridView.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = TableDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            TableDataGridView.Rows.RemoveAt(rowIndex);
            this.ContextTable.DeleteRow(rowIndex);
            TableDataGridView.ClearSelection();
        }
    }
}
