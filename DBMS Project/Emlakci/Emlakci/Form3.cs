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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source = LAPTOP-1NBIHC2E; Initial Catalog = EmlakDB; Integrated Security = True");

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form2"].Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();                
                string query = "SELECT *FROM Kullanıcı WHERE KullanıcıAdı = @KullanıcıAdı AND Şifre = @Şifre";               
                SqlParameter prm1 = new SqlParameter("@KullanıcıAdı", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("@Şifre", textBox2.Text.Trim());
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(prm1);
                command.Parameters.Add(prm2);
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);                

                if (dataTable.Rows.Count > 0)
                {
                    Form1 f1 = new Form1();
                    this.Hide();
                    f1.Show();
                }
            }
            
            catch(Exception)
            {
                MessageBox.Show("Hatalı Giriş! Bilgilerinizi Kontrol Edin!");               

            }           
        }
    }
}

