/* ==============================================================================
  * 功能描述：ISqlText  
  * 创 建 者：nsb
  * 创建日期：2012-11-13 10:12:44
  * ==============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Service.SqlText
{
    /// <summary>
    /// ISqlText
    /// </summary>
    public interface ISqlText
    {
        string GetPageSqlText(string sql, int pagesize, int pageindex,string Key);
    }
}
