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
        void Open();
        DbConnection getConnection();
    }

}
