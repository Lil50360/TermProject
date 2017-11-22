<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TechSupportHelp.aspx.cs" Inherits="TermProject.TechSupportHelp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <h2>Tech Support Help Team </h2>
<asp:Label ID="lblDisplay" runat="server" Text="Questions and Answers"></asp:Label>
    <br />
    <div runat="server" id="EnterUser">
        <asp:Label ID="lblUsername" runat="server" Text="UserName"></asp:Label>
        <asp:TextBox ID="txtuserName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblError" runat="server" ></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        <br />
    </div>
    <div runat="server" id="User">
        <asp:GridView ID="gvHelp" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="UserName" HeaderText="User" />
                <asp:BoundField DataField="Admin" HeaderText="Admin" />
                <asp:BoundField DataField="Question" HeaderText="Questions" />
                <asp:BoundField DataField="Answer" HeaderText="Answers" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblQuestion" runat="server" Text="Question"></asp:Label>
        <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblQuestionError" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnUserSubmit" runat="server" Text="Submit" OnClick="btnUserSubmit_Click" /><br />
        <asp:Button ID="btnUseBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </div>

    <div runat="server" id="Admin">
        <asp:GridView ID="gvAdminHelp" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="UserName" HeaderText="User" />
                <asp:BoundField DataField="Admin" HeaderText="Admin" />
                <asp:BoundField DataField="Question" HeaderText="Questions" />
                <asp:BoundField DataField="Answer" HeaderText="Answers" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblQAID" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblQAIDError" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblAnswer" runat="server" Text="Answer"></asp:Label>
        <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblAnswerError" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnAdminSubmit" runat="server" Text="Submit" OnClick="btnAdminSubmit_Click" />

        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </div>
</asp:Content>
