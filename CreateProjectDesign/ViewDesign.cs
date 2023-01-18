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

    public partial class ViewDesign : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ViewDesign()
        {
            InitializeComponent();
            BindGridView();
            GetName();
            
        }

        private void ViewDesign_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wINFORM_DMDataSet.Table_1' table. You can move, or remove it, as needed.
            this.table_1TableAdapter.Fill(this.wINFORM_DMDataSet.Table_1);
            // TODO: This line of code loads data into the 'wINFORM_DMDataSet.ADMIN_A' table. You can move, or remove it, as needed.
            this.aDMIN_ATableAdapter.Fill(this.wINFORM_DMDataSet.ADMIN_A);

        }

        public void GetName()
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
                    textBox4.Text = Convert.ToString(dr.GetValue(0));
                }
                dr.Close();
            }
            c.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Image GetPhoto(byte[] picture)
        {
            MemoryStream ms = new MemoryStream(picture);
            return System.Drawing.Image.FromStream(ms);
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                    SqlConnection con = new SqlConnection(cs);
                    string query = "insert into order_table values (@name,@designid,@designname,@price,@designpicture)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", textBox4.Text);
                    cmd.Parameters.AddWithValue("@designid", textBox3.Text);
                    cmd.Parameters.AddWithValue("@designname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@price", textBox1.Text);
                    cmd.Parameters.AddWithValue("@designpicture", SavePhoto());
                   
                  

                    con.Open();
                    int ab = cmd.ExecuteNonQuery();
                    if (ab > 0)
                    {
                        MessageBox.Show("Order has been done!!You have to pay within 3 days otherwise order will get cancelled.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        //textBox4.Clear();                      
                        pictureBox1.Image = Properties.Resources.Apps_preferences_system_login_icon;
                    }
                    else
                    {
                        MessageBox.Show("Order failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
               
            
        }

        void BindGridView()
        {
            //Connection

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from table_1 ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //Data GridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //Image Clmn and table fit
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 70;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
           ClientForm cf = new ClientForm();
            this.Hide();
            cf.ShowDialog();
            Application.Exit();
           
        }
    }
}
