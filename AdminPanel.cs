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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        //sql bağlantısı
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\SeferMirza162803034\SeferMirza162803034\kelimelerDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        SqlCommand komut = new SqlCommand();
        SqlDataReader oku;
        //Form drag Drop komutları
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void btnBack_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Close();
        }
        //Form sürükleme 
        private void AdminPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //Kelime ekleme komutları
        private void btnEkle_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            try
            {
                komut = new SqlCommand("INSERT INTO Kelimeler (KelimeIng,KelimeTurkce,Durum,CumleIng,CumleTr) VALUES ('"+txtIng.Text+"','"+txtTr.Text+"','Aktif','"+txtCumleIng.Text +"','"+txtCumleTr.Text+"')", connection);
                oku = komut.ExecuteReader();
                oku.Read();


                lblUyarı.Text = "Eklendi!";
                
            }
            catch
            {
                MessageBox.Show("Bir hata ile karşılaşıldı");
            }
            txtCumleIng.Text = "";txtCumleTr.Text = "";txtIng.Text = "";txtTr.Text = "";
            connection.Close();
        }
        //exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Verilerin yüklendiği alan (istatistik ve grid)
        private void AdminPanel_Load(object sender, EventArgs e)
        {
            this.kullaniciTableAdapter.Fill(this.kelimelerDbDataSet.Kullanici);
            this.kelimelerTableAdapter.Fill(this.kelimelerDbDataSet.Kelimeler);
            AdminVeriler veriler = new AdminVeriler();
            lblGunluk.Text = veriler.Gunluk.ToString();
            lblHafta.Text = veriler.Haftalik.ToString();
            lblAy.Text = veriler.Aylik.ToString();
            lblToplam.Text = veriler.Toplam.ToString();
            lblOrtGun.Text = veriler.OrtGun.ToString();
            lblOrtHafta.Text = veriler.OrtHafta.ToString();
            lblOrtAy.Text = veriler.OrtAy.ToString();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }
        //Kelimelerin güncellendiği yer
        private void btnKelimeleriGuncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sorgu = "";
            int i=99;
            if (txtKelimeGuncelleIng.Text!="")
            {

                sorgu += " KelimeIng='" + txtKelimeGuncelleIng.Text + "',";
                i = 0;
            }
            if (txtKelimeGuncelleTr.Text != "")
            {
                if (i == 0)
                    sorgu += " and ";
                sorgu += " KelimeTurkce='" + txtKelimeGuncelleTr.Text + "'";
                
                i = 1;
            }
            if (txtKelimeGuncelleCumleIng.Text == " ")
            {
                if (i == 1)
                    sorgu += " and ";
                sorgu += " CumleIng='" + txtKelimeGuncelleCumleIng.Text + "',";
                
                i = 2;
            }
            if (txtKelimeGuncelleCumleTr.Text == " ")
            {
                if (i == 2)
                    sorgu += " and ";
                sorgu += " CumleTr='" + txtKelimeGuncelleCumleTr.Text + "',";
               
                i = 3;
            }
            if (txtKelimeDurum.Text == " ")
            {
                if (i == 3)
                    sorgu += " and ";
                sorgu += " Durum='" + txtKelimeDurum.Text + "' ";
               
            }

            komut =new SqlCommand("UPDATE Kelimeler SET"+sorgu+"WHERE Id='"+txtID.Text+"'",connection);
            oku = komut.ExecuteReader();
            oku.Read();
            connection.Close();
        }
        
        private void btnKelimeSil_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                connection.Open();
                komut = new SqlCommand("DELETE FROM Kelimeler WHERE Id='" + txtID.Text + "'", connection);
                oku = komut.ExecuteReader();
                oku.Read();
            }
            else
            {
                MessageBox.Show("Sadece ID Kısmını doldurarak siliniz!");
            }
            connection.Close();
        }
        //Kullanıcı güncelleme
        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sorgu = "";
            int i = 99;
            if (txtKullanicilarSifre.Text != "")
            {
               
                sorgu += " KullaniciSifre='" + txtKelimeGuncelleTr.Text + "'";

                i = 0;
            }
            if (txtKullanicilarAdi.Text != "")
            {
                if (i == 0)
                    sorgu += " and ";
                sorgu += " KullaniciAdi='" + txtKullanicilarAdi.Text + "',";
                i = 1;
            }
            
            if (txtKullanicilarSeviye.SelectedIndex >0){
                if (i == 1)
                    sorgu += " and ";
                sorgu += " Seviye='" + txtKullanicilarSeviye.SelectedIndex + "',";

                
            }
            

            komut = new SqlCommand("UPDATE Kelimeler SET" + sorgu + "WHERE Id='" + txtKullanicilarId.Text + "'", connection);
            oku = komut.ExecuteReader();
            oku.Read();
            connection.Close();
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (txtKullanicilarId.Text != "")
            {
                connection.Open();
                komut = new SqlCommand("DELETE FROM Kelimeler WHERE Id='" + txtKullanicilarId.Text + "'", connection);
                oku = komut.ExecuteReader();
                oku.Read();
            }
            else
            {
                MessageBox.Show("Sadece ID Kısmını doldurarak siliniz!");
            }
            connection.Close();
        }
        //form yenileme
        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Close();
        }
    }
}
