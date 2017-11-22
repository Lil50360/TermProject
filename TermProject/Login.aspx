<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TermProject.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <%@ Register Src="~/UserControlTechSupport.ascx" TagPrefix="uc1" TagName="UserControlTechSupport" %>

    <h1>Login:</h1>
    <p>&nbsp;</p>
    <p>
        User Name:
                <asp:TextBox ID="txtboxUserName" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblUserName" runat="server"></asp:Label>
    </p>
    <p>
        Password:
                <asp:TextBox type="password" ID="txtboxPassword" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblPassword" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server" ForeColor="#990000"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblDisplay" runat="server" ForeColor="#990000"></asp:Label>
    </p>
    <p>
        <asp:CheckBox ID="chkboxCookies" runat="server" Text="Remember Me " ForeColor="#990000" />
    </p>
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegister" runat="server" Text="Register " OnClick="btnRegister_Click" />
    



    


</asp:Content>
