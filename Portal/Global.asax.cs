using System;
using System.Web.UI;

namespace Portal
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-3.6.0.min.js", // jQuery dosyanızın yolunu kontrol edin
                DebugPath = "~/Scripts/jquery-3.6.0.js", // Hata ayıklama sürümünün yolu (opsiyonel)
                CdnPath = "https://code.jquery.com/jquery-3.6.0.min.js", // CDN alternatifi (opsiyonel)
                CdnDebugPath = "https://code.jquery.com/jquery-3.6.0.js" // CDN hata ayıklama (opsiyonel)
            });
        }
    }
}