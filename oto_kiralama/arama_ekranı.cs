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

namespace oto_kiralama
{
    public partial class arama_ekranı : Form
    {
        string vv01_str_veritabani_yolu = @"Data Source=DESKTOP-E73DNUQ;Initial Catalog=vtb_01_oto_kiralama;Integrated Security=True";
        string vv02_str_komut_yazisi = "";
        SqlConnection vv03_con_baglanti1;
        SqlCommand vv04_cmd_komut1;
        SqlDataReader vv05_rdr_okuyucu1;
        SqlDataAdapter vv06_adp_adaptor1;
        DataTable vv07_tbl_tablo1;

        int ii01_id_tutucu = -1;
        public arama_ekranı()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)//tc ye  göre
        {
            string arama_musteritc = textBox1.Text;

            vv02_str_komut_yazisi= "select " +
                 "musteri_00_id as [İD]," +
                  "musteri_01_ad as [AD]," +
                  "musteri_02_soyad as [SOYAD]," +
                  "musteri_03_tc as [TC]," +
                  "musteri_04_telefon as [TELEFON]," +
                  "musteri_05_adres as [ADRES]," +
                  "musteri_06_dtarih as [DOĞUM TARİHİ]," +
                  "musteri_07_ehliyet_turu as [EHLİYET TİPİ]," +
                  "musteri_08_cinsiyet as [CİNSİYET]," +
                  "musteri_09_ticari_unvan as [TİCARİ UNVAN]," +
                  "musteri_10_ehliyet_no as [EHLİYET NO]" +
                  " from tbl_musteri_islemleri" +
                  " where musteri_03_tc like'%" + arama_musteritc + "%' " +
                  " order by musteri_00_id ";


            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_03_tc", arama_musteritc);

            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);

            dataGridView1.DataSource = vv07_tbl_tablo1;
        }

        private void button4_Click(object sender, EventArgs e)//plakaya göre
        {
            string plaka_ara = textBox3.Text;

           vv02_str_komut_yazisi= "select " +
                "araba_00_id as [İD]," +
                "araba_01_marka as [MARKA]," +
                "araba_02_model as [MODEL]," +
                "araba_03_plaka as [PLAKA]," +
                "araba_04_yakıt_turu as [YAKIT TÜRÜ]," +
                "araba_05_renk as [RENK]," +
                "araba_06_km as [KM]," +
                "araba_07_bakim_tarihi as [BAKIM TARİHİ]," +
                "araba_08_gelecek_bakim as [GELECEK BAKIM TARİHİ]," +
                "araba_09_vites_turu as [VİTES TÜRÜ]," +
                "araba_10_yil as [YIL] ," +
                "araba_11_durum as [DURUM] " +
                "  from tbl_arac_islemleri" +
                 " where araba_03_plaka like'%" + plaka_ara + "%' " +
                " order by araba_00_id ";

           

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv04_cmd_komut1.Parameters.AddWithValue("@araba_03_plaka", plaka_ara);


            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);
            dataGridView1.DataSource = vv07_tbl_tablo1;

        }

       

        private void button3_Click(object sender, EventArgs e)//kira durumuna göre
        {
            string durum_ara = textBox2.Text;

            vv02_str_komut_yazisi = "select " +
                "araba_00_id as [İD]," +
                "araba_01_marka as [MARKA]," +
                "araba_02_model as [MODEL]," +
                "araba_03_plaka as [PLAKA]," +
                "araba_04_yakıt_turu as [YAKIT TÜRÜ]," +
                "araba_05_renk as [RENK]," +
                "araba_06_km as [KM]," +
                "araba_07_bakim_tarihi as [BAKIM TARİHİ]," +
                "araba_08_gelecek_bakim as [GELECEK BAKIM TARİHİ]," +
                "araba_09_vites_turu as [VİTES TÜRÜ]," +
                "araba_10_yil as [YIL] ," +
                "araba_11_durum as [DURUM] " +
                "  from tbl_arac_islemleri" +
                " where araba_11_durum like'%" + durum_ara + "%' " +
                " order by araba_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv04_cmd_komut1.Parameters.AddWithValue("@araba_11_durum", durum_ara);


            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);
            dataGridView1.DataSource = vv07_tbl_tablo1;
        }

        private void öncekiEkranaGeriDönToolStripMenuItem_Click(object sender, EventArgs e)//önceki ekrana geri dön
        {
            arac_kiralama_islemi kiralama = new arac_kiralama_islemi();
            kiralama.Show();
            this.Hide();
        }

        private void aramayıTemizleToolStripMenuItem_Click(object sender, EventArgs e)//aramayı temizle
        {
            vv07_tbl_tablo1.Rows.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)//Müşteri adına göre arama
        {
            string arama_musteriad = textBox4.Text;

            vv02_str_komut_yazisi = "select " +
                "musteri_00_id as [İD]," +
                 "musteri_01_ad as [AD]," +
                 "musteri_02_soyad as [SOYAD]," +
                 "musteri_03_tc as [TC]," +
                 "musteri_04_telefon as [TELEFON]," +
                 "musteri_05_adres as [ADRES]," +
                 "musteri_06_dtarih as [DOĞUM TARİHİ]," +
                 "musteri_07_ehliyet_turu as [EHLİYET TİPİ]," +
                 "musteri_08_cinsiyet as [CİNSİYET]," +
                 "musteri_09_ticari_unvan as [TİCARİ UNVAN]," +
                 "musteri_10_ehliyet_no as [EHLİYET NO]" +
                 " from tbl_musteri_islemleri" +
                 " where musteri_01_ad like'%" + arama_musteriad + "%' " +
                 " order by musteri_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);

            dataGridView1.DataSource = vv07_tbl_tablo1;
        }

        
    }
}
