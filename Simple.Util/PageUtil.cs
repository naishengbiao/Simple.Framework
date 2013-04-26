using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Simple.Util
{
    /// <summary>
    /// WebPageUtil
    /// </summary>
    public class PageUtil
    {
        #region 构造函数
        public PageUtil()
        { }
        #endregion

        #region 数据转换
        /// <summary>
        /// 将类指定数据转换为布尔类型
        /// </summary>
        /// <param name="val">object</param>
        /// <returns>bool</returns>
        public static bool ConvertToBool(object val)
        {

            if (val == null)
            {
                return false;
            }
            return (((val.ToString() == "1") || val.ToString().Equals("Y", StringComparison.OrdinalIgnoreCase)) || val.ToString().Equals("TRUE", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 将类指定数据转换为时间类型
        /// </summary>
        /// <param name="val">指定数据</param>
        /// <returns>Datatime</returns>
        public static DateTime ConvertToDatetime(object val)
        {
            if ((val == null) || string.IsNullOrEmpty(val.ToString()))
            {
                return DateTime.MinValue;
            }
            return DateTime.Parse(val.ToString());
        }

        /// <summary>
        /// 将类指定数据转换为十进制数
        /// </summary>
        /// <param name="val">指定数据</param>
        /// <returns>Decimal</returns>
        public static decimal ConvertToDecimal(object val)
        {

            if ((val == null) || string.IsNullOrEmpty(val.ToString()))
            {
                return 0M;
            }
            decimal result = 0M;
            decimal.TryParse(val.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 将类指定数据转换为双精度
        /// </summary>
        /// <param name="val">object</param>
        /// <returns>Double</returns>
        public static double ConvertToDouble(object val)
        {
            if ((val == null) || string.IsNullOrEmpty(val.ToString()))
            {
                return 0.0;
            }
            double result = 0.0;
            double.TryParse(val.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 将类指定数据转换为Int32类型
        /// </summary>
        /// <param name="val">object</param>
        /// <returns>Int32</returns>
        public static int ConvertToInt(object val)
        {
            if ((val == null) || string.IsNullOrEmpty(val.ToString()))
            {
                return 0;
            }
            int result = 0;
            int.TryParse(val.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 将类指定数据转换为Int64类型
        /// </summary>
        /// <param name="val">object</param>
        /// <returns>Int64</returns>
        public static long ConvertToInt64(object val)
        {
            if ((val == null) || string.IsNullOrEmpty(val.ToString()))
            {
                return 0L;
            }
            long result = 0L;
            long.TryParse(val.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 将类指定数据转换为long类型
        /// </summary>
        /// <param name="val">object</param>
        /// <returns>Long</returns>
        public static long ConvertToLong(object val)
        {
            if ((val == null) || string.IsNullOrEmpty(val.ToString()))
            {
                return 0L;
            }
            long result = 0L;
            long.TryParse(val.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 将类指定数据转换为String类型
        /// </summary>
        /// <param name="val">object</param>
        /// <returns>String</returns>
        public static string ConvertToString(object val)
        {
            if (val == null)
            {
                return string.Empty;
            }
            return val.ToString();
        }

        #endregion

        #region 获取Get参数
        /// <summary>
        /// 获取decimal参数
        /// </summary>
        /// <param name="qs">参数</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>decimal</returns>
        public static decimal GeDecimalQs(string qs, decimal defaultValue)
        {
            decimal num;
            string stringQs = GetStringQs(qs);
            if (stringQs.IndexOf("#", StringComparison.OrdinalIgnoreCase) > 0)
            {
                stringQs = stringQs.Substring(0, stringQs.IndexOf("#", StringComparison.OrdinalIgnoreCase));
            }
            return (decimal.TryParse(stringQs, out num) ? num : defaultValue);
        }

        /// <summary>
        /// 获取double参数
        /// </summary>
        /// <param name="qs">参数</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>double</returns>
        public static double GetDoubleQs(string qs, double defaultValue)
        {
            double num;
            string stringQs = GetStringQs(qs);
            if (stringQs.IndexOf("#", StringComparison.OrdinalIgnoreCase) > 0)
            {
                stringQs = stringQs.Substring(0, stringQs.IndexOf("#", StringComparison.OrdinalIgnoreCase));
            }
            return (double.TryParse(stringQs, out num) ? num : defaultValue);
        }


        /// <summary>
        /// 获取Int64参数
        /// </summary>
        /// <param name="qs">参数</param>
        /// <returns>Int64</returns>
        public static long GetInt64Qs(string qs)
        {
            return GetInt64Qs(qs, -1L);
        }

        /// <summary>
        /// 获取Int64参数
        /// </summary>
        /// <param name="qs">参数</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Int64</returns>
        public static long GetInt64Qs(string qs, long defaultValue)
        {
            long num;
            string stringQs = GetStringQs(qs);
            if (stringQs.IndexOf("#", StringComparison.OrdinalIgnoreCase) > 0)
            {
                stringQs = stringQs.Substring(0, stringQs.IndexOf("#", StringComparison.OrdinalIgnoreCase));
            }
            return (long.TryParse(stringQs, out num) ? num : defaultValue);
        }

        /// <summary>
        /// 获取Int32参数
        /// </summary>
        /// <param name="qs">参数</param>
        /// <returns>Int32</returns>
        public static int GetIntQs(string qs)
        {
            return GetIntQs(qs, -1);
        }


        /// <summary>
        /// 获取Int32参数
        /// </summary>
        /// <param name="qs">参数</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Int32</returns>
        public static int GetIntQs(string qs, int defaultValue)
        {
            int num;
            string stringQs = GetStringQs(qs);
            if (stringQs.IndexOf("#", StringComparison.OrdinalIgnoreCase) > 0)
            {
                stringQs = stringQs.Substring(0, stringQs.IndexOf("#", StringComparison.OrdinalIgnoreCase));
            }
            return (int.TryParse(stringQs, out num) ? num : defaultValue);
        }

        /// <summary>
        /// 获取String参数
        /// </summary>
        /// <param name="qs">参数</param>
        /// <returns>String</returns>
        public static string GetStringQs(string qs)
        {
            return GetStringQs(qs, "");
        }

        /// <summary>
        /// 获取String参数
        /// </summary>
        /// <param name="qs">参数</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>String</returns>
        public static string GetStringQs(string qs, string defaultValue)
        {
            string str = HttpContext.Current.Request.QueryString[qs];
            str = UrlDecode(str);
            return (str ?? defaultValue);
        }

        #endregion

        #region 获取Form参数
        /// <summary>
        /// 获取DateTime参数
        /// </summary>
        /// <param name="parmname">参数</param>
        /// <param name="defaultval">默认值</param>
        /// <returns>DateTime</returns>
        public static DateTime GetFormDateTime(string parmname, DateTime defaultval)
        {
            DateTime time;
            return (DateTime.TryParse(HttpContext.Current.Request.Form[parmname], out time) ? time : defaultval);
        }

        /// <summary>
        /// 获取Int参数
        /// </summary>
        /// <param name="parmname">参数</param>
        /// <param name="defaultval">默认值</param>
        /// <returns>Int</returns>
        public static int GetFormInt(string parmname, int defaultval)
        {
            int num;
            return (int.TryParse(HttpContext.Current.Request.Form[parmname], out num) ? num : defaultval);
        }

        /// <summary>
        /// 获取decimal参数
        /// </summary>
        /// <param name="parmname">参数</param>
        /// <param name="defaultval">默认值</param>
        /// <returns>decimal</returns>
        public static decimal GetFormdecimal(string parmname, decimal defaultval)
        {
            decimal num;
            return (decimal.TryParse(HttpContext.Current.Request.Form[parmname], out num) ? num : defaultval);
        }

        /// <summary>
        /// 获取Long参数
        /// </summary>
        /// <param name="parmname">参数</param>
        /// <param name="defaultval">默认值</param>
        /// <returns>Long</returns>
        public static long GetFormLong(string parmname, int defaultval)
        {
            long num;
            return (long.TryParse(HttpContext.Current.Request.Form[parmname], out num) ? num : ((long)defaultval));
        }

        /// <summary>
        /// 获取Strin参数
        /// </summary>
        /// <param name="parmname">参数</param>
        /// <param name="defaultval">默认值</param>
        /// <returns>Strin</returns>
        public static string GetFormString(string parmname, string defaultval)
        {
            return (UrlDecode(HttpContext.Current.Request.Form[parmname]) ?? defaultval);
        }

        #endregion

        #region 参数编码

        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(string str)
        {
            if (str != null)
            {
                str = HttpUtility.UrlDecode(str);
            }
            return str;
        }

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            if (str != null)
            {
                str = HttpUtility.UrlEncode(str);
            }
            return str;
        }

        #endregion
    }
}