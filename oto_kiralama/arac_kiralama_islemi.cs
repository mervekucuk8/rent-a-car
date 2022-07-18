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
    public partial class arac_kiralama_islemi : Form
    {
        string vv01_str_veritabani_yolu = @"Data Source=DESKTOP-E73DNUQ;Initial Catalog=vtb_01_oto_kiralama;Integrated Security=True";
        string vv02_str_komut_yazisi = "";
        SqlConnection vv03_con_baglanti1;
        SqlCommand vv04_cmd_komut1;
        SqlDataReader vv05_rdr_okuyucu1;
        SqlDataAdapter vv06_adp_adaptor1;
        DataTable vv07_tbl_tablo1;

        int ii01_id_tutucu = -1;


        public arac_kiralama_islemi()
        {
            InitializeComponent();
        }

      
        private void arac_kiralama_islemi_Load(object sender, EventArgs e)
        {
            mm03_kiralama_DataGridDoldur();
            mm04_plaka_ComboDoldur();
            mm05_tc_ComboDoldur();
        }
        public void mm04_plaka_ComboDoldur()//plaka combo doldur.
        {
            //combo doldurma araç plaka  için
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1 = new SqlCommand("select araba_03_plaka" +
                " from tbl_arac_islemleri" +
                " where araba_11_durum='Uygun'", vv03_con_baglanti1);
            vv05_rdr_okuyucu1 = vv04_cmd_komut1.ExecuteReader();
            while (vv05_rdr_okuyucu1.Read())
            {
                bbkiralama_03_arac_plaka_str_comboBox.Items.Add(vv05_rdr_okuyucu1["araba_03_plaka"]);
            }

            vv03_con_baglanti1.Close();
        }
        public void mm05_tc_ComboDoldur()//tc combo doldur.
        {
            //combo doldurma musteri tc için
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1 = new SqlCommand("select musteri_03_tc" +
                " from tbl_musteri_islemleri", vv03_con_baglanti1);
            vv05_rdr_okuyucu1 = vv04_cmd_komut1.ExecuteReader();
            while (vv05_rdr_okuyucu1.Read())
            {
                bbkiralama_01_musteri_tc_int_comboBox.Items.Add(vv05_rdr_okuyucu1["musteri_03_tc"]);
            }
            bbkiralama_03_arac_plaka_str_comboBox.Refresh();
            vv03_con_baglanti1.Close();
            
        }

        public void mm03_kiralama_DataGridDoldur()//datagrid doldur.
        {
            

            vv02_str_komut_yazisi = "select " +
               "kiralama_00_id as[İD]," +
               "kiralama_01_musteri_tc as[MÜŞTERİ TC]," +
               "kiralama_02_musteri_ad as [MÜŞTERİ AD SOYAD]," +    
               "kiralama_03_arac_plaka as[ARAÇ PLAKA]," +
               "kiralama_04_arac_marka as [MARKA]," +
               "kiralama_05_veris_tarihi as[VERİLİŞ TARİHİ]," +
               "kiralama_06_alis_tarihi as[ALIŞ TARİHİ]," +
               "kiralama_07_ucret as[ÜCRET]," +
               "kiralama_08_ek_ucret as[EK ÜCRET]," +
               "kiralama_09_toplam_ucret as[TOPLAM ÜCRET]," +
               "kiralama_10_vrldg_km as[VERİLDİĞİ KM]" +  
               " from tbl_kiralama_islemi" +              
               " order by kiralama_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);

            dataGridView1.DataSource = vv07_tbl_tablo1;          
        }

        private void button2_Click(object sender, EventArgs e)//kaydet
        {
            ssarac_kirala aa = new ssarac_kirala();

            aa.kiralama_01_musteri_tc_str = bbkiralama_01_musteri_tc_int_comboBox.Text;
            aa.kiralama_02_musteri_ad_str = bbkiralama_02_musteri_ad_str_textBox.Text;
            aa.kiralama_03_arac_plaka_str = bbkiralama_03_arac_plaka_str_comboBox.Text;
            aa.kiralama_04_arac_marka_str = bbkiralama_04_arac_marka_str_textBox.Text;            
            aa.kiralama_05_veris_tarihi_dtm = Convert.ToDateTime(bbkiralama_05_veris_tarihi_dtm_dateTimePicker.Value);
            aa.kiralama_06_alis_tarihi_dtm = Convert.ToDateTime(bbkiralama_06_alis_tarihi_dtm_dateTimePicker.Value);
            aa.kiralama_07_ucret_int = Convert.ToInt32(bbkiralama_07_ucret_int_textBox.Text);
            aa.kiralama_08_ek_ucret_int = Convert.ToInt32(bbkiralama_08_ek_ucret_int_textBox.Text);
            aa.kiralama_09_toplam_ucret_int = Convert.ToInt32(bbkiralama_09_toplam_ucret_int_textBox.Text);
            aa.kiralama_10_vrldg_km_int = Convert.ToInt32(bbkiralama_10_vrldg_km_str_textBox.Text);
            
            

            vv02_str_komut_yazisi = " insert into tbl_kiralama_islemi(" +
                  "kiralama_01_musteri_tc,"+
                  "kiralama_02_musteri_ad," +
                  "kiralama_03_arac_plaka," +
                  "kiralama_04_arac_marka," +
                  "kiralama_05_veris_tarihi," +
                  "kiralama_06_alis_tarihi,"+
                  "kiralama_07_ucret,"+
                  "kiralama_08_ek_ucret,"+
                  "kiralama_09_toplam_ucret," +
                  "kiralama_10_vrldg_km" +
                  ")" +
                  " values (" +
                  "@kiralama_01_musteri_tc," +
                  "@kiralama_02_musteri_ad," +
                  "@kiralama_03_arac_plaka," +
                  "@kiralama_04_arac_marka," +
                  "@kiralama_05_veris_tarihi," +
                  "@kiralama_06_alis_tarihi," +
                  "@kiralama_07_ucret," +
                  "@kiralama_08_ek_ucret," +
                  "@kiralama_09_toplam_ucret," +
                  "@kiralama_10_vrldg_km" +     
                  ")";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_01_musteri_tc", aa.kiralama_01_musteri_tc_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_02_musteri_ad", aa.kiralama_02_musteri_ad_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_03_arac_plaka", aa.kiralama_03_arac_plaka_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_04_arac_marka", aa.kiralama_04_arac_marka_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_05_veris_tarihi", aa.kiralama_05_veris_tarihi_dtm);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_06_alis_tarihi", aa.kiralama_06_alis_tarihi_dtm);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_07_ucret", aa.kiralama_07_ucret_int);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_08_ek_ucret", aa.kiralama_08_ek_ucret_int);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_09_toplam_ucret", aa.kiralama_09_toplam_ucret_int);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_10_vrldg_km", aa.kiralama_10_vrldg_km_int);
            
           

            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            
            try
            {
                vv02_str_komut_yazisi = " update tbl_arac_islemleri set " +
                   "araba_11_durum=" + "'" + "Kirada" +
                   "'where araba_03_plaka='" + bbkiralama_03_arac_plaka_str_comboBox.Text + "' ";

                vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
                vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

                vv03_con_baglanti1.Open();
                vv04_cmd_komut1.ExecuteNonQuery();               
               
                uygunaracdoldur();
            }
            catch (Exception)
            {
                
            }
            
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            MessageBox.Show("Kiralama İşleminiz Başarılı");
            mm03_kiralama_DataGridDoldur();
        }

        
        private void uygunaracdoldur()
        {
            bbkiralama_03_arac_plaka_str_comboBox.Items.Clear();
            if (vv03_con_baglanti1.State == ConnectionState.Closed)
            {
                vv03_con_baglanti1.Open();
            }

            vv02_str_komut_yazisi = "select araba_03_plaka from tbl_arac_islemleri where araba_11_durum='" + "Uygun" + "'";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();       
           
            while (vv05_rdr_okuyucu1.Read())
            {
                bbkiralama_03_arac_plaka_str_comboBox.Items.Add(vv05_rdr_okuyucu1["araba_03_plaka"].ToString());
            }
           vv03_con_baglanti1.Close();
        }
        

        private void button3_Click(object sender, EventArgs e)//sil
        {
            ssarac_kirala aa = new ssarac_kirala();

            aa.kiralama_01_musteri_tc_str = bbkiralama_01_musteri_tc_int_comboBox.Text;
            aa.kiralama_02_musteri_ad_str = bbkiralama_02_musteri_ad_str_textBox.Text;
            aa.kiralama_03_arac_plaka_str = bbkiralama_03_arac_plaka_str_comboBox.Text;
            aa.kiralama_04_arac_marka_str = bbkiralama_04_arac_marka_str_textBox.Text;
            aa.kiralama_05_veris_tarihi_dtm = Convert.ToDateTime(bbkiralama_05_veris_tarihi_dtm_dateTimePicker.Value);
            aa.kiralama_06_alis_tarihi_dtm = Convert.ToDateTime(bbkiralama_06_alis_tarihi_dtm_dateTimePicker.Value);
            aa.kiralama_07_ucret_int = Convert.ToInt32(bbkiralama_07_ucret_int_textBox.Text);
            aa.kiralama_08_ek_ucret_int = Convert.ToInt32(bbkiralama_08_ek_ucret_int_textBox.Text);
            aa.kiralama_09_toplam_ucret_int = Convert.ToInt32(bbkiralama_09_toplam_ucret_int_textBox.Text);
            aa.kiralama_10_vrldg_km_int = Convert.ToInt32(bbkiralama_10_vrldg_km_str_textBox.Text);




            vv02_str_komut_yazisi = " delete from tbl_kiralama_islemi " +
                  " where kiralama_00_id=@kiralama_00_id";
                  
           

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@kiralama_00_id", ii01_id_tutucu);
     
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            mm03_kiralama_DataGridDoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//datagriddeki tüm verilerin seçilmesini akti etmek için yazılan kod
        {
            ii01_id_tutucu = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString());
            ssarac_kirala aa = new ssarac_kirala();
            aa.kiralama_01_musteri_tc_str = dataGridView1[1, e.RowIndex].Value.ToString();
            aa.kiralama_02_musteri_ad_str = dataGridView1[2, e.RowIndex].Value.ToString();
            aa.kiralama_03_arac_plaka_str = dataGridView1[3, e.RowIndex].Value.ToString();
            aa.kiralama_04_arac_marka_str = dataGridView1[4, e.RowIndex].Value.ToString();
            aa.kiralama_05_veris_tarihi_dtm = Convert.ToDateTime(dataGridView1[5, e.RowIndex].Value.ToString());
            aa.kiralama_06_alis_tarihi_dtm = Convert.ToDateTime(dataGridView1[6, e.RowIndex].Value.ToString());
            aa.kiralama_07_ucret_int = Convert.ToInt32(dataGridView1[7, e.RowIndex].Value.ToString());
            aa.kiralama_08_ek_ucret_int = Convert.ToInt32(dataGridView1[8, e.RowIndex].Value.ToString());
            aa.kiralama_09_toplam_ucret_int = Convert.ToInt32(dataGridView1[9, e.RowIndex].Value.ToString());
            aa.kiralama_10_vrldg_km_int = Convert.ToInt32(dataGridView1[10, e.RowIndex].Value.ToString());
            
   

            bbkiralama_01_musteri_tc_int_comboBox.Text = aa.kiralama_01_musteri_tc_str;
            bbkiralama_02_musteri_ad_str_textBox.Text = aa.kiralama_02_musteri_ad_str;
            bbkiralama_03_arac_plaka_str_comboBox.Text = aa.kiralama_03_arac_plaka_str;
            bbkiralama_04_arac_marka_str_textBox.Text = aa.kiralama_04_arac_marka_str;
            bbkiralama_05_veris_tarihi_dtm_dateTimePicker.Value = aa.kiralama_05_veris_tarihi_dtm;
            bbkiralama_06_alis_tarihi_dtm_dateTimePicker.Value = aa.kiralama_06_alis_tarihi_dtm;
            bbkiralama_07_ucret_int_textBox.Text = Convert.ToString(aa.kiralama_07_ucret_int);
            bbkiralama_08_ek_ucret_int_textBox.Text = Convert.ToString(aa.kiralama_08_ek_ucret_int);
            bbkiralama_09_toplam_ucret_int_textBox.Text = Convert.ToString(aa.kiralama_09_toplam_ucret_int);
            bbkiralama_10_vrldg_km_str_textBox.Text = Convert.ToString(aa.kiralama_10_vrldg_km_int);
     
        }
        
 
        private void aRAMAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            arama_ekranı arama = new arama_ekranı();
            arama.Show();
            this.Hide();
        }

        private void kİRASÖZLEŞMESİToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kira_sözleşme sözlesme = new kira_sözleşme();
            sözlesme.Show();
            this.Hide();
        }

        private void bbkiralama_04_alis_tarihi_dtm_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {       
            try
            {
                DateTime dt1 = DateTime.Parse(bbkiralama_05_veris_tarihi_dtm_dateTimePicker.Text);
                DateTime dt2 = DateTime.Parse(bbkiralama_06_alis_tarihi_dtm_dateTimePicker.Text);
                TimeSpan fark = dt2 - dt1;
                bbkiralama_07_ucret_int_textBox.Text = (fark.TotalDays * 200).ToString();

            }
            catch
            {
                ;
            }
        }

        private void menüyeDönToolStripMenuItem_Click(object sender, EventArgs e)//menüye dön
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void bbkiralama_01_musteri_tc_int_comboBox_SelectedIndexChanged(object sender, EventArgs e)//müşteri tcsi sseçilen kişisin adını ve soyadını textboxta vermek
        {
            vv04_cmd_komut1 = new SqlCommand("select musteri_01_ad,musteri_02_soyad" +
                " from tbl_musteri_islemleri"+                
                " where musteri_03_tc="+"'" + bbkiralama_01_musteri_tc_int_comboBox.SelectedItem.ToString() + "' ", vv03_con_baglanti1);
            
            vv03_con_baglanti1.Close();
            vv03_con_baglanti1.Open();
            vv05_rdr_okuyucu1 = vv04_cmd_komut1.ExecuteReader();
            if (vv05_rdr_okuyucu1.Read())
            {
                bbkiralama_02_musteri_ad_str_textBox.Text = vv05_rdr_okuyucu1["musteri_01_ad"].ToString();
                bbkiralama_02_musteri_ad_str_textBox.Text += vv05_rdr_okuyucu1[""+"musteri_02_soyad"].ToString();
            }
            
            vv05_rdr_okuyucu1.Close();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
        }

        //toplam ücreti otomatik bulma.
        private void bbkiralama_06_ek_ucret_int_textBox_TextChanged(object sender, EventArgs e)
        {
            int ucret =Convert.ToInt32(bbkiralama_07_ucret_int_textBox.Text);
            int ekucret= Convert.ToInt32(bbkiralama_08_ek_ucret_int_textBox.Text);
            int sonuc = ucret + ekucret;
            bbkiralama_09_toplam_ucret_int_textBox.Text = Convert.ToString(sonuc);
        }


        private void bbkiralama_03_arac_plaka_str_comboBox_SelectedIndexChanged(object sender, EventArgs e)//plakası seçilen arabanın markasını ve kilometresini vermek.
        {
            vv04_cmd_komut1 = new SqlCommand("select araba_01_marka,araba_06_km" +

              " from tbl_arac_islemleri" +
              " where araba_03_plaka=" + "'" + bbkiralama_03_arac_plaka_str_comboBox.SelectedItem.ToString() + "' ", vv03_con_baglanti1);

            vv03_con_baglanti1.Close();
            vv03_con_baglanti1.Open();
            vv05_rdr_okuyucu1 = vv04_cmd_komut1.ExecuteReader();
            if (vv05_rdr_okuyucu1.Read())
            {
                bbkiralama_04_arac_marka_str_textBox.Text = vv05_rdr_okuyucu1["araba_01_marka"].ToString();
                bbkiralama_10_vrldg_km_str_textBox.Text += vv05_rdr_okuyucu1["araba_06_km"].ToString();
            }

            vv05_rdr_okuyucu1.Close();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
        }
    }
    }

