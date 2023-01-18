using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateProjectDesign
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }





        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            DesignerRecord ds = new DesignerRecord();
            this.Hide();
            ds.ShowDialog();
            Application.Exit();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminAccount lo = new AdminAccount();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            LogInForm lo = new LogInForm();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
            ShowAllClient lo = new ShowAllClient();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
        }
    }
}
