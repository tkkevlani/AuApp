using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Configuration;

namespace AU.Common
{
    public static class LogWriter
    {
        private static string StoreLogs = ConfigurationManager.AppSettings["StoreAppLogs"].ToString();
        private static readonly ILog Log =
              LogManager.GetLogger("ADONetAppender");
        private static readonly ILog FileLog =
             LogManager.GetLogger("FileInfoAppender");

        public static void Error(Exception ex)
        {
            if (StoreLogs.ToString().ToUpper() == Convert.ToString("Database").ToUpper())
                Log.Error(ex.Message, ex);
            else
                FileLog.Error(ex.Message, ex);
        }
        public static void Error(string message, Exception ex)
        {
            if (StoreLogs.ToString().ToUpper() == Convert.ToString("Database").ToUpper())
                Log.Error(message, ex);
            else
                FileLog.Error(message, ex);
        }
        public static void Debug(string message)
        {
            if (StoreLogs.ToString().ToUpper() == Convert.ToString("Database").ToUpper())
                Log.Debug(message);
            else
                FileLog.Debug(message);
        }
        public static void Fatal(string message)
        {
            if (StoreLogs.ToString().ToUpper() == Convert.ToString("Database").ToUpper())
                Log.Fatal(message);
            else
                FileLog.Fatal(message);
        }
        public static void Info(string info)
        {
            if (StoreLogs.ToString().ToUpper() == Convert.ToString("Database").ToUpper())
                Log.Info(info);
            else
                FileLog.Info(info);
        }
        public static void Warn(string warning)
        {
            if (StoreLogs.ToString().ToUpper() == Convert.ToString("Database").ToUpper())
                Log.Warn(warning);
            else
                FileLog.Warn(warning);
        }

        public static void WriteIntoFile(Exception ex)
        {
            FileLog.Error(ex);
        }
    }
}
