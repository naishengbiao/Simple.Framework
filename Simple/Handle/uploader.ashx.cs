using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using Simple.Util;
namespace Simple.Handle
{
    /// <summary>
    /// uploader 的摘要说明
    /// </summary>
    public class uploader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //System.Threading.Thread.Sleep(9000);
            string Status = string.Empty, message = string.Empty, AbsPath = string.Empty, abs = string.Empty;
            string type = context.Request.QueryString["type"];
            if (type == "up")
            {
                HttpPostedFile file = context.Request.Files["qqfile"];
                ImagesUp.ImageUpload up = new ImagesUp.ImageUpload();
                up.SavePath = @"~/up/";
                up.hpFile = file;
                up.Upload();
                AbsPath = string.Format("{0}/up/{1}", BaseUtil.GetRootURI(), up.OutThumbFileName);
                abs = up.OutThumbFileName;
                if (up.Error == 0)
                {
                    Status = "true";
                }
                else
                {
                    message = ErrorFramt(up.Error);
                }

            }
            else
            {
                var path = string.Empty;
                var Bool = false;
                path = HttpContext.Current.Server.MapPath(@"~/up/" + type);
                //删除缩略图
                Bool = FileManager.DeleteFile(path);
                path = HttpContext.Current.Server.MapPath(@"~/up/" + type.Replace("_", "").Replace("s", ""));
                //删除原图
                Bool = FileManager.DeleteFile(path);
                Status = "true";
            }
            context.Response.Write("{\"success\":\"" + Status + "\",\"src\":\"" + AbsPath + "\",\"mes\":\"" + message + "\",\"abs\":\"" + abs + "\"}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_int"></param>
        /// <returns></returns>
        private string ErrorFramt(int _int)
        {
            string Result = string.Empty;
            switch (_int)
            {
                case 1: Result = "文件不能为空"; break;
                case 2: Result = "不允许上传的类型"; break;
                case 3: Result = "文件大小超出限制"; break;
                case 4: Result = "服务器发生未知错误"; break;
            }
            return Result;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}