<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CloudUser.aspx.cs" Inherits="TermProject.CloudUser" %>

<%@ Register src="UserControlLogOut.ascx" tagname="UserControlLogOut" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2>Welcome to Your Cloud Base</h2>
    <br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" OnClick="Button1_Click" Text="Save" />
    <br />


    <p>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        <br />
        <asp:LinkButton ID="lnkDisplay" runat="server" OnClick="LinkButton1_Click">My Files</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="lnkRestore" runat="server" OnClick="lnkRestore_Click">Restore Files</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="lnkOperation" runat="server" OnClick="lnkOperation_Click">User Log Operations </asp:LinkButton>
        <br />
        <uc1:UserControlLogOut ID="UserControlLogOut1" runat="server" />
        <br />
        <asp:LinkButton ID="lnkStorageLimit" runat="server" OnClick="lnkStorageLimit_Click">Increase My Storage Limits</asp:LinkButton>
        <br />
        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Go Back" OnClick="btnBack_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <br />
</asp:Content>
