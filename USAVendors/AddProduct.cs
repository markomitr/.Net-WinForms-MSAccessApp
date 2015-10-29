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
    public partial class AddProduct : Form
    {
        private String konekcija; //Se zema konekcijata za bazata definirana vo MainForm
        private int Sifra_Proizvod;
        private bool daliIzlezi;

        CheckBox daliPromenaImeCheckBox;
        TextBox novoImeTextBox;

        public AddProduct()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            this.Inicijaliziraj_Forma();
            this.dozvoli(false);
            NapolniGrupi();
        }
        public void Inicijaliziraj_Forma()
        {
            daliIzlezi = false;
            this.Text = "Add New Product";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(800 / 2, (600 * 3) / 6);
            this.Inicijaliziraj_Controli();

            MainForm pom = (MainForm)this.MdiParent;
            konekcija = pom.ConnectionStr;

        }
        public void Inicijaliziraj_Controli()
        {

            daliPromenaImeCheckBox = new CheckBox();
            novoImeTextBox = new TextBox();


            this.groupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            this.codeLbl.Text = "Code";
            this.groupLbl.Text = "Group";
            this.descriptionLbl.Text = "Description";

            this.codeLbl.Location = new System.Drawing.Point(5, 10);
            this.groupLbl.Location = new System.Drawing.Point(this.codeLbl.Location.X, this.codeLbl.Location.Y + 40);
            this.descriptionLbl.Location = new System.Drawing.Point(this.codeLbl.Location.X, this.codeLbl.Location.Y + 120);

            this.codeTextBox.Location = new System.Drawing.Point(this.codeLbl.Location.X + 100, this.codeLbl.Location.Y );
            this.groupComboBox.Location = new System.Drawing.Point(this.codeLbl.Location.X + 100, this.codeLbl.Location.Y + 40);
            this.description1TextBox.Location = new System.Drawing.Point(this.codeLbl.Location.X + 100, this.codeLbl.Location.Y + 80);
            
            this.codeTextBox.Size = new System.Drawing.Size(200, 20);
            this.groupComboBox.Size = new System.Drawing.Size(200, 20);
            this.description1TextBox.Size = new System.Drawing.Size(200, 100);

            this.potvrdiBtn.Location = new System.Drawing.Point(10, this.Height - 75);
            this.potvrdiBtn.Size = new System.Drawing.Size(100, 50);
            this.potvrdiBtn.Text = "Submit (F10)";
            this.potvrdiBtn.Click += new System.EventHandler(this.novProdukt_Klik);
            this.potvrdiBtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vnesi_KeyUp);

            this.otkaziBtn.Text = "Cancel (F2)";
            this.otkaziBtn.Location = new System.Drawing.Point(this.potvrdiBtn.Location.X + 105, this.Height - 75);
            this.otkaziBtn.Size = this.potvrdiBtn.Size;
            this.otkaziBtn.Click += new System.EventHandler(this.novProdukt_Klik);
            this.otkaziBtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vnesi_KeyUp);

           
        }
        private void dozvoli(bool dali)
        {
            this.potvrdiBtn.Enabled = dali;
            this.description1TextBox.Enabled = dali;
            this.groupComboBox.Enabled = dali;
            
        }
        private void Vnesi_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
            {
                if (this.ActiveControl.Equals(potvrdiBtn))
                {
                    this.novProdukt_Klik(this.potvrdiBtn, e);
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
            else if (e.KeyCode == Keys.F10)
                this.novProdukt_Klik(this.potvrdiBtn, e);
            else if (e.KeyCode == Keys.F2)
                this.novProdukt_Klik(this.otkaziBtn, e);

        }
        private void novProdukt_Klik(object sender, EventArgs e)
        {
            if (sender.Equals(this.potvrdiBtn))
            {
                this.VnesiProizvod();
                daliIzlezi = true;
                this.Close();
            }
            else if(sender.Equals(this.otkaziBtn))
                this.Close();
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.codeTextBox.Text != " " && this.codeTextBox.Text != "" && this.codeTextBox.Text.Length > 0)
                this.dozvoli(true);
            else
                this.dozvoli(false);
        }
        private void AddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!daliIzlezi)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
           
        }
        public void NapolniGrupi()
        {
            OleDbConnection OleCn = new OleDbConnection(konekcija);
            String komanda = "EXECUTE spVratiGrupi";
            OleDbCommand OleCm = new OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;
            try
            {
                OleCn.Open();

                dt = OleCm.ExecuteReader();
                while (dt.Read())
                {
                    groupComboBox.Items.Add(dt["Ime"].ToString());
                }
                dt.Close();
                OleCn.Close();
                this.groupComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                OleCn.Close();
                MessageBox.Show(ex.Message);
            }

        }

        public void VnesiProizvod()
        {
            String komanda = "";
            Boolean update = false;

            OleDbConnection  OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand  OleCm = new System.Data.OleDb.OleDbCommand();
            OleDbDataReader dt;
            if (DaliPostoiProizvod())
            {
                komanda = "EXECUTE spUpdateProizvod";
                OleCm.Connection = OleCn;
                OleCm.CommandText = komanda;
                update = true;
            }
            else
            {
                komanda = "EXECUTE spDodadiProizvod";
                OleCm.Connection = OleCn;
                OleCm.CommandText = komanda;
            }

                if (daliPromenaImeCheckBox.Checked)
                {
                    OleCm.Parameters.Add(new OleDbParameter("@Name", novoImeTextBox.Text.ToString()));
                }
                else
                {
                    OleCm.Parameters.Add(new OleDbParameter("@Name", codeTextBox.Text.ToString()));
                }

                int pom=VratiSifraZaGrupa(groupComboBox.SelectedItem.ToString());
                OleCm.Parameters.Add(new OleDbParameter("@Group", pom.ToString()));
                OleCm.Parameters.Add(new OleDbParameter("@Description", description1TextBox.Text.ToString()));
            

            if (update) OleCm.Parameters.Add(new OleDbParameter("@Sifra_Pro", Sifra_Proizvod.ToString()));
            try
            {
                OleCn.Open();
                dt = OleCm.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int VratiSifraZaGrupa(String ime)
        {
            
            OleDbConnection OleCn = new OleDbConnection(konekcija);
            String komanda = "EXECUTE spVratiSifraGrupa";

            OleDbCommand  OleCm = new OleDbCommand(komanda, OleCn);
            OleCm.Parameters.Add(new OleDbParameter("@Name",ime));
            OleDbDataReader dt;
            try
            {
                OleCn.Open();

                dt = OleCm.ExecuteReader();
                if (dt.Read())
                {
                    return Convert.ToInt32(dt["Sifra"].ToString());
                }
                dt.Close();
                OleCn.Close();
                this.groupComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                return -1;
                OleCn.Close();
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
        public Boolean DaliPostoiProizvod()
        {
            String komanda = "EXECUTE spProveriCode";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand  OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;

            OleCm.Parameters.Add(new OleDbParameter("@Code",codeTextBox.Text.Trim()));
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

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (DaliPostoiProizvod())
            {
                novoImePrikaziControli();
                NapolniForma();
            }

        }
        public void NapolniForma()
        {
            String komanda = "EXECUTE spPodatociProizvod";

            OleDbConnection  OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand  OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleCm.Parameters.Add(new OleDbParameter("@Code", this.codeTextBox.Text.Trim()));
            OleDbDataReader dt;

            try
            {
                OleCn.Open();
                dt = OleCm.ExecuteReader();
                if (dt.Read())
                {
                    groupComboBox.SelectedIndex = groupComboBox.Items.IndexOf(dt["Ime_PG"].ToString());
                    description1TextBox.Text = dt["Description"].ToString();
                    Sifra_Proizvod = Convert.ToInt32(dt["Sifra_Pro"].ToString());
                }
                dt.Close();
                OleCn.Close();
                this.codeTextBox.Enabled = false;
            }
            catch (Exception ex)
            {
                OleCn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void novoImePrikaziControli()
        {

            this.Controls.Add(daliPromenaImeCheckBox);
            this.Controls.Add(novoImeTextBox);

            this.daliPromenaImeCheckBox.Text = "Check to add new Name";
            this.daliPromenaImeCheckBox.Size = new System.Drawing.Size(200, 20);
            this.daliPromenaImeCheckBox.Location = new System.Drawing.Point(10, this.potvrdiBtn.Location.Y - 30);
            this.daliPromenaImeCheckBox.CheckedChanged += new System.EventHandler(this.ProveriDaliNovoIme);

            novoImeTextBox.Location = new Point(this.daliPromenaImeCheckBox.Location.X + 200, this.daliPromenaImeCheckBox.Location.Y);
            novoImeTextBox.Enabled = false;


        }

        public void ProveriDaliNovoIme(object sender, EventArgs e)
        {
            if (daliPromenaImeCheckBox.Checked)
            {
                novoImeTextBox.Enabled = true;
            }
            else
            {
                novoImeTextBox.Enabled = false;
            }
        }
    }
}