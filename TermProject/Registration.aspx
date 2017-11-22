<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProject.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <h1>Register</h1>
    <p>&nbsp;</p>

    <asp:Label ID="Label1" runat="server" Text="User Name "></asp:Label>
    <asp:TextBox ID="txtUserName" runat="server" placeholder=""></asp:TextBox>

    <br />

    <asp:Label ID="lblUserName" runat="server" ForeColor="#990000"></asp:Label>

    <br />
    <asp:Label ID="pass" runat="server" Text="Password "></asp:Label>
    <asp:TextBox ID="txtPass" runat="server" type="password" placeholder=""></asp:TextBox>
    <br />
    <asp:Label ID="lblPassword" runat="server" ForeColor="#990000"></asp:Label>
    <br />
    <asp:Label ID="confirmpass" runat="server" Text="Confirm Password "></asp:Label>
    <asp:TextBox ID="txtConfirmPass" runat="server" type="password" placeholder=""></asp:TextBox>
    <br />
    <asp:Label ID="lblConfirm" runat="server" ForeColor="#990000"></asp:Label>
    <br />
    First Name:
        <asp:TextBox ID="txtboxFirstName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblFirstName" runat="server" ForeColor="#990000"></asp:Label>
    <br />
    Last Name:
        <asp:TextBox ID="txtboxLastName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblLastName" runat="server" ForeColor="#990000"></asp:Label>
    <br />
    Email:
        <asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblEmail" runat="server" ForeColor="#990000"></asp:Label>
    <br />
    <asp:Label ID="lblDisplay" runat="server" ForeColor="#990000"></asp:Label>
    <br />
    <asp:CheckBox ID="chkbx" runat="server" Text="Remember Me" ForeColor="#990000" />
    <br />
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
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />



</asp:Content>
