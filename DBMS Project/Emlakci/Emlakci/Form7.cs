using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Emlakci
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlDataAdapter adapter;

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form6"].Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source = LAPTOP-1NBIHC2E; Initial Catalog = EmlakDB; Integrated Security = True");
            connection.Open();
            string sql = "SELECT *FROM İlan";
            adapter = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }        
    }
}
