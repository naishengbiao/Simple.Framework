using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Simple.Dal;
using Simple.DALFactory;
using Simple.IDal;
using Simple.Service.DataAcess;
using Simple.Entity;

namespace Simple.Bll
{
    public class AdctabBll:BaseService
    {
        private readonly IAdctab Dal=CreateInstanceDal.CreateDal("AdctabDal") as AdctabDal; 
        
        public AdctabBll()
        {}
        
        public static AdctabBll Instance
        {
            get
            {
                return new AdctabBll();
            }
        }
        
        
        #region 方法
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">新增信息</param>
        public int add(Adctab  model)
        {

            return Dal.add(model);
        }
        
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">修改对象</param>
        public int Update(Adctab  model)
        {
            return Dal.Update(model);
        }
        
        
        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <param name="obj">对象</param>
        public int Delete(object obj)
        {
           return Dal.Delete(obj);
        }
        
        
        /// <summary>
        /// 删除多条记录【批量】
        /// </summary>
        /// <param name="array">数组</param>
        public int Delete(ArrayList array)
        {
            return Dal.Delete(array);
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
            return Dal.GetPageList(pageindex,pagesize,out rowCount,model);
           
        }
        
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="model">查询对象</param>
        public DataTable GetList(Adctab  model)
        {
            return Dal.GetList(model);
        }
        
        /// <summary>
        /// 获取全部数据
        /// </summary>
        public DataTable GetAllList()
        {
              return Dal.GetAllList();
        }
        
        /// <summary>
        /// 获取行数据
        /// </summary>
        /// <param name="model">查询对象</param>
        public DataRow GetRow(Adctab  model)
        {
             return Dal.GetRow(model);
        }
        
        /// <summary>
        /// 获取数据总数
        /// </summary>
        public int GetRowCount()
        {
            return Dal.GetRowCount();
        }
        #endregion
        
    }
}