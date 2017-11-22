<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cloud Super-Admins.aspx.cs" Inherits="TermProject.Cloud_Super_Admins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <h2>Cloud Super-Admins </h2>
    <p>&nbsp;</p>
    <p>
        <asp:LinkButton ID="lnkViewAdmins" runat="server" OnClick="lnkViewAdmins_Click">View All Admin Accounts</asp:LinkButton>
        <asp:GridView ID="gvAllAdmins" runat="server">
        </asp:GridView>
    </p>
    <p>&nbsp;</p>

    <p>&nbsp;</p>
    <p>Enter Admin ID Number to view thier specific admin&#39;s logs information: </p>
    <p>
        AdminID:
    <asp:TextBox ID="txtAdminID" runat="server"></asp:TextBox>
        <asp:Button ID="btnGetAdmin" runat="server" Text="Get Admin's Logs" OnClick="btnGetAdmin_Click" />
        <asp:Label ID="lblIDError" runat="server" Text=""></asp:Label>
    </p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>
