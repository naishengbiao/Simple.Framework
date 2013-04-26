/* ==============================================================================
  * 功能描述：SqlPageText  
  * 创 建 者：nsb
  * 创建日期：2012-11-13 10:21:26
  * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Service.SqlText
{
    /// <summary>
    /// SqlPageText
    /// </summary>
    public class SqlPageText:ISqlText
    {

       
        #region ISqlText 成员

        public string GetPageSqlText(string sql, int pagesize, int pageindex,string Key)
        {
            int pos = sql.IndexOf("select", StringComparison.OrdinalIgnoreCase);
            int from = sql.IndexOf("from", StringComparison.OrdinalIgnoreCase);
            int wherer = sql.IndexOf("where", StringComparison.OrdinalIgnoreCase);
            if (pos < 0)
            {
                throw new ArgumentException("缺少select关键字", sql);
            }
            if (from < 0)
            {
                throw new ArgumentException("缺少from关键字", sql);
            }
            if (wherer < 0)
            {
                throw new ArgumentException("缺少wherer关键字", sql);
            }
            StringBuilder sb = new StringBuilder();
            
            sb.Append(string.Format("select top {0} {1} from {2}", pagesize, sql.Substring((pos + "select".Length), from - (pos + "select".Length)), sql.Substring((from + "from".Length), wherer - (from + "from".Length))));
            sb.Append(string.Format(" where {0} >=(SELECT ISNULL(MAX({0}),0) FROM (SELECT TOP ({1}*({2}-1)+1) {0} FROM {3} where {4}  )  A) and {4}", Key, pagesize, pageindex, sql.Substring((from + "from".Length), wherer - (from + "from".Length)), sql.Substring((wherer + "where".Length)).Replace("DESC","")));
            return sb.ToString();

        }

        #endregion
    }
}