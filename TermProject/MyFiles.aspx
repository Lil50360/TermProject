<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyFiles.aspx.cs" Inherits="TermProject.MyFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <h2>My Files</h2>
    
        <br />
    <asp:Button ID="btnGetUserStor" runat="server" OnClick="btnGetUserStor_Click" Text="Get User's Storage" />
        <br />
        <asp:GridView ID="gvGetUserStor" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkboxDelete" runat="server" AutoPostBack="True" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderText="File">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# bind("Name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Extn" HeaderText="Extn" />
                <asp:BoundField DataField="Size" HeaderText="File Size" />
                <asp:BoundField DataField="Date" HeaderText="Upload Date" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
            </Columns>
        </asp:GridView>
   <br />
    <br />
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDeleteAll" runat="server" Text="Delete All " OnClick="btnDeleteAll_Click" />
    <br />
    <br />
    <br />
    
</asp:Content>
