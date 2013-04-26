using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
namespace Simple.DButils
{
    public  class Command
    {

        #region 私有属性
        private static string defaultProviderName = DbHelper.Instance.ProviderName;
        private static string defaultConnectionString = DbHelper.Instance.ConnectionString;
        private static Command instance = new Command(defaultConnectionString, defaultProviderName);
        public static Command Instance
        {
            get
            {
                return instance;
            }
        }

        private DbHelper dbHelper;

        public string ProviderName
        {
            get { return dbHelper.ProviderName; }
            set { dbHelper.ProviderName = value; }
        }

        public string ConnectionString
        {
            get { return dbHelper.ConnectionString; }
            set { dbHelper.ConnectionString = value; }
        }

        #endregion

        #region 构造函数
        public Command()
        {
            dbHelper = DbHelper.Instance;
;
        }

        public Command(string connectionString, string providerName)
        {
            dbHelper = new DbHelper(connectionString, providerName);
        }


        #endregion


        #region 创建对象
        public DbCommand CreateCommand()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(defaultProviderName);
            return dbfactory.CreateCommand();
        }


        #endregion
        #region 执行
        /// <summary>
        /// 运行一个SQL 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns>返回影响的行数</returns>
        public int RunSql(string sql, params DbParameter[] ps)
        {
            int num;

            DbCommand cmd = dbHelper.CreateSqlsCommand(sql);

            try
            {
                cmd.Parameters.AddRange(ps);
                cmd.Connection = dbHelper.CreateConnection();
                num = dbHelper.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }

            return num;
        }


        /// <summary>
        /// 运行一个SQL 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回影响的行数</returns>
        public int RunSql(string sql)
        {
            int num;

            DbCommand cmd = dbHelper.CreateSqlsCommand(sql);

            try
            {
                
                cmd.Connection = dbHelper.CreateConnection();
                num = dbHelper.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }

            return num;
        }


        /// <summary>
        /// 运行一个存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="ps"></param>
        /// <returns>返回影响的行</returns>
        public int RunProc(string procName, params DbParameter[] ps)
        {
            int num;

            DbCommand cmd = dbHelper.CreateProcCommand(procName);

            try
            {
                cmd.Parameters.AddRange(ps);
                cmd.Connection = dbHelper.CreateConnection();
                num = dbHelper.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                cmd.Dispose();
            }
            return num;
        }

        /// <summary>
        /// 获得一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public object GetVar(string sql, params DbParameter[] ps)
        {
            object o;

            DbCommand cmd = dbHelper.CreateSqlsCommand(sql);

            try
            {
                cmd.Parameters.AddRange(ps);
                cmd.Connection = dbHelper.CreateConnection();
                o = dbHelper.ExecuteScalar(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }

            return o;
        }

        /// <summary>
        /// 获得一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object GetVar(string sql)
        {
            object o;

            DbCommand cmd = dbHelper.CreateSqlsCommand(sql);

            try
            {
                
                cmd.Connection = dbHelper.CreateConnection();
                o = dbHelper.ExecuteScalar(cmd);
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }

            return o;
        }


        /// <summary>
        /// 获得一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object GetVar(DbCommand cmd)
        {
            object o;

           

            try
            {

                cmd.Connection = dbHelper.CreateConnection();
                o = dbHelper.ExecuteScalar(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }

            return o;
        }

        /// <summary>
        /// 获得一行数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public DataRow GetRow(string sql, params DbParameter[] ps)
        {
            DataTable dataTable = Select(sql, ps);
            if (dataTable != null)
            {
                if (dataTable.Rows.Count > 0)
                {
                    return Select(sql, ps).Rows[0];
                }
            }

            return null;
        }


        /// <summary>
        /// 获得一行数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public DataRow GetRow(DbCommand cmd)
        {
            DataTable dataTable = Select(cmd);
            if (dataTable != null)
            {
                if (dataTable.Rows.Count > 0)
                {
                    return Select(cmd).Rows[0];
                }
            }

            return null;
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns>返回自动产生的标识</returns>
        public object Insert(string sql, params DbParameter[] ps)
        {
            return GetVar(sql + ";select SCOPE_IDENTITY();", ps);
        }

        /// <summary>
        /// 执行update 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public int Update(string sql, params DbParameter[] ps)
        {
            return RunSql(sql, ps);
        }

        /// <summary>
        /// 执行删除操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public int Delete(string sql, params DbParameter[] ps)
        {
            return RunSql(sql, ps);
        }


        /// <summary>
        /// 执行删除操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public int Delete(string sql)
        {
            return RunSql(sql);
        }

        /// <summary>
        /// 执行select 操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public DataTable Select(string sql, params DbParameter[] ps)
        {

            DbCommand cmd = dbHelper.CreateSqlsCommand(sql);
            DataTable Dt = new DataTable();
            try
            {
                
                cmd.Parameters.AddRange(ps);
                cmd.Connection = dbHelper.CreateConnection();
                Dt = dbHelper.ExecuteDataTable(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }

            return Dt;
        }


        /// <summary>
        /// 执行select 操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Select(string sql)
        {

            DbCommand cmd = dbHelper.CreateSqlsCommand(sql);
            DataTable Dt = new DataTable();
            try
            {
                
                cmd.Connection = dbHelper.CreateConnection();
                Dt = dbHelper.ExecuteDataTable(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }

            return Dt;
        }



        /// <summary>
        /// 执行select 操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public DataTable Select(DbCommand cmd)
        {

            
            DataTable Dt = new DataTable();
            try
            {
                cmd.Connection = dbHelper.CreateConnection();
                Dt = dbHelper.ExecuteDataTable(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
            }

            return Dt;
        }


        /// <summary>
        /// 执行SQL 一行一行地读取
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string sql, params  DbParameter[] ps)
        {

            DbCommand cmd = dbHelper.CreateSqlsCommand(sql);
            try
            {
                cmd.Parameters.AddRange(ps);
                cmd.Connection = dbHelper.CreateConnection();
                return dbHelper.ExecuteReader(cmd);
            }
            catch (Exception e)
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                }
                throw e;
            }
        }

        public DbParameter CreateParameter()
        {
            return dbHelper.CreateParameter();
        }

        public DbParameter CreateParameter(string name, object value)
        {
            return dbHelper.CreateParameter(name, value);
        }

        public DbParameter CreateParameter(string name, object value, DbType dbType)
        {
            return dbHelper.CreateParameter(name, value, dbType);
        }

        public DbParameter CreateParameter(string name, object value, DbType dbType, int size)
        {
            return dbHelper.CreateParameter(name, value, dbType, size);
        }
        #endregion

        //protected static string ConnectionString
        //{
        //    get
        //    {
        //        return ConfigurationManager.AppSettings["Connection"].ToString();
        //    }
        //}


        //#region 存储过程操作


        ///// <summary>
        ///// 执行命令
        ///// </summary>
        ///// <param name="storedProcName">SQL语句</param>
        ///// <param name="parameters">命令参数</param>
        //public static void ExNonQuery(SqlParameter[] sqlparameter, string spName)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {

        //        SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, spName, sqlparameter);

        //    }
        //}




        ///// <summary>
        ///// 返回DataTABLE
        ///// </summary>
        ///// <param name="storedProcName">SQL语句</param>
        ///// <param name="parameters">命令参数</param>
        ///// <returns>DataSet</returns>
        //public static DataTable ExecuteDataTable(SqlParameter[] sqlparameter, string spName)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        DataSet ds = SqlHelper.ExecuteDataset(connection, System.Data.CommandType.Text, spName, sqlparameter);
        //        return ds.Tables[0];
        //    }

        //}
        //#endregion
    }
}
