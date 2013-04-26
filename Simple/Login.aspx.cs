using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace Simple
{
    public partial class login : System.Web.UI.Page
    {

        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void loginsubmit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
        #endregion

    }
}
