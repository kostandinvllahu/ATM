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
    public partial class AdminInfo : Form
    {

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");
        public void populate()
        {
            Con.Open();
            string Myquery = "select * from Admin_tbl";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            Room.DataSource = ds.Tables[0];
            Con.Close();
        }
        public AdminInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }
       // DateTime today;
        private void AdminInfo_Load(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            // today = dateTimePicker1.Value;
            populate();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        public void clean()
        {
            txtID.Text = "";
            ID.Text = "";
            txtAdmin.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            password.Text = "";
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
                SqlCommand cmd = new SqlCommand("insert into Admin_tbl values(" + ID.Text + ",'" + txtName.Text + "','" + txtPassword.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Successfully Added!");
                Con.Close();
                populate();
                //updateroomstate();
                clean();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void ID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtID_OnValueChanged(object sender, EventArgs e)
        {
            ID.Text = txtID.Text;
        }

        private void txtAdmin_OnValueChanged(object sender, EventArgs e)
        {
            txtName.Text = txtAdmin.Text;
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            password.Text = txtPassword.Text;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            populate();
            search.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
                Con.Open();
                string myquery = "UPDATE Admin_tbl set Username='" + txtName.Text + "',Password='" + password.Text +"'where Id=" + txtID.Text + ";";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Successfully Edited!");
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
                string query = "delete from Admin_tbl where Id=" + txtID.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Successfully Deleted!");
                Con.Close();
                populate();
                clean();
            }
        }

        private void Room_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = Room.SelectedRows[0].Cells[0].Value.ToString();
            txtAdmin.Text = Room.SelectedRows[0].Cells[1].Value.ToString();
            txtPassword.Text = Room.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (search.Text == "")
            {
                MessageBox.Show("Please enter the ID");
            }
            else
            {
                Con.Open();
                string Myquery = "select * from Admin_tbl where ResId = '" + search.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                Room.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
