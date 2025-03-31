using System.Configuration;

namespace Portal.Configuration
{
    public static class AppConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["Laptop"]?.ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ConfigurationErrorsException("Bağlantı dizesi bulunamadı.");
                }
                return connectionString;
            }
        }
    }
}