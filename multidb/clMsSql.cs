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
        private SqlConnection _conn;
        private SqlConnectionStringBuilder _StrSql;
        
        public DbConnection getConnection()
        {
            return this._conn;
        }

        private static clMsSql _Instance = null;
        public static clMsSql getInstance()
        {
            if (_Instance == null)
                _Instance = new clMsSql();
            return _Instance;
        }

        private clMsSql()
        {
            this._conn = new SqlConnection();
            this._StrSql = new SqlConnectionStringBuilder();
            this._StrSql.DataSource = "JONATHAN-NOTE";
            this._StrSql.InitialCatalog = "multidb";
            this._StrSql.UserID = "empresa";
            this._StrSql.Password = "123456";

            this._conn.ConnectionString = this._StrSql.ToString();
        }

        public void Open()
        {
            if (this._conn.State != ConnectionState.Open)
                this._conn.Open();

        }
    }
}
