using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;

namespace USAVendors
{
    public partial class ProductGroup : Form
    {
        private String konekcija; //Se zema konekcijata za bazata definirana vo MainForm
        private String StaroIme;
        private TextBox novoImeTextBox;

        private bool daliIzlezi;
        public ProductGroup()
        {
            InitializeComponent();
        }

        private void PrdouctGroup_Load(object sender, EventArgs e)
        {
            this.Inicijaliziraj_Forma();
        }
        public void Inicijaliziraj_Forma()
        {
            daliIzlezi = false ;
            this.Text = "Add New Group";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(800 / 2 - 50, (600 * 2) / 6);
            this.Inicijaliziraj_Controli();

            MainForm pom = (MainForm)this.MdiParent;
            konekcija = pom.ConnectionStr;
        }
        public void Inicijaliziraj_Controli()
        {


            this.grupaLbl.Text = "Group Name";
            this.grupaLbl.Location = new System.Drawing.Point(5, 50);

            this.groupTextBox.Location = new System.Drawing.Point(this.grupaLbl.Location.X + 100, this.grupaLbl.Location.Y);
            this.groupTextBox.Size = new System.Drawing.Size(150, 20);

            this.potvrdiBtn.Location = new System.Drawing.Point(10, this.Height - 75);
            this.potvrdiBtn.Size = new System.Drawing.Size(100, 50);
            this.potvrdiBtn.Text = "Submit (F10)";
            this.potvrdiBtn.Click += new System.EventHandler(this.novaGrupa_Klik);
            this.potvrdiBtn.Enabled = false;

            this.otkaziBtn.Text = "Cancel (F2)";
            this.otkaziBtn.Location = new System.Drawing.Point(this.potvrdiBtn.Location.X + 105, this.Height - 75);
            this.otkaziBtn.Size = this.potvrdiBtn.Size;
            this.otkaziBtn.Click += new System.EventHandler(this.novaGrupa_Klik);
        }
        private void Vnesi_KeyUp(object sender, KeyEventArgs e)
        
        {
            if (e.KeyCode == Keys.Return)
            {
                if (this.ActiveControl.Equals(potvrdiBtn))
                {
                    this.novaGrupa_Klik(this.potvrdiBtn, e);
                }
                else  //if(this.groupTextBox.Enabled != false)
                {
                    if (this.ActiveControl.Equals(groupTextBox))
                    {
                        this.groupTextBox_Leave(this.groupTextBox, e);
                    }
                    else
                    {
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    }
                    
                }
                //else if (this.ActiveControl.Equals(groupTextBox))
                //{
                //    this.groupTextBox_Leave(this.groupTextBox, e);
                //}
            }
            else  if (e.KeyCode == Keys.F10)
                this.novaGrupa_Klik(this.potvrdiBtn, e);
            else if (e.KeyCode == Keys.F2)
                this.novaGrupa_Klik(this.otkaziBtn, e);

        }
        private void novaGrupa_Klik(object sender, EventArgs e)
        {
            if (sender.Equals(this.potvrdiBtn))
            {
                this.VnesiGrupa();
                daliIzlezi = true;
                this.Close();
            }
            else if (sender.Equals(this.otkaziBtn))
                this.Close();
        }
        private void AddGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!daliIzlezi)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void groupTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.groupTextBox.Text != "" && this.groupTextBox.Text != " " && this.groupTextBox.Text.Length > 0)
                this.potvrdiBtn.Enabled = true;
            else
                this.potvrdiBtn.Enabled = false;
           
        }
        public Boolean  DaliPostoiGrupa()
        {
             String komanda = "EXECUTE spProveriGrupa";

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand  OleCm = new System.Data.OleDb.OleDbCommand(komanda, OleCn);
            OleDbDataReader dt;
   

            if (groupTextBox.Enabled)
            {
                OleCm.Parameters.Add(new OleDbParameter("@Code", groupTextBox.Text.Trim()));
            }
            else
            {
                OleCm.Parameters.Add(new OleDbParameter("@Code", novoImeTextBox.Text.Trim()));
               
            }
           
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
        public void VnesiGrupa()
        {
            String komanda = "";
            Boolean update = false;

            OleDbConnection OleCn = new System.Data.OleDb.OleDbConnection(konekcija);
            OleDbCommand OleCm = new System.Data.OleDb.OleDbCommand();
            OleDbDataReader dt;
            if (DaliPostoiGrupa())
            {
                komanda = "EXECUTE spUpdateGrupa";
                OleCm.Connection = OleCn;
                OleCm.CommandText = komanda;
                update = true;
            }
            else
            {
                komanda = "EXECUTE spDodadiGrupa";
                OleCm.Connection = OleCn;
                OleCm.CommandText = komanda;
            }
            if (update) OleCm.Parameters.Add(new OleDbParameter("@Staro_Ime", StaroIme.ToString()));
            if (groupTextBox.Enabled == false )
            {
                if (update) return;
                OleCm.Parameters.Add(new OleDbParameter("@Name", novoImeTextBox.Text.ToString().Trim()));
            }
            else
            {
                OleCm.Parameters.Add(new OleDbParameter("@Name", groupTextBox.Text.ToString().Trim()));
            }
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
        private void groupTextBox_Leave(object sender, EventArgs e)
        {
            if (this.groupTextBox.Enabled != false)
            {
                if (DaliPostoiGrupa())
                {

                    if (MessageBox.Show("Group already exists.\n Do you want to change the name? ", "Choose", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        groupTextBox.Enabled = false;
                        StaroIme = groupTextBox.Text.Trim();
                        novoImeTextBox = new TextBox();
                        this.Controls.Add(novoImeTextBox);
                        novoImeTextBox.Location = new Point(105, 50 + 30);
                        novoImeTextBox.Size = groupTextBox.Size;
                        grupaLbl.Text = "New Group Name: ";
                        grupaLbl.Location = new Point(5, this.novoImeTextBox.Location.Y);
                        this.ActiveControl = novoImeTextBox;

                    }
                    else
                    {
                        groupTextBox.Enabled = true;
                        this.groupTextBox.Text = "";
                    }
                }
                else
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
            }
          
        }
    }
}