using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace USAVendors
{
    public partial class searchControla : UserControl
    {
        GroupBox gb;
        Label text1Lbl, text2Lbl, text3Lbl, text4Lbl,text5Lbl;
        String sto;
        public searchControla()
        {
            InitializeComponent();
            this.Size = new Size(500,40);
            this.Location = new Point(0, 0);
        }

        private void searchControla_Load(object sender, EventArgs e)
        {

        }
        public void Incijaliziraj_Product(String text1,String text2, String text3)
        {
            gb = new GroupBox();

            gb.Size = new Size(500, 40);
            this.Controls.Add(gb);
            gb.Location = new Point(0, 0);


            text1Lbl= new Label();
            gb.Controls.Add(text1Lbl);
            text1Lbl.Text = text1;
            text1Lbl.Font = new Font("Verdana",10,System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            text1Lbl.Size = new Size(150, 20);
            text1Lbl.Location = new Point(5, 15);

            text2Lbl = new Label();
            gb.Controls.Add(text2Lbl);
            text2Lbl.Text = text2;
            text2Lbl.Size = new Size(100, 20);
            text2Lbl.Location = new Point(this.text1Lbl.Location.X + 155, 15);

            text3Lbl = new Label();
            gb.Controls.Add(text3Lbl);
            text3Lbl.Text = text3;
            text3Lbl.Size = new Size(200, 20);
            text3Lbl.Location = new Point(this.text1Lbl.Location.X + 260, 15);
        }
        public void Incijaliziraj_Company(String text1, String text2, String text3,String text4)
        {
            gb = new GroupBox();

            gb.Size = new Size(500, 40);
            this.Controls.Add(gb);
            gb.Location = new Point(0, 0);


            text1Lbl = new Label();
            gb.Controls.Add(text1Lbl);
            text1Lbl.Text = text1;
            text1Lbl.Font = new Font("Verdana", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            text1Lbl.Size = new Size(150, 20);
            text1Lbl.Location = new Point(5, 15);

            text2Lbl = new Label();
            gb.Controls.Add(text2Lbl);
            text2Lbl.Text = text2;
            text2Lbl.Size = new Size(100, 15);
            text2Lbl.Location = new Point(this.text1Lbl.Location.X + 150,15);

            text3Lbl = new Label();
            gb.Controls.Add(text3Lbl);
            text3Lbl.Text = text3;
            text3Lbl.Size = new Size(100, 15);
            text3Lbl.Location = new Point(this.text1Lbl.Location.X + 250, 15);

            text4Lbl = new Label();
            gb.Controls.Add(text4Lbl);
            text4Lbl.Text = text4;
            text4Lbl.Size = new Size(50, 15);
            text4Lbl.Location = new Point(this.text1Lbl.Location.X + 440, 15);
        }
    }
}
