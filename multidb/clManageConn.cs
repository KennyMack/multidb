using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace multidb
{
    public class clManageConn
    {
        #region Properties
        private DbConnection _connection;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">Current Connection</param>
        public clManageConn(DbConnection connection)
        {
            this._connection = connection;
        }
        #endregion

        #region Validates whether connection can change state
        /// <summary>
        /// Validates whether connection can change state
        /// </summary>
        /// <param name="State">Connection State</param>
        /// <returns>bool</returns>
        private bool connState(System.Data.ConnectionState State)
        {
            var ret = false;
            if (State == System.Data.ConnectionState.Open)
            {
                switch (this._connection.State)
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
                switch (this._connection.State)
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
        #endregion

        #region Open connection
        /// <summary>
        /// Open DB connection
        /// </summary>
        /// <returns>bool</returns>
        public bool Open()
        {
            try
            {
                if (this.connState(System.Data.ConnectionState.Open))
                    this._connection.Open();                
            }
            catch (DbException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Connection failed\r\nError cod.:{0}\r\nMessage:{1}", ex.ErrorCode, ex.Message));
                return false;
            }
            return true;
        }
        #endregion

        #region Close connection
        /// <summary>
        /// Close DB connection
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            try
            {
                if (this.connState(System.Data.ConnectionState.Closed))
                    this._connection.Close();
                return true;
            }
            catch (DbException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Connection failed\r\nError cod.:{0}\r\nMessage:{1}", ex.ErrorCode, ex.Message));
                return false;
            }
        }
        #endregion
        
    }

}
