using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
namespace TermProject
{
    public partial class Cloud_Super_Admins : System.Web.UI.Page
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

        protected void btnGetAdmin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdminID.Text))
            {
                lblIDError.Text = "AdminID required!";
            }
            else
            {
                int adminID = int.Parse(txtAdminID.Text);
                String securityCode = "1234";

                if (pxy.UserIDExist(securityCode, adminID))
                {
                    Session["AdminID"] = txtAdminID.Text;
                    Server.Transfer("~/GetAdminLogs.aspx");
                }
                else
                {
                    lblIDError.Text = "AdminID you have entered does not exist!";
                }


            }
        }

        protected void lnkViewAdmins_Click(object sender, EventArgs e)
        {
            string securityCode = "1234";
            DataSet ds = pxy.GetAllAdminAccounts(securityCode);

            gvAllAdmins.DataSource = ds;
            gvAllAdmins.DataBind();
        }
    }
}
