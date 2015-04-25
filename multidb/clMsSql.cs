using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Data.Common;

namespace multidb
{
    public class clMsSql : Iconnection
    {
        #region Properties
        private SqlConnection _conn;
        private SqlConnectionStringBuilder _StrSql;
        private clManageConn _manage = null;
        private clManageTran _tranmanage = null;
        #endregion        

        #region Instance
        private static clMsSql _Instance = null;
        /// <summary>
        /// Singleton instance
        /// </summary>
        /// <returns></returns>
        public static clMsSql getInstance()
        {
            if (_Instance == null)
                _Instance = new clMsSql();
            return _Instance;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        private clMsSql()
        {
            this._conn = new SqlConnection();
            this._StrSql = new SqlConnectionStringBuilder();
            this._StrSql.DataSource = "JONATHAN-NOTE";
            this._StrSql.InitialCatalog = "multidb";
            this._StrSql.UserID = "empresa";
            this._StrSql.Password = "123456";
            this._conn.ConnectionString = this._StrSql.ToString();
            this._manage = new clManageConn(this._conn);
            this._tranmanage = new clManageTran(this._conn);
        }
        #endregion
        
        #region Returns connection
        /// <summary>
        /// Returns connection to instance
        /// </summary>
        /// <returns>DbConnection</returns>
        public DbConnection getConnection()
        {
            return this._conn;
        }
        #endregion

        #region Returns connection with aditional option creates a transaction
        /// <summary>
        /// Returns connection with aditional option creates a transaction
        /// </summary>
        /// <param name="transaction">Option to creates transaction</param>
        /// <returns>DbConnection</returns>
        public DbConnection getConnection(clTranState.transactionState transaction)
        {
            if (transaction == clTranState.transactionState.start)
                this.beginTransaction();
            return this.getConnection();
        }
        #endregion

        #region Open Connection
        /// <summary>
        /// Open connection with bd
        /// </summary>
        /// <returns>bool</returns>
        public bool Open()
        {
            return this._manage.Open();
        }
        #endregion

        #region Close Connection
        /// <summary>
        /// Close connection with bd
        /// </summary>
        /// <returns>bool</returns>
        public bool Close()
        {
            return this._manage.Close();
        }
        #endregion

        #region Close connection and optionaly commit the current transaction
        /// <summary>
        /// Close connection and optionaly commit the current transaction
        /// </summary>
        /// <param name="commit">Commit Current Transaction</param>
        /// <returns></returns>
        public bool Close(bool commit)
        {
            if (commit)
                return this.Commit(true);
            else
                return this.RollBack(true);
        }
        #endregion

        #region Return current transaction
        /// <summary>
        /// Return current transaction
        /// </summary>
        /// <returns>DbTransaction</returns>
        public DbTransaction getTransaction()
        {
            this._manage.Open();
            return this._tranmanage.getTransaction();
        }
        #endregion

        #region Start a new db Transaction
        /// <summary>
        /// Start a new db transaction
        /// </summary>
        public void beginTransaction()
        {
            this._tranmanage.beginTransaction();
        }
        #endregion

        #region Commit the current transaction
        /// <summary>
        /// Commit the current transaction
        /// </summary>
        /// <returns>bool</returns>
        public bool Commit()
        {
            return this._tranmanage.Commit();
        }
        #endregion

        #region Commit the current transaction and close connection
        /// <summary>
        /// Commit the current transaction and optionaly close connection
        /// </summary>
        /// <param name="close">Close connection</param>
        /// <returns>bool</returns>
        public bool Commit(bool close)
        {
            return (this.Commit() && (close ? this.Close() : true));
        }
        #endregion

        #region Rollback the current transaction
        /// <summary>
        /// Rollback the current transaction
        /// </summary>
        /// <returns>bool</returns>
        public bool RollBack()
        {
            return this._tranmanage.RollBack();
        }
        #endregion

        #region Rollback the current transaction and optionaly close connection
        /// <summary>
        /// Rollback the current transaction and optionaly close connection
        /// </summary>
        /// <param name="close">close connection</param>
        /// <returns>bool</returns>
        public bool RollBack(bool close)
        {
            return (this.RollBack() && (close ? this.Close() : true));
        }
        #endregion

        #region Dispose the current connection instance
        /// <summary>
        /// Dispose the current connection instance
        /// </summary>
        public void Dispose()
        {
            this.RollBack(true);
            if (_Instance != null)
                _Instance = null;
        }
        #endregion
    }
}
