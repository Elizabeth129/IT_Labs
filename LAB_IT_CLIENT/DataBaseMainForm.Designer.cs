namespace LAB_IT_CLIENT
{
    partial class DataBaseMainForm
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
            this.CreateDataBaseButton = new System.Windows.Forms.Button();
            this.ShowDataBaseButton = new System.Windows.Forms.Button();
            this.RestoreDataBaseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateDataBaseButton
            // 
            this.CreateDataBaseButton.Location = new System.Drawing.Point(70, 47);
            this.CreateDataBaseButton.Name = "CreateDataBaseButton";
            this.CreateDataBaseButton.Size = new System.Drawing.Size(237, 82);
            this.CreateDataBaseButton.TabIndex = 0;
            this.CreateDataBaseButton.Text = "Создать базу данных";
            this.CreateDataBaseButton.UseVisualStyleBackColor = true;
            this.CreateDataBaseButton.Click += new System.EventHandler(this.CreateDataBaseButton_Click);
            // 
            // ShowDataBaseButton
            // 
            this.ShowDataBaseButton.Location = new System.Drawing.Point(70, 175);
            this.ShowDataBaseButton.Name = "ShowDataBaseButton";
            this.ShowDataBaseButton.Size = new System.Drawing.Size(237, 82);
            this.ShowDataBaseButton.TabIndex = 1;
            this.ShowDataBaseButton.Text = "Посмотреть базу данных";
            this.ShowDataBaseButton.UseVisualStyleBackColor = true;
            this.ShowDataBaseButton.Click += new System.EventHandler(this.ShowDataBaseButton_Click);
            // 
            // RestoreDataBaseButton
            // 
            this.RestoreDataBaseButton.Location = new System.Drawing.Point(70, 298);
            this.RestoreDataBaseButton.Name = "RestoreDataBaseButton";
            this.RestoreDataBaseButton.Size = new System.Drawing.Size(237, 82);
            this.RestoreDataBaseButton.TabIndex = 2;
            this.RestoreDataBaseButton.Text = "Загрузить базу данных";
            this.RestoreDataBaseButton.UseVisualStyleBackColor = true;
            this.RestoreDataBaseButton.Click += new System.EventHandler(this.RestoreDataBaseButton_Click);
            // 
            // DataBaseMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 450);
            this.Controls.Add(this.RestoreDataBaseButton);
            this.Controls.Add(this.ShowDataBaseButton);
            this.Controls.Add(this.CreateDataBaseButton);
            this.Name = "DataBaseMainForm";
            this.Text = "DataBaseMainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateDataBaseButton;
        private System.Windows.Forms.Button ShowDataBaseButton;
        private System.Windows.Forms.Button RestoreDataBaseButton;
    }
}