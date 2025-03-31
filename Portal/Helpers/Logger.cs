using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Portal.Helpers
{
    public static class Logger
    {
        public static void Log(string message)
        {
            string logDir = HttpContext.Current.Server.MapPath("~/logs");
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            string logPath = Path.Combine(logDir, "log.txt");
            File.AppendAllText(logPath, $"{DateTime.Now}: {message}\n");
        }
    }
}