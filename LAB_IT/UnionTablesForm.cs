using LAB_IT.BL;
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
    public partial class UnionTablesForm : Form
    {
        private Database ContextDb;
        private Table table1;
        private Table table2;

        public UnionTablesForm(Database db)
        {
            InitializeComponent();

            ContextDb = db;

            Table1ComboBox.DataSource = new BindingSource(this.ContextDb.Tables, null);
            Table2ComboBox.DataSource = new BindingSource(this.ContextDb.Tables, null);
            Table1ComboBox.DisplayMember = "Name";
            Table2ComboBox.DisplayMember = "Name";
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            table1 = (Table)Table1ComboBox.SelectedItem;
            table2 = (Table)Table2ComboBox.SelectedItem;

            var form = new UnionTablesResultForm(table1, table2);
            form.ShowDialog();
        }
    }
}
