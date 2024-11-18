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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=BUKET\SQLEXPRESS;Initial Catalog=dbSatisVT;Integrated Security=True;Encrypt=False");

        void Listele()
        {
            SqlCommand komut = new SqlCommand("select * from TBLMUSTERİ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);  
            DataTable dt = new DataTable();
            da.Fill(dt);    
            dataGridView1.DataSource = dt;
        }
        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            Listele();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from TBLSEHIR", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while(dr.Read())
            {
                CmbSehir.Items.Add(dr["SEHİRAD"]);
            }
            baglanti.Close();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();

        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            txtMusteriID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMusteriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMusteriSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMusteriBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void txtMusteriSehir_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBLMUSTERİ (MUSTERİAD, MUSTERİSOYAD, MUSTERİSEHİR, MUSTERİBAKİYE) values (@p1,@p2,@p3,@p4)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtMusteriAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtMusteriSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut2.Parameters.AddWithValue("@p4", decimal.Parse(txtMusteriBakiye.Text));

            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Sisteme Kaydedildi..");
            Listele();
        }

        private SqlCommand SqlCommand(string v, SqlConnection baglanti)
        {
            throw new NotImplementedException();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from TBLMUSTERİ where MUSTERİID=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtMusteriID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close() ;
            MessageBox.Show("Müşteri Silini..");
            Listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update TBLMUSTERİ set MUSTERİAD = @p1, MUSTERİSOYAD = @p2, MUSTERİSEHİR = @p3, MUSTERİBAKİYE = @p4 where MusteriID = @id", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtMusteriAd.Text);
            komut4.Parameters.AddWithValue("@p2", txtMusteriSoyad.Text);
            komut4.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut4.Parameters.AddWithValue("@p4", decimal.Parse(txtMusteriBakiye.Text));
            komut4.Parameters.AddWithValue("@id", int.Parse(txtMusteriID.Text)); // Güncelleme için bir ID belirleyin

            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Güncellendi..");
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut5 = new SqlCommand("select * from TBLMUSTERİ where MUSTERİAD=@p1", baglanti);
            komut5.Parameters.AddWithValue("@p1", txtMusteriAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut5);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
