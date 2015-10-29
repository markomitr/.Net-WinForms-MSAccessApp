namespace USAVendors
{
    partial class ProductGroup
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
            this.grupaLbl = new System.Windows.Forms.Label();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.potvrdiBtn = new System.Windows.Forms.Button();
            this.otkaziBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grupaLbl
            // 
            this.grupaLbl.AutoSize = true;
            this.grupaLbl.Location = new System.Drawing.Point(13, 48);
            this.grupaLbl.Name = "grupaLbl";
            this.grupaLbl.Size = new System.Drawing.Size(35, 13);
            this.grupaLbl.TabIndex = 0;
            this.grupaLbl.Text = "label1";
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(73, 48);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(100, 20);
            this.groupTextBox.TabIndex = 1;
            this.groupTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vnesi_KeyUp);
            this.groupTextBox.TextChanged += new System.EventHandler(this.groupTextBox_TextChanged);
            // 
            // potvrdiBtn
            // 
            this.potvrdiBtn.Location = new System.Drawing.Point(13, 349);
            this.potvrdiBtn.Name = "potvrdiBtn";
            this.potvrdiBtn.Size = new System.Drawing.Size(75, 23);
            this.potvrdiBtn.TabIndex = 18;
            this.potvrdiBtn.Text = "Потврди";
            this.potvrdiBtn.UseVisualStyleBackColor = true;
            // 
            // otkaziBtn
            // 
            this.otkaziBtn.Location = new System.Drawing.Point(246, 349);
            this.otkaziBtn.Name = "otkaziBtn";
            this.otkaziBtn.Size = new System.Drawing.Size(75, 23);
            this.otkaziBtn.TabIndex = 20;
            this.otkaziBtn.Text = "button1";
            this.otkaziBtn.UseVisualStyleBackColor = true;
            // 
            // ProductGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.grupaLbl);
            this.Controls.Add(this.potvrdiBtn);
            this.Controls.Add(this.otkaziBtn);
            this.Name = "ProductGroup";
            this.Text = "PrdouctGroup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddGroup_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vnesi_KeyUp);
            this.Load += new System.EventHandler(this.PrdouctGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label grupaLbl;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.Button potvrdiBtn;
        private System.Windows.Forms.Button otkaziBtn;
    }
}