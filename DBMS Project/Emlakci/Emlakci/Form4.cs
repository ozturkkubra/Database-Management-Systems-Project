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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form1"].Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();

            connection = new SqlConnection("Data Source = LAPTOP-1NBIHC2E; Initial Catalog = EmlakDB; Integrated Security = True");
            string query = "INSERT INTO İlan(KonutDurum,İl,İlçe,Adres,KonutTipi,OdaSayısı,Fiyat,Metrekare) VALUES (@KonutDurum,@İl,@İlçe,@Adres,@KonutTipi,@OdaSayısı,@Fiyat,@Metrekare)";            
            command = new SqlCommand(query, connection);            
            string konutDurum = "";
            if (radioButton1.Checked)
                konutDurum = radioButton1.Text;
            else if (radioButton2.Checked)
                 konutDurum = radioButton2.Text;
            command.Parameters.AddWithValue("@KonutDurum",konutDurum);
            command.Parameters.AddWithValue("@İl", comboBox1.Text);
            command.Parameters.AddWithValue("@İlçe", comboBox2.Text);
            command.Parameters.AddWithValue("@Adres", textBox1.Text);
            string konutTipi = "";
            if (radioButton3.Checked)
                konutTipi = radioButton3.Text;
            else if (radioButton4.Checked)
                konutTipi = radioButton4.Text;
            else if (radioButton5.Checked)
                konutTipi = radioButton5.Text;
            else if (radioButton6.Checked)
                konutTipi = radioButton6.Text;
            else if (radioButton7.Checked)
                konutTipi = radioButton7.Text;
            command.Parameters.AddWithValue("@KonutTipi", konutTipi);
            string odaSayısı = "";
            if (radioButton8.Checked)
                odaSayısı = radioButton8.Text;
            else if (radioButton9.Checked)
                odaSayısı = radioButton9.Text;
            else if (radioButton10.Checked)
                odaSayısı = radioButton10.Text;
            else if (radioButton11.Checked)
                odaSayısı = radioButton11.Text;
            else if (radioButton12.Checked)
                odaSayısı = radioButton12.Text;
            command.Parameters.AddWithValue("@OdaSayısı", odaSayısı);
            command.Parameters.AddWithValue("@Fiyat", textBox2.Text);
            command.Parameters.AddWithValue("@Metrekare", textBox3.Text);            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
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
