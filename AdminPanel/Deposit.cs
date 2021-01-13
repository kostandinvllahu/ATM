using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class Deposit : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");

        public Deposit()
        {
            InitializeComponent();
           // fillbox();
        }

        public void fillbox()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Amount from total_tbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                textBox1.Text = (rdr["Amount"].ToString()) + "Lek";
                //  label3.Text = (rdr["Username"].ToString());
                //textBox1.Text = (rdr["Deposit"].ToString());
                //textBox2.Text = (rdr["ID"].ToString());
                //txtID.Text = (rdr["ID"].ToString());
            }
            Con.Close(); ;
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            fillbox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
