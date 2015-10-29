using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace USAVendors
{
    public partial class AddProductsToCompany : Form
    {
        bool daliCheckBox;
        string sto;
        string prerfleno;
        String Sifra_Firma;
        String Sifra_Proizvod;

        Panel lev, desen,centar;
        Button submitBtn,cancelBtn;

        RedPanel novPanelD,novPanelC;

        TextBox vnesiTexBox;
        Label pom;

        Label groupLbl, descriptionLbl;
        Label groupLbl1, descriptionLbl1;

        Label contaktLbl, telLbl, faxLbl, emailLbl,cityLbl,countryLbl;
        Label contaktLbl1, telLbl1, faxLbl1, emailLbl1, cityLbl1, countryLbl1;

        String konekcija;
        public AddProductsToCompany(String zaso,bool daliCheckBoksoj)
        {
            daliCheckBox = daliCheckBoksoj;
            sto = zaso;
            InitializeComponent();

        }
        public AddProductsToCompany(String zaso, String prefrlam, bool daliCheckBoksoj)
        {
            daliCheckBox = daliCheckBoksoj;
            sto = zaso;
            prerfleno = prefrlam;
            InitializeComponent();

        }
        private void AddProductsToCompany_Load(object sender, EventArgs e)
        {
            this.Inicijaliziraj_Forma();
            if(daliCheckBox)
                this.NacartajKopcinja();

            if (this.sto == "Product")
            {
                this.Inicijaliziraj_Product();
                this.IscistiLableP();
                if (daliCheckBox)
                {
                    this.Text = "AddCompaniesToProduct";  
                }
                else
                {
                    this.Text = "SearchCompaniesForProducts";
                    this.Size = new Size(this.Width + 5, this.Height / 2 + 30);
                }     
            }
            else if (this.sto == "Company")
            {
                this.Inicijaliziraj_Company();
                this.IscistiLable();
                if (daliCheckBox)
                {
                    this.Text = "AddProductsToCompany";
                }
                else
                {
                    this.Text = "SearchProducts";
                    this.Size = new Size(this.Width + 5, this.Height / 2 + 30);
                }


            }
            else
            {
                this.Text = "SearchGroups";
                this.Inicijaliziraj_Group();
                this.Size = new Size(this.Width + 5, this.Height / 2 + 30);
                
            }
            MainForm pom = (MainForm)this.MdiParent;
            konekcija = pom.ConnectionStr;

            this.setirajTextBox();
            vnesiTexBox.Focus();


        }
        public void Inicijaliziraj_Forma()
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(800 , 600);

            lev = new Panel();
            desen = new Panel();
            centar = new Panel();

            this.Controls.Add(lev);
            this.Controls.Add(desen);
            this.Controls.Add(centar);

            this.lev.Location = new Point(0, 0);
            this.lev.Size = new Size(this.Size.Width / 3, this.Size.Height / 2);
            this.lev.BackColor = Color.Gray;

            this.desen.Location = new Point(Convert.ToInt32(this.lev.Size.Width.ToString()), 0);
            this.desen.Size = new Size(this.Size.Width * 2 / 3, this.Size.Height / 2);
            this.desen.BackColor = Color.Blue;
            
            this.centar.Location  = new Point(0,Convert.ToInt32(this.lev.Size.Height.ToString()));
            this.centar.Size = new Size(this.Width,this.Size.Height / 2);
            this.centar.BackColor = Color.Gray;

            vnesiTexBox = new TextBox();
            vnesiTexBox.KeyUp += new KeyEventHandler(this.Enter);

            novPanelD = new RedPanel();
            this.desen.Controls.Add(novPanelD);
            novPanelD.Location = new Point(0, 0);
            novPanelD.Size = desen.Size;
            novPanelD.BorderStyle = BorderStyle.Fixed3D;

            novPanelC = new RedPanel();
            this.centar.Controls.Add(novPanelC);
            novPanelC.Location = new Point(0, 0);
            novPanelC.BackColor = Color.AntiqueWhite;
            novPanelC.BorderStyle = BorderStyle.FixedSingle;
            novPanelC.Size = centar.Size;
            

        }
        public void Inicijaliziraj_Company()
        {
            pom = new Label();
            this.lev.Controls.Add(pom);
            this.pom.Location = new Point(15, 15);
            this.pom.Size = new Size(70, 20);
            this.pom.Text = sto;

            

            this.lev.Controls.Add(vnesiTexBox);
            this.vnesiTexBox.Location = new Point(this.pom.Location.X + 70, 15);
            this.vnesiTexBox.Size = new Size(150, 20);

            contaktLbl1 = new Label();

            this.lev.Controls.Add(contaktLbl1);
            this.contaktLbl1.Text = "Contact:";
            this.contaktLbl1.Location = new Point(15 , this.vnesiTexBox.Location.Y + 30);
            this.contaktLbl1.Size = new Size(50, 30);

            telLbl1 = new Label();

            this.lev.Controls.Add(telLbl1);
            this.telLbl1.Text = "Tel:";
            this.telLbl1.Location = new Point(this.contaktLbl1.Location.X, this.vnesiTexBox.Location.Y + 60);
            this.telLbl1.Size = new Size(50, 30);

            faxLbl1 = new Label();

            this.lev.Controls.Add(faxLbl1);
            this.faxLbl1.Text = "Fax:";
            this.faxLbl1.Location = new Point(this.contaktLbl1.Location.X, this.vnesiTexBox.Location.Y + 90);
            this.faxLbl1.Size = new Size(50, 30);

            emailLbl1 = new Label();

            this.lev.Controls.Add(emailLbl1);
            this.emailLbl1.Text = "Email:";
            this.emailLbl1.Location = new Point(this.contaktLbl1.Location.X, this.vnesiTexBox.Location.Y + 120);
            this.emailLbl1.Size = new Size(50, 30);

            cityLbl1 = new Label();

            this.lev.Controls.Add(cityLbl1);
            this.cityLbl1.Text = "City:";
            this.cityLbl1.Location = new Point(this.contaktLbl1.Location.X, this.vnesiTexBox.Location.Y + 150);
            this.cityLbl1.Size = new Size(50, 30);

            countryLbl1 = new Label();

            this.lev.Controls.Add(countryLbl1);
            this.countryLbl1.Text = "Country:";
            this.countryLbl1.Location = new Point(this.contaktLbl1.Location.X, this.vnesiTexBox.Location.Y + 180);
            this.countryLbl1.Size = new Size(50, 30);

            contaktLbl = new Label();

            this.lev.Controls.Add(contaktLbl);
            this.contaktLbl.Text = "Contact";
            this.contaktLbl.Location = new Point(this.vnesiTexBox.Location.X, this.vnesiTexBox.Location.Y + 30);
            this.contaktLbl.Size = new Size(150, 30);

            telLbl = new Label();

            this.lev.Controls.Add(telLbl);
            this.telLbl.Text = "Contact";
            this.telLbl.Location = new Point(this.vnesiTexBox.Location.X, this.vnesiTexBox.Location.Y + 60);
            this.telLbl.Size = new Size(150, 30);

            faxLbl = new Label();

            this.lev.Controls.Add(faxLbl);
            this.faxLbl.Text = "Contact";
            this.faxLbl.Location = new Point(this.vnesiTexBox.Location.X, this.vnesiTexBox.Location.Y + 90);
            this.faxLbl.Size = new Size(150, 30);

            emailLbl = new Label();

            this.lev.Controls.Add(emailLbl);
            this.emailLbl.Text = "Contact";
            this.emailLbl.Location = new Point(this.vnesiTexBox.Location.X, this.vnesiTexBox.Location.Y + 120);
            this.emailLbl.Size = new Size(150, 30);

            cityLbl = new Label();

            this.lev.Controls.Add(cityLbl);
            this.cityLbl.Text = "Contact";
            this.cityLbl.Location = new Point(this.vnesiTexBox.Location.X, this.vnesiTexBox.Location.Y + 150);
            this.cityLbl.Size = new Size(150, 30);

            countryLbl = new Label();

            this.lev.Controls.Add(countryLbl);
            this.countryLbl.Text = "Contact";
            this.countryLbl.Location = new Point(this.vnesiTexBox.Location.X, this.vnesiTexBox.Location.Y + 180);
            this.countryLbl.Size = new Size(150, 30);
        }
        public void Inicijaliziraj_Product()
        {

            pom = new Label();

            this.lev.Controls.Add(pom);
            this.pom.Location = new Point(15, 15);
            this.pom.Size = new Size(70, 20);
            this.pom.Text = sto;

            this.lev.Controls.Add(vnesiTexBox);
            this.vnesiTexBox.Location = new Point(this.pom.Location.X + 70, 15);
            this.vnesiTexBox.Size = new Size(150, 20);

            groupLbl1 = new Label();

            this.lev.Controls.Add(groupLbl1);
            this.groupLbl1.Text = "Group:";
            this.groupLbl1.Location = new Point(15, this.vnesiTexBox.Location.Y + 30);
            this.groupLbl1.Size = new Size(50, 30);

            descriptionLbl1 = new Label();

            this.lev.Controls.Add(descriptionLbl1);
            this.descriptionLbl1.Text = "Descrip. :";
            this.descriptionLbl1.Location = new Point(this.groupLbl1.Location.X, this.vnesiTexBox.Location.Y + 60);
            this.descriptionLbl1.Size = new Size(60, 30);

            groupLbl = new Label();

            this.lev.Controls.Add(groupLbl);
            this.groupLbl.Text = "Group";
            this.groupLbl.Location = new Point(this.vnesiTexBox.Location.X, this.vnesiTexBox.Location.Y + 30);
            this.groupLbl.Size = new Size(150, 30);

            descriptionLbl = new Label();

            this.lev.Controls.Add(descriptionLbl);
            this.descriptionLbl.Text = "Description";
            this.descriptionLbl.Location = new Point(this.vnesiTexBox.Location.X, this.vnesiTexBox.Location.Y + 60);
            this.descriptionLbl.Size = new Size(150, 30);
        }
        public void Inicijaliziraj_Group()
        {
            pom = new Label();

            this.lev.Controls.Add(pom);
            this.pom.Location = new Point(15, 15);
            this.pom.Size = new Size(70, 20);
            this.pom.Text = sto;


            this.lev.Controls.Add(vnesiTexBox);
            this.vnesiTexBox.Location = new Point(this.pom.Location.X + 70, 15);
            this.vnesiTexBox.Size = new Size(150, 20);
        }
        public void NacartajKopcinja()
        {
            submitBtn = new Button ();

            submitBtn.Text = "Submit Changes";
            submitBtn.Size = new Size(80,40);
            this.lev.Controls.Add(submitBtn);
            submitBtn.Location = new Point(15,this.desen.Size.Height - 40 );
            submitBtn.Click += new EventHandler(this.kopce_Klik);
            this.submitBtn.BackColor = Color.Brown;
            this.submitBtn.Enabled = false;

            cancelBtn = new Button();

            cancelBtn.Text = "Cancel";
            cancelBtn.Size = this.submitBtn.Size;
            this.lev.Controls.Add(cancelBtn);
            cancelBtn.Location = new Point(20 + this.submitBtn.Size.Width ,this.desen.Size.Height - 40);
            cancelBtn.Click += new EventHandler(this.kopce_Klik);


        }
        public void setirajTextBox()
        {
            if (prerfleno != null && prerfleno.Trim() != "")
            {
                this.vnesiTexBox.Text = prerfleno;
                this.Enter(vnesiTexBox, new KeyEventArgs(Keys.Enter));
                //this.vnesiTexBox.Enabled = false;
            }
            //else 
            //    this.vnesiTexBox.Enabled = true;
        }
        public void kopce_Klik(Object sender, EventArgs e)
        {
            if( sender.Equals(submitBtn))
            {
                if (sto == "Company")
                {
                    if (daliCheckBox)
                    {
                        foreach (Control var in novPanelD.Controls)
                        {
                            Redica red = var as Redica;
                            if (red != null)
                            {
                                if (red.Box.Checked == false)
                                {
                                    BrisiProizvod(red.SifraFirma, red.Sifra);
                                }
                            }
                        }
                        foreach (Control var in novPanelC.Controls)
                        {
                            Redica red = var as Redica;
                            if (red != null)
                            {
                                if (red.Box.Checked == true)
                                {
                                    DodadiProizvodFirma(red.Sifra);
                                }
                            }
                        }
                    }
                    else
                    {
                        //search
                    }
                }
                else if (sto == "Product")
                {
                    if (daliCheckBox)
                    {
                        foreach (Control var in novPanelD.Controls)
                        {
                            Redica red = var as Redica;
                            if (red != null)
                            {
                                if (red.Box.Checked == false)
                                {
                                    BrisiFirma(red.SifraFirma);
                                }
                            }
                        }
                        foreach (Control var in novPanelC.Controls)
                        {
                            Redica red = var as Redica;
                            if (red != null)
                            {
                                if (red.Box.Checked == true)
                                {
                                    DodadiProizvodFirma(red.SifraFirma);
                                }
                            }
                        }
                    }
                    else
                    {
                        //Seacrch
                    }
                }
                this.Close();
            }
            else if (sender.Equals(cancelBtn))
            {
                this.Close();
            }
        }
        public void Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.vnesiTexBox.Text.Trim() == "" && this.submitBtn != null)
                    this.submitBtn.Enabled = false;
                else if (this.submitBtn != null && this.vnesiTexBox.Text.Trim() != "") 
                    this.submitBtn.Enabled = true;

                this.novPanelD.Controls.Clear();
                this.novPanelC.Controls.Clear();
                if (sto == "Product")
                {
                    if (daliCheckBox)//Add/Update
                    {
                        if (DaliPostoiProizvod())
                        {
                            NapolniFormaProizvod();
                            novPanelD.DodatiPanel(vnesiTexBox.Text, "spVratiFirmaProizvod");
                            novPanelC.DodatiPanel(vnesiTexBox.Text, "spVratiNeFirmaProizvod");
                            this.submitBtn.Enabled = true;
                        }
                        else
                        {
                            IscistiLableP();
                            vnesiTexBox.Text = "";
                            this.submitBtn.Enabled = false;
                        }

                    }
                    else//Search
                    {
                        if (DaliPostoiProizvod())
                        {
                            NapolniFormaProizvod();
                            novPanelD.DodajSearchPanel(vnesiTexBox.Text, "spVratiFirmaProizvod");
                        }
                        else
                        {
                            vnesiTexBox.Text = "";
                            IscistiLableP();
                        }
                    }
                }
                else if (sto == "Company")
                {
                    if (daliCheckBox)//Add/Update
                    {
                        if (DaliPostoiFirma())
                        {
                            NapolniForma();
                            novPanelD.DodatiPanel(vnesiTexBox.Text, "spVratiProizvodFirma");
                            novPanelC.DodatiPanel(vnesiTexBox.Text, "spVratiNeProizvodFirma");
                            this.submitBtn.Enabled = true;
                        }
                        else
                        {
                            if (this.prerfleno == null)
                            {
                                this.IscistiLable();
                                vnesiTexBox.Text = "";
                                this.submitBtn.Enabled = false;
                            }
                            else
                            {
                                prerfleno = null;
                                this.Enter(this.vnesiTexBox,new KeyEventArgs(Keys.Enter));
                                
                            }
                        }
                        
                    }
                    else //Search
                    {
                        if (DaliPostoiFirma())
                        {
                            NapolniForma();
                            novPanelD.DodajSearchPanel(vnesiTexBox.Text, "spVratiProizvodFirma");
                           
                        }
                        else
                        {
                            this.IscistiLable();
                 
                        }
                    }
                }
                else if (sto == "Group")
                {
                    if (daliCheckBox)
                    {
                    }
                    else//Search
                    {
                        if (DaliPostoiGrupa())
                        {
                            novPanelD.DodajSearchPanel(vnesiTexBox.Text, "spProizvodiZaGrupa");
                        }
                        else
                        {
                            this.vnesiTexBox.Text = "";
                        }
                    }
                }
            }
        }
        public Boolean DaliPostoiProizvod()
        {
            String komanda = "EXECUTE spProveriCode";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;

            OleCm.Parameters.Add(new OleDbParameter("@Code", vnesiTexBox.Text.Trim()));
            int rezultat = -1;
            try
            {
                OleCn.Open();
                dt = OleCm.ExecuteReader();
                if (dt.Read())
                {
                    rezultat = Convert.ToInt32(dt["Rezultat"].ToString());
                }
                dt.Close();
                OleCn.Close();
                if (rezultat >= 1)
                {
                    OleCn.Close();
                    return true;
                }
                else if (rezultat == 0)
                {
                    OleCn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public Boolean DaliPostoiFirma()
        {
            String komanda = "EXECUTE spProveriFirma";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;
            OleCm.Parameters.Add(new OleDbParameter("@Firma", this.vnesiTexBox.Text.Trim()));
            int rezultat = -1;
            try
            {
                OleCn.Open();
                dt = OleCm.ExecuteReader();
                if (dt.Read())
                {
                    rezultat = Convert.ToInt32(dt["Rezultat"].ToString());
                }
                dt.Close();
                OleCn.Close();
                if (rezultat >= 1)
                {
                    OleCn.Close();
                    return true;
                }
                else if (rezultat == 0)
                {
                    OleCn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public void BrisiProizvod(int sifraFirma, int sifraPro)
        {

            OleDbConnection OleCn = new OleDbConnection(konekcija);
            OleDbCommand OleCm = new OleDbCommand("EXECUTE spBrisiProizvodFirma", OleCn);
            OleDbDataReader dt;
            try
            {
                OleCn.Open();
                OleCm.Parameters.Add("@Sifra_Firma", sifraFirma);
                OleCm.Parameters.Add("@Sifra_Proizovod", sifraPro);

                dt = OleCm.ExecuteReader();
                dt.Close();
                OleCn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void DodadiProizvodFirma(int sifraPro)
        {

            OleDbConnection OleCn = new OleDbConnection(konekcija);
            OleDbCommand OleCm = new OleDbCommand("EXECUTE spInsertDobavuvaci", OleCn);
            OleDbDataReader dt;
            try
            {
                OleCn.Open();
                if (sto == "Company")
                {
                    OleCm.Parameters.Add("@Sifra_Proizovod", sifraPro);
                    OleCm.Parameters.Add("@Sifra_Firma", Sifra_Firma);
                }
                else
                {
                    OleCm.Parameters.Add("@Sifra_Proizovod",Sifra_Proizvod );
                    OleCm.Parameters.Add("@Sifra_Firma", sifraPro);
                }

                dt = OleCm.ExecuteReader();
                dt.Close();
                OleCn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void NapolniForma()
        {
            String komanda = "EXECUTE spPodatociFirma";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;
            OleCm.Parameters.Add(new OleDbParameter("@Firma",vnesiTexBox.Text.Trim()));

            try
            {
                OleCn.Open();
                dt = OleCm.ExecuteReader();
                if (dt.Read())
                {
                    contaktLbl.Text = dt["Contact"].ToString();
                    telLbl.Text = dt["Tel"].ToString();
                    faxLbl.Text = dt["Fax"].ToString();
                    emailLbl.Text = dt["Email"].ToString();
                    cityLbl.Text = dt["City"].ToString();
                    countryLbl.Text = dt["Country"].ToString();
                    Sifra_Firma = dt["Sifra_Firma"].ToString();
                }
            }
            catch (Exception ex)
            {
                OleCn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void NapolniFormaProizvod()
        {
            String komanda = "EXECUTE spPodatociProizvod";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleCm.Parameters.Add(new OleDbParameter("@Code", this.vnesiTexBox.Text.Trim()));
            OleDbDataReader dt;

            try
            {
                OleCn.Open();
                dt = OleCm.ExecuteReader();
                if (dt.Read())
                {
                    groupLbl.Text  = dt["Ime_PG"].ToString();
                    descriptionLbl.Text =  dt["Description"].ToString();
                    Sifra_Proizvod = dt["Sifra_Pro"].ToString();
                }
                dt.Close();
                OleCn.Close();

            }
            catch (Exception ex)
            {
                OleCn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void BrisiFirma(int sifraFirma)
        {

            OleDbConnection OleCn = new OleDbConnection(konekcija);
            OleDbCommand OleCm = new OleDbCommand("EXECUTE spBrisiProizvodFirma", OleCn);
            OleDbDataReader dt;
            try
            {
                OleCn.Open();
                OleCm.Parameters.Add("@Sifra_Firma", sifraFirma);
                OleCm.Parameters.Add("@Sifra_Proizovod", Sifra_Proizvod);

                dt = OleCm.ExecuteReader();
                dt.Close();
                OleCn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void IscistiLable()
        {
            this.contaktLbl.Text = "";
            this.telLbl.Text = "";
            this.faxLbl.Text = "";
            this.cityLbl.Text = "";
            this.emailLbl.Text = "";
            this.countryLbl.Text = "";
        }
        public void IscistiLableP()
        {
            this.descriptionLbl.Text = "";
            this.groupLbl.Text = "";
        }
        public Boolean DaliPostoiGrupa()
        {
            String komanda = "EXECUTE spProveriGrupa";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;

            OleCm.Parameters.Add(new OleDbParameter("@Code", vnesiTexBox.Text.Trim()));


            int rezultat = -1;
            try
            {
                OleCn.Open();
                dt = OleCm.ExecuteReader();
                if (dt.Read())
                {
                    rezultat = Convert.ToInt32(dt["Rezultat"].ToString());
                }
                dt.Close();
                OleCn.Close();
                if (rezultat >= 1)
                {
                    OleCn.Close();
                    return true;

                }
                else if (rezultat == 0)
                {
                    OleCn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;

        }  
    }
}