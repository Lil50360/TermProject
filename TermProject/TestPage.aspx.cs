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
    public partial class TestPage : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();
        /*string conStr = @"Data Source= SUNFLOWER-PC\SQLExpress;Database=PractiveDB; Integrated Security=true;";*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DBConnect objDB = new DBConnect();

                
                    Clouduser.Visible = false;
                    admin.Visible = false;
                    btnBack.Visible = false;
                
                //ddlProducts.DataSource = objDB.GetDataSet(strSQL);
                //ddlProducts.DataTextField = "Description";
                //ddlProducts.DataValueField = "ProductNumber";
                //ddlProducts.DataBind();

                //FillData();
            }
        }

        /*protected void OpenFile(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lnk.NamingContainer;

            int id = int.Parse(gvGetStorage.DataKeys[gr.RowIndex].Value.ToString());
        }
        private void FillData()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            string strSQL2 = "SELECT Content FROM TPFile";

            DataTable dt = new DataTable();
            using(SqlConnection cn = new SqlConnection(strSQL2)) { 
            string strSQL = "TPGetFile";

            objCommand.CommandType = CommandType.StoredProcedure;
                
            objCommand.CommandText = strSQL;
                cn.Open();
                SqlDataReader reader = objCommand.ExecuteReader();
            dt.Load(reader);
            }
            if (dt.Rows.Count > 0)
            {
                gvGetStorage.DataSource = dt;
                gvGetStorage.DataBind();

            }

        }*/

        protected void Button1_Click(object sender, EventArgs e)
        {
            /* FileInfo fi = new FileInfo(FileUpload1.FileName);
             byte[] content = FileUpload1.FileBytes;

             string name = fi.Name;
             string extn = fi.Extension;

             using (SqlConnection cn = new SqlConnection(conStr))
             {
                 SqlCommand Cmd = new SqlCommand("TPSaveFile", cn);
                 Cmd.CommandType = CommandType.StoredProcedure;

                 Cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name;
                 Cmd.Parameters.AddWithValue("@Content", SqlDbType.VarBinary).Value = content;
                 Cmd.Parameters.AddWithValue("@Extn", SqlDbType.VarChar).Value = extn;

                 cn.Open();
                 Cmd.ExecuteNonQuery(); 

             }*/
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            int result = 0, Size;
            string fileExtension, Type, Name, strSQL;

            try
            {
                // Use the FileUpload control to get the uploaded data
                if (FileUpload1.HasFile)
                {
                    Size = FileUpload1.PostedFile.ContentLength;
                    byte[] data = new byte[Size];
                    FileUpload1.PostedFile.InputStream.Read(data, 0, Size);
                    Name = FileUpload1.PostedFile.FileName;
                    Type = FileUpload1.PostedFile.ContentType;

                    byte[] FileContent = FileUpload1.FileBytes;

                    fileExtension = Name.Substring(Name.LastIndexOf("."));
                    fileExtension = fileExtension.ToLower();
                    if (fileExtension.Equals(".docx"))
                    {
                        FileUpload1.SaveAs(Server.MapPath("Image/docIcon"));
                    }

                    string userName = (String)Session["UserName"];

                    strSQL = "TPStoreFile";

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = strSQL;

                    objCommand.Parameters.AddWithValue("@Name", Name);
                    objCommand.Parameters.AddWithValue("@Content", data);
                    objCommand.Parameters.AddWithValue("@Extn", fileExtension);
                    objCommand.Parameters.AddWithValue("@Size", data.Length);
                    objCommand.Parameters.AddWithValue("@Date", DateTime.Now);
                    objCommand.Parameters.AddWithValue("@UserName", userName);

                    result = objDB.DoUpdateUsingCmdObj(objCommand);
                    lblStatus.Text = "Your file is uploaded in the database.";

                    string securityCode = "1234";
                    DataSet ds = pxy.Getfiles(securityCode, userName);
                    DataTable objTable = ds.Tables[0];
                    DataRow objRow = objTable.Rows[0];
                    long size = ((long)objRow["Size"]);
                    pxy.UpdateCap(securityCode, userName, size);

                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error ocurred: [" + ex.Message + "] cmd=" + result;
            }
        }

        protected void btnTransaction_Click(object sender, EventArgs e)
        {
            string securityCode = "1234";
            gvTransaction.DataSource = pxy.GetFile(securityCode);
            gvTransaction.DataBind();
        }

        protected void btnGetUserStorage_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            string strSQL;
            DataSet ds;
            strSQL = "SELECT Id, Name, Content,Extn, Size, Date FROM TPFile ";
            ds = objDB.GetDataSet(strSQL);

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

            gvGetStorage.DataSource = ds;
            gvGetStorage.DataBind();
        }

        //protected void OpenFile(object sender, EventArgs e)
        //{
        //    LinkButton lnk = (LinkButton)sender;
        //    GridViewRow Row = (GridViewRow)lnk.NamingContainer;

        //    int id = int.Parse(gvGetStorage.DataKeys[Row.RowIndex].Value.ToString());
        //    Download(id);
        //}

        //private void Download(int ID)
        //{
        //    objCommand.Parameters.AddWithValue("@ID", ID);

        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "TPGetFileByID";
        //    DataSet get = objDB.GetDataSetUsingCmdObj(objCommand);
        //    gvGetStorage.DataSource = get;
        //    gvGetStorage.DataBind();

        //    string name = get.Tables[0].Rows[0]["Name"].ToString();
        //    byte[] fileBytes = (byte[])get.Tables[0].Rows[0]["Content"];

        //    Response.ClearContent();
        //    Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + name));
        //    Response.AddHeader("Content-Length", fileBytes.Length.ToString());

        //    Response.BinaryWrite(fileBytes);
        //    Response.Flush();
        //    Response.Close();
        //}

        protected void OpenFile(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lnk.NamingContainer;

            int id = int.Parse(gvGetStorage.DataKeys[gvRow.RowIndex].Value.ToString());
            Download(id);
        }

        private void Download(int ID)
        {
            objCommand.Parameters.AddWithValue("@ID", ID);

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TPGetFileByID";
            DataSet get = objDB.GetDataSetUsingCmdObj(objCommand);
            gvGetStorage.DataSource = get;
            gvGetStorage.DataBind();

            string name = get.Tables[0].Rows[0]["Name"].ToString();
            byte[] documentBytes = (byte[])get.Tables[0].Rows[0]["Content"];

            Response.ClearContent();
            //Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + name));
            Response.AddHeader("Content-Length", documentBytes.Length.ToString());

            Response.BinaryWrite(documentBytes);
            Response.Flush();
            Response.Close();
        }

        protected void btnGetAccount_Click(object sender, EventArgs e)
        {
            lblConfirmError.Text = "";
            lblEmailError.Text = "";
            lblFirstNameError.Text = "";
            lblLastNameError.Text = "";
            lblPassError.Text = "";
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                lblUserName.Text = "UserName can't Empty!";
            }
            else
            {
                string securityCode = "1234";
                DataSet ds = pxy.GetAccount(securityCode, txtUserName.Text);
                DataTable objTable = ds.Tables[0];
                DataRow objRow = objTable.Rows[0];
                txtUserName.Text = (objRow["UserName"]).ToString();
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                txtFirstName.Text = (objRow["FirstName"]).ToString();
                txtLastName.Text = (objRow["LastName"]).ToString();
                txtEmail.Text = (objRow["Email"]).ToString();
                txtStorage.Text = ((long)objRow["StorageCap"]).ToString();
                lblDisplay.Text = "";
                btnUpdate.Visible = true;
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            bool validation = true, name = true, email = true, pass = true;

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                validation = false;

            }
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
                    lblDisplay.Text = "Updated!";
                }
                if (validation && pass)
                {
                    pxy.ChangePassword(securityCode, txtUserName.Text, Password);
                    lblDisplay.Text = "Updated!";
                }
                if (validation && email)
                {
                    pxy.UpdateUserEmail(securityCode, txtUserName.Text, txtEmail.Text);
                    lblDisplay.Text = "Updated!";
                }

                if (validation && pass && name && email)
                {
                    pxy.UpdateUser(securityCode,txtUserName.Text, Password, txtFirstName.Text, txtLastName.Text, txtEmail.Text);
                    lblDisplay.Text = "Updated!";

                }
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                txtEmail.Text = "";
            }
        }


        protected void submit_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "User")
            {
                Clouduser.Visible = true;
                admin.Visible = false;
                lblDisplay.Text = "";
                submit.Visible = false;
                btnBack.Visible = true;
                select.Visible = false;
                lblInstruction.Text = "Enter your UserName then click \"Get Info\" button to Update and view your information:";

            }
            else if (RadioButtonList1.SelectedValue == "Admin")
            {
                Clouduser.Visible = true;
                admin.Visible = true;
                lblDisplay.Text = "";
                submit.Visible = false;
                btnBack.Visible = true;
                select.Visible = false;
                lblInstruction.Text = "Enter your UserName then click \"Get Info\" button to Update and view your information:";

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            string userType;
            bool validation = true;

            if (txtUserName.Text == "")
            {
                lblUserError.Text = "User Name Required";
                validation = false;
            }
            if (txtNewPass.Text == "")
            {
                lblPassError.Text = "Password Required";
                validation = false;
            }
            if (txtConfirmPass.Text == "")
            {
                lblConfirmError.Text = "Confirm Password Required";
                validation = false;
            }
            if (!txtConfirmPass.Text.Equals(txtNewPass.Text))
            {
                lblDisplay.Text = "Passwords do not match!";
                validation = false;
            }
            if (txtFirstName.Text == "")
            {
                lblFirstNameError.Text = "First Name Required";
                validation = false;
            }
            if (txtLastName.Text == "")
            {
                lblLastNameError.Text = "Last Name Required";
                validation = false;
            }
            if (txtEmail.Text == "")
            {
                lblEmailError.Text = "Email Required";
                validation = false;
            }
            if (!reg.IsMatch(txtEmail.Text))
            {
                lblEmailError.Text = "Email is not in its correct format";
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
                String Password = Hash.Data(txtNewPass.Text, HashKey);
                string securityCode = "1234";
                if (validation)
                {
                    if (pxy.UsernameExist2(securityCode, txtUserName.Text))
                    {
                        lblDisplay.Text = "UserName Exists Try Again!";
                    }
                    else
                    {
                        pxy.Register2(securityCode ,userType, txtUserName.Text, Password, txtFirstName.Text, txtLastName.Text, txtEmail.Text, 1024000000,"Active");
                        lblDisplay.Text = "Registed!";
                    }

                }
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
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
                lblDisplay.Text = "Deleted User!";

            }
        }

        protected void btnStorage_Click(object sender, EventArgs e)
        {
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
            if (string.IsNullOrEmpty(txtStorage.Text))
            {
                validation = false;
                lblStorageError.Text = "Storage Capacity Required!";
            }
            if (validation)
            {
                string securityCode = "1234";
                pxy.UpdateStorageCap(securityCode, txtUserName.Text, (int.Parse(txtStorage.Text)));
                lblDisplay.Text = "Updated the Storage Capacity!";

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestPage.aspx");
        }

        protected void btnGetTransByUser_Click(object sender, EventArgs e)
        {
            string securityCode = "1234";
            string username = (string)Session["UserName"]; 
            gvUserTrans.DataSource = pxy.GetFileByUserName(securityCode, username);
            gvUserTrans.DataBind();
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
    }
}