/* ==============================================================================
  * 功能描述：OraclePageText  
  * 创 建 者：nsb
  * 创建日期：2012-11-13 17:26:11
  * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Service.SqlText
{
    /// <summary>
    /// OraclePageText
    /// </summary>
    public class OraclePageText:ISqlText
    {
        public OraclePageText()
        { 
        }

        #region ISqlText 成员

        public string GetPageSqlText(string sql, int pagesize, int pageindex, string Key)
        {
            if (string.IsNullOrEmpty(sql))
            {
                return sql;
            }
            int startIndex = (pageindex - 1) * pagesize;
            int endIndex = startIndex + pagesize;
            return string.Format("SELECT * FROM ( SELECT row_.*, rownum rownum_ FROM ({0}) row_ WHERE rownum <= {1}) where rownum_ > {2} ", sql, endIndex, startIndex);

        }


        public string GetPageSqlText(string sql, int pagesize, int pageindex)
        {
            return GetPageSqlText(sql, pagesize, pageindex, "");
        }
        #endregion
    }
}