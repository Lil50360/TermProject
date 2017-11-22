using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using Utilities;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UserSystem;

namespace TermProject
{
    public partial class UserLogOperations : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();
        protected void Page_Load(object sender, EventArgs e)
        {
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/CloudUser.aspx");
        }

        protected void btnGetTransByUser_Click(object sender, EventArgs e)
        {
            string securityCode = "1234";
            string username = (string)Session["UserName"];
            gvUserTrans.DataSource = pxy.GetFileByUserName(securityCode, username);
            gvUserTrans.DataBind();
        }
    }
}