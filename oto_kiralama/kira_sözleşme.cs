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
    public partial class kira_sözleşme : Form
    {
        public kira_sözleşme()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)//yazdır buton
        {          
            System.Drawing.Printing.PrintDocument belge = new System.Drawing.Printing.PrintDocument();
            belge.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pprint_PrintPage);
            ppdialog.ShowDialog();
            belge.Print();   
        }

        private void pprint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)//yazdırma
        {
            Bitmap bmap = new Bitmap(kira_sözlesme_panel.Width, kira_sözlesme_panel.Height);
            kira_sözlesme_panel.DrawToBitmap(bmap, new Rectangle(0, 0, kira_sözlesme_panel.Width, kira_sözlesme_panel.Height));
            RectangleF bounds1 = e.PageSettings.PrintableArea;
            float factor1 = ((float)bmap.Height/ (float)bmap.Width);
            e.Graphics.DrawImage(bmap, bounds1.Left, bounds1.Top, bounds1.Width, factor1 * bounds1.Width);
        }

   
        private void öncekiEkranaGeriDönToolStripMenuItem_Click(object sender, EventArgs e)//önceki ekrana dönme
        {
            arac_kiralama_islemi kiralama = new arac_kiralama_islemi();
            kiralama.Show();
            this.Hide();
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)//menüstriptten yazdır
        {
            System.Drawing.Printing.PrintDocument belge = new System.Drawing.Printing.PrintDocument();
            belge.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pprint_PrintPage);
            ppdialog.ShowDialog();
            belge.Print();
        }
    }
}
