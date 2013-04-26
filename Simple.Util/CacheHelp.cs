using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;

namespace Simple.Util
{
   public class CacheHelp
   {
       #region 构造函数
       public CacheHelp()
       { 
       }
       #endregion

       #region 方法

       /// <summary>
       /// 获取当前应用程序指定CacheKey的Cache值
       /// </summary>
       /// <param name="CacheKey"></param>
       /// <returns></returns>
       public static object GetCache(string CacheKey)
       {
           System.Web.Caching.Cache objCache = HttpRuntime.Cache;
           return objCache[CacheKey];
       }

       /// <summary>
       /// 设置当前应用程序指定CacheKey的Cache值
       /// </summary>
       /// <param name="CacheKey"></param>
       /// <param name="objObject"></param>
       public static void SetCache(string CacheKey, object objObject)
       {
           System.Web.Caching.Cache objCache = HttpRuntime.Cache;
           objCache.Insert(CacheKey, objObject);
       }

       /// <summary>
       /// 设置当前应用程序指定CacheKey的Cache值
       /// </summary>
       /// <param name="CacheKey"></param>
       /// <param name="objObject"></param>
       public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
       {
           System.Web.Caching.Cache objCache = HttpRuntime.Cache;
           objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
       }

       /// <summary>
       /// 移除指定数据缓存
       /// </summary>
       public static void RemoveAllCache(string CacheKey)
       {
           System.Web.Caching.Cache _cache = HttpRuntime.Cache;
           _cache.Remove(CacheKey);
       }

       /// <summary>
       /// 移除全部缓存
       /// </summary>
       public static void RemoveAllCache()
       {
           System.Web.Caching.Cache _cache = HttpRuntime.Cache;
           IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
           while (CacheEnum.MoveNext())
           {
               _cache.Remove(CacheEnum.Key.ToString());
           }
       }
       #endregion
   }
}
