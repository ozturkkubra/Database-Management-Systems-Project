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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
      
        public void ilanSilVeyaGuncelle()
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

        private void Form8_Load(object sender, EventArgs e)
        {          
            ilanSilVeyaGuncelle();
        }     

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ilanNo = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string konutDurum = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string il = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string ilçe = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string adres = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string konutTipi = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string odaSayisi = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            string fiyat = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            string metrekare = dataGridView1.Rows[secilen].Cells[8].Value.ToString();

            textBox1.Text = ilanNo;
            comboBox1.Text = konutDurum;
            textBox2.Text = il;
            textBox3.Text = ilçe;
            textBox4.Text = adres;
            textBox5.Text = konutTipi;
            textBox6.Text = odaSayisi;
            textBox7.Text = fiyat;
            textBox8.Text = metrekare;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM İlan WHERE İlanNo=@İlanNo";
            command = new SqlCommand(sorgu, connection);
            command.Parameters.AddWithValue("@İlanNo", Convert.ToInt32(textBox1.Text));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
         
            ilanSilVeyaGuncelle();
        }     

        private void button2_Click(object sender, EventArgs e)
        {           
            
            SqlCommand command = new SqlCommand("UPDATE İlan SET KonutDurum=@KonutDurum, Fiyat=@Fiyat WHERE İlanNo = @İlanNo", connection);
            command.Parameters.AddWithValue("@İlanNo", textBox1.Text);
            command.Parameters.AddWithValue("@KonutDurum", comboBox1.Text);
            command.Parameters.AddWithValue("@Fiyat", Convert.ToInt32(textBox7.Text));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            ilanSilVeyaGuncelle();           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form1"].Show();
            this.Hide();
        }
    }
}
