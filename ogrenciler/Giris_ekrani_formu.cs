using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ogrenciler
{
    public partial class Giris_ekrani_formu : Form
    {
        public Giris_ekrani_formu()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=Database1.mdb");


        private void Giris_ekrani_formu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "SELECT * FROM kullanicilar WHERE kullanici = '"+textBox1.Text+"' AND parola='"+textBox2.Text+"'";

            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            
            OleDbDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Kullanıcı adı veya parola yanlış");


            baglanti.Close();
        }
    }
}
