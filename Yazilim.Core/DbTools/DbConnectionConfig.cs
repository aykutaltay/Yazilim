
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yazilim.Core.DbTools
{
    public class DbConnectionConfig
    {

        #region Public Static Methods
        public static DbConnectionConfig GetDbConnection(eConnectionType connectionType)
        {
            DbConnectionConfig result = new DbConnectionConfig();

            switch (connectionType)
            {
                case eConnectionType.CubeConnection:
                    result.ConnectionString = "";
                    result.Connection = new SqlConnection(result.ConnectionString);
                    break;
                case eConnectionType.KPConnection:
                    result.ConnectionString = "";
                    result.Connection = new SqlConnection(result.ConnectionString);
                    break;
                case eConnectionType.LogSqliteConnection:


                    Path.GetFullPath(Path.Combine(Application.StartupPath, @"../"));

                    string VeriTabaniyolu = @"F:\Projeler\TestOrtami\KatmanliMimari\Yazilim\Yazilim\Yazilim.Core\Data\DBLogs.db";
                    result.ConnectionString =("Data Source=" + VeriTabaniyolu);


                    result.Connection = new SQLiteConnection(result.ConnectionString);
                    break;

                default:
                    throw new ArgumentNullException("connectionType", "Bağlantı tipi parametresi boş olamaz....");
            }

            return result;
        }
        #endregion

        #region Public Properties
        public IDbConnection Connection { get; private set; }
        public string ConnectionString { get; private set; }
        #endregion
    }
}
