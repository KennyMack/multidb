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
    public static class clCommand
    {
        private static Iconnection conn = null;
        private static DbCommand cmd = null;
        private static Iconnection getConnection(string database)
        {            
            if (clDbTypes.MySql == database)
            {
                conn = clMySql.getInstance();
            }
            else if (clDbTypes.MsSql == database)
            {
                conn = clMsSql.getInstance();
            }
            return conn;
        }

        private static DbCommand getCommand(string database)
        {

            if (clDbTypes.MySql == database)
            {
                cmd = new MySqlCommand();
            }
            else if (clDbTypes.MsSql == database)
            {
                cmd = new SqlCommand();
            }
            return cmd;
        }

        private static void setDefault(DbTransaction tran = null, System.Data.CommandType type = System.Data.CommandType.Text)
        {
            cmd.Connection = conn.getConnection();
            cmd.Transaction = tran;
            cmd.CommandType = type;
        }

        public static DbCommand Command(string database, string sql)
        {       
            conn = clCommand.getConnection(database);
            cmd = clCommand.getCommand(database);
            setDefault();
            cmd.CommandText = sql;
            
            conn.Open();
            return cmd;
        }

        public static DbCommand Command(string database, string sql, System.Data.CommandType type)
        {
            conn = clCommand.getConnection(database);
            cmd = clCommand.getCommand(database);
            setDefault(null, type);
            cmd.CommandText = sql;

            conn.Open();
            return cmd;
        }
        public static DbCommand Command(string database, string sql, DbTransaction tran)
        {
            conn = clCommand.getConnection(database);
            cmd = clCommand.getCommand(database);
            setDefault(tran);
            cmd.CommandText = sql;

            conn.Open();
            return cmd;
        }

        public static DbCommand Command(string database, string sql, DbTransaction tran, System.Data.CommandType type)
        {
            conn = clCommand.getConnection(database);
            cmd = clCommand.getCommand(database);
            setDefault(tran, type);
            cmd.CommandText = sql;

            conn.Open();
            return cmd;
        }
    }
    
}
