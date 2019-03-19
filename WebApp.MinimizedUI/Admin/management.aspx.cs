using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.MizimizedUI.Admin
{
    public partial class management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If login 
            if (Session["username"] == null || Session["loginType"].ToString().Equals("0"))
            {
                Response.Redirect("/");
            }
            else
            {
                
            }
        }
    }
}