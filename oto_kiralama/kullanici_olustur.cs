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
    public partial class kullanici_olustur : Form
    {
        string vv01_str_veritabani_yolu = @"Data Source=DESKTOP-E73DNUQ;Initial Catalog=vtb_01_oto_kiralama;Integrated Security=True";
        string vv02_str_komut_yazisi = "";
        SqlConnection vv03_con_baglanti1;
        SqlCommand vv04_cmd_komut1;
        SqlDataReader vv05_rdr_okuyucu1;
        SqlDataAdapter vv06_adp_adaptor1;
        DataTable vv07_tbl_tablo1;
        
        public kullanici_olustur()
        {
            InitializeComponent();
        }

        private void kullanici_olustur_Load(object sender, EventArgs e)
        {
            mm01_kullanici_olustur_DataGridDoldur();
            bbkullaniciolustır_02_sifre_str_textBox.PasswordChar = '*';
        }

        public void mm01_kullanici_olustur_DataGridDoldur()//datagrid doldur.
        {
               vv02_str_komut_yazisi = "select " +
              "kullaniciadi  ," +
              "sifre " +

            " from tbl_kullanici_olustur" +
             " order by kullaniciadi ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);
        }

        private void button1_Click(object sender, EventArgs e)//kaydet
        {
            //sql komutumuzu yazdık komutta veritabanındaki giris tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyiçekmesini istedik.
            SqlCommand vv04_cmd_komut1 = new SqlCommand("select * from tbl_kullanici_olustur where kullaniciadi='" + bbkullaniciolustır_01_adi_str_textBox.Text + "' and sifre ='" + bbkullaniciolustır_02_sifre_str_textBox.Text + "'", vv03_con_baglanti1);

            vv03_con_baglanti1.Open();//bağlantıyı açdık

            SqlDataReader vv05_rdr_okuyucu1 = vv04_cmd_komut1.ExecuteReader();//veriyi okutma emrini verdik
            if (vv05_rdr_okuyucu1.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                MessageBox.Show("Kullanıcı Zaten Kayıtlı.");   
            }
            else
            {
                sskullanici_olustur aa = new sskullanici_olustur();
                aa.kullanici_00_olustur_str =bbkullaniciolustır_01_adi_str_textBox.Text;
                aa.kullanici_01_sifre_str = bbkullaniciolustır_02_sifre_str_textBox.Text;

                vv02_str_komut_yazisi = "insert into tbl_kullanici_olustur(" +
                    "kullaniciadi," +
                    "sifre " +
                    ")" +
                    " values(" +
                    "@kullaniciadi," +
                    "@sifre" +
                   ")";

                vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
                vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

                vv04_cmd_komut1.Parameters.AddWithValue("@kullaniciadi", aa.kullanici_00_olustur_str);
                vv04_cmd_komut1.Parameters.AddWithValue("@sifre", aa.kullanici_01_sifre_str);
                vv03_con_baglanti1.Open();
                vv04_cmd_komut1.ExecuteNonQuery();
                vv04_cmd_komut1.Dispose();
                vv03_con_baglanti1.Close();
 
                MessageBox.Show("Kullanıcı Kayıt Edildi.");
                bbkullaniciolustır_01_adi_str_textBox.Text = "";
                bbkullaniciolustır_02_sifre_str_textBox.Text = "";
                mm01_kullanici_olustur_DataGridDoldur();
            }
        }

        private void gGToolStripMenuItem_Click(object sender, EventArgs e)//girişe dön.
        {
            giris_ekranı giris = new giris_ekranı();
            giris.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)//sil
        {
            sskullanici_olustur aa = new sskullanici_olustur();
            aa.kullanici_00_olustur_str = bbkullaniciolustır_01_adi_str_textBox.Text;
            aa.kullanici_01_sifre_str = bbkullaniciolustır_02_sifre_str_textBox.Text;

            vv02_str_komut_yazisi = "delete from tbl_kullanici_olustur" +
                " where kullaniciadi=@kullaniciadi ";


            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv04_cmd_komut1.Parameters.AddWithValue("@kullaniciadi", aa.kullanici_00_olustur_str);
           

            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();

            MessageBox.Show("Kullanıcı Silindi.");
            bbkullaniciolustır_01_adi_str_textBox.Text = "";
            bbkullaniciolustır_02_sifre_str_textBox.Text = "";
            mm01_kullanici_olustur_DataGridDoldur();
        }

        
    }
}
