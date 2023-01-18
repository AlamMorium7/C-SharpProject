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
    public partial class MyAccountInfo : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public MyAccountInfo()
        {
            InitializeComponent();
            showPage();
        }

        public void showPage()
        {
            SqlConnection c = new SqlConnection(cs);
            c.Open();
            SqlCommand cmd = new SqlCommand("select * from client where nid=@nid", c);
            cmd.Parameters.AddWithValue("@nid", LogInForm.nid.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {



                    textBox1.Text = Convert.ToString(dr.GetValue(0));
                    textBox2.Text = Convert.ToString(dr.GetValue(1));
                    textBox3.Text = Convert.ToString(dr.GetValue(2));
                    textBox4.Text = Convert.ToString(dr.GetValue(3));
                    textBox5.Text = Convert.ToString(dr.GetValue(3));
                    textBox6.Text = Convert.ToString(dr.GetValue(4));
                    textBox7.Text = Convert.ToString(dr.GetValue(5));
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
        private void MyAccountInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
        {
            this.Close();
            ClientForm cl = new ClientForm();
            this.Hide();
            cl.ShowDialog();
            Application.Exit();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == textBox5.Text)
            {

                SqlConnection con = new SqlConnection(cs);
                string query = " Update Client set name=@name,email=@email,pass=@pass, phoneno=@phoneno,address=@address,picture=@picture where nid=@nid";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                cmd.Parameters.AddWithValue("@passs", textBox5.Text);
                cmd.Parameters.AddWithValue("@phoneno", textBox6.Text);
                cmd.Parameters.AddWithValue("@address", textBox7.Text);
                cmd.Parameters.AddWithValue("@picture", SavePhoto());

                con.Open();
                int ab = cmd.ExecuteNonQuery();
                if (ab > 0)
                {
                    MessageBox.Show("Update completed", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                   // pictureBox1.Image = Properties.Resources._4051919_small;
                }
                else
                {
                    MessageBox.Show("Update failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Confirm Password Did not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // textBox5.Clear();
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
