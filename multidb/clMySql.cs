using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
namespace multidb
{
    public class clMySql : Iconnection
    {
        private MySqlConnectionStringBuilder _StrSql;
        private MySqlConnection _conn;

        public DbConnection getConnection()
        {
            return this._conn;
        }

        #region Instance
        private static clMySql _Instance = null;
        public static clMySql getInstance()
        {
            if (_Instance == null)
                _Instance = new clMySql();
            return _Instance;
        }
        #endregion

        #region Constructor
        private clMySql()
        {
            this._conn = new MySqlConnection();
            this._StrSql = new MySqlConnectionStringBuilder();
            this._StrSql.Database = "multidb";
            this._StrSql.Server = "127.0.0.1";
            this._StrSql.Password = "123456";
            this._StrSql.UserID = "root";
            this._StrSql.Port = 3306;
            this._conn.ConnectionString = this._StrSql.ToString();
        }
        #endregion
        
        public void Open()
        {
            if (this._conn.State != System.Data.ConnectionState.Open)
                this._conn.Open();

        }

        
        
    
    }
}
