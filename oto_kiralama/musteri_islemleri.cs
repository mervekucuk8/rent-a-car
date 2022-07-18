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
    public partial class musteri_islemleri : Form
    {
        string vv01_str_veritabani_yolu = @"Data Source=DESKTOP-E73DNUQ;Initial Catalog=vtb_01_oto_kiralama;Integrated Security=True";
        string vv02_str_komut_yazisi = "";
        SqlConnection vv03_con_baglanti1;
        SqlCommand vv04_cmd_komut1;
        SqlDataReader vv05_rdr_okuyucu1;
        SqlDataAdapter vv06_adp_adaptor1;
        DataTable vv07_tbl_tablo1;

        int ii01_id_tutucu = -1;

        public musteri_islemleri()
        {
            InitializeComponent();
        }

       

        private void musteri_islemleri_Load(object sender, EventArgs e)
        {
            mm02_musteri_DataGridDoldur();
        }

        public void mm02_musteri_DataGridDoldur()//datagrid doldur.
        {
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
                  "musteri_09_ticari_unvan as [MESLEK]," +
                  "musteri_10_ehliyet_no as [EHLİYET NO]"+
                  " from tbl_musteri_islemleri" +
                  " order by musteri_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);

            dataGridView1.DataSource = vv07_tbl_tablo1;

        }

        private void button2_Click(object sender, EventArgs e)//kaydet
        {
            ssmusteri_islemi aa = new ssmusteri_islemi();

            aa.musteri_01_ad_str= bbmusteri_01_ad_str_textBox.Text;
            aa.musteri_02_soyad_str = bbmusteri_02_soyad_str_textBox.Text;
            aa.musteri_03_tc_str = bbmusteri_03_tc_int_textBox.Text;
            aa.musteri_04_telefon_str = bbmusteri_04_telefon_int_textBox.Text;
            aa.musteri_05_adres_str = bbmusteri_05_adres_str_textBox.Text;
            aa.musteri_06_dtarih_dtm = Convert.ToDateTime(bbmusteri_06_dtarih_dtm_dateTimePicker.Value);
            aa.musteri_07_ehliyet_turu_str = bbmusteri_07_ehliyet_turu_str_textBox.Text;
            aa.musteri_08_cinsiyet_str = bbmusteri_08_cinsiyet_str_comboBox.Text;
            aa.musteri_09_ticari_unvan_str = bbmusteri_09_ticari_unvan_str_textBox.Text;
            aa.musteri_10_ehliyet_no_int = Convert.ToInt32(bbmusteri_10_ehliyet_no_int_textBox.Text);


            vv02_str_komut_yazisi = "insert into tbl_musteri_islemleri(" +
                  "musteri_01_ad," +
                  "musteri_02_soyad," +
                  "musteri_03_tc," +
                  "musteri_04_telefon," +
                  "musteri_05_adres," +
                  "musteri_06_dtarih," +
                  "musteri_07_ehliyet_turu," +
                  "musteri_08_cinsiyet," +
                  "musteri_09_ticari_unvan," +
                  "musteri_10_ehliyet_no " +
                  ")" +
                  " values (" +
                  "@musteri_01_ad," +
                  "@musteri_02_soyad," +
                  "@musteri_03_tc," +
                  "@musteri_04_telefon," +
                  "@musteri_05_adres," +
                  "@musteri_06_dtarih," +
                  "@musteri_07_ehliyet_turu," +
                  "@musteri_08_cinsiyet," +
                  "@musteri_09_ticari_unvan," +
                  "@musteri_10_ehliyet_no " +
                  ")";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_01_ad", aa.musteri_01_ad_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_02_soyad", aa.musteri_02_soyad_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_03_tc", aa.musteri_03_tc_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_04_telefon", aa.musteri_04_telefon_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_05_adres", aa.musteri_05_adres_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_06_dtarih", aa.musteri_06_dtarih_dtm);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_07_ehliyet_turu", aa.musteri_07_ehliyet_turu_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_08_cinsiyet", aa.musteri_08_cinsiyet_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_09_ticari_unvan", aa.musteri_09_ticari_unvan_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_10_ehliyet_no", aa.musteri_10_ehliyet_no_int);
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            mm02_musteri_DataGridDoldur();

        }

        private void button3_Click(object sender, EventArgs e)//sil
        {
            ssmusteri_islemi aa = new ssmusteri_islemi();

            aa.musteri_01_ad_str = bbmusteri_01_ad_str_textBox.Text;
            aa.musteri_02_soyad_str = bbmusteri_02_soyad_str_textBox.Text;
            aa.musteri_03_tc_str = bbmusteri_03_tc_int_textBox.Text;
            aa.musteri_04_telefon_str = bbmusteri_04_telefon_int_textBox.Text;
            aa.musteri_05_adres_str = bbmusteri_05_adres_str_textBox.Text;
            aa.musteri_06_dtarih_dtm = Convert.ToDateTime(bbmusteri_06_dtarih_dtm_dateTimePicker.Value);
            aa.musteri_07_ehliyet_turu_str = bbmusteri_07_ehliyet_turu_str_textBox.Text;
            aa.musteri_08_cinsiyet_str = bbmusteri_08_cinsiyet_str_comboBox.Text;
            aa.musteri_09_ticari_unvan_str = bbmusteri_09_ticari_unvan_str_textBox.Text;
            aa.musteri_10_ehliyet_no_int = Convert.ToInt32(bbmusteri_10_ehliyet_no_int_textBox.Text);


            vv02_str_komut_yazisi = "delete from tbl_musteri_islemleri " +
                  "where musteri_00_id=@musteri_00_id";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_00_id", ii01_id_tutucu);
            
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            mm02_musteri_DataGridDoldur();
        }

        private void button4_Click(object sender, EventArgs e)//düzenle
        {
            ssmusteri_islemi aa = new ssmusteri_islemi();

            aa.musteri_01_ad_str = bbmusteri_01_ad_str_textBox.Text;
            aa.musteri_02_soyad_str = bbmusteri_02_soyad_str_textBox.Text;
            aa.musteri_03_tc_str = bbmusteri_03_tc_int_textBox.Text;
            aa.musteri_04_telefon_str = bbmusteri_04_telefon_int_textBox.Text;
            aa.musteri_05_adres_str = bbmusteri_05_adres_str_textBox.Text;
            aa.musteri_06_dtarih_dtm = Convert.ToDateTime(bbmusteri_06_dtarih_dtm_dateTimePicker.Value);
            aa.musteri_07_ehliyet_turu_str = bbmusteri_07_ehliyet_turu_str_textBox.Text;
            aa.musteri_08_cinsiyet_str = bbmusteri_08_cinsiyet_str_comboBox.Text;
            aa.musteri_09_ticari_unvan_str = bbmusteri_09_ticari_unvan_str_textBox.Text;
            aa.musteri_10_ehliyet_no_int = Convert.ToInt32(bbmusteri_10_ehliyet_no_int_textBox.Text);


            vv02_str_komut_yazisi = " update tbl_musteri_islemleri set " +
                  "musteri_01_ad=@musteri_01_ad," +
                  "musteri_02_soyad=@musteri_02_soyad," +
                  "musteri_03_tc=@musteri_03_tc," +
                  "musteri_04_telefon=@musteri_04_telefon," +
                  "musteri_05_adres=@musteri_05_adres," +
                  "musteri_06_dtarih=@musteri_06_dtarih," +
                  "musteri_07_ehliyet_turu=@musteri_07_ehliyet_turu," +
                  "musteri_08_cinsiyet=@musteri_08_cinsiyet," +
                  "musteri_09_ticari_unvan=@musteri_09_ticari_unvan," +
                  "musteri_10_ehliyet_no=@musteri_10_ehliyet_no " +
                  " where musteri_00_id=@musteri_00_id";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_01_ad", aa.musteri_01_ad_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_02_soyad", aa.musteri_02_soyad_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_03_tc", aa.musteri_03_tc_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_04_telefon", aa.musteri_04_telefon_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_05_adres", aa.musteri_05_adres_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_06_dtarih", aa.musteri_06_dtarih_dtm);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_07_ehliyet_turu", aa.musteri_07_ehliyet_turu_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_08_cinsiyet", aa.musteri_08_cinsiyet_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_09_ticari_unvan", aa.musteri_09_ticari_unvan_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_10_ehliyet_no", aa.musteri_10_ehliyet_no_int);

            vv04_cmd_komut1.Parameters.AddWithValue("@musteri_00_id ", ii01_id_tutucu);

            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            mm02_musteri_DataGridDoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ii01_id_tutucu = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString());
            ssmusteri_islemi aa = new ssmusteri_islemi();
            aa.musteri_01_ad_str = dataGridView1[1, e.RowIndex].Value.ToString();
            aa.musteri_02_soyad_str = dataGridView1[2, e.RowIndex].Value.ToString();
            aa.musteri_03_tc_str = dataGridView1[3, e.RowIndex].Value.ToString();
            aa.musteri_04_telefon_str = dataGridView1[4, e.RowIndex].Value.ToString();
            aa.musteri_05_adres_str = dataGridView1[5, e.RowIndex].Value.ToString();
            aa.musteri_06_dtarih_dtm = Convert.ToDateTime(dataGridView1[6, e.RowIndex].Value.ToString());
            aa.musteri_07_ehliyet_turu_str = dataGridView1[7, e.RowIndex].Value.ToString();
            aa.musteri_08_cinsiyet_str = dataGridView1[8, e.RowIndex].Value.ToString();
            aa.musteri_09_ticari_unvan_str = dataGridView1[9, e.RowIndex].Value.ToString();
            aa.musteri_10_ehliyet_no_int =Convert.ToInt32(dataGridView1[10, e.RowIndex].Value.ToString());



            bbmusteri_01_ad_str_textBox.Text = aa.musteri_01_ad_str;
            bbmusteri_02_soyad_str_textBox.Text = aa.musteri_02_soyad_str;
            bbmusteri_03_tc_int_textBox.Text = aa.musteri_03_tc_str;
            bbmusteri_04_telefon_int_textBox.Text = aa.musteri_04_telefon_str;
            bbmusteri_05_adres_str_textBox.Text = aa.musteri_05_adres_str;
            bbmusteri_06_dtarih_dtm_dateTimePicker.Value = aa.musteri_06_dtarih_dtm;
            bbmusteri_07_ehliyet_turu_str_textBox.Text = aa.musteri_07_ehliyet_turu_str;
            bbmusteri_08_cinsiyet_str_comboBox.Text = aa.musteri_08_cinsiyet_str;
            bbmusteri_09_ticari_unvan_str_textBox.Text = aa.musteri_09_ticari_unvan_str;
            bbmusteri_10_ehliyet_no_int_textBox.Text =Convert.ToString(aa.musteri_10_ehliyet_no_int);

        }

        private void menüyeDönToolStripMenuItem_Click(object sender, EventArgs e)//menüye dön
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

       
    }
}
