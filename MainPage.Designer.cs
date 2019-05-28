namespace SeferMirza162803034
{
    partial class MainPage
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
            this.lblInglizceKelime = new System.Windows.Forms.Label();
            this.btnTurkceButon = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.btnHatirlat = new System.Windows.Forms.Button();
            this.btnOnay = new System.Windows.Forms.Button();
            this.lblCumleIng = new System.Windows.Forms.Label();
            this.lblCumleTr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInglizceKelime
            // 
            this.lblInglizceKelime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblInglizceKelime.Location = new System.Drawing.Point(30, 23);
            this.lblInglizceKelime.Name = "lblInglizceKelime";
            this.lblInglizceKelime.Size = new System.Drawing.Size(100, 23);
            this.lblInglizceKelime.TabIndex = 0;
            this.lblInglizceKelime.Text = "label1";
            this.lblInglizceKelime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTurkceButon
            // 
            this.btnTurkceButon.FlatAppearance.BorderSize = 0;
            this.btnTurkceButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurkceButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTurkceButon.Location = new System.Drawing.Point(21, 95);
            this.btnTurkceButon.Name = "btnTurkceButon";
            this.btnTurkceButon.Size = new System.Drawing.Size(122, 41);
            this.btnTurkceButon.TabIndex = 2;
            this.btnTurkceButon.Text = "Göster";
            this.btnTurkceButon.UseVisualStyleBackColor = true;
            this.btnTurkceButon.Click += new System.EventHandler(this.btnTurkceButon_Click);
            // 
            // exit
            // 
            this.exit.BackgroundImage = global::SeferMirza162803034.Properties.Resources.close;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Location = new System.Drawing.Point(136, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(29, 23);
            this.exit.TabIndex = 5;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // btnHatirlat
            // 
            this.btnHatirlat.BackgroundImage = global::SeferMirza162803034.Properties.Resources.kronometreicon;
            this.btnHatirlat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHatirlat.FlatAppearance.BorderSize = 0;
            this.btnHatirlat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHatirlat.Location = new System.Drawing.Point(82, 173);
            this.btnHatirlat.Name = "btnHatirlat";
            this.btnHatirlat.Size = new System.Drawing.Size(61, 32);
            this.btnHatirlat.TabIndex = 4;
            this.btnHatirlat.UseVisualStyleBackColor = true;
            this.btnHatirlat.Click += new System.EventHandler(this.btnHatirlat_Click);
            // 
            // btnOnay
            // 
            this.btnOnay.BackgroundImage = global::SeferMirza162803034.Properties.Resources.okey;
            this.btnOnay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOnay.FlatAppearance.BorderSize = 0;
            this.btnOnay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnay.Location = new System.Drawing.Point(21, 173);
            this.btnOnay.Name = "btnOnay";
            this.btnOnay.Size = new System.Drawing.Size(61, 32);
            this.btnOnay.TabIndex = 3;
            this.btnOnay.UseVisualStyleBackColor = true;
            this.btnOnay.Click += new System.EventHandler(this.btnOnay_Click);
            // 
            // lblCumleIng
            // 
            this.lblCumleIng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCumleIng.Location = new System.Drawing.Point(12, 46);
            this.lblCumleIng.Name = "lblCumleIng";
            this.lblCumleIng.Size = new System.Drawing.Size(140, 39);
            this.lblCumleIng.TabIndex = 7;
            this.lblCumleIng.Text = "label1";
            this.lblCumleIng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCumleIng.Click += new System.EventHandler(this.lblCumleIng_Click);
            // 
            // lblCumleTr
            // 
            this.lblCumleTr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCumleTr.Location = new System.Drawing.Point(12, 131);
            this.lblCumleTr.Name = "lblCumleTr";
            this.lblCumleTr.Size = new System.Drawing.Size(140, 39);
            this.lblCumleTr.TabIndex = 8;
            this.lblCumleTr.Text = "label1";
            this.lblCumleTr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPage
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 224);
            this.Controls.Add(this.lblCumleTr);
            this.Controls.Add(this.lblCumleIng);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.btnHatirlat);
            this.Controls.Add(this.btnOnay);
            this.Controls.Add(this.lblInglizceKelime);
            this.Controls.Add(this.btnTurkceButon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.ShowIcon = false;
            this.Text = "Kelime";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPage_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInglizceKelime;
        private System.Windows.Forms.Button btnTurkceButon;
        private System.Windows.Forms.Button btnOnay;
        private System.Windows.Forms.Button btnHatirlat;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label lblCumleIng;
        private System.Windows.Forms.Label lblCumleTr;
    }
}

