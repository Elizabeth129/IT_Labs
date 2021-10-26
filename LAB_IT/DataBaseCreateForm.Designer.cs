namespace LAB_IT
{
    partial class DataBaseCreateForm
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
            this.DataBaseNameLabel = new System.Windows.Forms.Label();
            this.DataBaseNameTextBox = new System.Windows.Forms.TextBox();
            this.CreateDataBaseButton = new System.Windows.Forms.Button();
            this.CreateDataBaseCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DataBaseNameLabel
            // 
            this.DataBaseNameLabel.AutoSize = true;
            this.DataBaseNameLabel.Location = new System.Drawing.Point(24, 25);
            this.DataBaseNameLabel.Name = "DataBaseNameLabel";
            this.DataBaseNameLabel.Size = new System.Drawing.Size(124, 17);
            this.DataBaseNameLabel.TabIndex = 0;
            this.DataBaseNameLabel.Text = "Имя базы данных";
            // 
            // DataBaseNameTextBox
            // 
            this.DataBaseNameTextBox.Location = new System.Drawing.Point(168, 25);
            this.DataBaseNameTextBox.Name = "DataBaseNameTextBox";
            this.DataBaseNameTextBox.Size = new System.Drawing.Size(334, 22);
            this.DataBaseNameTextBox.TabIndex = 1;
            // 
            // CreateDataBaseButton
            // 
            this.CreateDataBaseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CreateDataBaseButton.Location = new System.Drawing.Point(274, 53);
            this.CreateDataBaseButton.Name = "CreateDataBaseButton";
            this.CreateDataBaseButton.Size = new System.Drawing.Size(111, 41);
            this.CreateDataBaseButton.TabIndex = 2;
            this.CreateDataBaseButton.Text = "Создать";
            this.CreateDataBaseButton.UseVisualStyleBackColor = true;
            // 
            // CreateDataBaseCancelButton
            // 
            this.CreateDataBaseCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CreateDataBaseCancelButton.Location = new System.Drawing.Point(391, 53);
            this.CreateDataBaseCancelButton.Name = "CreateDataBaseCancelButton";
            this.CreateDataBaseCancelButton.Size = new System.Drawing.Size(111, 41);
            this.CreateDataBaseCancelButton.TabIndex = 3;
            this.CreateDataBaseCancelButton.Text = "Отменить";
            this.CreateDataBaseCancelButton.UseVisualStyleBackColor = true;
            // 
            // DataBaseCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 118);
            this.Controls.Add(this.CreateDataBaseCancelButton);
            this.Controls.Add(this.CreateDataBaseButton);
            this.Controls.Add(this.DataBaseNameTextBox);
            this.Controls.Add(this.DataBaseNameLabel);
            this.Name = "DataBaseCreateForm";
            this.Text = "DataBaseCreateForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataBaseCreateForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DataBaseNameLabel;
        private System.Windows.Forms.TextBox DataBaseNameTextBox;
        private System.Windows.Forms.Button CreateDataBaseButton;
        private System.Windows.Forms.Button CreateDataBaseCancelButton;
    }
}