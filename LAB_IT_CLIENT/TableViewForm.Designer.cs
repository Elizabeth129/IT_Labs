namespace LAB_IT_CLIENT
{
    partial class TableViewForm
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
            this.SaveTableButton = new System.Windows.Forms.Button();
            this.CloseTableButton = new System.Windows.Forms.Button();
            this.TableDataGridView = new System.Windows.Forms.DataGridView();
            this.TableContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).BeginInit();
            this.TableContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveTableButton
            // 
            this.SaveTableButton.Location = new System.Drawing.Point(12, 383);
            this.SaveTableButton.Name = "SaveTableButton";
            this.SaveTableButton.Size = new System.Drawing.Size(158, 55);
            this.SaveTableButton.TabIndex = 0;
            this.SaveTableButton.Text = "Сохранить";
            this.SaveTableButton.UseVisualStyleBackColor = true;
            this.SaveTableButton.Click += new System.EventHandler(this.SaveTableButton_Click);
            // 
            // CloseTableButton
            // 
            this.CloseTableButton.Location = new System.Drawing.Point(630, 383);
            this.CloseTableButton.Name = "CloseTableButton";
            this.CloseTableButton.Size = new System.Drawing.Size(158, 55);
            this.CloseTableButton.TabIndex = 1;
            this.CloseTableButton.Text = "Закрыть";
            this.CloseTableButton.UseVisualStyleBackColor = true;
            this.CloseTableButton.Click += new System.EventHandler(this.CloseTableButton_Click);
            // 
            // TableDataGridView
            // 
            this.TableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGridView.ContextMenuStrip = this.TableContextMenu;
            this.TableDataGridView.Location = new System.Drawing.Point(13, 13);
            this.TableDataGridView.Name = "TableDataGridView";
            this.TableDataGridView.RowHeadersWidth = 51;
            this.TableDataGridView.RowTemplate.Height = 24;
            this.TableDataGridView.Size = new System.Drawing.Size(775, 364);
            this.TableDataGridView.TabIndex = 2;
            this.TableDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.TableDataGridView_RowValidating);
            this.TableDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TableDataGridView_MouseDown);
            // 
            // TableContextMenu
            // 
            this.TableContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TableContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem});
            this.TableContextMenu.Name = "TableContextMenu";
            this.TableContextMenu.Size = new System.Drawing.Size(135, 28);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // TableViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TableDataGridView);
            this.Controls.Add(this.CloseTableButton);
            this.Controls.Add(this.SaveTableButton);
            this.Name = "TableViewForm";
            this.Text = "TableViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).EndInit();
            this.TableContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveTableButton;
        private System.Windows.Forms.Button CloseTableButton;
        private System.Windows.Forms.DataGridView TableDataGridView;
        private System.Windows.Forms.ContextMenuStrip TableContextMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
    }
}