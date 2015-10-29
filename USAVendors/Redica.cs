using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace USAVendors
{
    public partial class Redica : UserControl
    {
        protected System.Windows.Forms.GroupBox gb;
        protected CheckBox novCB;
        protected Label imeLabel;
        protected Label grupaLabel;
        protected int sifra;
        protected int sifraFirma;
        public CheckBox Box
        {
            get
            {
                return this.novCB;
            }
        }
        public int Sifra
        {
            get
            {
                return this.sifra;
            }
            set
            {
                this.sifra = value;
            }
        }

        public int SifraFirma
        {
            get
            {
                return this.sifraFirma;
            }
            set
            {
                this.sifraFirma = value;
            }
        }
        public Redica(String ime, String grupa, Boolean stiklirano, String sifra,String sifraFirma)
        {
            InitializeComponent();
            this.Size = new Size(200, 100);
            this.Location = new Point(0, 0);
            DodadiRed(ime, grupa, stiklirano,Convert.ToInt32(sifra),Convert.ToInt32(sifraFirma));
        }
        public void DodadiRed(String ime, String grupa, Boolean stiklirano,int sifra,int sifraFirma)
        {
            gb = new System.Windows.Forms.GroupBox();
            Sifra = new Int32();
            this.Sifra = sifra;

            SifraFirma = new Int32();
            this.SifraFirma  = sifraFirma;
            //gb.Controls.Add(Sifra);
            gb.Size = new Size(190,70);
            this.Controls.Add(gb);
            gb.Location = new Point(0,0);
   

            novCB = new CheckBox();
            gb.Controls.Add(novCB);
            novCB.Checked = stiklirano;
            novCB.Location = new Point(5, 10);
            novCB.Size = new Size(15, 15);


            imeLabel = new Label();
            gb.Controls.Add(imeLabel);
            imeLabel.Text = ime;
            imeLabel.Size = new Size(183, 20);
            imeLabel.Location = new Point(5, this.novCB.Size.Height + 15);

            grupaLabel = new Label();
            gb.Controls.Add(grupaLabel);
            grupaLabel.Text = grupa;
            grupaLabel.Size = new Size(130, 20);
            grupaLabel.Location = new Point(5, this.imeLabel.Location.Y + 18);

        }
    }
}
