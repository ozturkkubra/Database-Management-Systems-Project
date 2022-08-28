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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlDataAdapter adapter;

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();         
        }        

        private void Form6_Load(object sender, EventArgs e)
        {           
            connection = new SqlConnection("Data Source = LAPTOP-1NBIHC2E; Initial Catalog = EmlakDB; Integrated Security = True");
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM İller", connection);            
            adapter.Fill(dataTable);            
            comboBox1.ValueMember = "İlNo";
            comboBox1.DisplayMember = "İl";            
            comboBox1.DataSource = dataTable;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DataTable ilceTablo = new DataTable();
                SqlDataAdapter ilceAdapter = new SqlDataAdapter("SELECT *FROM İlçeler WHERE İlNo = " + comboBox1.SelectedValue, connection);
                ilceAdapter.Fill(ilceTablo);
                comboBox2.ValueMember = "İlçeNo";
                comboBox2.DisplayMember = "İlçe";
                comboBox2.DataSource = ilceTablo;
            }
        }
    }
}
