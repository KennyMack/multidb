using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multidb
{
    public static class clCommand<T>
    {
        static Iconnection conn = null;

        public static DbCommand Command(string sql)
        {            
            DbCommand cmd = null;
            if (typeof(T) == typeof(clMySql))
            {
                conn = clMySql.getInstance();
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;
            }
            else if (typeof(T) == typeof(clMsSql))
            {
                conn = clMsSql.getInstance();
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn.getConnection();
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;
            }
            return cmd;
        }
    }
    
    /*public class dbType
    {
        public string type { get; private set; }
        public dbType(string ptype)
        {
            this.type = ptype;
        }
    }*/
}
