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
    public partial class Payment : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Admindtb.mdf;Integrated Security=True;Connect Timeout=30");
        public void populate()
        {
            Con.Open();
            string Myquery = "select * from Client_tbl";
            SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
            SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            Client.DataSource = ds.Tables[0];
            Con.Close();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Amount from total_tbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                txtBankDeposit.Text = (rdr["Amount"].ToString());
                //  label3.Text = (rdr["Username"].ToString());
                //textBox1.Text = (rdr["Deposit"].ToString());
//textBox2.Text = (rdr["ID"].ToString());
                //txtID.Text = (rdr["ID"].ToString());
            }
            Con.Close(); ;
        }

        public Payment()
        {
            //THIS PROBLEM IS FIXED
            //IT WORKS BUT AFTER YOU CHANGE SENDER ITS NOT UPDATEING THE VALUT AND EXCHANGE CHECK FOR A METHOD TO UPDATE!
            InitializeComponent();
            fillClientcombo();
            radioButton3.Checked = true;
            //populate();
        }
        String name;
        String add;
        String dep;

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }

        private void Client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID.Text = Client.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = Client.SelectedRows[0].Cells[1].Value.ToString();
            lname.Text = Client.SelectedRows[0].Cells[2].Value.ToString();
            phone.Text = Client.SelectedRows[0].Cells[3].Value.ToString();
            currency.Text = Client.SelectedRows[0].Cells[4].Value.ToString();
            //Deposit.Text = Client.SelectedRows[0].Cells[5].Value.ToString();
            Amount.Text = Client.SelectedRows[0].Cells[5].Value.ToString();
            Iban.Text = Client.SelectedRows[0].Cells[6].Value.ToString();
            password.Text = Client.SelectedRows[0].Cells[7].Value.ToString();
            idcard.Text = Client.SelectedRows[0].Cells[8].Value.ToString();
        }

       

        private void Payment_Load(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            label8.Visible = true;
            label8.Text = "Action";
            timer1.Start();
            populate();
           
        }

        public void fillClientcombo()
        {
            //E KE LENE KETU BEJE QE TE MARRI ID DHE TE JAPI EMRIN E FILANIT DHE TE DHENAT E TJERA!!!
            /* Con.Open();

              SqlCommand cmd = new SqlCommand("select Username from Client_tbl where IdCard='" + search.Text + "'", Con);
              SqlDataReader rdr;
              rdr = cmd.ExecuteReader();
              DataTable dt = new DataTable();
              dt.Columns.Add("Username", typeof(string));
              dt.Load(rdr);
              comboBox1.ValueMember = "Username";
              comboBox1.DataSource = dt;
              Con.Close();
             */

            Con.Open();
            SqlCommand cmd = new SqlCommand("select Username from Client_tbl where IdCard='" + search.Text + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Username", typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "Username";
            comboBox1.DataSource = dt;
            Con.Close();

        }


        public void fillvalut()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Valut from Client_tbl where Username='" + Sender.Text + "'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Valut", typeof(string));
            dt.Load(rdr);
            comboBox2.ValueMember = "Valut";
            comboBox2.DataSource = dt;
            Con.Close();



        }

        

        public void fillval()
        {
          

                Con.Open();
                SqlCommand cmd = new SqlCommand("select Exchange from Valut_tbl where Valut='" + currency.Text + "'", Con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Exchange", typeof(float));
                dt.Load(rdr);
                comboBox3.ValueMember = "Exchange";
                comboBox3.DataSource = dt;
                Con.Close();
            
        }



        public void total()
        {

            float a;
            float b;
            float c;
            float num = 0;

            //int x;
            // int z;
            a = float.Parse(Deposit.Text);
            b = float.Parse(Amount.Text);
            // num = float.Parse(txtBankDeposit.Text);
            txtEchange.Text = Convert.ToString(0);
            txtVal.Text = Convert.ToString(0);
            // d = Convert.ToInt32(txtEchange.Text);
            if (radioButton1.Checked == true)
            {
                if (ID.Text == "")
                {
                    MessageBox.Show("Select a client first!");
                    clean();
                }
                else
                {
                    label20.Visible = false;
                    label21.Visible = false;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    cmbExchange.Visible = false;
                    button3.Visible = false;
                    Deposit.Visible = true;
                    label8.Text = "Deposit";
                    label8.Visible = true;

                    //THERE IS A BUG WHEN DEPOSIT MONEY FROM ADMIN!
                    //ALSO CHECK THE USER PANEL TO FIX TO NOT SEND MONEY TO SAME ID AND WHEN MONEY IS 0 AND THE AMOUNT IS HIGHER
                    // THEN 0 TO NOT BE DELETED FROM THE DATABASE!

                    if (buttonClicked1 == true)
                    {
                        txtVal.Text = comboBox3.SelectedValue.ToString();
                        float d = float.Parse(comboBox3.SelectedValue.ToString());
                        float n;
                        //float c;
                        n = a / d;
                        int z = (int)Math.Round(n);
                        c = z + b;
                        Total.Text = Convert.ToString(c);
                        num += a;
                        txtBankDeposit.Text = Convert.ToString(num);
                        //MessageBox.Show(z.ToString());
                        Action.Text = "In your bank account was added " + a.ToString() + " your total balance now is " + c.ToString();
                        //MessageBox.Show("Total bank has: " + num);
                    }
                }
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    if (ID.Text == "")
                    {
                        MessageBox.Show("Select a client first!");
                        clean();
                    }
                    else
                    {
                        // Deposit.Visible = false;
                        // label8.Visible = false;
                        label20.Visible = false;
                        label21.Visible = false;
                        comboBox1.Visible = false;
                        comboBox2.Visible = false;
                        cmbExchange.Visible = false;
                        button3.Visible = false;

                        Deposit.Visible = true;
                        label8.Text = "Withdraw";
                        label8.Visible = true;
                        // int c;
                        if (b < a)
                        {
                            MessageBox.Show("You dont have enough money!");
                        }
                        else
                        {
                            if (b >= a)
                            {
                                c = b - a;
                                Total.Text = Convert.ToString(c);
                                Action.Text = "In your bank account was removed " + a.ToString() + " your total balance now is " + c.ToString();
                            }
                        }

                    }
                }
                else
                { //RREGULLO KETU QE TE DERGOSH LEKE NE LLOGARI TJETER

                    if (radioButton3.Checked == true)
                    {

                        if (ID.Text == "")
                        {
                           // MessageBox.Show("Select a client first!");
                            clean();
                        }
                        else
                        {
                            Deposit.Visible = true;
                            label8.Text = "Send";
                            label8.Visible = true;
                            label20.Visible = true;
                            label21.Visible = true;
                            comboBox1.Visible = true;
                            comboBox2.Visible = true;
                            cmbExchange.Visible = true;
                            button3.Visible = true;
                            if (buttonClicked == true)
                            {


                                txtVal.Text = comboBox3.SelectedValue.ToString();
                                float d = float.Parse(comboBox3.SelectedValue.ToString());
                                float n;
                                //float c;
                                n = a / d;
                                int z = (int)Math.Round(n);
                                c = z + b;
                                Total.Text = Convert.ToString(c);
                                //MessageBox.Show(z.ToString());
                                name = "From " + Convert.ToString(Sender.Text);
                                add = Convert.ToString(a);
                                dep = "Your overall deposit is " + Convert.ToString(b);
                                Action.Text = "In your bank account was added " + add;
                                textBox1.Text = name;
                                textBox2.Text = dep;
                                // Action.Text 
                            }
                        }
                    }
                }


            }
        }

        private bool buttonClicked1 = false;

        private bool buttonClicked = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
        }

        public void clean()
        {
            search.Text = "";
            //ID.Text = "";
            ID.Text = "";
            //txtAdmin.Text = "";
            txtName.Text = "";
            // txtlname.Text = "";
            lname.Text = "";
            // txtPhone.Text = "";
            phone.Text = "";
            currency.Text = "";
            // comboBox1.Text = "Currency";
            // bunifuMaterialTextbox1.Text = "";
            //  Deposit.Text = "";
            // txtIban.Text = "";
            Iban.Text = "";
            //txtPassword.Text = "";
            // txtIdCard.Text = "";
            idcard.Text = "";
            Deposit.Text = "0";
            Amount.Text = "0";
            password.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Deposit.Visible = false;
            label8.Text = "Action";
            comboBox1.Text = "Username";
            comboBox2.Text = "";
            txtValut.Text = "";
            Sender.Text = "";
            txtEchange.Text = "";
            cmbExchange.Text = "";
            label20.Visible = false;
            label21.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            cmbExchange.Visible = false;
            button3.Visible = false;
            radioButton3.Checked = false;


        }


        //===============E KE LENE KETU!================
        /*public void valut()
        {
            if(currency.Text == "Euro")
            {

            }
        }*/

            public void error()
        {
            if (radioButton3.Checked == true)
            {
                if (Sender.Text == "")
                {
                    MessageBox.Show("Please select the sender!");
                    clean();
                }
                //FIX HERE DEPOSIT VALUE  X != 0
                if(Deposit.Value == 0)
                {
                    MessageBox.Show("Please insert an ammount");
                }
            }
        }

        //DATABASE WHERE ALL HISTORY TRANSACTIONS ARE SAVED!
        public void Transactions()
        {
            if (radioButton3.Checked == true)
            {
                    Con.Open();
                SqlCommand cmd = new SqlCommand("insert into Transactions_tbl values(" + ID.Text + ",'" + txtName.Text + "','" + Action.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','"+idcard.Text+"')", Con);
                 
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transaction Successfully Added!");
                    Con.Close();
                    populate();
                    //updateroomstate();
                    clean();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            error();
            if (ID.Text == "")
            {
                MessageBox.Show("Please Insert ID!");
            }
            else
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                {
                    MessageBox.Show("Please choose an action!");
                }
                else
                {
                    total();
                    Con.Open();
                    string myquery = "UPDATE Client_tbl set Deposit='" + Total.Text + "'where Id=" + ID.Text + ";";
                    SqlCommand cmd = new SqlCommand(myquery, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Successfully Edited!");
                    Con.Close();
                    Con.Open();
                     myquery = "UPDATE total_tbl set Amount='" + txtBankDeposit.Text + "'";
                    SqlCommand abc = new SqlCommand(myquery, Con);
                    abc.ExecuteNonQuery();
                    MessageBox.Show("Bank Successfully Edited!");
                    Con.Close();
                    clean();
                    populate();
                    Transactions();
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            clean();
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
                string Myquery = "select * from Client_tbl where IdCard = '" + search.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                Client.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void Total_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fillval();
            buttonClicked = true;
            total();
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            total();
        }

        private void Deposit_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            populate();
            clean();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Action_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ERROR KETU
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void exrate()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Exchange from Valut_tbl where Valut='"+txtValut.Text+"'",Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Exchange", typeof(int));
            dt.Load(rdr);
            cmbExchange.ValueMember = "Exchange";
            cmbExchange.DataSource = dt;
            Con.Close();
        }

        private void cmbExchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEchange.Text = cmbExchange.SelectedValue.ToString();
            cmbExchange.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValut.Text = comboBox2.SelectedValue.ToString();
            comboBox2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fillClientcombo();
            fillvalut();
            exrate();
            buttonClicked = true;
            /*comboBox1.Text = "Username";
            Sender.Text = "";
            comboBox2.Text = "Valut";
            txtValut.Text = "";
            cmbExchange.Text = "";
            */
        }

        private void txtValut_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            fillval();
            buttonClicked1 = true;
            total();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TRY TO FIX THE PROBLEM WHERE IT TAKES FLOAT VALUE FORM VALUT TO CLIENT!
            //txtVal.Text = comboBox3.SelectedValue.ToString();
           // float.TryParse(comboBox3.Text);
          
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           // fillClientcombo();
            Sender.Text = comboBox1.SelectedValue.ToString();
        }

        private void currency_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.Show();
        }

        private void Sender_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBankDeposit_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
