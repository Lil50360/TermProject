using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace TermProjectWS
{
    /// <summary>
    /// Summary description for TermProjectWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TermProjectWS : System.Web.Services.WebService
    {
        DBConnect dbObj = new DBConnect();

        [WebMethod]
        public void Register(string userType, string userName, string password, string firstName, string lastName, string email)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "TPRegister";
            Cmd.Parameters.AddWithValue("@UserType", userType);
            Cmd.Parameters.AddWithValue("@UserName", userName);
            Cmd.Parameters.AddWithValue("@Password", password);
            Cmd.Parameters.AddWithValue("@FirstName", firstName);
            Cmd.Parameters.AddWithValue("@LastName", lastName);
            Cmd.Parameters.AddWithValue("@Email", email);
            
            dbObj.DoUpdateUsingCmdObj(Cmd);
        }
        [WebMethod]
        public bool UsernameExist(String Username)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "TPUserSystemGetUsernameCount";
            Cmd.Parameters.AddWithValue("@Username", Username);
            dbObj.GetDataSetUsingCmdObj(Cmd);
            int Count = (int)dbObj.GetField("Count", 0);
            if (Count > 0) return true;
            else return false;
        }
        [WebMethod]
        public bool PasswordMatch(String Username, String Password)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "TPUserSystemGetPasswordCount";
            Cmd.Parameters.AddWithValue("@Username", Username);
            Cmd.Parameters.AddWithValue("@Password", Password);
            dbObj.GetDataSetUsingCmdObj(Cmd);
            int Count = (int)dbObj.GetField("Count", 0);
            if (Count > 0) return true;
            else return false;
        }

        [WebMethod]
        public String GetUserName(String Username)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "TPUserSystemGetUserName";
            Cmd.Parameters.AddWithValue("@Username", Username);
            dbObj.GetDataSetUsingCmdObj(Cmd);
            return (String)dbObj.GetField("UserName", 0);
        }

        [WebMethod]
        public int GetUserID(String Username)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "TPGetUserID";
            Cmd.Parameters.AddWithValue("@Username", Username);
            dbObj.GetDataSetUsingCmdObj(Cmd);
            return (int)dbObj.GetField("UserID", 0);

        }

        [WebMethod]
        public string SelectUserType(string securityCode, string userName)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPSelectUserType";
                Cmd.Parameters.AddWithValue("@UserName", userName);

                dbObj.GetDataSetUsingCmdObj(Cmd);
                return (String)dbObj.GetField("UserType", 0);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }
    }
}
