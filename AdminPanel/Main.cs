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
            this.Close();
            f.Show();
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            AdminInfo a = new AdminInfo();
            this.Close();
            a.Show();
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
            this.Close();
            c.Show();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Payment p = new Payment();
            this.Close();
            p.Show();

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            Valut v = new Valut();
            this.Close();
            v.Show();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            Transactions t = new Transactions();
            this.Close();
            t.Show();
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            Deposit d = new Deposit();
            this.Close();
            d.Show();
        }
    }
}
