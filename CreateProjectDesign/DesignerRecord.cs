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
    public partial class DesignerRecord : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public DesignerRecord()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Close();
            AdminForm ad = new AdminForm();
            this.Hide();
            ad.ShowDialog();
            Application.Exit();
           
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            else if (textBox2.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox3.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if (textBox5.Text == " ")
            {
                MessageBox.Show("Please fill  the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
            }
            else if (textBox6.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }          

            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Focus();
            }


            else
            {
                if (textBox5.Text == textBox6.Text)
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "insert into designer values (@nid,@username,@email,@pass,@salary,@img)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nid", textBox1.Text);
                    cmd.Parameters.AddWithValue("@username", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox5.Text);
                    cmd.Parameters.AddWithValue("@passw", textBox6.Text);
                    cmd.Parameters.AddWithValue("@img", SavePhoto());
                    cmd.Parameters.AddWithValue("@salary", textBox8.Text);
                    con.Open();

                    int a = cmd.ExecuteNonQuery(); //Return true false (int type)
                    if (a > 0)
                    {
                        MessageBox.Show("Data Inserted successfully!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data Insertion failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show("Confirm Password Did Not Match!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                }
            }
        }

        private byte[] SavePhoto()
        {

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }


        void BindGridView()
        {
            //Connection

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from designer";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //Data GridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //Image Clmn and table fit
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 70;
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

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider4.SetError(this.textBox5, "Please enter the password!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider5.SetError(this.textBox6, "Please Confirm password!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

     
        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.Focus();
                errorProvider7.SetError(this.textBox8, "Please input salary for the designer!");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
            pictureBox1.Image = Properties.Resources.Graphic_designer_icon;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);

        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }

            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Focus();
            }

            else
            {
                if (textBox5.Text == textBox6.Text)
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "update designer set nid=@nid,username=@username,email=@email,pass=@pass,salary=@salary,picture=@img where nid=@nid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nid", textBox1.Text);
                    cmd.Parameters.AddWithValue("@username", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox5.Text);
                    cmd.Parameters.AddWithValue("@passw", textBox6.Text);
                    cmd.Parameters.AddWithValue("@img", SavePhoto());
                    cmd.Parameters.AddWithValue("@salary", textBox8.Text);
                    con.Open();

                    int a = cmd.ExecuteNonQuery(); //Return true false
                    if (a > 0)
                    {
                        MessageBox.Show("Data Updated successfully!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data Update failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show("Confirm Password Did Not Match!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            else if (textBox2.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox3.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if (textBox5.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
            }
            else if (textBox6.Text == " ")
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }

            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Focus();
            }

            else
            {
                if (textBox5.Text == textBox6.Text)
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "delete from designer where nid=@nid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nid", textBox1.Text);

                    con.Open();

                    int a = cmd.ExecuteNonQuery(); //Return true false
                    if (a > 0)
                    {
                        MessageBox.Show("Data deleted successfully!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data deletion failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show("Confirm Password Did Not Match!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
