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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }
    }
}
