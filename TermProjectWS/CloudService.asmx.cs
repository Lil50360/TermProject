using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace TermProjectWS
{
    /// <summary>
    /// Summary description for CloudService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CloudService : System.Web.Services.WebService
    {
        string conStr = @"Data Sourse= SUNFLOWER-PC\SQLExpress;Database=PractiveDB; Integrated Security=true;";
        DBConnect dbObj = new DBConnect();

        [WebMethod]
        public void Register(string userType, string userName, string password, string firstName, string lastName, string email, Int64 storage,string status)
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
            Cmd.Parameters.AddWithValue("@StorageCap", storage);
            Cmd.Parameters.AddWithValue("@Status", status);

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

        [WebMethod]
        public void SaveFile(string securityCode, string name, byte[] content, string extn)
        {
            if (securityCode == "1234")
            {
                
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPSaveFile";
                Cmd.Parameters.AddWithValue("@Name", name);
                Cmd.Parameters.AddWithValue("@Content", content);
                Cmd.Parameters.AddWithValue("@Extn", extn);

                dbObj.DoUpdateUsingCmdObj(Cmd);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet GetFile(string securityCode)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetFile";

                return dbObj.GetDataSetUsingCmdObj(Cmd);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet GetFileByUserName(string securityCode, string username)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetFileByUsername";
                Cmd.Parameters.AddWithValue("@UserName", username);

                return dbObj.GetDataSetUsingCmdObj(Cmd);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void GetSingleFile(string securityCode, int id, string name, byte[] content, string extn)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetSingleFile";
                Cmd.Parameters.AddWithValue("@Id", id);
                Cmd.Parameters.AddWithValue("@Name", name);
                Cmd.Parameters.AddWithValue("@Content", content);
                Cmd.Parameters.AddWithValue("@Extn", extn);

                dbObj.DoUpdateUsingCmdObj(Cmd);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        

        [WebMethod]
        public int TPGetUserID(string securityCode, string userName)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetUserID";
                Cmd.Parameters.AddWithValue("@UserName", userName);

                return Convert.ToInt32(dbObj.GetDataSetUsingCmdObj(Cmd));

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet GetAccount(string securityCode, string userName)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetAccount";
                Cmd.Parameters.AddWithValue("@UserName", userName);

                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }
        [WebMethod]
        public void DeleteAccount(string securityCode, string userName)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPDeleteUser";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }
        [WebMethod]
        public void UpdateStorageCap(string securityCode, string userName, Int64 storagecap)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUpdateStorageCap";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                Cmd.Parameters.AddWithValue("@StorageCap", storagecap);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void UpdateUser(string securityCode, string userName, string password, string firstName, string lastName, string email)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUpdateUser";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                Cmd.Parameters.AddWithValue("@Password", password);
                Cmd.Parameters.AddWithValue("@FirstName", firstName);
                Cmd.Parameters.AddWithValue("@LastName", lastName);
                Cmd.Parameters.AddWithValue("@Email", email);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void Register2(string securityCode, string userType, string userName, string password, string firstName, string lastName, string email, Int64 storagecap,string status)
        {
            if (securityCode == "1234")
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
                Cmd.Parameters.AddWithValue("@StorageCap", storagecap);
                Cmd.Parameters.AddWithValue("@Status", status);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public bool UsernameExist2(string securityCode, String username)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUserSystemGetUsernameCount";
                Cmd.Parameters.AddWithValue("@UserName", username);
                dbObj.GetDataSetUsingCmdObj(Cmd);
                int Count = (int)dbObj.GetField("Count", 0);
                if (Count > 0) return true;
                else return false;
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void UpdateUserName(string securityCode, string userName, string firstName, string lastName)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUpdateUserName";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                Cmd.Parameters.AddWithValue("@FirstName", firstName);
                Cmd.Parameters.AddWithValue("@LastName", lastName);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }
        [WebMethod]
        public void UpdateUserEmail(string securityCode, string userName, string email)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUpdateUserEmail";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                Cmd.Parameters.AddWithValue("@Email", email);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }
        [WebMethod]
        public void ChangePassword(string securityCode, string userName, string password)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPChangePassword";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                Cmd.Parameters.AddWithValue("@Password", password);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet Getfiles(string securitycode, string userName)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetFiles";
                Cmd.Parameters.AddWithValue("@UserName", userName);

                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            return null;
        }

        [WebMethod]
        public void UpdateCap(string securitycode, string userName, long size)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUpdateCap";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                Cmd.Parameters.AddWithValue("@Size", size);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
        }

        [WebMethod]
        public DataSet GetFilesByUser(string securitycode, string userName)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetFilesByUser";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                //dbObj.DoUpdateUsingCmdObj(Cmd);

                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            return null;
        }

        [WebMethod]
        public DataSet GetFilesRestoreByUser(string securitycode, string userName)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetFilesRestoreByUser";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                //dbObj.DoUpdateUsingCmdObj(Cmd);

                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            return null;
        }

        [WebMethod]
        public DataSet SelectRowByID(string securityCode, int Id)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPSelectRowByID";
                Cmd.Parameters.AddWithValue("@ID", Id);
                dbObj.DoUpdateUsingCmdObj(Cmd);

                return dbObj.GetDataSetUsingCmdObj(Cmd);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet SelectRowByIDFromBin(string securityCode, int Id)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPSelectRowByIDFromBin";
                Cmd.Parameters.AddWithValue("@ID", Id);
                dbObj.DoUpdateUsingCmdObj(Cmd);

                return dbObj.GetDataSetUsingCmdObj(Cmd);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void DeleteRowByID(string securitycode, int Id)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPDeleteRowByID";
                Cmd.Parameters.AddWithValue("@ID", Id);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
        }

        [WebMethod]
        public void DeleteRowByIDFromBin(string securitycode, int Id)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPDeleteRowByIDFromBin";
                Cmd.Parameters.AddWithValue("@ID", Id);
                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
        }

        [WebMethod]
        public void InsertIntoBin(string securitycode, int id, string name, byte[] content, string extn, Int64 size, DateTime date, string username)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPInsertIntoBin";
                Cmd.Parameters.AddWithValue("@ID", id);
                Cmd.Parameters.AddWithValue("@Name", name);
                Cmd.Parameters.AddWithValue("@Content", content);
                Cmd.Parameters.AddWithValue("@Extn", extn);
                Cmd.Parameters.AddWithValue("@Size", size);
                Cmd.Parameters.AddWithValue("@Date", date);
                Cmd.Parameters.AddWithValue("@UserName", username);

                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
        }

        [WebMethod]
        public void InsertIntoTPFile(string securitycode, string name, byte[] content, string extn, Int64 size, DateTime date, string username)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPInsertIntoTPFile";       
                Cmd.Parameters.AddWithValue("@Name", name);
                Cmd.Parameters.AddWithValue("@Content", content);
                Cmd.Parameters.AddWithValue("@Extn", extn);
                Cmd.Parameters.AddWithValue("@Size", size);
                Cmd.Parameters.AddWithValue("@Date", date);
                Cmd.Parameters.AddWithValue("@UserName", username);

                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
        }

        [WebMethod]
        public DataSet SelectAllFromBin(string securityCode, string username)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPSelectAllFromBin";
                Cmd.Parameters.AddWithValue("@UserName", username);
                dbObj.DoUpdateUsingCmdObj(Cmd);

                return dbObj.GetDataSetUsingCmdObj(Cmd);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void InsertTransaction(string securityCode, string username, string cardType, string name, string number, DateTime expDate, int pin, DateTime transDate, Double amount)
        {
            if (securityCode == "1234")
            {
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "TPInsertTransaction2";
            Cmd.Parameters.AddWithValue("@Username", username );
            Cmd.Parameters.AddWithValue("@CardType", cardType);
            Cmd.Parameters.AddWithValue("@Name", name);
            Cmd.Parameters.AddWithValue("@Number", number);
            Cmd.Parameters.AddWithValue("@ExpDate", expDate);
            Cmd.Parameters.AddWithValue("@Pin", pin);
            Cmd.Parameters.AddWithValue("@TransDate", transDate);
            Cmd.Parameters.AddWithValue("@Amount", amount);
            dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet ShowCusTransaction(string securityCode, string username)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "TPShowCusTransaction";
            Cmd.Parameters.AddWithValue("@Username", username);

            return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }
        [WebMethod]
        public bool UserIDExist(string securityCode, int userID)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUserIDExist";
                Cmd.Parameters.AddWithValue("@UserID", userID);
                dbObj.GetDataSetUsingCmdObj(Cmd);
                int Count = (int)dbObj.GetField("Count", 0);
                if (Count > 0) return true;
                else return false;
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet GetAllAccounts(string securityCode)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPViewAllAccounts";
                dbObj.GetDataSetUsingCmdObj(Cmd);
                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet GetAccountByID(string securityCode, int userID)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetAccountByID";
                Cmd.Parameters.AddWithValue("@UserID", userID);

                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }


        [WebMethod]
        public void UpdateStatus(string securityCode, int userID, string status)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUpdateStatus";
                Cmd.Parameters.AddWithValue("@UserID", userID);
                Cmd.Parameters.AddWithValue("@Status", status);

                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }
        [WebMethod]
        public DataSet GetUserNameByID(string securityCode, int userID)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetUserName";
                Cmd.Parameters.AddWithValue("@UserId", userID);

                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public bool UsernameExistInFile(string securityCode, String Username)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUserNameExistInFiles";
                Cmd.Parameters.AddWithValue("@Username", Username);
                dbObj.GetDataSetUsingCmdObj(Cmd);
                int Count = (int)dbObj.GetField("Count", 0);
                if (Count > 0) return true;
                else return false;
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void AdminLog(string securityCode, string Username, string description, DateTime date)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPInsertLog";
                Cmd.Parameters.AddWithValue("@Username", Username);
                Cmd.Parameters.AddWithValue("@Description", description);
                Cmd.Parameters.AddWithValue("@Date", date);
                dbObj.GetDataSetUsingCmdObj(Cmd);

            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet GetAllAdminAccounts(string securityCode)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPAllAdminAccounts";
                dbObj.GetDataSetUsingCmdObj(Cmd);
                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public DataSet GetAdminLogs(string securitycode, string userName)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetAdminLogs";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                dbObj.DoUpdateUsingCmdObj(Cmd);

                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securitycode);
            }
        }

        [WebMethod]
        public bool UsernameExistInAdminLog(string securityCode, String Username)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPUserNameExistInAdminLogs";
                Cmd.Parameters.AddWithValue("@Username", Username);
                dbObj.GetDataSetUsingCmdObj(Cmd);
                int Count = (int)dbObj.GetField("Count", 0);
                if (Count > 0) return true;
                else return false;
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void EnterQuestion(string securityCode, string userName, string question, DateTime date)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPInsertQuestion";
                Cmd.Parameters.AddWithValue("@UserName", userName);
                Cmd.Parameters.AddWithValue("@Question", question);
                Cmd.Parameters.AddWithValue("@Date", date);

                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }

        [WebMethod]
        public void EnterAnswer(string securityCode, int id, string admin, string answer, DateTime date)
        {
            if (securityCode == "1234")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPInsertAnswer";
                Cmd.Parameters.AddWithValue("@ID", id);
                Cmd.Parameters.AddWithValue("@Admin", admin);
                Cmd.Parameters.AddWithValue("@Answer", answer);
                Cmd.Parameters.AddWithValue("@Date", date);

                dbObj.DoUpdateUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securityCode);
            }
        }
        [WebMethod]
        public DataSet GetQA(string securitycode)
        {
            if (securitycode.Equals("1234"))
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "TPGetQA";
                dbObj.DoUpdateUsingCmdObj(Cmd);

                return dbObj.GetDataSetUsingCmdObj(Cmd);
            }
            else
            {
                throw new Exception("Invalid Security Code: " + securitycode);
            }
        }
    }
}



