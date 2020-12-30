using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            AdminInfo a = new AdminInfo();
            a.Show();
            this.Close();
        }

        private void Datelbl_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Clients c = new Clients();
            c.Show();
            this.Close();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Payment p = new Payment();
            p.Show();
            this.Close();

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            Valut v = new Valut();
            v.Show();
            this.Close();
        }
    }
}
