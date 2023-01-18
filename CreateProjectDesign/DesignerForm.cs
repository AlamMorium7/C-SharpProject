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
    public partial class DesignerForm : Form
    {
        public DesignerForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            UploadDesign up = new UploadDesign();
            this.Hide();
            up.ShowDialog();
            Application.Exit();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            LogInForm lo = new LogInForm();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomizeDesignRequest cd = new CustomizeDesignRequest();
            this.Hide();
            cd.ShowDialog();
            Application.Exit();
            
        }

        private void DesignerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
