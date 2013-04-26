using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Simple.Entity;
namespace Simple.IDal
{
    public interface IAdctab 
    {
       
        
        #region 操作
        int add(Adctab  model);
        int Update(Adctab  model);
        int Delete(object obj);
        int Delete(ArrayList array);
        #endregion
        
        #region 结果
        DataTable GetPageList(int pageindex, int pagesize, out int rowCount, Adctab  model);
        DataTable GetList(Adctab  model);
        DataTable GetAllList();
        DataRow GetRow(Adctab  model);
        int GetRowCount();
        #endregion
    }
}