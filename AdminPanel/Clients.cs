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
    public partial class Clients : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");
        public void populate()
        {
            Con.Open();
            string Myquery = "select Id, Username, Lastname, Phone, Valut, Deposit, IBAN, Password, IdCard from Client_tbl ";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            Client.DataSource = ds.Tables[0];
            Con.Close();
        }
        public Clients()
        {
            InitializeComponent();
            fillCurrencycombo();
            populate();
        }

        private void txtID_OnValueChanged(object sender, EventArgs e)
        {
            ID.Text = txtID.Text;
        }

        private void txtAdmin_OnValueChanged(object sender, EventArgs e)
        {
            txtName.Text = txtAdmin.Text;
        }

        private void txtlname_OnValueChanged(object sender, EventArgs e)
        {
            lname.Text = txtlname.Text;
        }

        private void txtPhone_OnValueChanged(object sender, EventArgs e)
        {
            phone.Text = txtPhone.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currency.Text = comboBox1.SelectedValue.ToString();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
           // Deposit.Text = bunifuMaterialTextbox1.Text;
        }

        private void txtIban_OnValueChanged(object sender, EventArgs e)
        {
            Iban.Text = txtIban.Text;
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            password.Text = txtPassword.Text;
        }

        private void txtIdCard_OnValueChanged(object sender, EventArgs e)
        {
            idcard.Text = txtIdCard.Text;
        }

        public void clean()
        {
            txtID.Text = "";
            ID.Text = "";
            txtAdmin.Text = "";
            txtName.Text = "";
            txtlname.Text = "";
            lname.Text = "";
            txtPhone.Text = "";
            phone.Text = "";
            currency.Text = "";
            comboBox1.Text = "Currency";
           // bunifuMaterialTextbox1.Text = "";
            Deposit.Text = "";
            txtIban.Text = "";
            Iban.Text = "";
            txtPassword.Text = "";
            txtIdCard.Text = "";
            idcard.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clean();
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
                SqlCommand cmd = new SqlCommand("insert into Client_tbl values(" + ID.Text + ",'" + txtName.Text + "','" + lname.Text + "','"+ phone.Text + "','" + currency.Text +"','"+Deposit.Text+"','"+Iban.Text+"','"+password.Text+"','"+idcard.Text+"')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Successfully Added!");
                Con.Close();
                populate();
                //updateroomstate();
                clean();
            }
        }

        public void RandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers = "0123456789";
            var stringChars = new char[34];
            var random = new Random();

            for (int i = 0; i < 2; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            for (int i = 2; i < 6; i++)
            {
                stringChars[i] = numbers[random.Next(numbers.Length)];
            }
            for (int i = 6; i < 34; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            // return finalString;
            txtIban.Text = finalString;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //txtIban.Text = Convert.string(RandomString());
            RandomString();
        }

        public void fillCurrencycombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Valut from Valut_tbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Currency", typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "Valut";
            comboBox1.DataSource = dt;
            Con.Close();
        }



        private void Clients_Load(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            populate();
            Valut();
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
                string query = "delete from Client_tbl where Id=" + txtID.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client Successfully Deleted!");
                Con.Close();
                populate();
                clean();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ID.Text == "")
            {
                MessageBox.Show("Please Insert ID!");
            }
            else
            {
                Con.Open();
                string myquery = "UPDATE Client_tbl set Username='" + txtName.Text + "',Lastname='" + lname.Text + "',Phone='" + phone.Text + "',Valut='" + currency.Text +"',Password='" + password.Text + "',IdCard='" + idcard.Text +"'where Id=" + txtID.Text +";";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client Successfully Edited!");
                Con.Close();
                populate();
                clean();

            }
        }

        private void Client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = Client.SelectedRows[0].Cells[0].Value.ToString();
            txtAdmin.Text = Client.SelectedRows[0].Cells[1].Value.ToString();
            txtlname.Text = Client.SelectedRows[0].Cells[2].Value.ToString();
            txtPhone.Text = Client.SelectedRows[0].Cells[3].Value.ToString();
            currency.Text = Client.SelectedRows[0].Cells[4].Value.ToString();
            Deposit.Text = Client.SelectedRows[0].Cells[5].Value.ToString();
            txtIban.Text = Client.SelectedRows[0].Cells[6].Value.ToString();
            txtPassword.Text = Client.SelectedRows[0].Cells[7].Value.ToString();
            txtIdCard.Text = Client.SelectedRows[0].Cells[8].Value.ToString();
            //txtExchange.Text = Client.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
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
                string Myquery = "select * from Client_tbl where Username = '" + search.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                Client.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void Deposit_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            Deposit.Text = a.ToString();
        }

       
        //ERROR!!!!!
        public void Valut()
        {

            /*try
            {
                Con.Open();
                string Myquery = "select * from Valut_tbl values";
                SqlCommand cmd = new SqlCommand(Myquery, Con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtAdmin.Text = dr.GetValue(0).ToString();
                }
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }
    

        private void exchange_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void currency_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
          //  Exchange();
        }
    }
}
