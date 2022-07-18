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
    struct ssaraba_islemi
    {     
        public int aaraba_00_id_int;
        public string aaraba_01_marka_str;
        public string aaraba_02_model_str;
        public string aaraba_03_plaka_str;
        public string aaraba_04_yakıt_turu_str;
        public string aaraba_05_renk_str;
        public string aaraba_06_km_str;
        public DateTime aaraba_07_bakim_tarihi_dtm;
        public DateTime aaraba_08_gelecek_bakim_dtm;
        public string aaraba_09_vites_turu_str;
        public string araba_10_yil_str;
    }

    struct ssmusteri_islemi
    {
        public int musteri_00_id_int;
        public string musteri_01_ad_str;
        public string musteri_02_soyad_str;
        public string musteri_03_tc_str;
        public string musteri_04_telefon_str;
        public string musteri_05_adres_str;
        public DateTime musteri_06_dtarih_dtm;
        public string musteri_07_ehliyet_turu_str;
        public string musteri_08_cinsiyet_str;
        public string musteri_09_ticari_unvan_str;
        public int musteri_10_ehliyet_no_int;
    }

    struct ssarac_kirala
    { 
        public int kiralama_00_id_int;
        public string kiralama_01_musteri_tc_str;
        public string kiralama_02_musteri_ad_str;
        public string kiralama_03_arac_plaka_str;
        public string kiralama_04_arac_marka_str;
        public DateTime kiralama_05_veris_tarihi_dtm;
        public DateTime kiralama_06_alis_tarihi_dtm;
        public int kiralama_07_ucret_int;
        public int kiralama_08_ek_ucret_int;
        public int kiralama_09_toplam_ucret_int;
        public int kiralama_10_vrldg_km_int;  
    }

    struct ssarac_teslim
    {
        public int teslim_00_id_int;
        public string teslim_01_arac_plaka_str;
        public string teslim_02_alındıgı_km_str;
 
    }
    struct sskullanici_olustur
    {    
        public string kullanici_00_olustur_str;
        public string kullanici_01_sifre_str;
    }

    public partial class giris_ekranı : Form
    {
        public giris_ekranı()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

                                                                   
        {
            SqlConnection vv03_con_baglanti1 = new SqlConnection(@"Data Source=DESKTOP-E73DNUQ;Initial Catalog=vtb_01_oto_kiralama;Integrated Security=True");
            //sql bağlantıyı sağladık
            SqlCommand vv04_cmd_komut1 = new SqlCommand("select * from tbl_kullanici_olustur where kullaniciadi='" + textBox1.Text + "' and sifre ='" + textBox2.Text + "'", vv03_con_baglanti1);
            //sql komutumuzu yazdık komutta veritabanındaki giris tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            vv03_con_baglanti1.Open();//bağlantıyı açdık

            SqlDataReader vv05_rdr_okuyucu1 = vv04_cmd_komut1.ExecuteReader();//veriyi okutma emrini verdik
            if (vv05_rdr_okuyucu1.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                MessageBox.Show("Giriş Başarılı !");//giriş başarılı diye uyari verir
                vv03_con_baglanti1.Close();//bağlantıyı kapar
                menu menuu = new menu();
                menuu.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış !");//hayır veri okuyamadıysa uyarı verir
                textBox1.Text = "";//verileri temizler
                textBox2.Text = "";//verileri temizler

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ana_form_Load(object sender, EventArgs e)
        {

            textBox2.PasswordChar = '*';
                                                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kullanici_olustur menu = new kullanici_olustur();//yeni bir menü sayfası oluşturur.
            menu.Show();//menü sayfasını açar.
            this.Hide();//mevcut sayfayı kapatır.
        }

    }
}
