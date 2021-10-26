namespace LAB_IT
{
    partial class UnionTablesForm
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
            this.Table1Label = new System.Windows.Forms.Label();
            this.Table2Label = new System.Windows.Forms.Label();
            this.Table1ComboBox = new System.Windows.Forms.ComboBox();
            this.Table2ComboBox = new System.Windows.Forms.ComboBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Table1Label
            // 
            this.Table1Label.AutoSize = true;
            this.Table1Label.Location = new System.Drawing.Point(23, 13);
            this.Table1Label.Name = "Table1Label";
            this.Table1Label.Size = new System.Drawing.Size(65, 17);
            this.Table1Label.TabIndex = 0;
            this.Table1Label.Text = "Таблица";
            // 
            // Table2Label
            // 
            this.Table2Label.AutoSize = true;
            this.Table2Label.Location = new System.Drawing.Point(23, 71);
            this.Table2Label.Name = "Table2Label";
            this.Table2Label.Size = new System.Drawing.Size(65, 17);
            this.Table2Label.TabIndex = 1;
            this.Table2Label.Text = "Таблица";
            // 
            // Table1ComboBox
            // 
            this.Table1ComboBox.FormattingEnabled = true;
            this.Table1ComboBox.Location = new System.Drawing.Point(26, 33);
            this.Table1ComboBox.Name = "Table1ComboBox";
            this.Table1ComboBox.Size = new System.Drawing.Size(180, 24);
            this.Table1ComboBox.TabIndex = 2;
            // 
            // Table2ComboBox
            // 
            this.Table2ComboBox.FormattingEnabled = true;
            this.Table2ComboBox.Location = new System.Drawing.Point(26, 92);
            this.Table2ComboBox.Name = "Table2ComboBox";
            this.Table2ComboBox.Size = new System.Drawing.Size(180, 24);
            this.Table2ComboBox.TabIndex = 3;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(247, 17);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(173, 55);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "Показать объединение";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(247, 89);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(173, 55);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // UnionTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 156);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.Table2ComboBox);
            this.Controls.Add(this.Table1ComboBox);
            this.Controls.Add(this.Table2Label);
            this.Controls.Add(this.Table1Label);
            this.Name = "UnionTablesForm";
            this.Text = "UnionTablesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Table1Label;
        private System.Windows.Forms.Label Table2Label;
        private System.Windows.Forms.ComboBox Table1ComboBox;
        private System.Windows.Forms.ComboBox Table2ComboBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
    }
}