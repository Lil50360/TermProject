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
    public partial class CloudUser : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        CloudWS.CloudService pxy = new CloudWS.CloudService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            
            }
            Control myCtrl = LoadControl("UserControlLogOut.ascx");
            Form.Controls.Add(myCtrl);
            Control myCtrl2 = LoadControl("UserControlTechSupport.ascx");
            Form.Controls.Add(myCtrl2);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/MyFiles.aspx");
        }

        protected void lnkRestore_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Restore Files.aspx");
        }

        protected void lnkOperation_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/UserLogOperations.aspx");
        }

        protected void lnkStorageLimit_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/IncreaseStorage.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Login.aspx");
        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {
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
    }
}
    
    