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
using System.Configuration;
using System.Threading;

namespace SeferMirza162803034
{
    public partial class KullaniciPanel : Form
    {
        public KullaniciPanel()
        {
            InitializeComponent();
        }
        //sql kodları
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\SeferMirza162803034\SeferMirza162803034\kelimelerDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        SqlCommand komut,komutforword;
        SqlDataReader oku;
        SqlDataReader dr;
        MainPage main;
        //Form Drag Drop kodları
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //ezberleme ekranı açma
        private void btnEzberle_Click(object sender, EventArgs e)
        {
            main = new MainPage();
            main.Show();
        }
        //Drag Drop fonksiyon
        private void KullaniciPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //Çıkış
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Kullanıcı girişi ekranı gider
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Giris giris = new Giris();
            giris.Show();
        }
        
        private void KullaniciPanel_Load(object sender, EventArgs e)
        {
            bilgileridoldur();
        }
        //Ekrandaki verileri yükler
        private void bilgileridoldur()
        {
            connection.Open();
            komut = new SqlCommand("SELECT * FROM Kullanici WHERE KullaniciAdi='" + KullaniciBilgileri.KullaniciAdi + "'", connection);
            oku = komut.ExecuteReader();
            oku.Read();
            lblKullaniciSeviye.Text = oku.GetValue(3).ToString();
            lblKullaniciGunlukKelime.Text = oku.GetValue(4).ToString();
            lblKullaniciHaftalik.Text = oku.GetValue(6).ToString();
            lblAylik.Text = oku.GetValue(5).ToString();
            lblToplam.Text = oku.GetValue(7).ToString();
            lblKullaniciAdi.Text = KullaniciBilgileri.KullaniciAdi;
            connection.Close();
            kelimeleridoldur();
        }
        //Kullanıcı havuzdan kelime seçer
        private void btnEkle_Click(object sender, EventArgs e)
        {
            lstList.Items.Add(lstKelimeHavuzu.SelectedItem);
            connection.Open();
            int ID;
            string a=lstKelimeHavuzu.SelectedItem.ToString();
            komutforword = new SqlCommand("select Id from Kelimeler where KelimeIng='"+a+"'", connection);
            oku = komutforword.ExecuteReader();
            oku.Read();
            ID = Convert.ToInt32(oku.GetValue(0));
            komut = new SqlCommand("insert into KullaniciKelimeleri(KullaniciId,KelimeId,AlınmaTarihi,Durum) VALUES ('"+KullaniciBilgileri.KullaniciId+"','"+ID+"','"+ DateTime.Now.ToString("yyyy-MM-dd")+"','Aktif')",connection);
            
            dr = komut.ExecuteReader();
            dr.Read();
            dr.Dispose();
            connection.Close();
        }
       
        //Kullanıcı kelimelerini kaldırır
        private void btnCikar_Click(object sender, EventArgs e)
        {
            
            
                connection.Open();
                SqlCommand kelimeidbul = new SqlCommand("select Kelimeler.KelimeIng,Kelimeler.Id,KullaniciKelimeleri.KelimeId from Kelimeler,KullaniciKelimeleri where KullaniciKelimeleri.KelimeId=Kelimeler.Id",connection);
                dr = kelimeidbul.ExecuteReader();
                dr.Read();
                komut = new SqlCommand("DELETE FROM KullaniciKelimeleri WHERE KelimeId='"+dr.GetValue(0)+"'", connection);
                oku = komut.ExecuteReader();
                oku.Read();
            connection.Close();
            lstList.Items.RemoveAt(lstList.SelectedIndex);
            
        }
        //ekran yenileme
        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciPanel kullaniciPanel = new KullaniciPanel();
            kullaniciPanel.Show();
            this.Close();
        }
        //kelimeleri veri tabanından çeker
        private void kelimeleridoldur()
        {
            connection.Open();
            komutforword = new SqlCommand("SELECT KelimeIng FROM Kelimeler WHERE Durum='Aktif'", connection);
            SqlCommand komutkullanicikelime = new SqlCommand("SELECT Kelimeler.Id,Kelimeler.KelimeIng,KullaniciKelimeleri.KelimeId FROM Kelimeler,KullaniciKelimeleri WHERE KullaniciKelimeleri.KelimeId=Kelimeler.Id and KullaniciKelimeleri.KullaniciId="+KullaniciBilgileri.KullaniciId,connection);
            dr = komutforword.ExecuteReader();
            oku = komutkullanicikelime.ExecuteReader();
            while (dr.Read())
            {
                lstKelimeHavuzu.Items.Add(dr["KelimeIng"]);
            }
            while (oku.Read())
            {
                lstList.Items.Add(oku["KelimeIng"]);
            }
            connection.Close();

        }
        
    }
}
