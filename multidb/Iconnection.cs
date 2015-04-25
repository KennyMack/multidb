using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multidb
{
    interface Iconnection
    {
        bool Open();
        bool Close();
        bool Close(bool commit);
        DbTransaction getTransaction();
        DbConnection getConnection();
        DbConnection getConnection(clTranState.transactionState transaction);
        bool Commit();
        bool Commit(bool close);
        bool RollBack();
        bool RollBack(bool close);
        void Dispose();

    }

}
