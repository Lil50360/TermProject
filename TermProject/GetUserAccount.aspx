<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GetUserAccount.aspx.cs" Inherits="TermProject.GetUserAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
 <div runat="server" id="Clouduser">
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="UserName: "></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblUserError" runat="server" ForeColor="#990000"></asp:Label>
        <br />
        <div runat="server" id="password">
            <asp:Label ID="lblNewPass" runat="server" Text="New Password: "></asp:Label>
            <asp:TextBox ID="txtNewPass" type="password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassError" runat="server" ForeColor="#990000"></asp:Label>
            <br />
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="txtConfirmPass" type="password" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblConfirmError" runat="server" ForeColor="#990000"></asp:Label>
            <br />
        </div>

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
        <asp:Label ID="lblStorageCap" runat="server" Text="Storage Capacity: "></asp:Label>
        <asp:TextBox ID="txtStorage" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblStorageError" runat="server" ForeColor="#990000"></asp:Label>
        <br />
        <asp:Label ID="lblStatus" runat="server" Text="Status "></asp:Label>
        <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblStatusError" runat="server" ForeColor="#990000"></asp:Label>
        <br />
        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete User" OnClick="btnDelete_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDeActivate" runat="server" Text="DeActivate User" OnClick="btnDeActivate_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnActivate" runat="server" Text="Activate User" OnClick="btnActivate_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" OnClick="btnResetPassword_Click" />
        <br />

        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <br />
        <br />
    </div>


</asp:Content>
