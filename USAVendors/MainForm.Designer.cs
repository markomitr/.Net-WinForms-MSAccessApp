namespace USAVendors
{
    partial class MainForm
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
            this.GlavnomeniStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byCompanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byProductGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GlavenToolbar = new System.Windows.Forms.ToolStrip();
            this.AddlStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.AddNewCompanyStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddProductStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddProductCategoryStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.SearchProductStripButton = new System.Windows.Forms.ToolStripButton();
            this.SearchCompnayStripButton = new System.Windows.Forms.ToolStripButton();
            this.SearchProductGroupStripButton = new System.Windows.Forms.ToolStripButton();
            this.productsToCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companiesToProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GlavnomeniStrip.SuspendLayout();
            this.GlavenToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // GlavnomeniStrip
            // 
            this.GlavnomeniStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.GlavnomeniStrip.Location = new System.Drawing.Point(0, 0);
            this.GlavnomeniStrip.Name = "GlavnomeniStrip";
            this.GlavnomeniStrip.Size = new System.Drawing.Size(486, 24);
            this.GlavnomeniStrip.TabIndex = 0;
            this.GlavnomeniStrip.Text = "Main Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::USAVendors.Properties.Resources.cross_48;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.productToolStripMenuItem,
            this.productGroupsToolStripMenuItem,
            this.productsToCompanyToolStripMenuItem,
            this.companiesToProductToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Image = global::USAVendors.Properties.Resources.vcard;
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.companyToolStripMenuItem.Tag = "Company";
            this.companyToolStripMenuItem.Text = "Company";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.klik);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Image = global::USAVendors.Properties.Resources.box_address;
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.productToolStripMenuItem.Tag = "Product";
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.klik);
            // 
            // productGroupsToolStripMenuItem
            // 
            this.productGroupsToolStripMenuItem.Image = global::USAVendors.Properties.Resources.AddProduct;
            this.productGroupsToolStripMenuItem.Name = "productGroupsToolStripMenuItem";
            this.productGroupsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.productGroupsToolStripMenuItem.Tag = "Group";
            this.productGroupsToolStripMenuItem.Text = "Product Groups";
            this.productGroupsToolStripMenuItem.Click += new System.EventHandler(this.klik);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byCompanToolStripMenuItem,
            this.byProductToolStripMenuItem,
            this.byProductGroupToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // byCompanToolStripMenuItem
            // 
            this.byCompanToolStripMenuItem.Image = global::USAVendors.Properties.Resources.searchCompany;
            this.byCompanToolStripMenuItem.Name = "byCompanToolStripMenuItem";
            this.byCompanToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.byCompanToolStripMenuItem.Tag = "SCompany";
            this.byCompanToolStripMenuItem.Text = "By Company";
            this.byCompanToolStripMenuItem.Click += new System.EventHandler(this.klik);
            // 
            // byProductToolStripMenuItem
            // 
            this.byProductToolStripMenuItem.Image = global::USAVendors.Properties.Resources.searchCode;
            this.byProductToolStripMenuItem.Name = "byProductToolStripMenuItem";
            this.byProductToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.byProductToolStripMenuItem.Tag = "SProduct";
            this.byProductToolStripMenuItem.Text = "By Product";
            this.byProductToolStripMenuItem.Click += new System.EventHandler(this.klik);
            // 
            // byProductGroupToolStripMenuItem
            // 
            this.byProductGroupToolStripMenuItem.Image = global::USAVendors.Properties.Resources.search;
            this.byProductGroupToolStripMenuItem.Name = "byProductGroupToolStripMenuItem";
            this.byProductGroupToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.byProductGroupToolStripMenuItem.Tag = "SGroup";
            this.byProductGroupToolStripMenuItem.Text = "By Product Group";
            this.byProductGroupToolStripMenuItem.Click += new System.EventHandler(this.klik);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // GlavenToolbar
            // 
            this.GlavenToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddlStripLabel,
            this.AddNewCompanyStripButton,
            this.AddProductStripButton,
            this.AddProductCategoryStripButton,
            this.toolStripSeparator1,
            this.SearchStripLabel,
            this.SearchProductStripButton,
            this.SearchCompnayStripButton,
            this.SearchProductGroupStripButton});
            this.GlavenToolbar.Location = new System.Drawing.Point(0, 24);
            this.GlavenToolbar.MinimumSize = new System.Drawing.Size(0, 50);
            this.GlavenToolbar.Name = "GlavenToolbar";
            this.GlavenToolbar.Size = new System.Drawing.Size(486, 50);
            this.GlavenToolbar.TabIndex = 1;
            this.GlavenToolbar.Text = "Choose Option :";
            // 
            // AddlStripLabel
            // 
            this.AddlStripLabel.Name = "AddlStripLabel";
            this.AddlStripLabel.Size = new System.Drawing.Size(29, 47);
            this.AddlStripLabel.Text = "Add ";
            // 
            // AddNewCompanyStripButton
            // 
            this.AddNewCompanyStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddNewCompanyStripButton.Image = global::USAVendors.Properties.Resources.vcard;
            this.AddNewCompanyStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddNewCompanyStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNewCompanyStripButton.Name = "AddNewCompanyStripButton";
            this.AddNewCompanyStripButton.Size = new System.Drawing.Size(52, 47);
            this.AddNewCompanyStripButton.Tag = "Company";
            this.AddNewCompanyStripButton.Text = "Add New Company";
            this.AddNewCompanyStripButton.Click += new System.EventHandler(this.klik);
            // 
            // AddProductStripButton
            // 
            this.AddProductStripButton.AutoSize = false;
            this.AddProductStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddProductStripButton.Image = global::USAVendors.Properties.Resources.box_address;
            this.AddProductStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddProductStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddProductStripButton.Name = "AddProductStripButton";
            this.AddProductStripButton.Size = new System.Drawing.Size(50, 50);
            this.AddProductStripButton.Tag = "Product";
            this.AddProductStripButton.Text = "Add New Product";
            this.AddProductStripButton.Click += new System.EventHandler(this.klik);
            // 
            // AddProductCategoryStripButton
            // 
            this.AddProductCategoryStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddProductCategoryStripButton.Image = global::USAVendors.Properties.Resources.AddProduct;
            this.AddProductCategoryStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddProductCategoryStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddProductCategoryStripButton.Name = "AddProductCategoryStripButton";
            this.AddProductCategoryStripButton.Size = new System.Drawing.Size(52, 47);
            this.AddProductCategoryStripButton.Tag = "Group";
            this.AddProductCategoryStripButton.Text = "Add New Product Group";
            this.AddProductCategoryStripButton.Click += new System.EventHandler(this.klik);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // SearchStripLabel
            // 
            this.SearchStripLabel.Name = "SearchStripLabel";
            this.SearchStripLabel.Size = new System.Drawing.Size(40, 47);
            this.SearchStripLabel.Text = "Search";
            this.SearchStripLabel.ToolTipText = "Search By";
            // 
            // SearchProductStripButton
            // 
            this.SearchProductStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchProductStripButton.Image = global::USAVendors.Properties.Resources.searchCode;
            this.SearchProductStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SearchProductStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchProductStripButton.Name = "SearchProductStripButton";
            this.SearchProductStripButton.Size = new System.Drawing.Size(52, 47);
            this.SearchProductStripButton.Tag = "SProduct";
            this.SearchProductStripButton.Text = "Search by Product";
            this.SearchProductStripButton.Click += new System.EventHandler(this.klik);
            // 
            // SearchCompnayStripButton
            // 
            this.SearchCompnayStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchCompnayStripButton.Image = global::USAVendors.Properties.Resources.searchCompany;
            this.SearchCompnayStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SearchCompnayStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchCompnayStripButton.Name = "SearchCompnayStripButton";
            this.SearchCompnayStripButton.Size = new System.Drawing.Size(52, 47);
            this.SearchCompnayStripButton.Tag = "SCompany";
            this.SearchCompnayStripButton.Text = "Search by Company";
            this.SearchCompnayStripButton.Click += new System.EventHandler(this.klik);
            // 
            // SearchProductGroupStripButton
            // 
            this.SearchProductGroupStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchProductGroupStripButton.Image = global::USAVendors.Properties.Resources.search;
            this.SearchProductGroupStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SearchProductGroupStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchProductGroupStripButton.Name = "SearchProductGroupStripButton";
            this.SearchProductGroupStripButton.Size = new System.Drawing.Size(52, 47);
            this.SearchProductGroupStripButton.Tag = "SGroup";
            this.SearchProductGroupStripButton.Text = "Search by Product Group";
            this.SearchProductGroupStripButton.Click += new System.EventHandler(this.klik);
            // 
            // productsToCompanyToolStripMenuItem
            // 
            this.productsToCompanyToolStripMenuItem.Name = "productsToCompanyToolStripMenuItem";
            this.productsToCompanyToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.productsToCompanyToolStripMenuItem.Tag = "ProductC";
            this.productsToCompanyToolStripMenuItem.Text = "Products To Company";
            this.productsToCompanyToolStripMenuItem.Click += new System.EventHandler(this.klik);
            // 
            // companiesToProductToolStripMenuItem
            // 
            this.companiesToProductToolStripMenuItem.Name = "companiesToProductToolStripMenuItem";
            this.companiesToProductToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.companiesToProductToolStripMenuItem.Tag = "CompanyP";
            this.companiesToProductToolStripMenuItem.Text = "Companies To Product";
            this.companiesToProductToolStripMenuItem.Click += new System.EventHandler(this.klik);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 266);
            this.Controls.Add(this.GlavenToolbar);
            this.Controls.Add(this.GlavnomeniStrip);
            this.MainMenuStrip = this.GlavnomeniStrip;
            this.Name = "MainForm";
            this.Text = "Vendors";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.GlavnomeniStrip.ResumeLayout(false);
            this.GlavnomeniStrip.PerformLayout();
            this.GlavenToolbar.ResumeLayout(false);
            this.GlavenToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip GlavnomeniStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byCompanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byProductGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip GlavenToolbar;
        private System.Windows.Forms.ToolStripButton AddProductStripButton;
        private System.Windows.Forms.ToolStripButton AddNewCompanyStripButton;
        private System.Windows.Forms.ToolStripButton AddProductCategoryStripButton;
        private System.Windows.Forms.ToolStripLabel AddlStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel SearchStripLabel;
        private System.Windows.Forms.ToolStripButton SearchProductStripButton;
        private System.Windows.Forms.ToolStripButton SearchCompnayStripButton;
        private System.Windows.Forms.ToolStripButton SearchProductGroupStripButton;
        private System.Windows.Forms.ToolStripMenuItem productsToCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companiesToProductToolStripMenuItem;
    }
}

