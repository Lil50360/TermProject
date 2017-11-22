<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Super-AdminsCode.aspx.cs" Inherits="TermProject.Super_AdminsCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
     <h2>Enter Super-Admins Code Below: </h2>
<p>&nbsp;</p>
<p>
    <asp:TextBox type="password" ID="txtboxCode" runat="server"></asp:TextBox>
    <asp:Button ID="btnEnter" runat="server" Text="Enter" OnClick="btnEnter_Click" />
    <br />
     <asp:Label ID="lblCodeError" runat="server" Text=""></asp:Label>
</p>
</asp:Content>
