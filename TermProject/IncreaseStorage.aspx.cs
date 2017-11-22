using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    public partial class IncreaseStorage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
                txtboxMonth.MaxLength = 2;
                txtboxYear.MaxLength = 4;
                txtboxNumber.MaxLength = 16;
                txtboxPin.MaxLength = 3;
                txtboxAmount.Text = "2";
            }
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            bool validation = true;

            if (string.IsNullOrEmpty(txtboxAmount.Text))
            {
                validation = false;
            }
            if (string.IsNullOrEmpty(txtboxMonth.Text))
            {
                validation = false;
            }
            if (string.IsNullOrEmpty(txtboxName.Text))
            {
                validation = false;
            }
            if (string.IsNullOrEmpty(txtboxNumber.Text))
            {
                validation = false;
            }
            if (string.IsNullOrEmpty(txtboxPin.Text))
            {
                validation = false;
            }
            if (string.IsNullOrEmpty(txtboxYear.Text))
            {
                validation = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtboxAmount.Text, "^[0-9]"))
            {
                validation = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtboxPin.Text, "^[0-9]"))
            {
                validation = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtboxNumber.Text, "^[0-9]"))
            {
                validation = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtboxMonth.Text, "^[0-9]"))
            {
                validation = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtboxYear.Text, "^[0-9]"))
            {
                validation = false;
            }
            if ((new DateTime(int.Parse(txtboxYear.Text), int.Parse(txtboxMonth.Text), 1)) < DateTime.Now)
            {
                validation = false;
            }

            if (validation)
            {
                lblError.Visible = false;
                pxy.InsertTransaction("1234", (string)Session["UserName"], ddlCardType.SelectedValue, txtboxName.Text, txtboxNumber.Text, new DateTime(int.Parse(txtboxYear.Text), int.Parse(txtboxMonth.Text), 1), int.Parse(txtboxPin.Text), DateTime.Now, Double.Parse(txtboxAmount.Text));

                gvDisplayTransaction.DataSource = pxy.ShowCusTransaction("1234", (string)(Session["UserName"]));
                gvDisplayTransaction.DataBind();

                Int64 a = 2000000;
                Int64 b = 4000000;
                Int64 c = 8000000; 


                if (ddlStorage.SelectedIndex == 0)
                {
                    pxy.UpdateStorageCap("1234", (string)Session["UserName"], a);
                }
                else if (ddlStorage.SelectedIndex == 1)
                {
                    pxy.UpdateStorageCap("1234", (string)Session["UserName"], b);
                }
                else if (ddlStorage.SelectedIndex == 2)
                {
                    pxy.UpdateStorageCap("1234", (string)Session["UserName"], c);
                }
                else
                {
                    lblError.Visible = true;
                }

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/CloudUser.aspx");
        }

        protected void ddlStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlStorage.SelectedIndex == 0)
            {
                txtboxAmount.Text = "2";
            }
            else if (ddlStorage.SelectedIndex == 1)
            {
                txtboxAmount.Text = "4";
            }
            else if (ddlStorage.SelectedIndex == 2)
            {
                txtboxAmount.Text = "8";
            }
        }

       
    }
}