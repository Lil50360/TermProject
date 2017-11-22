<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CloudAdmin.aspx.cs" Inherits="TermProject.CloudAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
     <br />
    <h2>Cloud Admin Management </h2>
    <br />
    
    <asp:LinkButton ID="lnkViewAllAccounts" runat="server" OnClick="lnkViewAllAccounts_Click">View All Accounts</asp:LinkButton>
    <br />
    <div runat="server" id="viewAccounts">
    <asp:GridView ID="gvViewAllAccounts" runat="server" AutoGenerateColumns="False">
        <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
            </Columns>
</asp:GridView>
        </div>
    <br />
    Enter User Account ID to Update, Delete, Deactivate and Modify account:
    <br />
    UserID:<asp:TextBox ID="txtboxUserID" runat="server"></asp:TextBox>
    <asp:Button ID="btnGetAccount" runat="server" Text="Get Account" OnClick="btnGetAccount_Click" />
    <asp:Button ID="btnGetFiles" runat="server" Text="Get User Files " OnClick="btnGetFiles_Click" />
    <br />
     <asp:Label ID="lblUserIDerror" runat="server"></asp:Label>
<br />
<asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Go Back" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log Out" />
    <br />
    <br />
    <br />
</asp:Content>

