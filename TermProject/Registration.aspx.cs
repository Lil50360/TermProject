using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using UserSystem;
using System.Security.Cryptography;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using System.Data;
using Utilities;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UserSystem;

namespace TermProject
{
    public partial class Registration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] != null)
            {

            }
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string userType;
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (chkbx.Checked)
            {
                if (Request.Cookies["CIS3342_Cookie"] != null)
                {
                    HttpCookie MyCookie = new HttpCookie("CIS3342_Cookie");
                    MyCookie.Values["Username"] = txtUserName.Text;
                    Response.Cookies.Add(MyCookie);

                    chkbx.Checked = false;
                    
                }
               
            }
            else
            {
                HttpCookie MyCookie = new HttpCookie("CIS3342_Cookie");
                MyCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(MyCookie);

                chkbx.Checked = false;
            }

            bool validation = true;

            if (txtUserName.Text == "")
            {
                lblUserName.Text = "User Name Required";
                validation = false;
            }
            if (txtPass.Text == "")
            {
                lblPassword.Text = "Password Required";
                validation = false;
            }
            if (txtConfirmPass.Text == "")
            {
                lblConfirm.Text = "Confirm Passoword Required";
                validation = false;
            }
            if (!txtConfirmPass.Text.Equals(txtPass.Text))
            {
                lblDisplay.Text = "Passwords do not match!";
                validation = false;
            }
            if (txtboxFirstName.Text == "")
            {
                lblFirstName.Text = "First Name Required";
                validation = false;
            }
            if (txtboxLastName.Text == "")
            {
                lblLastName.Text = "Last Name Required";
                validation = false;
            }
            if (txtboxEmail.Text == "")
            {
                lblEmail.Text = "Email Required";
                validation = false;
            }

            if (RadioButtonList1.SelectedValue == "User")
            {
                userType = "User";
            }
            else if (RadioButtonList1.SelectedValue == "Admin")
            {
                userType = "Admin";
            }

            else
            {
                userType = "User";
            }

            using (MD5 HashKey = MD5.Create())
            {
                String Password = Hash.Data(txtPass.Text, HashKey);
                
                if (validation)
                {
                    if (pxy.UsernameExist( txtUserName.Text))
                    {
                        lblDisplay.Text = "UserName Exists Try Again!";
                    }
                    else
                    {
                        pxy.Register(userType, txtUserName.Text, Password, txtboxFirstName.Text, txtboxLastName.Text, txtboxEmail.Text, 1024000000, "Active");
                        lblDisplay.Text = "";

                        if (chkbx.Checked)
                        {
                            HttpCookie MyCookie = new HttpCookie("CIS3342_Cookie");
                            MyCookie.Values["Username"] = txtUserName.Text;
                            Response.Cookies.Add(MyCookie);

                            chkbx.Checked = false;
                        }
                        else
                        {
                            HttpCookie MyCookie = new HttpCookie("CIS3342_Cookie");
                            MyCookie.Expires = DateTime.Now.AddDays(-1d);
                            Response.Cookies.Add(MyCookie);

                            chkbx.Checked = false;
                        }

                        Server.Transfer("~/Login.aspx");
                    }

                }
            }



        }
    }
}