namespace PDKS6
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnGirisCıkıs = new System.Windows.Forms.Button();
            this.btnMesaiİslemleri = new System.Windows.Forms.Button();
            this.btnMaas = new System.Windows.Forms.Button();
            this.btnMesaiEkle = new System.Windows.Forms.Button();
            this.btnİzinHareketleri = new System.Windows.Forms.Button();
            this.btnPersonelListele = new System.Windows.Forms.Button();
            this.btnPersonelEkle = new System.Windows.Forms.Button();
            this.btnDepartman = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnGirisCıkıs);
            this.panelMenu.Controls.Add(this.btnMesaiİslemleri);
            this.panelMenu.Controls.Add(this.btnMaas);
            this.panelMenu.Controls.Add(this.btnMesaiEkle);
            this.panelMenu.Controls.Add(this.btnİzinHareketleri);
            this.panelMenu.Controls.Add(this.btnPersonelListele);
            this.panelMenu.Controls.Add(this.btnPersonelEkle);
            this.panelMenu.Controls.Add(this.btnDepartman);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 1053);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnGirisCıkıs
            // 
            this.btnGirisCıkıs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGirisCıkıs.FlatAppearance.BorderSize = 0;
            this.btnGirisCıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirisCıkıs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirisCıkıs.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGirisCıkıs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGirisCıkıs.Location = new System.Drawing.Point(0, 500);
            this.btnGirisCıkıs.Name = "btnGirisCıkıs";
            this.btnGirisCıkıs.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnGirisCıkıs.Size = new System.Drawing.Size(220, 60);
            this.btnGirisCıkıs.TabIndex = 8;
            this.btnGirisCıkıs.Text = "Giriş-Çıkış";
            this.btnGirisCıkıs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGirisCıkıs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGirisCıkıs.UseVisualStyleBackColor = true;
            this.btnGirisCıkıs.Click += new System.EventHandler(this.btnGirisCıkıs_Click);
            // 
            // btnMesaiİslemleri
            // 
            this.btnMesaiİslemleri.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMesaiİslemleri.FlatAppearance.BorderSize = 0;
            this.btnMesaiİslemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesaiİslemleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMesaiİslemleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMesaiİslemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMesaiİslemleri.Location = new System.Drawing.Point(0, 440);
            this.btnMesaiİslemleri.Name = "btnMesaiİslemleri";
            this.btnMesaiİslemleri.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnMesaiİslemleri.Size = new System.Drawing.Size(220, 60);
            this.btnMesaiİslemleri.TabIndex = 7;
            this.btnMesaiİslemleri.Text = "Mesai İşlemleri";
            this.btnMesaiİslemleri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMesaiİslemleri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMesaiİslemleri.UseVisualStyleBackColor = true;
            this.btnMesaiİslemleri.Click += new System.EventHandler(this.btnMesaiİslemleri_Click);
            // 
            // btnMaas
            // 
            this.btnMaas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMaas.FlatAppearance.BorderSize = 0;
            this.btnMaas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMaas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMaas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaas.Location = new System.Drawing.Point(0, 380);
            this.btnMaas.Name = "btnMaas";
            this.btnMaas.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnMaas.Size = new System.Drawing.Size(220, 60);
            this.btnMaas.TabIndex = 6;
            this.btnMaas.Text = "Maaş Zamları";
            this.btnMaas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaas.UseVisualStyleBackColor = true;
            this.btnMaas.Click += new System.EventHandler(this.btnMaas_Click);
            // 
            // btnMesaiEkle
            // 
            this.btnMesaiEkle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMesaiEkle.FlatAppearance.BorderSize = 0;
            this.btnMesaiEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesaiEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMesaiEkle.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMesaiEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMesaiEkle.Location = new System.Drawing.Point(0, 320);
            this.btnMesaiEkle.Name = "btnMesaiEkle";
            this.btnMesaiEkle.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnMesaiEkle.Size = new System.Drawing.Size(220, 60);
            this.btnMesaiEkle.TabIndex = 5;
            this.btnMesaiEkle.Text = "Mesai Ekle";
            this.btnMesaiEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMesaiEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMesaiEkle.UseVisualStyleBackColor = true;
            this.btnMesaiEkle.Click += new System.EventHandler(this.BtnMesaiEkle);
            // 
            // btnİzinHareketleri
            // 
            this.btnİzinHareketleri.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnİzinHareketleri.FlatAppearance.BorderSize = 0;
            this.btnİzinHareketleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnİzinHareketleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnİzinHareketleri.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnİzinHareketleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnİzinHareketleri.Location = new System.Drawing.Point(0, 260);
            this.btnİzinHareketleri.Name = "btnİzinHareketleri";
            this.btnİzinHareketleri.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnİzinHareketleri.Size = new System.Drawing.Size(220, 60);
            this.btnİzinHareketleri.TabIndex = 4;
            this.btnİzinHareketleri.Text = "İzin Hareketleri";
            this.btnİzinHareketleri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnİzinHareketleri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnİzinHareketleri.UseVisualStyleBackColor = true;
            this.btnİzinHareketleri.Click += new System.EventHandler(this.btnİzinHareketleri_Click);
            // 
            // btnPersonelListele
            // 
            this.btnPersonelListele.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPersonelListele.FlatAppearance.BorderSize = 0;
            this.btnPersonelListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonelListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonelListele.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPersonelListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonelListele.Location = new System.Drawing.Point(0, 200);
            this.btnPersonelListele.Name = "btnPersonelListele";
            this.btnPersonelListele.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnPersonelListele.Size = new System.Drawing.Size(220, 60);
            this.btnPersonelListele.TabIndex = 3;
            this.btnPersonelListele.Text = "Personel Listele";
            this.btnPersonelListele.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonelListele.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPersonelListele.UseVisualStyleBackColor = true;
            this.btnPersonelListele.Click += new System.EventHandler(this.btnPersonelListele_Click);
            // 
            // btnPersonelEkle
            // 
            this.btnPersonelEkle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPersonelEkle.FlatAppearance.BorderSize = 0;
            this.btnPersonelEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonelEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonelEkle.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPersonelEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonelEkle.Location = new System.Drawing.Point(0, 140);
            this.btnPersonelEkle.Name = "btnPersonelEkle";
            this.btnPersonelEkle.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnPersonelEkle.Size = new System.Drawing.Size(220, 60);
            this.btnPersonelEkle.TabIndex = 2;
            this.btnPersonelEkle.Text = "Personel Ekle";
            this.btnPersonelEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonelEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPersonelEkle.UseVisualStyleBackColor = true;
            this.btnPersonelEkle.Click += new System.EventHandler(this.btnPersonelEkle_Click);
            // 
            // btnDepartman
            // 
            this.btnDepartman.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDepartman.FlatAppearance.BorderSize = 0;
            this.btnDepartman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartman.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDepartman.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDepartman.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartman.Location = new System.Drawing.Point(0, 80);
            this.btnDepartman.Name = "btnDepartman";
            this.btnDepartman.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnDepartman.Size = new System.Drawing.Size(220, 60);
            this.btnDepartman.TabIndex = 1;
            this.btnDepartman.Text = "Departmanlar";
            this.btnDepartman.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartman.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepartman.UseVisualStyleBackColor = true;
            this.btnDepartman.Click += new System.EventHandler(this.btnDepartman_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(58, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "PDKS";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1620, 80);
            this.panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(828, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ana Sayfa";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Controls.Add(this.label2);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(220, 80);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(1620, 973);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(648, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 153);
            this.label2.TabIndex = 0;
            this.label2.Text = "PDKS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1840, 1053);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(1352, 874);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            this.panelDesktopPane.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnDepartman;
        private System.Windows.Forms.Panel panelLogo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnMaas;
        private System.Windows.Forms.Button btnMesaiEkle;
        private System.Windows.Forms.Button btnİzinHareketleri;
        private System.Windows.Forms.Button btnPersonelListele;
        private System.Windows.Forms.Button btnPersonelEkle;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button btnMesaiİslemleri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGirisCıkıs;
    }
}

