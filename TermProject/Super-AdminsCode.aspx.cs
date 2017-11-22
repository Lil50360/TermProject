using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Super_AdminsCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtboxCode.Text.Equals("1234"))
            {
                Server.Transfer("~/Cloud Super-Admins.aspx");
            }
            else
            {
                lblCodeError.Text = "Wrong Code!";
            }
        }
    }
}