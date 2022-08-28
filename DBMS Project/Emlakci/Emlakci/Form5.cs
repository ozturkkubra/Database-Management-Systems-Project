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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form2"].Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();

            connection = new SqlConnection("Data Source = LAPTOP-1NBIHC2E; Initial Catalog = EmlakDB; Integrated Security = True");
            string query = "INSERT INTO Kullanıcı(Ad,Soyad,Telefon,KullanıcıAdı,Şifre) VALUES (@Ad,@Soyad,@Telefon,@KullanıcıAdı,@Şifre)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Ad", textBox1.Text);
            command.Parameters.AddWithValue("@Soyad", textBox2.Text);
            command.Parameters.AddWithValue("@Telefon", textBox3.Text);
            command.Parameters.AddWithValue("@KullanıcıAdı", textBox4.Text);
            command.Parameters.AddWithValue("@Şifre", textBox5.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            
        }
    }
    
}
