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
        private MySqlTransaction _transac = null;

        public DbConnection getConnection()
        {
            return this._conn;
        }

        public DbConnection getConnection(clTranState.transactionState transaction)
        {
            if (transaction == clTranState.transactionState.start)
                this.beginTransaction();
            return this.getConnection();
        }

        public DbTransaction getTransaction()
        {
            if (this._transac != null)
                return this._transac;
            else
            {
                this.beginTransaction();
                return this._transac;
            }
        }
        
        public void beginTransaction()
        {
            this._transac = this._conn.BeginTransaction();
        }

        public bool Commit()
        {
            try
            {
                if (this._transac != null)
                    this._transac.Commit();
                this._transac = null;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Commit failed\r\nError cod.:{0}\r\nMessage:{1}", ex.ErrorCode, ex.Message));
                return false;
            }
            return true;
        }

        public bool Commit(bool close)
        {
            if (this.Commit() &&
                this.Close())
                return true;
            else
                return false;
        }

        public bool RollBack()
        {
            try
            {
                if (this._transac != null)
                    this._transac.Rollback();
                this._transac = null;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("RollBack failed\r\nError cod.:{0}\r\nMessage:{1}", ex.ErrorCode, ex.Message));
                return false;
            }
            return true;
        }

        public bool RollBack(bool close)
        {
            if (this.RollBack() &&
                this.Close())
                return true;
            else
                return false;
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
        
        private bool connState(System.Data.ConnectionState State)
        {
            var ret = false;
            if (State == System.Data.ConnectionState.Open)
            {
                switch (this._conn.State)
                {
                    case System.Data.ConnectionState.Broken:
                        ret = true;
                        break;
                    case System.Data.ConnectionState.Closed:
                        ret = true;
                        break;
                    case System.Data.ConnectionState.Connecting:
                        ret = false;
                        break;
                    case System.Data.ConnectionState.Executing:
                        ret = false;
                        break;
                    case System.Data.ConnectionState.Fetching:
                        ret = false;
                        break;
                    case System.Data.ConnectionState.Open:
                        ret = false;
                        break;
                }
            }
            else
            {
                switch (this._conn.State)
                {
                    case System.Data.ConnectionState.Broken:
                        ret = false;
                        break;
                    case System.Data.ConnectionState.Closed:
                        ret = false;
                        break;
                    case System.Data.ConnectionState.Connecting:
                        ret = false;
                        break;
                    case System.Data.ConnectionState.Executing:
                        ret = false;
                        break;
                    case System.Data.ConnectionState.Fetching:
                        ret = false;
                        break;
                    case System.Data.ConnectionState.Open:
                        ret = true;
                        break;
                }
            }
            return ret;
        }

        public bool Open()
        {
            try
            {
                if (this.connState(System.Data.ConnectionState.Open))
                    this._conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Connection failed\r\nError cod.:{0}\r\nMessage:{1}", ex.ErrorCode, ex.Message));
                return false;
            }
            
        }

        public bool Close()
        {
            try
            {
                if (this.connState(System.Data.ConnectionState.Closed))
                    this._conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Connection failed\r\nError cod.:{0}\r\nMessage:{1}", ex.ErrorCode, ex.Message));
                return false;
            }
        }

        public bool Close(bool commit)
        {
            return this.Commit(true);
        }

        public void Dispose()
        {
            this.RollBack(true);
            if (_Instance != null)
                _Instance = null;
        }

       
    
    }
}
