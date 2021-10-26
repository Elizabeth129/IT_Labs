namespace LAB_IT
{
    partial class DataBaseListViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DataBaseListDataGridView = new System.Windows.Forms.DataGridView();
            this.databaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataBaseNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataBaseListDataGridView
            // 
            this.DataBaseListDataGridView.AllowUserToAddRows = false;
            this.DataBaseListDataGridView.AllowUserToDeleteRows = false;
            this.DataBaseListDataGridView.AutoGenerateColumns = false;
            this.DataBaseListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataBaseListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBaseListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataBaseNameColumn,
            this.ViewButtonColumn,
            this.DeleteButtonColumn});
            this.DataBaseListDataGridView.DataSource = this.databaseBindingSource;
            this.DataBaseListDataGridView.Location = new System.Drawing.Point(10, 8);
            this.DataBaseListDataGridView.Name = "DataBaseListDataGridView";
            this.DataBaseListDataGridView.ReadOnly = true;
            this.DataBaseListDataGridView.RowHeadersWidth = 51;
            this.DataBaseListDataGridView.RowTemplate.Height = 24;
            this.DataBaseListDataGridView.Size = new System.Drawing.Size(780, 435);
            this.DataBaseListDataGridView.TabIndex = 0;
            this.DataBaseListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataBaseListDataGridView_CellContentClick);
            // 
            // databaseBindingSource
            // 
            this.databaseBindingSource.DataSource = typeof(LAB_IT.BL.Database);
            // 
            // DataBaseNameColumn
            // 
            this.DataBaseNameColumn.DataPropertyName = "Name";
            this.DataBaseNameColumn.HeaderText = "Name";
            this.DataBaseNameColumn.MinimumWidth = 6;
            this.DataBaseNameColumn.Name = "DataBaseNameColumn";
            this.DataBaseNameColumn.ReadOnly = true;
            // 
            // ViewButtonColumn
            // 
            this.ViewButtonColumn.HeaderText = "View";
            this.ViewButtonColumn.MinimumWidth = 6;
            this.ViewButtonColumn.Name = "ViewButtonColumn";
            this.ViewButtonColumn.ReadOnly = true;
            // 
            // DeleteButtonColumn
            // 
            this.DeleteButtonColumn.HeaderText = "Delete";
            this.DeleteButtonColumn.MinimumWidth = 6;
            this.DeleteButtonColumn.Name = "DeleteButtonColumn";
            this.DeleteButtonColumn.ReadOnly = true;
            // 
            // DataBaseListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataBaseListDataGridView);
            this.Name = "DataBaseListViewForm";
            this.Text = "DataBaseListViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataBaseListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataBaseNameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ViewButtonColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButtonColumn;
        private System.Windows.Forms.BindingSource databaseBindingSource;
    }
}