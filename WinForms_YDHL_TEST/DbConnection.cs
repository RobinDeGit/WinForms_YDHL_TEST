﻿using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_YDHL_TEST
{
    public class DbConnection
    {
//        private static string connString = @"Data Source=KYEECIS; User ID=kyeecis;Password=kyeecis;Pooling=true;Min Pool Size=2;Max Pool Size=1500;";//郭升数据库连接串

        private static string connString1 = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                + "10.180.7.204" + ")(PORT = " + "1521" + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                + "orcl" + ")));Password=" + "kyeecis" + ";User ID=" + "kyeecis";

        private static OracleConnection _orcl_conn = new OracleConnection { ConnectionString = connString1 };

        public static OracleConnection getConn()
        {
            if (_orcl_conn.State != ConnectionState.Open)
                _orcl_conn.Open();
            return _orcl_conn;
        }

        public static DataTable ExecSql(string sql)
        {
            _orcl_conn.Open();
            OracleCommand com = _orcl_conn.CreateCommand();
            OracleTransaction m_OraTrans = _orcl_conn.BeginTransaction(IsolationLevel.ReadCommitted);//创建事务对象
            com.Transaction = m_OraTrans;
            com.CommandText = sql;

            OracleDataAdapter oda = new OracleDataAdapter(com);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            _orcl_conn.Close();
            com.Dispose();
            return dt;
        }


        public static void CloseConnet()
        {
            if (_orcl_conn.State != ConnectionState.Open)
                _orcl_conn.Close();

            return;
        }

        public static string ConnString
        {
            get
            {
                return connString1;
            }

            set
            {
                connString1 = value;
            }
        }

        public static string ConnString1
        {
            get
            {
                return connString1;
            }

            set
            {
                connString1 = value;
            }
        }
    }
}
