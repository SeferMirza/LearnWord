using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SeferMirza162803034
{
    public partial class MainPage : Form
    {
        //Drag Drop Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public MainPage()
        {
            InitializeComponent();
            
            Baglan(1);

        }

        private void MainPage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            
            this.Close();
            

        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\SeferMirza162803034\SeferMirza162803034\kelimelerDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        SqlCommand komut;
        SqlDataReader oku;
        string cumleTr;
        //Veri tabanına bağlanarak ekrandaki label ları dolduruyor
        private void Baglan(int i)
        {
            connection.Open();
            komut = new SqlCommand("SELECT Kelimeler.Id,Kelimeler.KelimeIng,Kelimeler.KelimeTurkce,Kelimeler.CumleIng,Kelimeler.CumleTr,KullaniciKelimeleri.KelimeId FROM Kelimeler,KullaniciKelimeleri WHERE KullaniciKelimeleri.KelimeId=Kelimeler.Id and KullaniciKelimeleri.Durum='Aktif' and KullaniciKelimeleri.KullaniciId="+KullaniciBilgileri.KullaniciId, connection);
            oku = komut.ExecuteReader();
            oku.Read();
            try
            {
                if (i == 1)
                {
                    lblInglizceKelime.Text = oku.GetValue(i).ToString();
                    lblCumleIng.Text = oku.GetValue(3).ToString();
                    cumleTr = oku.GetValue(4).ToString();

                }
                if (i == 2)
                {
                    btnTurkceButon.Text = oku.GetValue(i).ToString();
                }
            }
            catch
            {
                 MessageBox.Show("Tüm kelimeleri ezberlediniz !!!");
            }
            
            oku.Close();
            komut.Dispose();
            connection.Close();
        }
        int i;
        //Öğrenilen kelimelerin durumlarını güncelliyor
        private void Guncelle()
        { 
            connection.Open();
            string kelimesayi = "select Gunluk from Kullanici where Id='" + KullaniciBilgileri.KullaniciId + "'";
            SqlCommand sqlCommand = new SqlCommand(kelimesayi, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            i =Convert.ToInt32( reader.GetValue(0));
            string ifade = "UPDATE Kullanici" +
                " SET Gunluk='"+i+"',Haftalik='"+i+"',Aylik='"+i+"',Toplam='"+i+"'"+
                "WHERE Id='" + KullaniciBilgileri.KullaniciId+"'";
            string kelimeidifade = "select Kelimeler.Id from Kelimeler,KullaniciKelimeleri where Kelimeler.KelimeIng='" + lblInglizceKelime.Text + "' and KullaniciKelimeleri.KelimeId=Kelimeler.Id";
            SqlCommand kelimebul = new SqlCommand(kelimeidifade,connection);
            oku = kelimebul.ExecuteReader();
            oku.Read();
            string ifade2 = "update KullaniciKelimeleri set Durum='Beklemede' where KullaniciId='" + KullaniciBilgileri.KullaniciId + "' and KelimeId='"+oku.GetValue(0)+"'";
            komut = new SqlCommand(ifade, connection);
            SqlCommand cmd = new SqlCommand(ifade2, connection);
            komut.ExecuteNonQuery();
            cmd.ExecuteReader();
            komut.Dispose();
            connection.Close();
            i++;
        }
        private void MainPage_Load(object sender, EventArgs e)
        {
        }
        //Türkçe kelimeyi gösteriyor
        private void btnTurkceButon_Click(object sender, EventArgs e)
        {
            Baglan(2);
            lblCumleTr.Text = cumleTr;
        }
        //Kelimenin ezberlendiğinin onaylaması
        private void btnOnay_Click(object sender, EventArgs e)
        {
            btnTurkceButon.Text = "Göster";
            lblCumleTr.Text = "";
            Guncelle();
            Baglan(1);
        }

        private void btnHatirlat_Click(object sender, EventArgs e)
        {
            btnTurkceButon.Text = "Göster";
            connection.Open();
            string ifade = "UPDATE Kelimeler" +
                " SET Tarih='10',Durum='Beklemede',BaslangicTarih='"+ DateTime.Now.ToString("yyyy-MM-dd") + "'"+
                "WHERE KelimeIng='" + lblInglizceKelime.Text + "'";
            komut = new SqlCommand(ifade, connection);
            komut.ExecuteNonQuery();
            komut.Dispose();
            connection.Close();
            Baglan(1);

        }
        
        private void lblCumleIng_Click(object sender, EventArgs e)
        {

        }
    }
}
