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
    public partial class arac_teslim_alma_islemi : Form
    {
        string vv01_str_veritabani_yolu = @"Data Source=DESKTOP-E73DNUQ;Initial Catalog=vtb_01_oto_kiralama;Integrated Security=True";
        string vv02_str_komut_yazisi = "";
        SqlConnection vv03_con_baglanti1;
        SqlCommand vv04_cmd_komut1;
        SqlDataReader vv05_rdr_okuyucu1;
        SqlDataAdapter vv06_adp_adaptor1;
        DataTable vv07_tbl_tablo1;

        int ii01_id_tutucu = -1;

        public arac_teslim_alma_islemi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//menüye dön
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        private void arac_teslim_alma_islemi_Load(object sender, EventArgs e)
        {
            mm04_teslimalma_DataGridDoldur();

            //combo doldurma
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1=new SqlCommand("select araba_03_plaka from tbl_arac_islemleri where araba_11_durum='Kirada'",vv03_con_baglanti1);
            vv05_rdr_okuyucu1 = vv04_cmd_komut1.ExecuteReader();
            while (vv05_rdr_okuyucu1.Read())
            {
                bbteslim_01_arac_plaka_str_comboBox.Items.Add(vv05_rdr_okuyucu1["araba_03_plaka"]);
            }
        }
    
       
        public void mm04_teslimalma_DataGridDoldur()//datagrid doldur.
        {

            vv02_str_komut_yazisi ="select " +
              "teslim_00_id as[İD] ," +
              "teslim_01_arac_plaka as [PLAKA]" +                  

            " from tbl_teslim_alma_islemi" +
             " order by teslim_00_id ";
       
            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);

           
        }
        
        private void button2_Click(object sender, EventArgs e)//kaydet(teslim alma)
        {
            
            ssarac_teslim aa = new ssarac_teslim();
            aa.teslim_01_arac_plaka_str = bbteslim_01_arac_plaka_str_comboBox.Text;

            vv02_str_komut_yazisi = " update tbl_arac_islemleri set " +
                   "araba_11_durum=" + "'" + "Uygun" +
                   "'where araba_03_plaka='" + bbteslim_01_arac_plaka_str_comboBox.Text + "' ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);       

            vv04_cmd_komut1.Parameters.AddWithValue("@teslim_01_arac_plaka", aa.teslim_01_arac_plaka_str);

            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            MessageBox.Show("Araç kiralamaya uygun hale gelmiştir.");
           
   

            aa.teslim_01_arac_plaka_str = bbteslim_01_arac_plaka_str_comboBox.Text;
   
            vv02_str_komut_yazisi = " insert into tbl_teslim_alma_islemi(" +
                  "teslim_01_arac_plaka" +                
                  ")" +
                  " values (" +
                  "@teslim_01_arac_plaka" +                 
                  ")";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv04_cmd_komut1.Parameters.AddWithValue("@teslim_01_arac_plaka", aa.teslim_01_arac_plaka_str);

            vv03_con_baglanti1.Open();
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();
            vv03_con_baglanti1.Close();
            
            

        }
        
        private void menüyeDönToolStripMenuItem_Click(object sender, EventArgs e)//menüye dön
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

        
    }
}
