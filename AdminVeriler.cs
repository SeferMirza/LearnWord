using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace SeferMirza162803034
{
    public class AdminVeriler
    {
        public int Gunluk { get; set; }
        public int Haftalik { get; set; }
        public int Aylik { get; set; }
        public int Toplam { get; set; }
        public float OrtGun { get; set; }
        public float OrtHafta { get; set; }
        public float OrtAy { get; set; }
        string sorgu = "select Gunluk,Haftalik,Aylik,Toplam from Kullanici";

        public AdminVeriler()
        {
            hesapla();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\SeferMirza162803034\SeferMirza162803034\kelimelerDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        SqlCommand cmd;
        SqlDataReader dr;
        private void hesapla()
        {
            connection.Open();
            int i=0;
            cmd = new SqlCommand(sorgu, connection);
            dr =cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                Gunluk += Convert.ToInt32(dr.GetValue(0));
                Haftalik += Convert.ToInt32(dr.GetValue(1));
                Aylik+= Convert.ToInt32(dr.GetValue(2));
                Toplam+= Convert.ToInt32(dr.GetValue(3));
            }
            OrtGun = Gunluk / i;
            OrtHafta = Haftalik / i;
            OrtAy = Aylik / i;
            connection.Close();
        }
    }
}
