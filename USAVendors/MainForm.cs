using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace USAVendors
{
    public partial class MainForm : Form
    {
        String cnString; //Za konekcija so baza
        public String ConnectionStr
        {
            get
            {
                return cnString;
            }
        }
        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Inicializiraj();            
            this.WindowState = FormWindowState.Maximized;


        }
        public void Inicializiraj()
        {
            
            this.Size = new Size(800,600);
            this.Location = new Point(0, 0);
            this.IsMdiContainer = true;
            this.cnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Vendors.mdb;Jet OLEDB:Database Password=qwe123;";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void klik(object sender, EventArgs e)
        {
            Type pom;
            pom = sender.GetType();
            if (this.proveriAktivniFormi())
            {
                if (pom.Name == "ToolStripMenuItem")
                {
                    ToolStripMenuItem nov = ((ToolStripMenuItem)sender);
                    if (nov.Tag == "Product")
                    {
                        AddProduct nova = new AddProduct();
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();

                    }
                    else if (nov.Tag == "Company")
                    {
                        AddCompany nova = new AddCompany();
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag=="Group")
                    {
                        ProductGroup nova = new ProductGroup();
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "ProductC")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Company", true);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "CompanyP")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Product", true);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "SProduct")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Product", false);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "SCompany")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Company", false );
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "SGroup")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Group", false);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                }
                else
                {
                    ToolStripButton nov = ((ToolStripButton)sender);

                    if (nov.Tag == "Product")
                    {
                        AddProduct nova = new AddProduct();
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();

                    }
                    else if (nov.Tag == "Company")
                    {
                        AddCompany nova = new AddCompany();
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag=="Group")
                    {
                        ProductGroup nova = new ProductGroup();
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "ProductC")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Company", true);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "CompanyP")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Product", true);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "SProduct")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Product", false);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "SCompany")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Company", false);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                    else if (nov.Tag == "SGroup")
                    {
                        AddProductsToCompany nova = new AddProductsToCompany("Group", false);
                        nova.MdiParent = this;
                        this.ActivateMdiChild(nova);
                        nova.Show();
                    }
                }
            }
            else
                MessageBox.Show("You can not open new form,because there is active one: \n - " + this.ActiveMdiChild.Name.ToString(), "Active Form - " + this.ActiveMdiChild.Name.ToString());

        }
        public bool proveriAktivniFormi()
        {
            Form proveri = this.ActiveMdiChild;
            if (proveri == null)
                return true;
            else
                return false;

        }
    }
}