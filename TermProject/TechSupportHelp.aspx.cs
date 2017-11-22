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
    public partial class TechSupportHelp : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();
        string securityCode = "1234";
        protected void Page_Load(object sender, EventArgs e)
        {
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);

            User.Visible = false;
            Admin.Visible = false;
            if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] != null)
            {
                HttpCookie Cookie = Request.Cookies["CIS3342_Cookie"];
                txtuserName.Text = Cookie.Values["Username"].ToString();
                txtuserName.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool valid = pxy.UsernameExist2(securityCode, txtuserName.Text);
            if (valid == true)
            {
                string userType = pxy.SelectUserType(securityCode, txtuserName.Text);

                if (userType == "User")
                {
                    User.Visible = true;
                    DataSet ds = pxy.GetQA(securityCode);
                    gvHelp.DataSource = ds;
                    gvHelp.DataBind();
                    EnterUser.Visible = false;
                }
                else
                {
                    Admin.Visible = true;
                    DataSet ds = pxy.GetQA(securityCode);
                    gvAdminHelp.DataSource = ds;
                    gvAdminHelp.DataBind();
                    EnterUser.Visible = false;
                }
            }
            else
            {
                lblError.Text = "UserName does not exist!";
            }
        }

        protected void btnUserSubmit_Click(object sender, EventArgs e)
        {
            bool validation = true;
            if (string.IsNullOrEmpty(txtQuestion.Text))
            {
                validation = false;
                lblQuestionError.Text = "Question Required!";
            }

            if (validation)
            {
                pxy.EnterQuestion(securityCode, txtuserName.Text, txtQuestion.Text, DateTime.Now);

            }

            DataSet ds = pxy.GetQA(securityCode);
            gvHelp.DataSource = ds;
            gvHelp.DataBind();
        }

        protected void btnAdminSubmit_Click(object sender, EventArgs e)
        {
            bool validation = true;
            if (string.IsNullOrEmpty(txtID.Text))
            {
                validation = false;
                lblQAIDError.Text = "ID Required!";
            }
            if (string.IsNullOrEmpty(txtAnswer.Text))
            {
                validation = false;
                lblAnswerError.Text = "Answer Required!";
            }
            int id = int.Parse(txtID.Text);
            if (validation)
            {
                pxy.EnterAnswer(securityCode, id, txtuserName.Text, txtAnswer.Text, DateTime.Now);

            }
            DataSet ds = pxy.GetQA(securityCode);
            gvAdminHelp.DataSource = ds;
            gvAdminHelp.DataBind();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/TechSupportHelp.aspx");
        }
    }
}