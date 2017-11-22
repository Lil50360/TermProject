<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GetAdminLogs.aspx.cs" Inherits="TermProject.GetAdminLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <p>&nbsp;</p>
    <p>
        <h2>Cloud Admin Management </h2>
        <br />
        <asp:Label ID="lblAdmin" runat="server" Text=""></asp:Label>
        <asp:GridView ID="gvAdminLogs" runat="server">
        </asp:GridView>
        <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </p>
</asp:Content>
