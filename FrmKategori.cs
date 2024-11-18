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

namespace SQL_SatisDB
{
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {

        }
        //Global alan
        SqlConnection baglanti = new SqlConnection(@"Data Source=BUKET\SQLEXPRESS;Initial Catalog=dbSatisVT;Integrated Security=True;Encrypt=False");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TBLKATEGORİ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut); //verileri bellek tarafına bağlamak için kullanılacak
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, System.EventArgs e)
        {
           
        }

        private void txtKategoriID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            txtKategoriID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBLKATEGORİ (KATEGORİAD) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori kaydetme işlemi başarıyla tamamlandı..");
        }

        private void dataGridView1_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from TBLKATEGORİ where KATEGORİID=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtKategoriID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori silme işlemi başarıyla tamamlandı.."); 
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update TBLKATEGORİ set KATEGORİAD=@p1 where KATEGORİAD=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komut4.Parameters.AddWithValue("@p2", txtKategoriID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori güncelleme işlemi başarıyla tamamlandı..");

        }

        private void FrmKategori_Load(object sender, EventArgs e)
        {

        }
    }
}
//Data Source=BUKET\SQLEXPRESS;Initial Catalog=dbSatisVT;Integrated Security=True;Encrypt=False
