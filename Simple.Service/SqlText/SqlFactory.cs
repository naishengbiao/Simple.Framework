/* ==============================================================================
  * 功能描述：SqlFactory  
  * 创 建 者：nsb
  * 创建日期：2012-11-13 10:14:37
  * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Util;
namespace Simple.Service.SqlText
{
    /// <summary>
    /// SqlFactory
    /// </summary>
    public  class SqlFactory
    {
        public SqlFactory()
        { }


        public static ISqlText CreateSqlDialect(string name)
        {
            if (name.Equals("System.Data.OracleClient", StringComparison.OrdinalIgnoreCase))
            {
                
            }
            if (name.Equals("MySql", StringComparison.OrdinalIgnoreCase))
            {
                
            }
            if (name.Equals("System.Data.SqlClient", StringComparison.OrdinalIgnoreCase))
            {
                return new SqlPageText();
            }
            return null;


        }

        public static ISqlText CreateSqlDialect()
        {
            return CreateSqlDialect(ConfigHelp.GetConfigString("dbProviderName"));
        }

    }
}