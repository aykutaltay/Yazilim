using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC = Dapper.Contrib.Extensions;

namespace Yazilim.Entities.Log
{
    [DC.Table("Logs")]
    public class Logs
    {
        [Browsable(false)]
        [DC.Key]
        public int LogId { get; set; }
        [DisplayName("Log Zaman")]
        public DateTime LogDate { get; set; }
        [DisplayName("Konu")]
        public string Thread { get; set; }
        [DisplayName("Seviyesi")]
        public string LogLevel { get; set; }
        [DisplayName("LogTipi")]
        public string LogType { get; set; }
        [DisplayName("LogMesaj")]
        public string LogMessage { get; set; }
     
        [DisplayName("LogListesi")]
        public string LogObject { get; set; }
        [DisplayName("Tablo")]
        public string TableName { get; set; }
    }
}
