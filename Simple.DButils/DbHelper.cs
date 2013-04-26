using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Simple.Util;
namespace Simple.DButils
{
    public sealed class DbHelper
    {
        #region 私有属性
        private static string defaultProviderName =ConfigHelp.GetConfigString("dbProviderName");
        private static string defaultConnectionString = ConfigHelp.GetConfigString("dbConnection");
        private static DbHelper instance = new DbHelper(defaultConnectionString, defaultProviderName);
        public static DbHelper Instance
        {
            get
            {
                return instance;
            }
        }


        private string providerName;
        private string connectionString;

        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        #endregion

        #region 构造函数
        public DbHelper()
        {

        }

        public DbHelper(string connectionString, string providerName)
        {
            this.connectionString = connectionString;
            this.providerName = providerName;
        }
        #endregion

        #region 创建对象
        public DbConnection CreateConnection()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            DbConnection dbconn = dbfactory.CreateConnection();
            dbconn.ConnectionString = connectionString;
            return dbconn;
        }

        public DbCommand CreateCommand()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            return dbfactory.CreateCommand();
        }

        public DbCommand CreateSqlsCommand(string sqls)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            DbCommand cmd = dbfactory.CreateCommand();
            cmd.CommandText = sqls;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        public DbCommand CreateProcCommand(string proc)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            DbCommand cmd = dbfactory.CreateCommand();
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public DbParameter CreateParameter()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            return dbfactory.CreateParameter();
        }

        public DbParameter CreateParameter(string name, object value)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            DbParameter p = dbfactory.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return p;
        }

        public DbParameter CreateParameter(string name, object value, DbType dbType)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            DbParameter p = dbfactory.CreateParameter();
            p.ParameterName = name;
            p.DbType = dbType;
            p.Value = value;
            return p;
        }

        public DbParameter CreateParameter(string name, object value, DbType dbType, int size)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            DbParameter p = dbfactory.CreateParameter();
            p.ParameterName = name;
            p.DbType = dbType;
            p.Value = value;
            p.Size = size;
            return p;
        }

        #endregion

        #region 执行
        public DataSet ExecuteDataSet(DbCommand cmd)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds);
            return ds;
        }

        public DataTable ExecuteDataTable(DbCommand cmd)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(providerName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            dbDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            cmd.Connection.Open();
            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public int ExecuteNonQuery(DbCommand cmd)
        {
            cmd.Connection.Open();
            int ret = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ret;
        }

        public object ExecuteScalar(DbCommand cmd)
        {
            cmd.Connection.Open();
            object ret = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return ret;
        }
        #endregion


    }
}
