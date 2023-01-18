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
    public partial class AdminAccount : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AdminAccount()
        {
            InitializeComponent();
            showPage();
        }

        public void showPage()
        {
            SqlConnection c = new SqlConnection(cs);
            c.Open();
            SqlCommand cmd = new SqlCommand("select * from admin_a where nid=@nid", c);
            cmd.Parameters.AddWithValue("@nid", LogInForm.nid.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {



                    textBox1.Text = Convert.ToString(dr.GetValue(0));
                    textBox2.Text = Convert.ToString(dr.GetValue(1));
                    textBox3.Text = Convert.ToString(dr.GetValue(2));
                    textBox4.Text = Convert.ToString(dr.GetValue(4));
                    textBox5.Text = Convert.ToString(dr.GetValue(5));
                    textBox6.Text = Convert.ToString(dr.GetValue(3));
                    textBox7.Text = Convert.ToString(dr.GetValue(3));
                    byte[] img = (byte[])(dr.GetValue(6));
                    if (img == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                dr.Close();
            }
            c.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox6.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox6.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please enter the NID Number!");
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
                errorProvider3.SetError(this.textBox3, "Please enter the Email!");
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
                errorProvider4.SetError(this.textBox4, "Please provide phone number!!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox6_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Please enter password!");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Please enter your address!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private byte[] SavePhoto()
        {

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select Image";

            op.Filter = "Image File (All files) *.* | *.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(op.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { /*
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            else if (textBox2.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
            }
            else if (textBox3.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
            }
            else if (textBox4.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Focus();
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Focus();
            }

            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
            }



            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pictureBox1.Focus();
            }

            else
            {
                if (textBox6.Text == textBox7.Text)
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "update admin_a set nid=@nid,name=@name,email=@email,pass=@pass,phoneno=@phoneno,address =@address,picture=@img where nid=@nid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nid", textBox1.Text);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@phoneno", textBox4.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox6.Text);
                    cmd.Parameters.AddWithValue("@passw", textBox7.Text);
                    cmd.Parameters.AddWithValue("@address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@img", SavePhoto());
                   
                    con.Open();

                    int a = cmd.ExecuteNonQuery(); 
                    if (a > 0)
                    {
                        MessageBox.Show("Data Updated successfully!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //pictureBox1.Image = Properties.Resources.lady_icon;
                        //ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data Update failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show(" Password Did Not Match!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            } */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminForm af = new AdminForm();
            this.Hide();
            af.ShowDialog();
            Application.Exit();

            //this.Hide();
           // AdminForm af = new AdminForm();
            //af.Show();
        }

       

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox2.Checked;
            switch (status)
            {
                case true:
                    textBox7.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox7.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
           
                if (string.IsNullOrEmpty(textBox7.Text))
                {
                    textBox7.Focus();
                    errorProvider7.SetError(this.textBox7, "Please enter password!");
                }
                else
                {
                    errorProvider7.Clear();
                }           
        }

        private void AdminAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
