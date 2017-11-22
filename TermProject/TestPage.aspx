<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="TermProject.TestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Upload
    
        Document:
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" OnClick="Button1_Click" Text="Save" />
        <br />
    
    </div>
        <p>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Transaction History:
        </p>
        <p>
            <asp:Button ID="btnTransaction" runat="server" OnClick="btnTransaction_Click" Text="Get All Transactions History" />
        </p>
        <p>
            <asp:GridView ID="gvTransaction" runat="server">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnGetTransByUser" runat="server" OnClick="btnGetTransByUser_Click" Text="Get User Transactions" />
        </p>
        <p>
            <asp:GridView ID="gvUserTrans" runat="server">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Get User&#39;s Cloud Storage:</p>
        <asp:Button ID="btnGetUserStorage" runat="server" Text="Get All Users Storage" OnClick="btnGetUserStorage_Click" />
        <asp:GridView ID="gvGetStorage" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk" OnClick="OpenFile" runat="server" Text='<%# bind("Name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Extn" HeaderText="Extn" />
                <asp:BoundField DataField="Size" HeaderText="File Size" />
                <asp:BoundField DataField="Date" HeaderText="Upload Date" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnGetUserStor" runat="server" OnClick="btnGetUserStor_Click" Text="Get User's Storage" />
        <br />
        <asp:GridView ID="gvGetUserStor" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderText="File">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("Name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Extn" HeaderText="Extn" />
                <asp:BoundField DataField="Size" HeaderText="File Size" />
                <asp:BoundField DataField="Date" HeaderText="Upload Date" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />


        Update: 
        <div runat="server" id="select">
            Are You a User or Admin?<br />
            <div class="input-group">
                <div class="checkbox">
                    <label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Selected="True">User</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                        </asp:RadioButtonList>
                    </label>
                </div>
            </div>
            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
            <br />
           
        </div>

        <div runat="server" id="Clouduser">
             <asp:Label ID="lblInstruction" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="UserName: "></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblUserError" runat="server" ForeColor="#990000"></asp:Label>
            <br />
            <asp:Label ID="lblNewPass" runat="server" Text="New Password: "></asp:Label>
            <asp:TextBox ID="txtNewPass" type="password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassError" runat="server" ForeColor="#990000"></asp:Label>
            <br />
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="txtConfirmPass" type="password" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblConfirmError" runat="server" ForeColor="#990000"></asp:Label>
            <br />
            <asp:Label ID="lblFName" runat="server" Text="First Name: "></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFirstNameError" runat="server" ForeColor="#990000"></asp:Label>
            <br />
            <asp:Label ID="lblLName" runat="server" Text="Last Name: "></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblLastNameError" runat="server" ForeColor="#990000"></asp:Label>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEmailError" runat="server" ForeColor="#990000"></asp:Label>
            <br />

            <div runat="server" id="storage">
                <asp:Label ID="lblStorageCap" runat="server" Text="Storage Capacity: "></asp:Label>
                <asp:TextBox ID="txtStorage" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblStorageError" runat="server" ForeColor="#990000"></asp:Label>
                <br />
            </div>

            <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnGetAccount" runat="server" OnClick="btnGetAccount_Click" Text="Get Account" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
            

        </div>
        <div runat="server" id="admin">
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete User" OnClick="btnDelete_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnStorage" runat="server" Text="Update Storage" OnClick="btnStorage_Click" />
            <br />
            <br />
        </div>
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"  />

    </form>
    <p>
        &nbsp;</p>
</body>
</html>
