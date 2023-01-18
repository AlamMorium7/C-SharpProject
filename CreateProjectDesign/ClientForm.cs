using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace CreateProjectDesign
{
    public partial class ClientForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ClientForm()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            MyAccountInfo mo = new MyAccountInfo();
            this.Hide();
            mo.ShowDialog();
            Application.Exit();
           // this.Hide();
            //MyAccountInfo ma = new MyAccountInfo();
            //ma.Show();
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewDesign vd = new ViewDesign();
            this.Hide();
            vd.ShowDialog();
            Application.Exit();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            OrderDetails cf = new OrderDetails();
            this.Hide();
            cf.ShowDialog();
            Application.Exit();
           
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            LogInForm lo = new LogInForm();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomizeDesign lo = new CustomizeDesign();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
                      
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Payment pm = new Payment();
            this.Hide();
            pm.ShowDialog();
            Application.Exit();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
