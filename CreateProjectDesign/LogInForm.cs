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
    public partial class LogInForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string nid, name, email, pass, phoneno, address, salary;
        public static byte[] image;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public LogInForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration rs = new Registration();
            rs.Show();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider1.SetError(this.textBox2, "Please insert user nid!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox1, "Please enter password!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox1.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox1.UseSystemPasswordChar = true;
                    break;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            nid = textBox2.Text;
            if (comboBox1.Text.Equals("Admin"))
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from admin_a where nid=@nid and pass=@pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox2.Text);
                cmd.Parameters.AddWithValue("@pass", textBox1.Text);


                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {


                    this.Hide();
                    AdminForm ad = new AdminForm();
                    ad.Show();


                }
                else
                {
                    MessageBox.Show("Password is not correct", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }





            else if (comboBox1.Text.Equals("Client"))
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from client where nid=@nid and pass=@pass ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox2.Text);
                cmd.Parameters.AddWithValue("@pass", textBox1.Text);


                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {


                    this.Hide();
                    ClientForm cf = new ClientForm();
                    cf.Show();


                }
                else
                {
                    MessageBox.Show("Password is not correct", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

            }









            /* else if (radioButton3.Checked == true)*/
            else if (comboBox1.Text.Equals("Designer"))
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from designer where nid=@nid and pass=@pass ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox2.Text);
                cmd.Parameters.AddWithValue("@pass", textBox1.Text);


                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    this.Hide();
                    DesignerForm dp = new DesignerForm();
                    dp.Show();


                }
                else
                {
                    MessageBox.Show("Password is not correct", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            else
            {
                MessageBox.Show("Please try again!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

            }

           
        }

    

       
    

