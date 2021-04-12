using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim.Core.DbTools
{
   

    public abstract class aRepository : IDisposable
    {
        
        #region Private Variables
        protected DbConnectionConfig connectionConfig;
        protected IDbConnection dbConnection;
        IDbTransaction transaction;
        public const int timeoutSec = 900;
        #endregion

        #region Construct
        protected aRepository(eConnectionType connectionType)
        {
            connectionConfig = DbConnectionConfig.GetDbConnection(connectionType);
            dbConnection = connectionConfig.Connection;
            dbConnection.Open();
        }
        #endregion

        #region BeginTransaction
        public void BeginTransaction()
        {
            checkConnection();
            transaction = dbConnection.BeginTransaction(IsolationLevel.ReadCommitted);
        }
        #endregion

        #region Count
        public int Count<T>() where T : class
        {
            var tableName = GetTableName(typeof(T));
            string sql = string.Format("SELECT COUNT(*) FROM {0}", tableName);
            return dbConnection.QueryFirst<int>(sql, transaction);
        }
        #endregion
        public IEnumerable<T> Query<T>(string sql, object param = null, int pageNumber = 0, int recordPerPage = 0) //where T : class
        {
            IEnumerable<T> result = null;

            result = dbConnection.Query<T>(sql, param, transaction, commandTimeout: timeoutSec);
            return result;
        }
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return dbConnection.GetAll<T>(transaction);
        }
        public T Get<T>(int id) where T : class
        {
            return dbConnection.Get<T>(id, transaction);
        }
        public long Insert<T>(T entity) where T : class
        {
            long result = -1;
            result = dbConnection.Insert(entity, transaction);
            return result;

        }
        public async Task<long> InsertAsync<T>(T entity) where T : class
        {
            long result = -1;
            result = await dbConnection.InsertAsync(entity, transaction, commandTimeout: timeoutSec);
            return result;
        }

        public bool Update<T>(T entity) where T : class
        {
            bool result = false;
            result = dbConnection.Update(entity, transaction);
            return result;
        }
        public bool Delete<T>(T entity) where T : class
        {
            bool result = false;
            result = dbConnection.Delete(entity, transaction);
            return result;
        }
        private  string GetTableName(Type type)
        {
            string result = type.Name;
            var attr = type.CustomAttributes.FirstOrDefault(w => w.AttributeType == typeof(TableAttribute));
            if (attr != null)
                result = attr.ConstructorArguments.First().Value.ToString();
            return result;
        }

        #region Commit & RollBack
        public void Commit(bool renewTransaction = false)
        {
            if (transaction == null) return;
            transaction.Commit();
            if (renewTransaction)
                transaction = dbConnection.BeginTransaction(IsolationLevel.ReadCommitted);
        }
        public void RollBack()
        {
            if (transaction == null || transaction.Connection == null) return;
            transaction.Rollback();
        }
        #endregion
        #region Check
        private void checkConnection()
        {
            if (dbConnection == null) return;
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
        }
        #endregion
        #region Dispose
        public void Dispose()
        {
            if (dbConnection == null) return;

            if ((transaction != null) && (transaction.Connection != null))
                transaction.Dispose();

            if (dbConnection.State != ConnectionState.Closed)
                dbConnection.Close();
            dbConnection.Dispose();
        }
        #endregion
    }
}
