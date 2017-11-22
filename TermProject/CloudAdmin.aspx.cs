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
    public partial class CloudAdmin : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();

        protected void Page_Load(object sender, EventArgs e)
        {
            viewAccounts.Visible = false;
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }

        protected void btnGetAccount_Click(object sender, EventArgs e)
        {
            String admin = (String)Session["Username"].ToString();
            if (string.IsNullOrEmpty(txtboxUserID.Text))
            {
                lblUserIDerror.Text = "UserID Required!";
            }
            else
            {
                int UserID = int.Parse(txtboxUserID.Text);
                String securityCode = "1234";

                if (pxy.UserIDExist(securityCode, UserID))
                {

                    Session["UserID"] = txtboxUserID.Text;
                    String user = (String)Session["UserID"].ToString();
                    int id = int.Parse(user);
                    DataSet ds = pxy.GetUserNameByID(securityCode, id);
                    DataTable objTable = ds.Tables[0];
                    DataRow objRow = objTable.Rows[0];
                    string userName = (objRow["UserName"]).ToString();
                    pxy.AdminLog(securityCode, admin, "Got Account for " + userName, DateTime.Now);
                    Server.Transfer("~/GetUserAccount.aspx");
                }
                else
                {
                    lblUserIDerror.Text = "UserID you have entered does not exist!";
                }
            }

        }

        protected void btnGetFiles_Click(object sender, EventArgs e)
        {
            String admin = (String)Session["Username"].ToString();
            if (string.IsNullOrEmpty(txtboxUserID.Text))
            {
                lblUserIDerror.Text = "UserID Required!";
            }
            else
            {
                int UserID = int.Parse(txtboxUserID.Text);
                String securityCode = "1234";
                if (pxy.UserIDExist(securityCode, UserID))
                {
                    Session["UserID"] = txtboxUserID.Text;
                    String user = (String)Session["UserID"].ToString();
                    int id = int.Parse(user);
                    DataSet ds = pxy.GetUserNameByID(securityCode, id);
                    DataTable objTable = ds.Tables[0];
                    DataRow objRow = objTable.Rows[0];
                    string userName = (objRow["UserName"]).ToString();
                    pxy.AdminLog(securityCode, admin, "Got Files that belong to " + userName, DateTime.Now);

                    Server.Transfer("~/GetUserFiles.aspx");
                }
                else
                {
                    lblUserIDerror.Text = "UserID you have entered does not exist!";
                }
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Login.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Login.aspx");
            Session.Remove("UserName");
        }

        protected void lnkViewAllAccounts_Click(object sender, EventArgs e)
        {

            String admin = (String)Session["Username"].ToString();
            viewAccounts.Visible = true;
            DBConnect objDB = new DBConnect();

            string securityCode = "1234";
            DataSet ds = pxy.GetAllAccounts(securityCode);

            gvViewAllAccounts.DataSource = ds;
            gvViewAllAccounts.DataBind();

            pxy.AdminLog(securityCode, admin, "Viewed all accounts ", DateTime.Now);
        }


    }
}