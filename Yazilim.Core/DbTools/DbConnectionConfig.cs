
using MySql.Data.MySqlClient;
using Npgsql;
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

        #region Public Static Methods-
        public static DbConnectionConfig GetDbConnection(eConnectionType connectionType)
        {
            DbConnectionConfig result = new DbConnectionConfig();
            string VeriTabaniyolu = "";
            switch (connectionType)
            {
                case eConnectionType.MysqlConnection:
                    result.ConnectionString = "";
                    result.Connection = new MySqlConnection(result.ConnectionString);
                    break;
                case eConnectionType.PostgreSQL:
                    result.ConnectionString = "";
                    result.Connection = new NpgsqlConnection(result.ConnectionString);
                    break;
                case eConnectionType.LogSqliteConnection:
                     VeriTabaniyolu = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName+"\\Yazilim.Core\\Data\\", "DBLogs.db");
                    result.ConnectionString =("Data Source=" + VeriTabaniyolu);
                    result.Connection = new SQLiteConnection(result.ConnectionString);
                    break;

                case eConnectionType.LogMssqlConnection:
                    VeriTabaniyolu = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Yazilim.Core\\Data\\", "MsDBLogs.mdf");
                    result.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + VeriTabaniyolu + ";Integrated Security=True";
                    result.Connection = new SqlConnection(result.ConnectionString);
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
