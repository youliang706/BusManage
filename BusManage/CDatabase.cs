using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Com.Database
{
    internal class CDatabase
    {
        //构造函数
        public CDatabase() { }

        //析构函数
        ~CDatabase()
        {
            mConn.Close();
            mConn = null;
        }

        private static OracleConnection mConn;

        private static object lockObj = new object();

        //创建数据库连接
        public bool CreateConn(string connectionString)
        {
            try
            {
                mConn = new OracleConnection(connectionString);
                mConn.Open();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Execute(params string[] sql)
        {
            lock (lockObj)
            {
                //创建事物
                OracleTransaction st = mConn.BeginTransaction();

                OracleCommand command = new OracleCommand();
                command.Connection = mConn;
                command.Transaction = st;

                try
                {
                    for (int i = 0; i < sql.Length; i++)
                    {
                        command.CommandText = sql[i];
                        DebugSql(command.CommandText);
                        command.ExecuteNonQuery();
                    }

                    //提交事物
                    st.Commit();
                }
                catch (Exception ex)
                {
                    //回滚事物
                    st.Rollback();
                    throw ex;
                }
            }
        }

        public void Execute(List<string> sql)
        {
            lock (lockObj)
            {
                //创建事物
                OracleTransaction st = mConn.BeginTransaction();

                OracleCommand command = new OracleCommand();
                command.Connection = mConn;
                command.Transaction = st;

                try
                {
                    for (int i = 0; i < sql.Count; i++)
                    {
                        command.CommandText = sql[i];
                        DebugSql(command.CommandText);
                        command.ExecuteNonQuery();
                    }

                    //提交事物
                    st.Commit();
                }
                catch (Exception ex)
                {
                    //回滚事物
                    st.Rollback();
                    throw ex;
                }
            }
        }

        public DataTable GetRs(string sql)
        {
            DataTable dt = new DataTable();

            lock (lockObj)
            { 
                try
                {
                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.TableMappings.Add("Table", "rs");

                    OracleCommand command = new OracleCommand(sql, mConn);
                    command.CommandType = CommandType.Text;
                    DebugSql(command.CommandText);
                    adapter.SelectCommand = command;

                    DataSet dataSet = new DataSet("rs");
                    adapter.Fill(dataSet);

                    dt = dataSet.Tables["rs"];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return dt;
        }

        public DataSet GetDs(string table)
        {
            DataSet ds = new DataSet();

            lock (lockObj)
            {
                try
                {
                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.TableMappings.Add("Table", "rs");

                    OracleCommand command = new OracleCommand("SELECT * FROM " + table + " WHERE ROWNUM = 0", mConn);
                    command.CommandType = CommandType.Text;
                    DebugSql(command.CommandText);
                    adapter.SelectCommand = command;

                    DataSet dataSet = new DataSet("rs");
                    adapter.FillSchema(ds, SchemaType.Source);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return ds;
        }

        private readonly object obj = new object();

        public void DebugSql(string sql)
        {
            //Console.WriteLine(sql);

            lock (obj)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (!string.IsNullOrEmpty(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "log\\" + DateTime.Now.ToString("yyyyMMdd");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    path = path + "\\sql.log";
                    if (!File.Exists(path))
                    {
                        FileStream fs = File.Create(path);
                        fs.Close();
                    }
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                        sw.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                        sw.WriteLine(sql);
                        sw.WriteLine("");
                        sw.Close();
                    }
                }
            }
        }
    }
}


