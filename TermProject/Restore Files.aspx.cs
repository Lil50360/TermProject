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
    public partial class Restore_Files : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DBConnect objDB = new DBConnect();
                string userName = (String)Session["UserName"];
                string securityCode = "1234";
                DataSet ds = pxy.SelectAllFromBin(securityCode, userName);

                gvRestore.DataSource = ds;
                gvRestore.DataBind();
            }
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/CloudUser.aspx");
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            List<int> List = new List<int>();
            for (int row = 0; row < gvRestore.Rows.Count; row++)
            {
                CheckBox CBox;

                CBox = (CheckBox)gvRestore.Rows[row].FindControl("chkboxRestore");

                if (CBox.Checked)
                {
                    List.Add(int.Parse(gvRestore.Rows[row].Cells[1].Text));
                }
            }

            for (int i = 0; i < List.Count; i++)
            {
                DataTable Table = pxy.SelectRowByIDFromBin("1234", List[i]).Tables[0];
                DataRow Row = Table.Rows[0];

                int ID = (int)Row["Id"];
                string name = (string)Row["Name"];
                byte[] content = (byte[])Row["Content"];
                string extn = (string)Row["Extn"];
                Int64 size = (Int64)Row["Size"];
                DateTime date = (DateTime)Row["date"];
                string userName = (string)Row["userName"];

                pxy.DeleteRowByIDFromBin("1234", List[i]);

                DBConnect objDB = new DBConnect();
                string userName2 = (String)Session["UserName"];
                string securityCode = "1234";
                DataSet ds = pxy.GetFilesRestoreByUser(securityCode, userName2);

                gvRestore.DataSource = ds;
                gvRestore.DataBind();

                pxy.InsertIntoTPFile("1234", name, content, extn, size, date, userName);
            }
        }
        //    for (int row = 0; row < gvRestore.Rows.Count; row++)
        //    {
        //        CheckBox CBox;

            //        CBox = (CheckBox)gvRestore.Rows[row].FindControl("chkboxRestore");

            //        if (CBox.Checked)
            //        {
            //            int id = int.Parse(gvRestore.Rows[row].Cells[1].Text);
            //            DataTable Table = pxy.SelectRowByIDFromBin("1234", id).Tables[0];
            //            DataRow Row = Table.Rows[row];

            //            int ID = (int)Row["Id"];
            //            string name = (string)Row["Name"];
            //            byte[] content = (byte[])Row["Content"];
            //            string extn = (string)Row["Extn"];
            //            Int64 size = (Int64)Row["Size"];
            //            DateTime date = (DateTime)Row["date"];
            //            string userName = (string)Row["userName"];

            //            pxy.DeleteRowByIDFromBin("1234", id);
            //            row--; 

            //            DBConnect objDB = new DBConnect();
            //            string userName2 = (String)Session["UserName"];
            //            string securityCode = "1234";
            //            DataSet ds = pxy.SelectAllFromBin(securityCode, userName2);

            //            gvRestore.DataSource = ds;
            //            gvRestore.DataBind();

            //            pxy.InsertIntoTPFile("1234", name, content, extn, size, date, userName);
            //        }
            //    }

            //}

        protected void btnRestoreAll_Click(object sender, EventArgs e)
        {
            while (gvRestore.Rows.Count != 0)
            {
                
                int id = int.Parse(gvRestore.Rows[0].Cells[1].Text);
                DataTable Table = pxy.SelectRowByIDFromBin("1234", id).Tables[0];
                DataRow Row = Table.Rows[0];

                int ID = (int)Row["Id"];
                string name = (string)Row["Name"];
                byte[] content = (byte[])Row["Content"];
                string extn = (string)Row["Extn"];
                Int64 size = (Int64)Row["Size"];
                DateTime date = (DateTime)Row["date"];
                string userName = (string)Row["userName"];

                pxy.DeleteRowByIDFromBin("1234", id);

                DBConnect objDB = new DBConnect();
                string userName2 = (String)Session["UserName"];
                string securityCode = "1234";
                DataSet ds = pxy.GetFilesRestoreByUser(securityCode, userName2);

                gvRestore.DataSource = ds;
                gvRestore.DataBind();

                pxy.InsertIntoTPFile("1234", name, content, extn, size, date, userName);

            }
        }
    }
}