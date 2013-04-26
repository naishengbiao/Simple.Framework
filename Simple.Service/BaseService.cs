using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Simple.DButils;
namespace Simple.Service
{
    public class BaseService:IDisposable
    {
        private DbConnection conn;
        private DbTransaction dbTrans;
        private DbHelper dbHelper;

        public BaseService()
        {
            dbHelper = DbHelper.Instance;
        }
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


        protected DbConnection DbConnection
        {
            get { return this.conn; }
        }
        protected DbTransaction DbTrans
        {
            get { return this.dbTrans; }
        }

        protected void BeginTransaction()
        {
            conn = dbHelper.CreateConnection();
            conn.Open();
            dbTrans = conn.BeginTransaction();
        }


        protected void Commit()
        {
            dbTrans.Commit();
            this.Colse();
        }

        protected void RollBack()
        {
            dbTrans.Rollback();
            this.Colse();
        }

        public void Dispose()
        {
            this.Colse();
        }

        protected void Colse()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }




        #region IDisposable 成员

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
