namespace USAVendors
{
    partial class AddProduct
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
            this.codeLbl = new System.Windows.Forms.Label();
            this.groupLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.description1TextBox = new System.Windows.Forms.RichTextBox();
            this.potvrdiBtn = new System.Windows.Forms.Button();
            this.otkaziBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Location = new System.Drawing.Point(13, 13);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(35, 13);
            this.codeLbl.TabIndex = 0;
            this.codeLbl.Text = "label1";
            // 
            // groupLbl
            // 
            this.groupLbl.AutoSize = true;
            this.groupLbl.Location = new System.Drawing.Point(13, 30);
            this.groupLbl.Name = "groupLbl";
            this.groupLbl.Size = new System.Drawing.Size(35, 13);
            this.groupLbl.TabIndex = 1;
            this.groupLbl.Text = "label2";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Location = new System.Drawing.Point(13, 47);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(35, 13);
            this.descriptionLbl.TabIndex = 2;
            this.descriptionLbl.Text = "label3";
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(109, 40);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(121, 21);
            this.groupComboBox.TabIndex = 4;
            this.groupComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vnesi_KeyUp);
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(109, 13);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(100, 20);
            this.codeTextBox.TabIndex = 3;
            this.codeTextBox.Leave += new System.EventHandler(this.codeTextBox_Leave);
            this.codeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vnesi_KeyUp);
            this.codeTextBox.TextChanged += new System.EventHandler(this.codeTextBox_TextChanged);
            // 
            // description1TextBox
            // 
            this.description1TextBox.Location = new System.Drawing.Point(109, 117);
            this.description1TextBox.Name = "description1TextBox";
            this.description1TextBox.Size = new System.Drawing.Size(100, 96);
            this.description1TextBox.TabIndex = 6;
            this.description1TextBox.Text = "";
            this.description1TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vnesi_KeyUp);
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
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.description1TextBox);
            this.Controls.Add(this.groupComboBox);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.groupLbl);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.potvrdiBtn);
            this.Controls.Add(this.otkaziBtn);
            this.Name = "AddProduct";
            this.Text = "Product";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddProduct_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vnesi_KeyUp);
            this.Load += new System.EventHandler(this.Product_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label codeLbl;
        private System.Windows.Forms.Label groupLbl;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.RichTextBox description1TextBox;
        private System.Windows.Forms.Button potvrdiBtn;
        private System.Windows.Forms.Button otkaziBtn;
    }
}