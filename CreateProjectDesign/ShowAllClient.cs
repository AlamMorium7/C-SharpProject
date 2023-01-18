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
    public partial class ShowAllClient : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ShowAllClient()
        {
            InitializeComponent();
            BindGridView_1();
            BindGridView_2();
        }

        private void ShowAllClient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wINFORM_DMDataSet2.PAYMENT' table. You can move, or remove it, as needed.
            this.pAYMENTTableAdapter.Fill(this.wINFORM_DMDataSet2.PAYMENT);
            // TODO: This line of code loads data into the 'wINFORM_DMDataSet1.CLIENT' table. You can move, or remove it, as needed.
            this.cLIENTTableAdapter.Fill(this.wINFORM_DMDataSet1.CLIENT);

        }

        void BindGridView_1()
        {
            //Connection

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from client";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //Data GridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 70;
        }

        void BindGridView_2()
        {
            //Connection

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from payment";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //Data GridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView2.DataSource = data;

                  

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.RowTemplate.Height = 70;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            AdminForm lo = new AdminForm();
            this.Hide();
            lo.ShowDialog();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
