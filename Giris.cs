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
namespace SeferMirza162803034
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\SeferMirza162803034\SeferMirza162803034\kelimelerDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        SqlCommand komut = new SqlCommand();
        SqlDataReader oku;
        KullaniciPanel kullanici;
        private void Giris_Load(object sender, EventArgs e)
        {

        }
        private void Baglan(int i)
        {
            connection.Open();
            try
            {
                if (i == 1)
                {
                    try
                    {
                        komut = new SqlCommand("INSERT INTO Kullanici (Sifre,KullaniciAdi) VALUES ('" + txtKayitSifre.Text + "','" + txtKayitKullaniciAdi.Text + "')", connection);
                        oku = komut.ExecuteReader();
                        oku.Read();
                        MessageBox.Show("Kayıt İşlemi tamamlandı lütfen girişe yönelin");
                    }
                    catch
                    {
                        MessageBox.Show("Kayıt işlemi başarısız!!!");
                    }
                }
                else
                {
                    if (i == 2)
                    {
                        komut = new SqlCommand("select * from Kullanici where KullaniciAdi='"+txtGirisKullaniciAdi.Text+"' and Sifre='"+txtGirisSifre.Text+"'", connection);
                        oku = komut.ExecuteReader();
                        if(oku.Read()){
                            KullaniciBilgileri.KullaniciAdi = txtGirisKullaniciAdi.Text;
                            KullaniciBilgileri.Sifre = txtGirisSifre.Text;
                            KullaniciBilgileri.KullaniciId =Convert.ToInt32(oku.GetValue(0));
                            kullanici = new KullaniciPanel();
                            kullanici.Show();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("Hatalı bilgiler girdiniz.");
                    }
                
                }

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("Lütfen boşlukları uygun şekilde doldurunuz !!! {0} ", e.ToString());
            }

            oku.Close();
            komut.Dispose();
            connection.Close();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtGirisKullaniciAdi.Text == "Admin"&& txtGirisSifre.Text=="admin")
            {
                AdminPanel admin = new AdminPanel();
                admin.Show();
                this.Hide();
            }
            else
            {
                Baglan(2);
            }
            

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Baglan(1);
            
        }
    }
}
