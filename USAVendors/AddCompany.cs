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
    public partial class AddCompany : Form
    {
        int i;
        String konekcija; //Se zema konekcijata za bazata definirana vo MainForm
        int Sifra_Firma; //Sifrata na firmata za koja se izmenuvaat podatocite
        CheckBox daliPromenaImeCheckBox;
        TextBox novoImeTextBox;
        private bool daliIzlezi;
        private bool daliDolu;

        public AddCompany()
        {
            InitializeComponent();
           
        }

        private void Proba_Load(object sender, EventArgs e)
        {
            this.Inicijaliziraj_Forma();
            this.dozvoli(false);
        }
        public void Inicijaliziraj_Forma()
        {
            Sifra_Firma = 0;
            this.Text = "Add New Company";
            daliIzlezi = false;
            daliDolu = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0,0);
            this.Size = new System.Drawing.Size(800 / 2, (600 * 4) / 5);
            this.Inicijaliziraj_Controli();

            MainForm pom = (MainForm)this.MdiParent;
            konekcija  = pom.ConnectionStr;
        }
        public void Inicijaliziraj_Controli()
        {
            i = 0;
            daliPromenaImeCheckBox = new CheckBox();
            novoImeTextBox = new TextBox();
            //postoiFirma = false;
            this.companyLbl.Text = "Company name";
            this.contactLbl.Text = "Contact";
            this.telLbl.Text = "Telephone";
            this.faxLbl.Text = "Fax";
            this.emailLbl.Text = "Email";
            this.cityLbl.Text = "City";
            this.zipcodeLbl.Text = "Zipcode";
            this.stateLbl.Text = "State";
            this.countryLbl.Text = "Country";

            this.companyLbl.Location = new System.Drawing.Point(5, 10);
            this.contactLbl.Location = new System.Drawing.Point(this.companyLbl.Location.X, this.companyLbl.Location.Y + 40);
            this.telLbl.Location = new System.Drawing.Point(this.companyLbl.Location.X, this.companyLbl.Location.Y + 80);
            this.faxLbl.Location = new System.Drawing.Point(this.companyLbl.Location.X, this.companyLbl.Location.Y + 120);
            this.emailLbl.Location = new System.Drawing.Point(this.companyLbl.Location.X, this.companyLbl.Location.Y + 160);
            this.cityLbl.Location = new System.Drawing.Point(this.companyLbl.Location.X, this.companyLbl.Location.Y + 200);
            this.zipcodeLbl.Location = new System.Drawing.Point(this.companyLbl.Location.X, this.companyLbl.Location.Y + 240);
            this.stateLbl.Location = new System.Drawing.Point(this.companyLbl.Location.X, this.companyLbl.Location.Y + 280);
            this.countryLbl.Location = new System.Drawing.Point(this.companyLbl.Location.X, this.companyLbl.Location.Y + 320);

            foreach (Control  pom in this.Controls)
            { 
                TextBox marko = pom as TextBox;
                if ( marko != null)
                {
                    pom.TabIndex = 1;
                    pom.Size = new System.Drawing.Size(200, 20);
                    pom.Location = new System.Drawing.Point(this.companyLbl.Location.X + 100, this.companyLbl.Location.Y + i);
                    i += 40;
                }
                
               
            }

            this.stateComboBox.Location = new System.Drawing.Point(this.companyLbl.Location.X + 100, this.companyLbl.Location.Y + i);
            this.stateComboBox.Size = new System.Drawing.Size(200, 20);
            this.stateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dodadi("State");
            this.stateComboBox.SelectedIndex = 50;

            this.countryComboBox.Location = new System.Drawing.Point(this.companyLbl.Location.X + 100,this.companyLbl.Location.Y + i + 40);
            this.countryComboBox.Size = new System.Drawing.Size(200, 20);
            this.countryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dodadi("Drzavi");
            this.countryComboBox.SelectedIndex = 244;

            

            this.potvrdiBtn.Location = new System.Drawing.Point(10, this.Height - 75);
            this.potvrdiBtn.Size = new System.Drawing.Size(100, 50);
            this.potvrdiBtn.Text = "Submit (F10)";
            this.dodadiProizvoiBtn.Text = "Add products";
            this.dodadiProizvoiBtn.Location = new System.Drawing.Point(this.potvrdiBtn.Location.X + 105, this.Height - 75);
            this.dodadiProizvoiBtn.Size = this.potvrdiBtn.Size;
            this.otkaziBtn.Text = "Cancel (F2)";
            this.otkaziBtn.Location = new System.Drawing.Point(this.dodadiProizvoiBtn.Location.X + 105, this.Height - 75);
            this.otkaziBtn.Size = this.potvrdiBtn.Size;
        }
        public void dozvoli(bool dali)
        {
            this.contactTxtBox.Enabled = dali;
            this.telTextBox.Enabled = dali;
            this.faxTexBox.Enabled = dali;
            this.emailTextBox.Enabled = dali;
            this.cityTextBox.Enabled = dali;
            this.zipcodeTextBox.Enabled = dali;
            this.stateComboBox.Enabled= dali;
            this.countryComboBox.Enabled = dali;
            this.potvrdiBtn.Enabled = dali;
            this.dodadiProizvoiBtn.Enabled = dali;
            this.countryComboBox.Enabled = dali;
        }
        private void Vnesi_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)

                if (this.ActiveControl.Equals(potvrdiBtn))
                {
                    this.novaKompanika_Klik(this.potvrdiBtn, e);
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            else if (e.KeyCode == Keys.F10)
            {
                this.novaKompanika_Klik(this.potvrdiBtn, e);
            }
            else if (e.KeyCode == Keys.F2)
                this.novaKompanika_Klik(this.otkaziBtn, e);

        }
        private void novaKompanika_Klik(object sender, EventArgs e)
        {
            if (sender.Equals(this.potvrdiBtn))
            {
                this.VnesiFirma();
                daliIzlezi = true;
                this.Close();
            }
            else if (sender.Equals(this.dodadiProizvoiBtn))
            {
                AddProductsToCompany nova;
                this.VnesiFirma();
                daliIzlezi = true;
                if (daliDolu)
                {
                    System.Threading.Thread.Sleep(500);
                    nova = new AddProductsToCompany("Company", this.novoImeTextBox.Text, true);
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                    nova = new AddProductsToCompany("Company", this.companyNameTextBox.Text, true);
                }
                    

                nova.MdiParent = this.MdiParent;
                nova.Show();
                this.Close();

            }
            else
            this.Close();
        }
        private void companyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (novoImeTextBox.Text.Trim() != "" && novoImeTextBox.Text.Trim() != "  ")
            {
                this.potvrdiBtn.Enabled = true;
            }
            else
            {
                this.potvrdiBtn.Enabled = false;
            }
            //if (this.companyNameTextBox.Text != "" && this.companyNameTextBox.Text != " " && this.companyNameTextBox.Text.Length > 0)
            //{
            //    this.dozvoli(true);
            //}
            //else
            //    this.dozvoli(false);

         }
        private void AddCompany_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!daliIzlezi)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void dodadi(String sto)
        {
            if(sto == "Drzavi")
            {

                string[] lines = Properties.Resources.Drzavi.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line != null)
                    {
                        this.countryComboBox.Items.Add(line);
                    }
                }

           }
            else if( sto == "State")
            {
                 string[] lines = Properties.Resources.States.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line != null)
                    {
                        this.stateComboBox.Items.Add(line);
                    }
                }
            }
        }
        private void proveriIndex(object sender, EventArgs e)
        {
            if (this.countryComboBox.SelectedIndex != 244)
                this.stateComboBox.SelectedIndex = Convert.ToInt16(this.stateComboBox.Items.IndexOf("None").ToString());
        }
        public Boolean DaliPostoiFirma()
        {
            String komanda = "EXECUTE spProveriFirma";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;
            if (!daliPromenaImeCheckBox.Checked)
            {
                OleCm.Parameters.Add(new OleDbParameter("@Firma", this.companyNameTextBox.Text.Trim()));
            }
            else
            {
                OleCm.Parameters.Add(new OleDbParameter("@Firma", this.novoImeTextBox.Text.Trim()));
            }
            int rezultat=-1;
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
        public void VnesiFirma()
        {
            daliDolu = false;
            String komanda = "";
            Boolean update = false;
            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand();
            OleDbDataReader dt;
            if (DaliPostoiFirma())
            {
                komanda = "EXECUTE spUpdateFirma";
                OleCm.Connection = OleCn;
                OleCm.CommandText = komanda;
                update = true;
            }
            else
            {
                if (this.daliPromenaImeCheckBox.Checked)
                {
                    komanda = "EXECUTE spUpdateFirma";
                    OleCm.Connection = OleCn;
                    OleCm.CommandText = komanda;
                    daliDolu = true;
                }
                else
                {
                    komanda = "EXECUTE spDodadiFirma";
                    OleCm.Connection = OleCn;
                    OleCm.CommandText = komanda;
                }
            }
            if(this.daliPromenaImeCheckBox.Checked)
            {
                if (update)
                {
                    MessageBox.Show(this.novoImeTextBox.Text + " already exists");
                    return;
                }
                if (novoImeTextBox.Text.Trim() != "")
                {
                    OleCm.Parameters.Add(new OleDbParameter("@Name", novoImeTextBox.Text.ToString().Trim()));
                    daliDolu = true;
                    update = true;
                }
                else
                {
                    MessageBox.Show("Empty name Field");
                    return;
                }
            }else
            {
                if (companyNameTextBox.Text.Trim() != "")
                {
                    OleCm.Parameters.Add(new OleDbParameter("@Name", companyNameTextBox.Text.ToString().Trim()));
                }
                else
                {
                    MessageBox.Show("Empty name Field");
                    return;
                }
            }
            
            OleCm.Parameters.Add(new OleDbParameter("@Contact", contactTxtBox.Text.ToString()));
            OleCm.Parameters.Add(new OleDbParameter("@Tel", telTextBox.Text.ToString()));
            OleCm.Parameters.Add(new OleDbParameter("@Fax", faxTexBox.Text.ToString()));
            OleCm.Parameters.Add(new OleDbParameter("@Email", emailTextBox.Text.ToString()));
            OleCm.Parameters.Add(new OleDbParameter("@City", cityTextBox.Text.ToString()));
            OleCm.Parameters.Add(new OleDbParameter("@ZipCode", zipcodeTextBox.Text.ToString()));
            OleCm.Parameters.Add(new OleDbParameter("@State", stateComboBox.Text.ToString()));
            OleCm.Parameters.Add(new OleDbParameter("@Country", countryComboBox.SelectedItem.ToString()));

            if (update) OleCm.Parameters.Add(new OleDbParameter("@Sifra",Sifra_Firma.ToString()));
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
        public void NapolniForma()
        {
            String komanda = "EXECUTE spPodatociFirma";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;
            OleCm.Parameters.Add(new OleDbParameter("@Firma", this.companyNameTextBox.Text.Trim()));

            try
            {
                OleCn.Open();
                dt = OleCm.ExecuteReader();
                if (dt.Read())
                {
                    contactTxtBox.Text = dt["Contact"].ToString();
                    telTextBox.Text = dt["Tel"].ToString();
                    faxTexBox.Text = dt["Fax"].ToString();
                    emailTextBox.Text = dt["Email"].ToString();
                    zipcodeTextBox.Text = dt["ZipCode"].ToString();
                    cityTextBox.Text = dt["City"].ToString();
                    stateComboBox.SelectedIndex = stateComboBox.Items.IndexOf(dt["State"].ToString());
                    countryComboBox.SelectedIndex = countryComboBox.Items.IndexOf(dt["Country"].ToString());
                    Sifra_Firma = Convert.ToInt32(dt["Sifra_Firma"].ToString());
                }

            }
            catch (Exception ex)
            {
                OleCn.Close();
                MessageBox.Show(ex.Message);
            }
            novoImePrikaziControli();
            companyNameTextBox.Enabled = false;
        }
        private void companyNameTextBox_Leave(object sender, EventArgs e)
        {
            if (DaliPostoiFirma())
            {
                //this.potvrdiBtn.Enabled = false;
                NapolniForma();
                this.dozvoli(true);
            }
            else
            {
                this.dozvoli(true);
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
            this.novoImeTextBox.TextChanged+= new EventHandler(this.companyNameTextBox_TextChanged);
           

        }
        public void ProveriDaliNovoIme(object sender,EventArgs e)
        {
            if (daliPromenaImeCheckBox.Checked)
            {
                novoImeTextBox.Enabled = true;
                this.novoImeTextBox.Focus();
                this.novoImeTextBox.Text = " ";
            }
            else
            {
                this.potvrdiBtn.Enabled = true;
                novoImeTextBox.Enabled = false;
            }
        }
    }
}