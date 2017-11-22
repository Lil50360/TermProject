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
    public partial class GetAdminLogs : System.Web.UI.Page
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

            if (!IsPostBack)
            {

                string securityCode = "1234";
                String adminID = (String)Session["AdminID"].ToString();
                int ID = int.Parse(adminID);

                DBConnect objDB = new DBConnect();
                DataSet ds2 = pxy.GetUserNameByID(securityCode, ID);
                DataTable objTable = ds2.Tables[0];
                DataRow objRow = objTable.Rows[0];
                string userName = objRow["UserName"].ToString();
                lblAdmin.Text = "You are viewing log history for " + userName;
                if (pxy.UsernameExistInAdminLog(securityCode, userName))
                {
                    DataSet ds = pxy.GetAdminLogs(securityCode, userName);
                    gvAdminLogs.DataSource = ds;
                    gvAdminLogs.DataBind();
                    lblDisplay.Text = "";
                }
                else
                {

                    lblDisplay.Text = "That Admin does not have log history!";
                }
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Cloud Super-Admins.aspx");
        }
    }
}