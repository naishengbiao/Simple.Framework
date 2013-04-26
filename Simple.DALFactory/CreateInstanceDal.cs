/* ==============================================================================
  * 功能描述：CreateInstanceDal  
  * 创 建 者：nsb
  * 创建日期：2012-11-7 16:57:21
  * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Simple.DALFactory
{
    /// <summary>
    /// CreateInstanceDal
    /// </summary>
    public sealed class CreateInstanceDal
    {
        public CreateInstanceDal()
        {
        }


        public static object CreateDal(string str)
        {

            string assemblyName = "Simple.Dal";
            string className = assemblyName + "." + str;
            // 创建无参数实例
            object member = (object)Assembly.Load(assemblyName).CreateInstance(className);
            return member;

        }

    }
}