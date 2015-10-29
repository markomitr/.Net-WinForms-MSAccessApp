using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace USAVendors
{
    public partial class RedPanel : UserControl
    {
        String konekcija;
        int pozicijaV;
        String pom;
        public RedPanel()
        {
            InitializeComponent();
        }

        private void RedPanel_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.AutoScroll = true;
            konekcija = ((MainForm)this.TopLevelControl).ConnectionStr;
            pozicijaV = 10;
        }
        public void DodatiPanel(String ime,String komanda)
        {
            int i = 1;
            pozicijaV = 10;
            OleDbConnection OleCn = new OleDbConnection(konekcija);
            OleDbCommand OleCm = new OleDbCommand("EXECUTE "+ komanda,OleCn);
            OleDbDataReader dt;
            try
            {
                OleCn.Open();
                OleCm.Parameters.Add("@Name",ime);
                Redica nova;
                nova = null;

                dt = OleCm.ExecuteReader();

                while (dt.Read())
                {
                   
                    if (komanda == "spVratiNeProizvodFirma")
                    {
                        nova = new Redica(dt["Name"].ToString(), dt["Ime_PG"].ToString(), false, dt["Sifra_PRO"].ToString(), null);
                        if (i % 4 == 1)
                        {
                            nova.Location = new Point(0, pozicijaV);
                        }
                        else if (i % 4 == 2)
                        {
                            nova.Location = new Point(200, pozicijaV);
                            
                        }
                        else if (i % 4 == 3)
                        {
                            nova.Location = new Point(400, pozicijaV);
                        }
                        else
                        {

                            nova.Location = new Point(600, pozicijaV);
                            pozicijaV += 75;
                        }
                    }
                    else if(komanda == "spVratiProizvodFirma")
                    {
                        nova = new Redica(dt["Name"].ToString(), dt["Ime_PG"].ToString(), true, dt["Proizvodi.Sifra_Pro"].ToString(), dt["Sifra_Firma"].ToString());
                        if (i % 2 != 0)
                        {
                            nova.Location = new Point(0, pozicijaV);
                        }
                        else
                        {
                            nova.Location = new Point(195, pozicijaV);
                            pozicijaV += 75;
                        }
                    }
                    else if (komanda == "spVratiFirmaProizvod")
                    {
                        nova = new Redica(dt["Firmi.Name"].ToString(), dt["City"].ToString(), true, dt["Proizvodi.Sifra_Pro"].ToString(), dt["Firmi.Sifra_Firma"].ToString());
                        if (i % 2 != 0)
                        {
                            nova.Location = new Point(0, pozicijaV);
                        }
                        else
                        {
                            nova.Location = new Point(195, pozicijaV);
                            pozicijaV += 75;
                        }
                    }
                    else if (komanda == "spVratiNeFirmaProizvod")
                    {
                        nova = new Redica(dt["Name"].ToString(), dt["City"].ToString(), false, null, dt["Sifra_Firma"].ToString());
                        if (i % 4 == 1)
                        {
                            nova.Location = new Point(0, pozicijaV);
                        }
                        else if (i % 4 == 2)
                        {
                            nova.Location = new Point(200, pozicijaV);

                        }
                        else if (i % 4 == 3)
                        {
                            nova.Location = new Point(400, pozicijaV);
                        }
                        else
                        {

                            nova.Location = new Point(600, pozicijaV);
                            pozicijaV += 75;
                        }
                    }
                    else
                    {
                    }

                    if (nova != null)
                    {
                        this.Controls.Add(nova);
                        nova.Size = new Size(195, 80);
                        i++;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }      

        }
        public void DodajSearchPanel(String ime,String komanda)
        {
            int i = 1;
            pozicijaV = 5;
            OleDbConnection OleCn = new OleDbConnection(konekcija);
            OleDbCommand OleCm = new OleDbCommand("EXECUTE " + komanda, OleCn);
            OleDbDataReader dt;
            try
            {
                OleCn.Open();
                OleCm.Parameters.Add("@Name", ime);
                searchControla nova;

                nova = null;

                dt = OleCm.ExecuteReader();

                while (dt.Read())
                {
                    if (komanda == "spVratiProizvodFirma")
                    {
                        nova = new searchControla();
                        nova.Location = new Point(5, pozicijaV);
                        nova.Incijaliziraj_Product(dt["Name"].ToString(), dt["Ime_PG"].ToString(), dt["Description"].ToString());
                        pozicijaV += 40;
                        this.Controls.Add(nova);
                    }
                    else if (komanda == "spVratiFirmaProizvod")
                    {
                        nova = new searchControla();
                        nova.Location = new Point(5, pozicijaV);
                        nova.Incijaliziraj_Company(dt["Firmi.Name"].ToString(),dt["Contact"].ToString(), dt["Email"].ToString(), dt["State"].ToString());
                        pozicijaV += 40;
                        this.Controls.Add(nova);
                    }
                    else if (komanda == "spProizvodiZaGrupa")
                    {
                        nova = new searchControla();
                        nova.Location = new Point(5, pozicijaV);
                        nova.Incijaliziraj_Product(dt["Name"].ToString(), dt["Ime_PG"].ToString(), dt["Description"].ToString());
                        pozicijaV += 40;
                        this.Controls.Add(nova);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            } 
        }
    }
}
