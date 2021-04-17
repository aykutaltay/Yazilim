using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yazilim.Core.DbTools;
using Yazilim.Core.Enums;
using Yazilim.Core.Log;
using Yazilim.Entities.Log;

namespace Yazilim.Core
{
    public static class DbLogger
    {
        public static void LogDb(string message, object data, string TableName = "General", eLogType logType = eLogType.NONE)
        {


            LogDb(new Logs()
            {
                LogDate = DateTime.Now,
                LogLevel = "INFO",
                LogMessage = message,
                LogObject = data.ToJsonString(),
                TableName = TableName,
                Thread = "Yazilim",
                LogType = logType.ToString()
            });
        }

        private static async void LogDb(Logs log)
        {
            try
            {
                /// sql lite loglama
                using (var rep = new Repository(eConnectionType.LogSqliteConnection))
                {
                    await rep.InsertAsync(log);
                }

                /// mmsql Loglama
                using (var rep = new Repository(eConnectionType.LogMssqlConnection))
                {
                    await rep.InsertAsync(log);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Logger.Error(ex.Message, ex);
            }
        }

    }
}
