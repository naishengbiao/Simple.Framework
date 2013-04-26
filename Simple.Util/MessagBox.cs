using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Simple.Util
{
    public class MessagBox
    {
        #region 构造函数
        public MessagBox()
        {
        }
        #endregion

        #region  方法
        /// <summary>
        /// 弹出信息,并跳转指定页面。
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="toURL">URL</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 弹出信息,并返回历史页面
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="value">返回标识 -1  or 1</param>
        public static void AlertAndGoHistory(string message, int value)
        {
            string js = @"<Script language='JavaScript'>alert('{0}');history.go({1});</Script>";
            HttpContext.Current.Response.Write(string.Format(js, message, value));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 直接跳转到指定的页面
        /// </summary>
        /// <param name="toUrl">url</param>
        public static void Redirect(string toUrl)
        {
            string js = @"<script language=javascript>window.location.replace('{0}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, toUrl));
        }

        /// <summary>
        /// 弹出信息 并指定到父窗口
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="toURL">URL</param>
        public static void AlertAndParentUrl(string message, string toURL)
        {
            string js = "<script language=javascript>alert('{0}');window.top.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        }

        /// <summary>
        /// 返回到父窗口
        /// </summary>
        /// <param name="ToUrl">URL</param>
        public static void ParentRedirect(string ToUrl)
        {
            string js = "<script language=javascript>window.top.location.replace('{0}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, ToUrl));
        }

        /// <summary>
        /// 返回历史页面
        /// </summary>
        /// <param name="value">返回标识 -1 OR 1</param>
        public static void BackHistory(int value)
        {
            string js = @"<Script language='JavaScript'>history.go({0});</Script>";
            HttpContext.Current.Response.Write(string.Format(js, value));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 弹出信息
        /// </summary>
        /// <param name="message">信息</param>
        public static void Alert(string message)
        {
            string js = "<script language=javascript>alert('{0}');</script>";
            HttpContext.Current.Response.Write(string.Format(js, message));
        }

        /// <summary>
        /// 注册脚本块
        /// </summary>
        /// <param name="page">page对象</param>
        /// <param name="_ScriptString">Script脚本</param>
        public static void RegisterScriptBlock(System.Web.UI.Page page, string _ScriptString)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "scriptblock", "<script type='text/javascript'>" + _ScriptString + "</script>");
        }

        #endregion
    }
}
