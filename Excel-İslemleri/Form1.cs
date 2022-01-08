using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Excel_İslemleri
{
    public partial class Excel : Form
    {
        public Excel()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ömer Alper Güneş\Desktop\SinavProgrami1.xlsx;Extended Properties='Excel 8.0; HDR=YES;'");
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from [Sayfa1$]", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into [Sayfa1$] (Saat,Ders) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtSaat.Text);
            komut.Parameters.AddWithValue("@p2", TxtDers.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydetme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

      
    }
}
