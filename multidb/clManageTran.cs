using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multidb
{
    public class clManageTran
    {
        #region Properties
        private DbConnection _connection;
        private DbTransaction _transac = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public clManageTran(DbConnection connection)
        {
            this._connection = connection;
        }
        #endregion

        #region Return transaction
        /// <summary>
        /// Returns the current transaction
        /// </summary>
        /// <returns>DbTransaction</returns>
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
        #endregion

        #region Start transaction
        /// <summary>
        /// Start a new transaction
        /// </summary>
        public void beginTransaction()
        {
            if (this._connection != null &&
                this._transac == null &&
                this._connection.State == System.Data.ConnectionState.Open)
                this._transac = this._connection.BeginTransaction();
        }
        #endregion

        #region Commit the transaction
        /// <summary>
        /// Commit the current transaction
        /// </summary>
        /// <returns>bool</returns>
        public bool Commit()
        {
            try
            {
                if (this._transac != null)
                    this._transac.Commit();
                this._transac = null;
            }
            catch (DbException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Commit failed\r\nError cod.:{0}\r\nMessage:{1}", ex.ErrorCode, ex.Message));
                return false;
            }
            return true;
        }
        #endregion

        #region Rollback the transaction
        /// <summary>
        /// Rollback the current transaction
        /// </summary>
        /// <returns>bool</returns>
        public bool RollBack()
        {
            try
            {
                if (this._transac != null)
                    this._transac.Rollback();
                this._transac = null;
            }
            catch (DbException ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("RollBack failed\r\nError cod.:{0}\r\nMessage:{1}", ex.ErrorCode, ex.Message));
                return false;
            }
            return true;
        }
        #endregion
        

    }
}
