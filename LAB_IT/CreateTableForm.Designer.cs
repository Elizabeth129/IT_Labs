namespace LAB_IT
{
    partial class CreateTableForm
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
            this.SaveCreateTableButton = new System.Windows.Forms.Button();
            this.CancelCreateTableButton = new System.Windows.Forms.Button();
            this.TableNameLabel = new System.Windows.Forms.Label();
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.ColumnsCreateTableDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsCreateTableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveCreateTableButton
            // 
            this.SaveCreateTableButton.Location = new System.Drawing.Point(532, 384);
            this.SaveCreateTableButton.Name = "SaveCreateTableButton";
            this.SaveCreateTableButton.Size = new System.Drawing.Size(125, 54);
            this.SaveCreateTableButton.TabIndex = 0;
            this.SaveCreateTableButton.Text = "Сохранить";
            this.SaveCreateTableButton.UseVisualStyleBackColor = true;
            this.SaveCreateTableButton.Click += new System.EventHandler(this.SaveCreateTableButton_Click);
            // 
            // CancelCreateTableButton
            // 
            this.CancelCreateTableButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCreateTableButton.Location = new System.Drawing.Point(663, 384);
            this.CancelCreateTableButton.Name = "CancelCreateTableButton";
            this.CancelCreateTableButton.Size = new System.Drawing.Size(125, 54);
            this.CancelCreateTableButton.TabIndex = 1;
            this.CancelCreateTableButton.Text = "Отмена";
            this.CancelCreateTableButton.UseVisualStyleBackColor = true;
            // 
            // TableNameLabel
            // 
            this.TableNameLabel.AutoSize = true;
            this.TableNameLabel.Location = new System.Drawing.Point(13, 13);
            this.TableNameLabel.Name = "TableNameLabel";
            this.TableNameLabel.Size = new System.Drawing.Size(96, 17);
            this.TableNameLabel.TabIndex = 2;
            this.TableNameLabel.Text = "Имя таблицы";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.Location = new System.Drawing.Point(135, 10);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(278, 22);
            this.TableNameTextBox.TabIndex = 3;
            // 
            // ColumnsCreateTableDataGridView
            // 
            this.ColumnsCreateTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColumnsCreateTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNameColumn,
            this.ColumnTypeColumn});
            this.ColumnsCreateTableDataGridView.Location = new System.Drawing.Point(12, 38);
            this.ColumnsCreateTableDataGridView.Name = "ColumnsCreateTableDataGridView";
            this.ColumnsCreateTableDataGridView.RowHeadersWidth = 51;
            this.ColumnsCreateTableDataGridView.RowTemplate.Height = 24;
            this.ColumnsCreateTableDataGridView.Size = new System.Drawing.Size(776, 340);
            this.ColumnsCreateTableDataGridView.TabIndex = 4;
            this.ColumnsCreateTableDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.ColumnsCreateTableDataGridView_DefaultValuesNeeded);
            // 
            // ColumnNameColumn
            // 
            this.ColumnNameColumn.HeaderText = "Column name";
            this.ColumnNameColumn.MinimumWidth = 6;
            this.ColumnNameColumn.Name = "ColumnNameColumn";
            this.ColumnNameColumn.Width = 125;
            // 
            // ColumnTypeColumn
            // 
            this.ColumnTypeColumn.HeaderText = "Column type";
            this.ColumnTypeColumn.MinimumWidth = 6;
            this.ColumnTypeColumn.Name = "ColumnTypeColumn";
            this.ColumnTypeColumn.Width = 125;
            // 
            // CreateTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ColumnsCreateTableDataGridView);
            this.Controls.Add(this.TableNameTextBox);
            this.Controls.Add(this.TableNameLabel);
            this.Controls.Add(this.CancelCreateTableButton);
            this.Controls.Add(this.SaveCreateTableButton);
            this.Name = "CreateTableForm";
            this.Text = "CreateTableForm";
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsCreateTableDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveCreateTableButton;
        private System.Windows.Forms.Button CancelCreateTableButton;
        private System.Windows.Forms.Label TableNameLabel;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.DataGridView ColumnsCreateTableDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNameColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnTypeColumn;
    }
}