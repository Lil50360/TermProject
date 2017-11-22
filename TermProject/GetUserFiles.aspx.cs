using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Utilities;


namespace TermProject
{
    public partial class GetUserFiles : System.Web.UI.Page
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
                String userID = Session["UserID"].ToString();
                int ID = int.Parse(userID);

                DBConnect objDB = new DBConnect();
                DataSet ds2 = pxy.GetUserNameByID(securityCode, ID);
                DataTable objTable = ds2.Tables[0];
                DataRow objRow = objTable.Rows[0];
                string userName = objRow["UserName"].ToString();
                if (pxy.UsernameExistInFile(securityCode, userName))
                {
                    DataSet ds = pxy.GetFilesByUser(securityCode, userName);
                    gvGetUserFiles.DataSource = ds;
                    gvGetUserFiles.DataBind();
                    lblDisplay.Text = "";
                }
                else
                {

                    lblDisplay.Text = "User does not have any files!";
                }

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/CloudAdmin.aspx");
        }
    }
}