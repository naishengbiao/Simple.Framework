using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Bll;
using Simple.Util;
using Simple.Entity;
using System.Data;
using Simple.AppCode;

namespace Simple.Handle
{
    /// <summary>
    /// SysInfoHandle 的摘要说明
    /// </summary>
    public class SysInfoHandle :BasePage, IHttpHandler
    {

        public new void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jsonto=string.Empty;
            string type=context.Request["type"];
            #region 查询信息
            if (type == "List")
            {
                
                int pageindex = PageUtil.GetIntQs("pageindex");
                int pagesize = PageUtil.GetIntQs("pagesize");
                string jsonstr = PageUtil.UrlDecode(PageUtil.GetStringQs("json"));
                Adctab info = new Adctab();
                if (!string.IsNullOrEmpty(jsonstr))
                {
                    info = SerializeHelp.ScriptDeserialize<Adctab>(jsonstr);
                }
                int rowCount = 0;
                int Count = 0;
                DataTable dt = AdctabBll.Instance.GetPageList(pageindex, pagesize, out rowCount, info);
                Count = rowCount / pagesize;
                if (rowCount % pagesize != 0)
                {
                    Count += 1;
                }
                string json = dt.Rows.Count > 0 ? JsonHelp.ToJson(dt) : "\"\"";
                jsonto = string.Format("{0}\"o\":{1},\"j\":{2},\"c\":{3}{4}", "{", json, Count, rowCount, "}");
            }
            #endregion

            #region 插入信息
            else if (type == "insert")
            {
                string jsonstr = PageUtil.GetFormString("json","");
                Adctab info = new Adctab();
                if (!string.IsNullOrEmpty(jsonstr))
                {
                    info = SerializeHelp.ScriptDeserialize<Adctab>(jsonstr);
                }
                
                int i = AdctabBll.Instance.add(info);
                jsonto = "{\"o\":\"ok\"}";
            }
            #endregion

            context.Response.Write(jsonto);
        }

        public new bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}