using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oto_kiralama
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arac_islemleri arac = new arac_islemleri();
            arac.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri_islemleri musteri = new musteri_islemleri();
            musteri.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            arac_kiralama_islemi kiralama = new arac_kiralama_islemi();
            kiralama.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arac_teslim_alma_islemi teslim = new arac_teslim_alma_islemi();
            teslim.Show();
            this.Hide();
        }

  
        private void girişeDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giris_ekranı giris = new giris_ekranı();
            giris.Show();
            this.Hide();
        }

        
    }
}
