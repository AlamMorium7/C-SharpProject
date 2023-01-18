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
    public partial class CustomizeDesignRequest : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public CustomizeDesignRequest()
        {
            InitializeComponent();
            BindGridView();
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
                MessageBox.Show("Customize Design Inserted!!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            DesignerForm mo = new DesignerForm();
            this.Hide();
            mo.ShowDialog();
            Application.Exit();
        }

        private void CustomizeDesignRequest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wINFORM_DMDataSet1.DESIGN_REQUEST' table. You can move, or remove it, as needed.
            this.dESIGN_REQUESTTableAdapter.Fill(this.wINFORM_DMDataSet1.DESIGN_REQUEST);

        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[1].Value);

        }

        void BindGridView()
        {
            //Connection

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from design_request";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //Data GridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //Image Clmn and table fit
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[1];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 70;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
