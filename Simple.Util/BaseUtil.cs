using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Simple.Util
{
    /// <summary>
    /// 操作基本类
    /// </summary>
    public class BaseUtil
    {
        #region 构造函数
        public BaseUtil()
        {
        }
        #endregion

        #region 基本方法

        /// <summary>
        /// 获取网站根目录或虚拟路径
        /// </summary>
        /// <returns></returns>
        public static string GetRootURI()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;
            if (HttpCurrent != null)
            {
                Req = HttpCurrent.Request;
                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                {
                    //直接安装在Web站点    
                    AppPath = UrlAuthority;
                }
                else
                {
                    //安装在虚拟子目录下            
                    AppPath = UrlAuthority + Req.ApplicationPath;
                }
            }
            return AppPath;
        }

        /// <summary>
        /// 得到客服端IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress;
            }
            if (!(!string.IsNullOrEmpty(userHostAddress) && StringHelp.IsIP(userHostAddress)))
            {
                return "127.0.0.1";
            }
            return userHostAddress;
        }

        /// <summary>
        /// 设置下拉框选中
        /// </summary>
        /// <param name="dropDownList">drop</param>
        /// <param name="value">选中值</param>
        public static void SetSelectedItem(DropDownList dropDownList, string value)
        {
            ListItem item = dropDownList.Items.FindByValue(value);
            if (item != null)
            {
                dropDownList.ClearSelection();
                item.Selected = true;
            }
        }

        #endregion

    }
}
