using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multidb
{
    public static class clTranState
    {
        public enum transactionState : int
        {
            start = 0,
            nostart = 1
        }
    }
}
