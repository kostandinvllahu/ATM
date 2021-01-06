using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdminPanel
{
    public partial class Valut : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");
        public void populate()
        {
            Con.Open();
            string Myquery = "select * from Valut_tbl";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            Room.DataSource = ds.Tables[0];
            Con.Close();
        }

        public Valut()
        {
            InitializeComponent();
            populate();
            
        }

        double num;

        private void Valut_Load(object sender, EventArgs e)
        {

        }

        public void clean()
        {
            ID.Text = "";
            txtName.Text = "";
            txtValut.Text = "";
            txtAdmin.Text = "";
            txtID.Text = "";
            vlera.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ID.Text == "")
            {
                MessageBox.Show("Please Insert ID!");
            }
            else
            {

                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into Valut_tbl values(" + ID.Text + ",'" + txtName.Text + "','" + txtValut.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Valut Successfully Added!");
                Con.Close();
                populate();
                //updateroomstate();
                clean();
            }
        }

        private void txtID_OnValueChanged(object sender, EventArgs e)
        {
            ID.Text = txtID.Text;
        }

        private void txtAdmin_OnValueChanged(object sender, EventArgs e)
        {
            txtName.Text = txtAdmin.Text;
        }

        private void txtValut_OnValueChanged(object sender, EventArgs e)
        {
            vlera.Text = txtValut.Text;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        private void Room_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = Room.SelectedRows[0].Cells[0].Value.ToString();
            txtAdmin.Text = Room.SelectedRows[0].Cells[1].Value.ToString();
            txtValut.Text = Room.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            string myquery = "UPDATE Valut_tbl set Valut='" + txtName.Text + "',Exchange='" + vlera.Text + "'where Id=" + ID.Text + ";";
            SqlCommand cmd = new SqlCommand(myquery, Con);
            cmd.ExecuteNonQuery();
           // MessageBox.Show("Valut Successfully Edited!");
           // myquery = "select from Valut_tbl Valut where Id=" + txtID.Text + " UPDATE Client_tbl set Valut='"+;";
           // SqlCommand cmd = new SqlCommand(myquery, Con);
           // cmd.ExecuteNonQuery();
            MessageBox.Show("Valut Successfully Edited!");
            Con.Close();
            populate();
            clean();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ID.Text == "")
            {
                MessageBox.Show("Please Insert ID!");
            }
            else
            {
                Con.Open();
                string query = "delete from Valut_tbl where Id=" + txtID.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Valut Successfully Deleted!");
                Con.Close();
                populate();
                clean();
            }
        }

        private void vlera_TextChanged(object sender, EventArgs e)
        {
            
         }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
