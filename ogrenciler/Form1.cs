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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=Database1.mdb;Jet OLEDB:Database Password=mustafaBilisim;");

        public void veriGoster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter adpt = new OleDbDataAdapter("SELECT * FROM ogrenciler", baglanti);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                dataGridView1.DataSource = dt;
                baglanti.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oldu");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
	        {	        
                int ogr_no = Convert.ToInt32(textBox1.Text);
                string ad = textBox2.Text;
                string soyad = textBox3.Text;
                string bolum = comboBox1.Text;
                string sinif;

                if (radioButton1.Checked) sinif = "9";
                else if (radioButton2.Checked) sinif = "10";
                else if (radioButton3.Checked) sinif = "11";
                else if (radioButton4.Checked) sinif = "12";
                else sinif = "0";

                string sorgu = "INSERT INTO ogrenciler VALUES (" + ogr_no + ",'" + ad+ "','" + soyad + "','" + sinif + "','" + bolum + "')";

                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                
        	 }
	        catch (Exception)
	        {
                MessageBox.Show("Beklenmeyen bir hata oldu");
            }
            veriGoster();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            veriGoster();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "9")
                radioButton1.Checked = true;
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "10")
                radioButton2.Checked = true;
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "11")
                radioButton3.Checked = true;
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "12")
                radioButton4.Checked = true;
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }

            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ogr_no = Convert.ToInt32(textBox1.Text);
            string ad = textBox2.Text;
            string soyad = textBox3.Text;
            string bolum = comboBox1.Text;
            string sinif;

            if (radioButton1.Checked) sinif = "9";
            else if (radioButton2.Checked) sinif = "10";
            else if (radioButton3.Checked) sinif = "11";
            else if (radioButton4.Checked) sinif = "12";
            else sinif = "0";

            string sorgu = "UPDATE ogrenciler SET ad = '" + ad + "', soyad = '" + soyad + "', bolum ='"+bolum+"',sinif='"+sinif+"' WHERE ogr_no = " + ogr_no;

            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            button3.Enabled = false;
            veriGoster();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "DELETE FROM ogrenciler WHERE ogr_no = " + textBox1.Text;
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            
            komut.ExecuteNonQuery();
            baglanti.Close();

            veriGoster();
        }
    }
}
