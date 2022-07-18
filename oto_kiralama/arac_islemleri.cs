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


    public partial class arac_islemleri : Form
    {

        string vv01_str_veritabani_yolu = @"Data Source=DESKTOP-E73DNUQ;Initial Catalog=vtb_01_oto_kiralama;Integrated Security=True";
        string vv02_str_komut_yazisi = "";
        SqlConnection vv03_con_baglanti1;
        SqlCommand vv04_cmd_komut1;
        SqlDataReader vv05_rdr_okuyucu1;
        SqlDataAdapter vv06_adp_adaptor1;
        DataTable vv07_tbl_tablo1;

        int ii01_id_tutucu = -1;
        private DateTime dt1;

        public arac_islemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// menüye dön butonu.
        {            
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void arac_islemleri_Load(object sender, EventArgs e)
        {
            mm01_araba_DataGridDoldur();
        }

        public void mm01_araba_DataGridDoldur()//datagrid doldurma metodu.
        {
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
                " order by araba_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi,vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);

            dataGridView1.DataSource = vv07_tbl_tablo1;

        }

        private void button2_Click(object sender, EventArgs e)//kaydet butonu.
        {
            ssaraba_islemi aa = new ssaraba_islemi();

            aa.aaraba_01_marka_str = bbaraba_01_marka_str_textBox.Text;
            aa.aaraba_02_model_str = bbaraba_02_model_str_textBox.Text;
            aa.aaraba_03_plaka_str = bbaraba_03_plaka_str_textBox.Text;
            aa.aaraba_04_yakıt_turu_str = bbaraba_04_yakıt_turu_str_comboBox.Text;
            aa.aaraba_05_renk_str = bbaraba_05_renk_str_comboBox.Text;
            aa.aaraba_06_km_str = bbaraba_06_km_int_textBox.Text;
            aa.aaraba_07_bakim_tarihi_dtm = bbaraba_07_bakim_tarihi_dtm_dateTimePicker.Value;
            aa.aaraba_08_gelecek_bakim_dtm = bbaraba_08_gelecek_bakim_dtm_dateTimePicker.Value;
            aa.aaraba_09_vites_turu_str = bbaraba_09_vites_turu_str_comboBox.Text;
            aa.araba_10_yil_str =bbaraba_10_yil_int_textBox.Text;

            vv02_str_komut_yazisi = "insert into tbl_arac_islemleri(" +             
                "araba_01_marka," +
                "araba_02_model," +
                "araba_03_plaka," +
                "araba_04_yakıt_turu," +
                "araba_05_renk," +
                "araba_06_km," +
                "araba_07_bakim_tarihi," +
                "araba_08_gelecek_bakim," +
                "araba_09_vites_turu," +
                "araba_10_yil," +
                "araba_11_durum " +
                ")" +
                " values (" +               
                "@araba_01_marka," +
                "@araba_02_model," +
                "@araba_03_plaka," +
                "@araba_04_yakıt_turu," +
                "@araba_05_renk,"+
                "@araba_06_km," +
                "@araba_07_bakim_tarihi," +
                "@araba_08_gelecek_bakim," +
                "@araba_09_vites_turu," +
                "@araba_10_yil," +
                "'Uygun'" +
                ")";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi,vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_01_marka",aa.aaraba_01_marka_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_02_model", aa.aaraba_02_model_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_03_plaka", aa.aaraba_03_plaka_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_04_yakıt_turu", aa.aaraba_04_yakıt_turu_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_05_renk", aa.aaraba_05_renk_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_06_km", aa.aaraba_06_km_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_07_bakim_tarihi", aa.aaraba_07_bakim_tarihi_dtm);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_08_gelecek_bakim", aa.aaraba_08_gelecek_bakim_dtm);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_09_vites_turu", aa.aaraba_09_vites_turu_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_10_yil", aa.araba_10_yil_str);
            
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            mm01_araba_DataGridDoldur();
        }

        private void button3_Click(object sender, EventArgs e)//sil butonu.
        { 
            ssaraba_islemi aa = new ssaraba_islemi();
            
            aa.aaraba_01_marka_str = bbaraba_01_marka_str_textBox.Text;
            aa.aaraba_02_model_str = bbaraba_02_model_str_textBox.Text;
            aa.aaraba_03_plaka_str = bbaraba_03_plaka_str_textBox.Text;
            aa.aaraba_04_yakıt_turu_str = bbaraba_04_yakıt_turu_str_comboBox.Text;
            aa.aaraba_05_renk_str = bbaraba_05_renk_str_comboBox.Text;
            aa.aaraba_06_km_str = bbaraba_06_km_int_textBox.Text;
            aa.aaraba_07_bakim_tarihi_dtm = bbaraba_07_bakim_tarihi_dtm_dateTimePicker.Value;
            aa.aaraba_08_gelecek_bakim_dtm = bbaraba_08_gelecek_bakim_dtm_dateTimePicker.Value;
            aa.aaraba_09_vites_turu_str = bbaraba_09_vites_turu_str_comboBox.Text;
            aa.araba_10_yil_str = bbaraba_10_yil_int_textBox.Text;
            
            vv02_str_komut_yazisi =" delete from tbl_arac_islemleri " +
                " where araba_00_id=@araba_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);


            vv04_cmd_komut1.Parameters.AddWithValue("@araba_00_id", ii01_id_tutucu);

            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            mm01_araba_DataGridDoldur();
         
        }

        private void button4_Click(object sender, EventArgs e)//güncelleme butonu.
        {
            ssaraba_islemi aa = new ssaraba_islemi();

            aa.aaraba_01_marka_str = bbaraba_01_marka_str_textBox.Text;
            aa.aaraba_02_model_str = bbaraba_02_model_str_textBox.Text;
            aa.aaraba_03_plaka_str = bbaraba_03_plaka_str_textBox.Text;
            aa.aaraba_04_yakıt_turu_str = bbaraba_04_yakıt_turu_str_comboBox.Text;
            aa.aaraba_05_renk_str = bbaraba_05_renk_str_comboBox.Text;
            aa.aaraba_06_km_str =bbaraba_06_km_int_textBox.Text;
            aa.aaraba_07_bakim_tarihi_dtm = bbaraba_07_bakim_tarihi_dtm_dateTimePicker.Value;
            aa.aaraba_08_gelecek_bakim_dtm = bbaraba_08_gelecek_bakim_dtm_dateTimePicker.Value;
            aa.aaraba_09_vites_turu_str = bbaraba_09_vites_turu_str_comboBox.Text;
            aa.araba_10_yil_str = bbaraba_10_yil_int_textBox.Text;

            vv02_str_komut_yazisi = " update tbl_arac_islemleri set " +
                "araba_01_marka=@araba_01_marka," +
                "araba_02_model=@araba_02_model," +
                "araba_03_plaka=@araba_03_plaka," +
                "araba_04_yakıt_turu=@araba_04_yakıt_turu," +
                "araba_05_renk=@araba_05_renk," +
                "araba_06_km=@araba_06_km," +
                "araba_07_bakim_tarihi=@araba_07_bakim_tarihi," +
                "araba_08_gelecek_bakim=@araba_08_gelecek_bakim," +
                "araba_09_vites_turu=@araba_09_vites_turu," +
                "araba_10_yil=@araba_10_yil " +

                " where araba_00_id=@araba_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_01_marka", aa.aaraba_01_marka_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_02_model", aa.aaraba_02_model_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_03_plaka", aa.aaraba_03_plaka_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_04_yakıt_turu", aa.aaraba_04_yakıt_turu_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_05_renk", aa.aaraba_05_renk_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_06_km", aa.aaraba_06_km_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_07_bakim_tarihi", aa.aaraba_07_bakim_tarihi_dtm);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_08_gelecek_bakim", aa.aaraba_08_gelecek_bakim_dtm);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_09_vites_turu", aa.aaraba_09_vites_turu_str);
            vv04_cmd_komut1.Parameters.AddWithValue("@araba_10_yil", aa.araba_10_yil_str);

            vv04_cmd_komut1.Parameters.AddWithValue("@araba_00_id",ii01_id_tutucu);


            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            mm01_araba_DataGridDoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//Tıklanan hücredeki verileri çeker.
        {
            ii01_id_tutucu = Convert.ToInt32(dataGridView1[0,e.RowIndex].Value.ToString());
            ssaraba_islemi aa = new ssaraba_islemi();
            aa.aaraba_01_marka_str=dataGridView1[1,e.RowIndex].Value.ToString();
            aa.aaraba_02_model_str = dataGridView1[2, e.RowIndex].Value.ToString();
            aa.aaraba_03_plaka_str = dataGridView1[3, e.RowIndex].Value.ToString();
            aa.aaraba_04_yakıt_turu_str = dataGridView1[4, e.RowIndex].Value.ToString();
            aa.aaraba_05_renk_str = dataGridView1[5, e.RowIndex].Value.ToString();
            aa.aaraba_06_km_str =dataGridView1[6, e.RowIndex].Value.ToString();
            aa.aaraba_07_bakim_tarihi_dtm =Convert.ToDateTime(dataGridView1[7, e.RowIndex].Value.ToString());
            aa.aaraba_08_gelecek_bakim_dtm = Convert.ToDateTime(dataGridView1[8, e.RowIndex].Value.ToString());
            aa.aaraba_09_vites_turu_str = dataGridView1[9, e.RowIndex].Value.ToString();
            aa.araba_10_yil_str = dataGridView1[10, e.RowIndex].Value.ToString();


            bbaraba_01_marka_str_textBox.Text = aa.aaraba_01_marka_str;
            bbaraba_02_model_str_textBox.Text = aa.aaraba_02_model_str;
            bbaraba_03_plaka_str_textBox.Text = aa.aaraba_03_plaka_str;
            bbaraba_04_yakıt_turu_str_comboBox.Text = aa.aaraba_04_yakıt_turu_str;
            bbaraba_05_renk_str_comboBox.Text = aa.aaraba_05_renk_str;
            bbaraba_06_km_int_textBox.Text = aa.aaraba_06_km_str;
            bbaraba_07_bakim_tarihi_dtm_dateTimePicker.Value = aa.aaraba_07_bakim_tarihi_dtm;
            bbaraba_08_gelecek_bakim_dtm_dateTimePicker.Value = aa.aaraba_08_gelecek_bakim_dtm;
            bbaraba_09_vites_turu_str_comboBox.Text = aa.aaraba_09_vites_turu_str;
            bbaraba_10_yil_int_textBox.Text = aa.araba_10_yil_str;
        }
     

        private void kiradaOlmayanAraçlarToolStripMenuItem_Click(object sender, EventArgs e)//kirada olmayan araçları gösterme
        {
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
               " from tbl_arac_islemleri" +
               " where araba_11_durum='Uygun'" +
               " order by araba_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);

            dataGridView1.DataSource = vv07_tbl_tablo1;
        }

        private void kiradakiAraçlarToolStripMenuItem_Click(object sender, EventArgs e)//kiradaki araçları gösterme
        {
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
              " from tbl_arac_islemleri" +
              " where araba_11_durum='Kirada'" +
              " order by araba_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);

            dataGridView1.DataSource = vv07_tbl_tablo1;
        }

        private void tümAraçlarToolStripMenuItem_Click(object sender, EventArgs e)//tüm kayıdı gösterme
        {
            mm01_araba_DataGridDoldur();
        }

        private void menüyeDönToolStripMenuItem_Click(object sender, EventArgs e)//menüye dönme
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        
        //bakım tarihini seçtikten sonra gelecek bakım tarihini otomatik atama yapma.
        private void bbaraba_07_bakim_tarihi_dtm_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            bbaraba_08_gelecek_bakim_dtm_dateTimePicker.Value = bbaraba_07_bakim_tarihi_dtm_dateTimePicker.Value.AddDays(90);
        }

        
    }
}
