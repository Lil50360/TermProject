<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="TermProject.LogOut" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    Please click here to completely log out of your session username:<br />
    <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log Out " />
    <br />
    <br />
<br />
    </asp:Content>
