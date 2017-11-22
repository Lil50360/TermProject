<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserLogOperations.aspx.cs" Inherits="TermProject.UserLogOperations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <h2>User Log Operations</h2>
        <br />
  <asp:Button ID="btnGetTransByUser" runat="server" OnClick="btnGetTransByUser_Click" Text="Get User Transactions" />
        </p>
        <p>
            <asp:GridView ID="gvUserTrans" runat="server">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </p>
</asp:Content>
