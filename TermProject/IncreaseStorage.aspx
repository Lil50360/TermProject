<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IncreaseStorage.aspx.cs" Inherits="TermProject.IncreaseStorage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <h2>Increase Storage</h2>
        Select your storage option:
    <br />
    <asp:DropDownList ID="ddlStorage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStorage_SelectedIndexChanged">
        <asp:ListItem Selected="True">2MB for $2</asp:ListItem>
        <asp:ListItem>4MB for $4</asp:ListItem>
        <asp:ListItem>8MB for $8</asp:ListItem>
    </asp:DropDownList>
    <br />
        <br />
        <br />
   CardType:
        <asp:DropDownList ID="ddlCardType" runat="server">
            <asp:ListItem>Visa</asp:ListItem>
            <asp:ListItem>Discover</asp:ListItem>
            <asp:ListItem>MasterCard</asp:ListItem>
            <asp:ListItem>American Express</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Name:
        <asp:TextBox ID="txtboxName" runat="server"></asp:TextBox>
        <br />
        <br />
        Card
        Number:
        <asp:TextBox ID="txtboxNumber" runat="server"></asp:TextBox>
        <br />
        <br />
        ExpDate:<br />
        Month:
        <asp:TextBox ID="txtboxMonth" runat="server" Height="16px" Width="30px" placeholder="MM"></asp:TextBox>
        &nbsp;&nbsp;&nbsp; Year:
        <asp:TextBox ID="txtboxYear" runat="server" Height="16px" Width="55px" placeholder="YYYY"></asp:TextBox>
        <br />
        <!--
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid month" ControlToValidate="txtboxMonth" ValidationExpression="\d+" ValidationGroup="A"></asp:RegularExpressionValidator>
        <br />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtboxMonth" ErrorMessage="Please enter Month value between 1 - 12 inclusive" MaximumValue="12" MinimumValue="1" ValidationGroup="A"></asp:RangeValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtboxYear" ErrorMessage="Please enter a valid Year" ValidationExpression="\d+" ValidationGroup="A"></asp:RegularExpressionValidator>
        <br />
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtboxYear" ErrorMessage="Please enter Year value between 2017 and 9999 inclusive" MaximumValue="9999" MinimumValue="2017"></asp:RangeValidator>
        -->
        <br />
        <br />
        3 Digits Security Pin:
        <asp:TextBox ID="txtboxPin" runat="server" Height="23px" Width="75px"></asp:TextBox>
        <br />
        <br />
        Payment Amount:$ <asp:TextBox ID="txtboxAmount" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="#990000" Text="Please enter correct data in textboxes and do not leave any textboxes blank. Expiration Date cannot be expired also. "></asp:Label>
        <br />
       
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="A" />
<br />
        <br />
        <br />

        <asp:GridView ID="gvDisplayTransaction" runat="server">
        </asp:GridView>
   
</asp:Content>
