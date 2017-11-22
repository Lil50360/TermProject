using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Login.aspx");
            Session.Remove("UserName");
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }
    }
}