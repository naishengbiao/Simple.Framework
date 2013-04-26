/* ==============================================================================
  * 功能描述：StringHelp  
  * 创 建 者：nsb
  * 创建日期：2012-11-9 15:57:58
  * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Simple.Util
{
    /// <summary>
    /// StringHelp
    /// </summary>
    public class StringHelp
    {
        #region 构造函数
        public StringHelp()
        { }
        #endregion

        #region 基本字符操作
        /// <summary>
        /// 判断是否IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }


        /// <summary>
        /// 把价格精确至小数点两位
        /// </summary>
        /// <param name="dPrice">价格</param>
        /// <returns>返回值</returns>
        public static string TransformPrice(double dPrice)
        {
            double d = dPrice;
            var myNfi = new NumberFormatInfo { NumberNegativePattern = 2 };
            string s = d.ToString("N", myNfi);
            return s;
        }


        /// <summary>
        ///  生成随机码
        /// </summary>
        /// <returns></returns>
        public static string GetRamCode()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        /// <summary>
        /// 截取字符长度
        /// </summary>
        /// <param name="inputString">字符</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string CutString(string inputString, int len)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return "";
            }
            inputString = HtmlHelp.NoHTML(inputString);
            ASCIIEncoding encoding = new ASCIIEncoding();
            int num = 0;
            string str = "";
            byte[] bytes = encoding.GetBytes(inputString);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x3f)
                {
                    num += 2;
                }
                else
                {
                    num++;
                }
                try
                {
                    str = str + inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }
                if (num > len)
                {
                    break;
                }
            }
            if (Encoding.Default.GetBytes(inputString).Length > len)
            {
                str = str + "…";
            }
            return str;
        }

        /// <summary>
        /// IList<int>链接字符
        /// </summary>
        /// <param name="ids">IList<int>集合</param>
        /// <returns>返回值</returns>
        public static string Join(IList<int> ids)
        {
            string str = string.Empty;
            for (int i = 0; i < ids.Count; i++)
            {
                str = str + ids[i] + ",";
            }
            return str.TrimEnd(new char[] { ',' });
        }


        /// <summary>
        /// List<long>链接字符
        /// </summary>
        /// <param name="ids">List<long>集合</param>
        /// <returns>返回值</returns>
        public static string Join(IList<long> ids)
        {
            string str = string.Empty;
            for (int i = 0; i < ids.Count; i++)
            {
                str = str + ids[i] + ",";
            }
            return str.TrimEnd(new char[] { ',' });
        }


        /// <summary>
        /// <T>链接字符
        /// </summary>
        /// <param name="ids">IList<object>集合</param>
        /// <returns>返回值</returns>
        public static string Join(IList<object> ids)
        {
            string str = string.Empty;
            for (int i = 0; i < ids.Count; i++)
            {
                str = str + "'" + ids[i].ToString() + "',";
            }
            return str.TrimEnd(new char[] { ',' });
        }

        /// <summary>
        /// ArrayList链接字符
        /// </summary>
        /// <param name="ids">ArrayList集合</param>
        /// <returns>返回值</returns>
        public static string Join(ArrayList array)
        {
            string str = string.Empty;
            for (int i = 0; i < array.Count; i++)
            {
                str = str + "'" + array[i].ToString() + "',";
            }
            return str.TrimEnd(new char[] { ',' });
        }


        /// <summary>
        /// 泛型集合链接字符
        /// </summary>
        /// <param name="ids">IList<string>集合</param>
        /// <returns>返回值</returns>
        public static string Join(IList<string> ids)
        {
            return string.Join(",", ids.ToArray<string>());
        }

        #endregion

        #region 字符串转换操作

        /// <summary>
        /// 将集合转换为字符串
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="speater">分隔符</param>
        /// <returns></returns>
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == (list.Count - 1))
                {
                    builder.Append(list[i]);
                }
                else
                {
                    builder.Append(list[i]);
                    builder.Append(speater);
                }
            }
            return builder.ToString();
        }


        /// <summary>
        /// 将字符串转换为数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="spilt">分隔符</param>
        /// <returns></returns>
        public static string[] GetStrArray(string str, char spilt)
        {
            return str.Split(new char[spilt]);
        }

        /// <summary>
        /// 汉字转编码 
        /// </summary>
        /// <param name="character">汉字</param>
        /// <returns>返回值</returns>
        public static string CharacterToCoding(string character)
        {
            string str = "";
            try
            {
                for (int i = 0; i < character.Length; i++)
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(character.Substring(i, 1));
                    string str2 = Convert.ToString(bytes[0], 0x10);
                    if (str2.Length == 1)
                    {
                        str2 = "0" + str2;
                    }
                    string str3 = Convert.ToString(bytes[1], 0x10);
                    if (str3.Length == 1)
                    {
                        str3 = "0" + str3;
                    }
                    str = str + str2 + str3;
                }
            }
            catch
            {
                str = character;
            }
            return str;
        }


        /// <summary>
        /// 编码转汉字 
        /// </summary>
        /// <param name="coding">编码</param>
        /// <returns>返回值</returns>
        public static string CodingToCharacter(string coding)
        {
            string str = "";
            try
            {
                if ((coding.Length % 4) != 0)
                {
                    throw new Exception("编码格式不正确");
                }
                for (int i = 0; i < coding.Length; i += 4)
                {
                    byte[] bytes = new byte[2];
                    string str2 = coding.Substring(i, 2);
                    bytes[0] = Convert.ToByte(str2, 0x10);
                    string str3 = coding.Substring(i + 2, 2);
                    bytes[1] = Convert.ToByte(str3, 0x10);
                    string str4 = Encoding.Unicode.GetString(bytes);
                    str = str + str4;
                }
            }
            catch
            {
                str = coding;
            }
            return str;
        }

        #endregion

        #region Url重组操作

        /// <summary>
        /// 组合URL参数 
        /// </summary>
        /// <param name="_url">URL</param>
        /// <param name="_keys">参数名</param>
        /// <param name="_values">参数值数组</param>
        /// <returns>返回值</returns>
        public static string CombUrlTxt(string _url, string _keys, params string[] _values)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                string[] strArray = _keys.Split(new char[] { '&' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!(string.IsNullOrEmpty(_values[i]) || !(_values[i] != "0")))
                    {
                        _values[i] = PageUtil.UrlEncode(_values[i]);
                        builder.Append(string.Format(strArray[i], (object[])_values) + "&");
                    }
                }
                if (!(string.IsNullOrEmpty(builder.ToString()) || (_url.IndexOf("?") != -1)))
                {
                    builder.Insert(0, "?");
                }
            }
            catch
            {
                return _url;
            }
            return (_url + DelLastChar(builder.ToString(), "&"));
        }


        /// <summary>
        /// 删除最后结尾的指定字符后的字符 
        /// </summary>
        /// <param name="str">原始字符</param>
        /// <param name="strchar">要删除的字符</param>
        /// <returns></returns>
        public static string DelLastChar(string str, string strchar)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            if ((str.LastIndexOf(strchar) >= 0) && (str.LastIndexOf(strchar) == (str.Length - 1)))
            {
                return str.Substring(0, str.LastIndexOf(strchar));
            }
            return str;
        }

        #endregion

        #region 字符串检测操作

        /// <summary>
        /// 检查危险字符 
        /// </summary>
        /// <param name="sInput">要检查的字符串</param>
        /// <returns></returns>
        public static string Filter(string sInput)
        {
            if ((sInput == null) || (sInput == ""))
            {
                return null;
            }
            string input = sInput.ToLower();
            string str2 = sInput;
            string str = "*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(input, Regex.Escape(str), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
            {
                throw new Exception("字符串中含有非法字符!");
            }
            return str2.Replace("'", "''");
        }




        /// <summary>
        /// 过滤特殊字符 
        /// </summary>
        /// <param name="Input">文本输入的字符串</param>
        /// <returns></returns>
        public static string Htmls(string Input)
        {
            if ((Input != string.Empty) && (Input != null))
            {
                return Input.ToLower().Replace("<script", "&lt;script").Replace("script>", "script&gt;").Replace("<%", "&lt;%").Replace("%>", "%&gt;").Replace("<$", "&lt;$").Replace("$>", "$&gt;");
            }
            return string.Empty;
        }


        

        /// <summary> 
        /// 检测含有中文字符串的实际长度 
        /// </summary> 
        /// <param name="str">字符串</param> 
        /// <returns>返回值</returns>
        public static int GetLength(string str)
        {
            var n = new ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int l = 0; // l 为字符串之实际长度 
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63) //判断是否为汉字或全脚符号 
                {
                    l++;
                }
                l++;
            }
            return l;
        }


        /// <summary>
        /// 截取长度,num是英文字母的总数，一个中文算两个英文
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="iNum">英文字母的总数</param>
        /// <param name="bAddDot">是否计算标点</param>
        /// <returns>返回值</returns>
        public static string GetLetter(string str, int iNum, bool bAddDot)
        {
            if (str == null || iNum <= 0) return "";

            if (str.Length < iNum && str.Length * 2 < iNum)
            {
                return str;
            }

            string sContent = str;
            int iTmp = iNum;

            char[] arrC = str.ToCharArray(0, sContent.Length >= iTmp ? iTmp : sContent.Length);

            int i = 0;
            int iLength = 0;
            foreach (char ch in arrC)
            {
                iLength++;

                int k = ch;
                if (k > 127 || k < 0)
                {
                    i += 2;
                }
                else
                {
                    i++;
                }

                if (i > iTmp)
                {
                    iLength--;
                    break;
                }
                if (i == iTmp)
                {
                    break;
                }
            }

            if (iLength < str.Length && bAddDot)
                sContent = sContent.Substring(0, iLength - 3) + "...";
            else
                sContent = sContent.Substring(0, iLength);

            return sContent;
        }

        #endregion


























    }
}