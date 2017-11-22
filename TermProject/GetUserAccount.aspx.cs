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
    public partial class GetUserAccount : System.Web.UI.Page
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
                String userID = Session["UserID"].ToString();
                int ID = int.Parse(userID);
                string securityCode = "1234";
                DataSet ds = pxy.GetAccountByID(securityCode, ID);
                DataTable objTable = ds.Tables[0];
                DataRow objRow = objTable.Rows[0];
                txtUserName.Text = (objRow["UserName"]).ToString();
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                txtFirstName.Text = (objRow["FirstName"]).ToString();
                txtLastName.Text = (objRow["LastName"]).ToString();
                txtEmail.Text = (objRow["Email"]).ToString();
                txtStorage.Text = ((long)objRow["StorageCap"]).ToString();
                txtStatus.Text = (objRow["Status"]).ToString();
                txtStatus.Enabled = false;
                txtStorage.Enabled = false;
                txtUserName.Enabled = false;
                lblDisplay.Text = "";
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String admin = (String)Session["Username"].ToString();
            bool validation = true, name = true, email = true, pass = true;

            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                pass = false;
            }
            if (string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                pass = false;
            }
            if (!txtConfirmPass.Text.Equals(txtNewPass.Text))
            {
                lblDisplay.Text = "Passwords do not match!";
                pass = false;
            }
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                name = false;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                name = false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                email = false;
            }

            using (MD5 HashKey = MD5.Create())
            {
                String Password = Hash.Data(txtNewPass.Text, HashKey);
                string securityCode = "1234";

                if (validation && name)
                {
                    pxy.UpdateUserName(securityCode, txtUserName.Text, txtFirstName.Text, txtLastName.Text);

                    string userName = txtUserName.Text;
                    pxy.AdminLog(securityCode, admin, "Changed First/Last Name for " + userName, DateTime.Now);

                    lblDisplay.Text = "Updated!";
                }
                if (validation && pass)
                {
                    pxy.ChangePassword(securityCode, txtUserName.Text, Password);

                    string userName = txtUserName.Text;
                    pxy.AdminLog(securityCode, admin, "Changed Password for " + userName, DateTime.Now);

                    lblDisplay.Text = "Updated!";
                }
                if (validation && email)
                {
                    pxy.UpdateUserEmail(securityCode, txtUserName.Text, txtEmail.Text);

                    string userName = txtUserName.Text;
                    pxy.AdminLog(securityCode, admin, "Changed email for " + userName, DateTime.Now);

                    lblDisplay.Text = "Updated!";
                }

                if (validation && name && email)
                {
                    pxy.UpdateUser(securityCode, txtUserName.Text, Password, txtFirstName.Text, txtLastName.Text, txtEmail.Text);

                    string userName = txtUserName.Text;
                    pxy.AdminLog(securityCode, admin, "Changed First/Last Name and email and password for " + userName, DateTime.Now);

                    lblDisplay.Text = "Updated!";
                }
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String admin = (String)Session["Username"].ToString();
            lblConfirmError.Text = "";
            lblEmailError.Text = "";
            lblFirstNameError.Text = "";
            lblLastNameError.Text = "";
            lblPassError.Text = "";

            bool validation = true;

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                validation = false;
                lblUserError.Text = "UserName Required!";
            }
            if (validation)
            {
                string securityCode = "1234";
                pxy.DeleteAccount(securityCode, txtUserName.Text);

                string userName = txtUserName.Text;
                pxy.AdminLog(securityCode, admin, "Deleted " + userName, DateTime.Now);

                lblDisplay.Text = "Deleted User!";

            }
        }

        protected void btnDeActivate_Click(object sender, EventArgs e)
        {
            String admin = (String)Session["Username"].ToString();
            String userID = Session["UserID"].ToString();
            int ID = int.Parse(userID);
            string securityCode = "1234";
            if (txtStatus.Text.Equals("Active"))
            {
                pxy.UpdateStatus(securityCode, ID, "InActive");
                DataSet ds = pxy.GetAccountByID(securityCode, ID);
                DataTable objTable = ds.Tables[0];
                DataRow objRow = objTable.Rows[0];
                txtStatus.Text = (objRow["Status"]).ToString();

                string userName = txtUserName.Text;
                pxy.AdminLog(securityCode, admin, "DeActivated " + userName, DateTime.Now);

                lblStatusError.Text = "Status of User is InActive";
            }
            else if (txtStatus.Text.Equals("InActive"))
            {
                lblStatusError.Text = "Status of User is already InActive";
            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            String admin = (String)Session["Username"].ToString();
            String userID = Session["UserID"].ToString();
            int ID = int.Parse(userID);
            string securityCode = "1234";
            if (txtStatus.Text.Equals("InActive"))
            {
                pxy.UpdateStatus(securityCode, ID, "Active");
                DataSet ds = pxy.GetAccountByID(securityCode, ID);
                DataTable objTable = ds.Tables[0];
                DataRow objRow = objTable.Rows[0];
                txtStatus.Text = (objRow["Status"]).ToString();

                string userName = txtUserName.Text;
                pxy.AdminLog(securityCode, admin, "DeActivated " + userName, DateTime.Now);

                lblStatusError.Text = "Status of User is Active";
            }
            else if (txtStatus.Text.Equals("Active"))
            {
                lblStatusError.Text = "Status of User is already Active";
            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            String admin = (String)Session["Username"].ToString();
            bool validation = true;
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                validation = false;
            }
            if (string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                validation = false;
            }
            if (!txtConfirmPass.Text.Equals(txtNewPass.Text))
            {
                lblDisplay.Text = "Passwords do not match!";
                validation = false;
            }
            using (MD5 HashKey = MD5.Create())
            {
                String Password = Hash.Data(txtNewPass.Text, HashKey);
                string securityCode = "1234";
                if (validation)
                {
                    pxy.ChangePassword(securityCode, txtUserName.Text, Password);

                    string userName = txtUserName.Text;
                    pxy.AdminLog(securityCode, admin, "Changed Password for " + userName, DateTime.Now);

                    lblDisplay.Text = "Updated!";
                    txtNewPass.Text = "";
                    txtConfirmPass.Text = "";

                }
                else
                {
                    lblDisplay.Text = "Password Fields are empty!";
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/CloudAdmin.aspx");
        }
    }
}