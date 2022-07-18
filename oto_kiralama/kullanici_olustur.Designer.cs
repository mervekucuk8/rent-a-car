
namespace oto_kiralama
{
    partial class kullanici_olustur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bbkullaniciolustır_01_adi_str_textBox = new System.Windows.Forms.TextBox();
            this.bbkullaniciolustır_02_sifre_str_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bbkullaniciolustır_01_adi_str_textBox
            // 
            this.bbkullaniciolustır_01_adi_str_textBox.Location = new System.Drawing.Point(120, 75);
            this.bbkullaniciolustır_01_adi_str_textBox.Name = "bbkullaniciolustır_01_adi_str_textBox";
            this.bbkullaniciolustır_01_adi_str_textBox.Size = new System.Drawing.Size(103, 20);
            this.bbkullaniciolustır_01_adi_str_textBox.TabIndex = 0;
            // 
            // bbkullaniciolustır_02_sifre_str_textBox
            // 
            this.bbkullaniciolustır_02_sifre_str_textBox.Location = new System.Drawing.Point(120, 108);
            this.bbkullaniciolustır_02_sifre_str_textBox.Name = "bbkullaniciolustır_02_sifre_str_textBox";
            this.bbkullaniciolustır_02_sifre_str_textBox.Size = new System.Drawing.Size(103, 20);
            this.bbkullaniciolustır_02_sifre_str_textBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkCyan;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(120, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kullanıcıyı Kaydet";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(36, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(80, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gGToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(325, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
//            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // gGToolStripMenuItem
            // 
            this.gGToolStripMenuItem.Name = "gGToolStripMenuItem";
            this.gGToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.gGToolStripMenuItem.Text = "Girişe Dön";
            this.gGToolStripMenuItem.Click += new System.EventHandler(this.gGToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(120, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "Kullanıcıyı Sil";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // kullanici_olustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(325, 277);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bbkullaniciolustır_02_sifre_str_textBox);
            this.Controls.Add(this.bbkullaniciolustır_01_adi_str_textBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "kullanici_olustur";
            this.Text = "Kullanıcı Oluştur-Sil";
            this.Load += new System.EventHandler(this.kullanici_olustur_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bbkullaniciolustır_01_adi_str_textBox;
        private System.Windows.Forms.TextBox bbkullaniciolustır_02_sifre_str_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gGToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}