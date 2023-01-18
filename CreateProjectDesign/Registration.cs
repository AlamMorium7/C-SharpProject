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
    public partial class Registration : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Registration()
        {
            InitializeComponent();
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            LogInForm ln = new LogInForm();
            this.Hide();
            ln.ShowDialog();
            Application.Exit();
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select Image";

            op.Filter = "Image File (All files) *.* | *.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(op.FileName);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please enter your nid number!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please enter the fullname");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Please enter your Email");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Enter New Password");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Confirm new password!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Provide Phone Number!");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Focus();
                errorProvider7.SetError(this.textBox7, "Please enter your Address!");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { 

               if (textBox1.Text == "")
               {
                   MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBox1.Focus();
               }

               else if (textBox2.Text == "")
               {
                   MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBox2.Focus();
               }

               else if (textBox3.Text == "")
               {
                   MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBox3.Focus();
               }

               else if (textBox4.Text == "")
               {
                   MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBox4.Focus();
               }
               else if (textBox5.Text == "")
               {
                   MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBox5.Focus();
               }
               else if (textBox6.Text == "")
               {
                   MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBox6.Focus();
               }
               else if (textBox7.Text == "")
               {
                   MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   textBox7.Focus();
               }
               else if (pictureBox1.Image == null)
               {
                   MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   pictureBox1.Focus();
               }

               else
               {
                   if (textBox4.Text == textBox5.Text)
                   {

                       SqlConnection con = new SqlConnection(cs);
                       string query = "insert into client values (@nid,@name,@email,@pass,@phoneno,@address,@img)";

                       SqlCommand cmd = new SqlCommand(query, con);
                       cmd.Parameters.AddWithValue("@nid", textBox1.Text);
                       cmd.Parameters.AddWithValue("@name", textBox2.Text);
                       cmd.Parameters.AddWithValue("@email", textBox3.Text);
                       cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                       cmd.Parameters.AddWithValue("@passs", textBox5.Text);
                       cmd.Parameters.AddWithValue("@phoneno", textBox6.Text);
                       cmd.Parameters.AddWithValue("@address", textBox7.Text);
                       cmd.Parameters.AddWithValue("@img", SavePhoto());

                       con.Open();
                       int ab = cmd.ExecuteNonQuery();
                       if (ab > 0)
                       {
                           MessageBox.Show("Registration completed", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           textBox1.Clear();
                           textBox2.Clear();
                           textBox3.Clear();
                           textBox4.Clear();
                           textBox5.Clear();
                           textBox6.Clear();
                           textBox7.Clear();
                           pictureBox1.Image = Properties.Resources._4051919_small;
                       }
                       else
                       {
                           MessageBox.Show("Registration failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                   }
                   else
                   {
                       MessageBox.Show("Confirm Password Did not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       textBox5.Clear();
                   }
               } 

        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
    }
}
