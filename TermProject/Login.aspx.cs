using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] != null) { 
                lblMessage.Text = "";
            
                HttpCookie Cookie = Request.Cookies["CIS3342_Cookie"];
                txtboxUserName.Text = Cookie.Values["Username"].ToString();
                
            }
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (MD5 HashKey = MD5.Create())
            {
                String Username = txtboxUserName.Text;
                String Password = Hash.Data(txtboxPassword.Text, HashKey);
                if (pxy.UsernameExist(Username))
                {
                    if (pxy.PasswordMatch(Username, Password))
                    {
                        string userType = pxy.SelectUserType("1234", Username);
                        if (userType == "User")
                        {
                            Session["Username"] = Username;
                            pxy.GetUserID(Username);

                            if (chkboxCookies.Checked)
                            {
                                HttpCookie MyCookie = new HttpCookie("CIS3342_Cookie");
                                MyCookie.Values["Username"] = txtboxUserName.Text;
                                Response.Cookies.Add(MyCookie);
                                lblMessage.Text = "Cookie added!";
                                chkboxCookies.Checked = false;
                            }
                            else
                            {
                                HttpCookie MyCookie = new HttpCookie("CIS3342_Cookie");
                                MyCookie.Expires = DateTime.Now.AddDays(-1d);
                                Response.Cookies.Add(MyCookie);
                                lblMessage.Text = "Cookie not added.";
                                chkboxCookies.Checked = false;
                            }

                            lblDisplay.Text = "It Matches!";

                            Server.Transfer("~/CloudUser.aspx");
                        }
                        else
                        {
                            Session["Username"] = Username;
                            //pxy.GetUserID(Username);

                            if (chkboxCookies.Checked)
                            {
                                HttpCookie MyCookie = new HttpCookie("CIS3342_Cookie");
                                MyCookie.Values["Username"] = txtboxUserName.Text;
                                Response.Cookies.Add(MyCookie);
                                lblMessage.Text = "Cookie added!";
                                chkboxCookies.Checked = false;
                            }
                            else
                            {
                                HttpCookie MyCookie = new HttpCookie("CIS3342_Cookie");
                                MyCookie.Expires = DateTime.Now.AddDays(-1d);
                                Response.Cookies.Add(MyCookie);
                                lblMessage.Text = "Cookie not added.";
                                chkboxCookies.Checked = false;
                            }

                            lblDisplay.Text = "It Matches!";

                            Server.Transfer("~/CloudAdmin.aspx");
                        }
                    }
                    else
                    {
                        lblDisplay.Text = "Password does not match with Username!";
                    }
                }
                else
                {
                    lblDisplay.Text = "Invalid Username and password!";
                }
            }

        

            if (txtboxUserName.Text == "")
            {
                lblUserName.Text = "User Name Required";
            }

            if (txtboxPassword.Text == "")
            {
                lblPassword.Text = "Password Required";
            }


        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Registration.aspx");
        }
    }
}