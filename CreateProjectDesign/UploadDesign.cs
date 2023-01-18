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
    public partial class UploadDesign : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public UploadDesign()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
            DesignerForm lo = new DesignerForm();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into table_1 values (@designid,@designname,@price,@designpicture)";

            SqlCommand cmd = new SqlCommand(query, con);
           
            cmd.Parameters.AddWithValue("@designid", textBox1.Text);
            cmd.Parameters.AddWithValue("@designname", textBox2.Text);
            cmd.Parameters.AddWithValue("@price", textBox3.Text);
            cmd.Parameters.AddWithValue("@designpicture", SavePhoto());



            con.Open();
            int ab = cmd.ExecuteNonQuery();
            if (ab > 0)
            {
                MessageBox.Show("Design Inserted!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();                
                pictureBox1.Image = Properties.Resources.poster_with_vertical_frames_empty_white_wall_living_room_interior_with_blue_velvet_armchair_3d_rendering_41470_2907;
            }
            else
            {
                MessageBox.Show(" Insertion Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please enter Design ID");
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
                errorProvider2.SetError(this.textBox2, "Please enter Design name");
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
                errorProvider3.SetError(this.textBox3, "Please enter the price!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select Image";

            op.Filter = "Image File (All files) *.* | *.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(op.FileName);
            }
        }
    }
}
