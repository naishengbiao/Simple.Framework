using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using Simple.IDal;
using Simple.DButils;
using Simple.Util;
using Simple.Entity;
using Simple.Service.SqlText;
namespace Simple.Dal
{
    public class AdctabDal:IAdctab
    {
        #region 属性
        /// <summary>
        /// 查询结果字段
        /// </summary>
        protected virtual string SelectedFields
        {
            get
            {
                return "adcName as AdcName, adcSex as AdcSex, adcAge as AdcAge, adcStatus as AdcStatus, aid as Aid";
            }
        }
        
        /// <summary>
        /// 默认排序规则
        /// </summary>
        protected virtual string OrderBy
        {
            get
            {
                return " ORDER BY aid DESC ";
            }
        }
        
        #endregion
        
        #region 构造函数
        public AdctabDal()
        {}
        #endregion
        
        #region 方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">新增信息</param>
        public int add(Adctab  model)
        {
            string sql = "INSERT INTO adctab (adcName, adcSex, adcAge, adcStatus) values (@AdcName, @AdcSex, @AdcAge, @AdcStatus)";
            Command db = new Command();
            DbParameter[] ps = new DbParameter[4];
            ps[0] = db.CreateParameter("@AdcName", model.AdcName,DbType.AnsiString);
            ps[1] = db.CreateParameter("@AdcSex", model.AdcSex,DbType.AnsiStringFixedLength);
            ps[2] = db.CreateParameter("@AdcAge", model.AdcAge,DbType.Int32);
            ps[3] = db.CreateParameter("@AdcStatus", model.AdcStatus,DbType.Int32);
            
            
            return Convert.ToInt32(db.Insert(sql,ps));
        }
        
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">修改对象</param>
        public int Update(Adctab  model)
        {
            string sql = "UPDATE adctab SET adcName = @AdcName, adcSex = @AdcSex, adcAge = @AdcAge, adcStatus = @AdcStatus WHERE 1=1  AND aid = @Aid";
            Command db = new Command();
            DbParameter[] ps = new DbParameter[5];
            ps[0] = db.CreateParameter("@AdcName", model.AdcName,DbType.AnsiString);
            ps[1] = db.CreateParameter("@AdcSex", model.AdcSex,DbType.AnsiStringFixedLength);
            ps[2] = db.CreateParameter("@AdcAge", model.AdcAge,DbType.Int32);
            ps[3] = db.CreateParameter("@AdcStatus", model.AdcStatus,DbType.Int32);
            ps[4] = db.CreateParameter("@Aid", model.Aid,DbType.Int32);
            
            return db.Update(sql,ps);
        }
        
        
        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <param name="obj">对象</param>
        public int Delete(object obj)
        {

            string sql = "DELETE adctab WHERE 1=1  AND aid = @Aid";
            Command db = new Command();
            DbParameter[] ps = new DbParameter[1];
            
            ps[0] = db.CreateParameter("@Aid", obj,DbType.Int32);
            
            return db.Delete(sql,ps);
        }
        
        
        /// <summary>
        /// 删除多条记录【批量】
        /// </summary>
        /// <param name="array">数组</param>
        public int Delete(ArrayList array)
        {
            
            if (array == null || array.Count == 0)
                throw new ArgumentNullException("array");
            string sql = string.Format("DELETE adctab  where aid in({0})", StringHelp.Join(array));
            Command db = new Command();

            return db.Delete(sql);
        }
        
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">分页大小</param>
        /// <param name="rowCount">输出总行数</param>
        /// <param name="model">查询对象</param>
        public  DataTable GetPageList(int pageindex, int pagesize, out int rowCount, Adctab  model)
        {
            string strwhere = " 1=1 ";
            
            Command db = new Command();
            DbCommand cmd = db.CreateCommand();
            
            #region -- 主键区 --
            
            if(model.Aid > 0)
            {
                
                strwhere += " and aid = @Aid";
                cmd.Parameters.Add(db.CreateParameter("@Aid", model.Aid,DbType.Int32));
                
            }
            #endregion
            
            #region -- 数字区 --
            if(model.AdcAge > 0)
            {
                strwhere += " and adcAge = @AdcAge";
                cmd.Parameters.Add(db.CreateParameter("@AdcAge", model.AdcAge,DbType.Int32));
            }
            
            if(model.AdcStatus > 0)
            {
                strwhere += " and adcStatus = @AdcStatus";
                cmd.Parameters.Add(db.CreateParameter("@AdcStatus", model.AdcStatus,DbType.Int32));
            }
            
            
            #endregion
            
            #region -- 字符区 --
            if(!string.IsNullOrEmpty(model.AdcName))
            {
                strwhere += " and adcName like  @AdcName+'%'";
                cmd.Parameters.Add(db.CreateParameter("@AdcName", model.AdcName,DbType.AnsiString));
            }
            if(!string.IsNullOrEmpty(model.AdcSex))
            {
                strwhere += " and adcSex = @AdcSex";
                cmd.Parameters.Add(db.CreateParameter("@AdcSex", model.AdcSex,DbType.AnsiStringFixedLength));
            }
            #endregion

            string sql = String.Format("SELECT {0} FROM adctab where {1} {2}", SelectedFields,strwhere, OrderBy);
            string countSql = "SELECT COUNT(*) FROM adctab where " + strwhere;
            cmd.CommandText = countSql;
            rowCount = Convert.ToInt32(db.GetVar(cmd));

            ISqlText sqlPage = SqlFactory.CreateSqlDialect();
            string sqlPageText = sqlPage.GetPageSqlText(sql, pagesize, pageindex, "aid");
            
			cmd.CommandText = sqlPageText;
            return db.Select(cmd);
           
        }
        
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="model">查询对象</param>
        public DataTable GetList(Adctab  model)
        {
            string strwhere = " 1=1 ";
            
            Command db = new Command();
            DbCommand cmd = db.CreateCommand();
            
            #region -- 主键区 --
            
            if(model.Aid > 0)
            {
                
                strwhere += " and aid = @Aid";
                cmd.Parameters.Add(db.CreateParameter("@Aid", model.Aid,DbType.Int32));
                
            }
            #endregion
            
            #region -- 数字区 --
            if(model.AdcAge > 0)
            {
                strwhere += " and adcAge = @AdcAge";
                cmd.Parameters.Add(db.CreateParameter("@AdcAge", model.AdcAge,DbType.Int32));
            }
            
            if(model.AdcStatus > 0)
            {
                strwhere += " and adcStatus = @AdcStatus";
                cmd.Parameters.Add(db.CreateParameter("@AdcStatus", model.AdcStatus,DbType.Int32));
            }
            
            
            #endregion
            
            #region -- 字符区 --
            if(!string.IsNullOrEmpty(model.AdcName))
            {
                strwhere += " and adcName = @AdcName";
                cmd.Parameters.Add(db.CreateParameter("@AdcName", model.AdcName,DbType.AnsiString));
            }
            if(!string.IsNullOrEmpty(model.AdcSex))
            {
                strwhere += " and adcSex = @AdcSex";
                cmd.Parameters.Add(db.CreateParameter("@AdcSex", model.AdcSex,DbType.AnsiStringFixedLength));
            }
            #endregion
            
            string sql = String.Format("SELECT {0} FROM adctab where {1} {2}", SelectedFields,strwhere, OrderBy);
            cmd.CommandText = sql;
            return db.Select(cmd);
            
        }
        
        /// <summary>
        /// 获取全部数据
        /// </summary>
        public DataTable GetAllList()
        {
             string strwhere = " 1=1 ";
            
            Command db = new Command();

            string sql = String.Format("SELECT {0} FROM adctab where {1} {2}", SelectedFields,strwhere, OrderBy);
            return db.Select(sql);
        }
        
        /// <summary>
        /// 获取行数据
        /// </summary>
        /// <param name="model">查询对象</param>
        public DataRow GetRow(Adctab  model)
        {
            string strwhere = " 1=1 ";
            
            Command db = new Command();
            DbCommand cmd = db.CreateCommand();
            
            #region -- 主键区 --
            
            if(model.Aid > 0)
            {
                
                strwhere += " and aid = @Aid";
                cmd.Parameters.Add(db.CreateParameter("@Aid", model.Aid,DbType.Int32));
                
            }
            #endregion
            
            #region -- 数字区 --
            if(model.AdcAge > 0)
            {
                strwhere += " and adcAge = @AdcAge";
                cmd.Parameters.Add(db.CreateParameter("@AdcAge", model.AdcAge,DbType.Int32));
            }
            
            if(model.AdcStatus > 0)
            {
                strwhere += " and adcStatus = @AdcStatus";
                cmd.Parameters.Add(db.CreateParameter("@AdcStatus", model.AdcStatus,DbType.Int32));
            }
            
            
            #endregion
            
            #region -- 字符区 --
            if(!string.IsNullOrEmpty(model.AdcName))
            {
                strwhere += " and adcName = @AdcName";
                cmd.Parameters.Add(db.CreateParameter("@AdcName", model.AdcName,DbType.AnsiString));
            }
            if(!string.IsNullOrEmpty(model.AdcSex))
            {
                strwhere += " and adcSex = @AdcSex";
                cmd.Parameters.Add(db.CreateParameter("@AdcSex", model.AdcSex,DbType.AnsiStringFixedLength));
            }
            #endregion
            
            string sql = String.Format("SELECT {0} FROM adctab where {1} {2}", SelectedFields,strwhere, OrderBy);
            cmd.CommandText = sql;
            return db.GetRow(cmd);
            
        }
        
        /// <summary>
        /// 获取数据总数
        /// </summary>
        public int GetRowCount()
        {
            string strwhere = " 1=1 ";
            
            Command db = new Command();
            string sql = "SELECT COUNT(*) FROM adctab where " + strwhere;
            return Convert.ToInt32(db.GetVar(sql));
        }
        #endregion
    }
}
