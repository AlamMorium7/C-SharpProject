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
    public partial class OrderDetails : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public OrderDetails()
        {
            InitializeComponent();
            GetOrderDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            ClientForm lo = new ClientForm();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
           
        }

        public void GetOrderDetails()
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Select * from order_table where name=@name", c);
                cmd.Parameters.AddWithValue("@name", LogInForm.nid.ToString());
                DataTable dataTable = new DataTable();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                dataTable.Load(sqlDataReader);
                c.Close();
                dataGridView1.DataSource = dataTable;


                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 70;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void OrderDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
