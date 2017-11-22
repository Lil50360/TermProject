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
    public partial class MyFiles : System.Web.UI.Page
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
                DataSet ds = pxy.GetFilesByUser(securityCode, userName);

                gvGetUserStor.DataSource = ds;
                gvGetUserStor.DataBind();
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

        protected void btnGetUserStor_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            string userName = (String)Session["UserName"];
            string securityCode = "1234";
            DataSet ds = pxy.GetFilesByUser(securityCode, userName);

            // Before binding the Dataset to GridView,
            // add a Column to the dataset for the image file & store the image from database using a handler.
            // The column/field name "imgFile" is already databound to the ImageField column in the GridView
            // using the properties (see ASPX Markup).

            /*ds.Tables[0].Columns.Add("Files");*/

            // Go through each row in the dataset and store a URL value in the imgFile field that
            // will be used to process and display the image from the database in the ImageField.

            /* foreach (DataRow tempRow in ds.Tables[0].Rows)
             {
                 tempRow["File"] = "ImageGrab.aspx?ID=" + tempRow["ProductNumber"];
             }*/

            gvGetUserStor.DataSource = ds;
            gvGetUserStor.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> List = new List<int>();
            for(int row = 0; row < gvGetUserStor.Rows.Count; row++)
            {
                CheckBox CBox;

                CBox = (CheckBox)gvGetUserStor.Rows[row].FindControl("chkboxDelete");

                if (CBox.Checked)
                {
                    List.Add(int.Parse(gvGetUserStor.Rows[row].Cells[1].Text));
                }
            }

            for(int i = 0; i < List.Count; i++)
            {
                DataTable Table = pxy.SelectRowByID("1234", List[i]).Tables[0];
                DataRow Row = Table.Rows[0];

                int ID = (int)Row["Id"];
                string name = (string)Row["Name"];
                byte[] content = (byte[])Row["Content"];
                string extn = (string)Row["Extn"];
                Int64 size = (Int64)Row["Size"];
                DateTime date = (DateTime)Row["date"];
                string userName = (string)Row["userName"];

                pxy.DeleteRowByID("1234", List[i]);

                DBConnect objDB = new DBConnect();
                string userName2 = (String)Session["UserName"];
                string securityCode = "1234";
                DataSet ds = pxy.GetFilesByUser(securityCode, userName2);

                gvGetUserStor.DataSource = ds;
                gvGetUserStor.DataBind();

                pxy.InsertIntoBin("1234", ID, name, content, extn, size, date, userName);
            }

            //for (int row = 0; row < gvGetUserStor.Rows.Count; row++)
            //{
            //    CheckBox CBox;

            //    CBox = (CheckBox)gvGetUserStor.Rows[row].FindControl("chkboxDelete");

            //    if (CBox.Checked)
            //    {
            //        int id = int.Parse(gvGetUserStor.Rows[row].Cells[1].Text);
            //        DataTable Table = pxy.SelectRowByID("1234", id).Tables[0];
            //        DataRow Row = Table.Rows[0];

            //        int ID = (int)Row["Id"];
            //        string name= (string)Row["Name"];
            //        byte[] content = (byte[])Row["Content"];
            //        string extn = (string)Row["Extn"];
            //        Int64 size = (Int64)Row["Size"];
            //        DateTime date = (DateTime)Row["date"];
            //        string userName = (string)Row["userName"];

            //        pxy.DeleteRowByID("1234", id);
            //        row--;

            //        DBConnect objDB = new DBConnect();
            //        string userName2 = (String)Session["UserName"];
            //        string securityCode = "1234";
            //        DataSet ds = pxy.GetFilesByUser(securityCode, userName2);

            //        gvGetUserStor.DataSource = ds;
            //        gvGetUserStor.DataBind();

            //        pxy.InsertIntoBin("1234", ID, name, content, extn, size, date, userName); 
            //    }
            //}

        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
                while (gvGetUserStor.Rows.Count != 0)
                {
               
                    int id = int.Parse(gvGetUserStor.Rows[0].Cells[1].Text);
                    DataTable Table = pxy.SelectRowByID("1234", id).Tables[0];
                    DataRow Row = Table.Rows[0];

                    int ID = (int)Row["Id"];
                    string name = (string)Row["Name"];
                    byte[] content = (byte[])Row["Content"];
                    string extn = (string)Row["Extn"];
                    Int64 size = (Int64)Row["Size"];
                    DateTime date = (DateTime)Row["date"];
                    string userName = (string)Row["userName"];

                    pxy.DeleteRowByID("1234", id);

                    DBConnect objDB = new DBConnect();
                    string userName2 = (String)Session["UserName"];
                    string securityCode = "1234";
                    DataSet ds = pxy.GetFilesByUser(securityCode, userName2);

                    gvGetUserStor.DataSource = ds;
                    gvGetUserStor.DataBind();

                    pxy.InsertIntoBin("1234", ID, name, content, extn, size, date, userName);
                
                }
        }


    }
}