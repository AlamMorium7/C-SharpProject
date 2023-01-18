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
    public partial class CustomizeDesign : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public CustomizeDesign()
        {
            InitializeComponent();
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
            string query = "insert into design_request values (@designname,@designpicture)";

            SqlCommand cmd = new SqlCommand(query, con);

          
            cmd.Parameters.AddWithValue("@designname", textBox1.Text);          
            cmd.Parameters.AddWithValue("@designpicture", SavePhoto());



            con.Open();
            int ab = cmd.ExecuteNonQuery();
            if (ab > 0)
            {
                MessageBox.Show("Dear Client, Your Request has been Sent!! Wait for the confirmation.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
              
                pictureBox1.Image = Properties.Resources.poster_with_vertical_frames_empty_white_wall_living_room_interior_with_blue_velvet_armchair_3d_rendering_41470_2907;
            }
            else
            {
                MessageBox.Show(" Request Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
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
            this.Close();
            ClientForm lo = new ClientForm();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Enter Name!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void CustomizeDesign_Load(object sender, EventArgs e)
        {

        }
    }
}
