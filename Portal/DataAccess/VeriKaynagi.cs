using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Portal.Configuration;

namespace Portal.DataAccess
{
    public static class VeriKaynagi
    {
        private static readonly string _connectionString = AppConfiguration.ConnectionString;
        public static DataTable SubeListesiGetir()
        {
            return VeriGetir("SELECT Birim_Ad FROM personel_birim ORDER BY Birim_Ad ASC");
        }

        public static DataTable UnvanListesiGetir()
        {
            return VeriGetir("SELECT Unvan FROM personel_unvan ORDER BY Unvan ASC");
        }

        public static DataTable OgrenimGecmisiGetir(string tcNo)
        {
            return VeriGetir($"SELECT TC_No, Ogr_Durumu, Okul, Bolum, Mezuniyet_Tarihi " +
                           $"FROM personel_ogrenim WHERE TC_No='{tcNo}' ORDER BY Mezuniyet_Tarihi ASC");
        }

        public static DataTable SendikaListesiGetir()
        {
            return VeriGetir("SELECT Sendika_Adi FROM personel_sendika ORDER BY Sendika_Adi ASC");
        }

        private static DataTable VeriGetir(string sorgu)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(sorgu, con))
            {
                con.Open();
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable KurumListesiGetir()
        {
            return VeriGetir("SELECT Kurum_Adi FROM personel_kurum ORDER BY Kurum_Adi ASC");
        }
    }
}
