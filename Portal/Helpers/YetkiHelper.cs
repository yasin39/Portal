
using Portal.Configuration;
using System.Data.SqlClient;

namespace Portal.Helpers
{
    public static class YetkiHelper
    {
        public static bool PersonelYetkisiVar(string sicilNo)
        {
            if (string.IsNullOrEmpty(sicilNo)) return false;

            string sorgu = "SELECT COUNT(*) FROM yetki WHERE Sicil_No = @Sicil AND Yetki_No = @YetkiKodu";

            using (var con = new SqlConnection(AppConfiguration.ConnectionString))
            using (var cmd = new SqlCommand(sorgu, con))
            {
                cmd.Parameters.AddWithValue("@Sicil", sicilNo);
                cmd.Parameters.AddWithValue("@YetkiKodu", Constants.PersonelYetkiKodu);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
