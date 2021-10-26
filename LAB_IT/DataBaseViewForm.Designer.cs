namespace LAB_IT
{
    partial class DataBaseViewForm
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
            this.CreateTableButton = new System.Windows.Forms.Button();
            this.UnionTablesButton = new System.Windows.Forms.Button();
            this.DumpDataBaseButton = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.TablesDataGridView = new System.Windows.Forms.DataGridView();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TableNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewContentsButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EditTableSchemaButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteTableButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateTableButton
            // 
            this.CreateTableButton.Location = new System.Drawing.Point(154, 383);
            this.CreateTableButton.Name = "CreateTableButton";
            this.CreateTableButton.Size = new System.Drawing.Size(154, 55);
            this.CreateTableButton.TabIndex = 0;
            this.CreateTableButton.Text = "Создать таблицу";
            this.CreateTableButton.UseVisualStyleBackColor = true;
            this.CreateTableButton.Click += new System.EventHandler(this.CreateTableButton_Click);
            // 
            // UnionTablesButton
            // 
            this.UnionTablesButton.Location = new System.Drawing.Point(314, 383);
            this.UnionTablesButton.Name = "UnionTablesButton";
            this.UnionTablesButton.Size = new System.Drawing.Size(154, 55);
            this.UnionTablesButton.TabIndex = 1;
            this.UnionTablesButton.Text = "Объединить таблицы";
            this.UnionTablesButton.UseVisualStyleBackColor = true;
            this.UnionTablesButton.Click += new System.EventHandler(this.UnionTablesButton_Click);
            // 
            // DumpDataBaseButton
            // 
            this.DumpDataBaseButton.Location = new System.Drawing.Point(474, 383);
            this.DumpDataBaseButton.Name = "DumpDataBaseButton";
            this.DumpDataBaseButton.Size = new System.Drawing.Size(154, 55);
            this.DumpDataBaseButton.TabIndex = 2;
            this.DumpDataBaseButton.Text = "Сохранить базу данных на диск";
            this.DumpDataBaseButton.UseVisualStyleBackColor = true;
            this.DumpDataBaseButton.Click += new System.EventHandler(this.DumpDataBaseButton_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DoneButton.Location = new System.Drawing.Point(634, 383);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(154, 55);
            this.DoneButton.TabIndex = 3;
            this.DoneButton.Text = "Готово";
            this.DoneButton.UseVisualStyleBackColor = true;
            // 
            // TablesDataGridView
            // 
            this.TablesDataGridView.AllowUserToAddRows = false;
            this.TablesDataGridView.AllowUserToDeleteRows = false;
            this.TablesDataGridView.AutoGenerateColumns = false;
            this.TablesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TablesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableNameColumn,
            this.ViewContentsButtonColumn,
            this.EditTableSchemaButtonColumn,
            this.DeleteTableButtonColumn});
            this.TablesDataGridView.DataSource = this.tableBindingSource;
            this.TablesDataGridView.Location = new System.Drawing.Point(13, 13);
            this.TablesDataGridView.Name = "TablesDataGridView";
            this.TablesDataGridView.ReadOnly = true;
            this.TablesDataGridView.RowHeadersWidth = 51;
            this.TablesDataGridView.RowTemplate.Height = 24;
            this.TablesDataGridView.Size = new System.Drawing.Size(775, 364);
            this.TablesDataGridView.TabIndex = 4;
            this.TablesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablesDataGridView_CellContentClick);
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataSource = typeof(LAB_IT.BL.Table);
            // 
            // TableNameColumn
            // 
            this.TableNameColumn.DataPropertyName = "Name";
            this.TableNameColumn.HeaderText = "Table name";
            this.TableNameColumn.MinimumWidth = 6;
            this.TableNameColumn.Name = "TableNameColumn";
            this.TableNameColumn.ReadOnly = true;
            // 
            // ViewContentsButtonColumn
            // 
            this.ViewContentsButtonColumn.HeaderText = "View";
            this.ViewContentsButtonColumn.MinimumWidth = 6;
            this.ViewContentsButtonColumn.Name = "ViewContentsButtonColumn";
            this.ViewContentsButtonColumn.ReadOnly = true;
            // 
            // EditTableSchemaButtonColumn
            // 
            this.EditTableSchemaButtonColumn.HeaderText = "Edit";
            this.EditTableSchemaButtonColumn.MinimumWidth = 6;
            this.EditTableSchemaButtonColumn.Name = "EditTableSchemaButtonColumn";
            this.EditTableSchemaButtonColumn.ReadOnly = true;
            this.EditTableSchemaButtonColumn.Visible = false;
            // 
            // DeleteTableButtonColumn
            // 
            this.DeleteTableButtonColumn.HeaderText = "Delete";
            this.DeleteTableButtonColumn.MinimumWidth = 6;
            this.DeleteTableButtonColumn.Name = "DeleteTableButtonColumn";
            this.DeleteTableButtonColumn.ReadOnly = true;
            // 
            // DataBaseViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TablesDataGridView);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.DumpDataBaseButton);
            this.Controls.Add(this.UnionTablesButton);
            this.Controls.Add(this.CreateTableButton);
            this.Name = "DataBaseViewForm";
            this.Text = "DataBaseViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.TablesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateTableButton;
        private System.Windows.Forms.Button UnionTablesButton;
        private System.Windows.Forms.Button DumpDataBaseButton;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.DataGridView TablesDataGridView;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableNameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ViewContentsButtonColumn;
        private System.Windows.Forms.DataGridViewButtonColumn EditTableSchemaButtonColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteTableButtonColumn;
    }
}