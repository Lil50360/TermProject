<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Restore Files.aspx.cs" Inherits="TermProject.Restore_Files" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <h2>Restore Files</h2>
    <p>&nbsp;</p>
        <asp:GridView ID="gvRestore" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkboxRestore" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderText="File">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# ("Name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Extn" HeaderText="Extn" />
                <asp:BoundField DataField="Size" HeaderText="File Size" />
                <asp:BoundField DataField="Date" HeaderText="Upload Date" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" />
            </Columns>
        </asp:GridView>
        <br />
  
    
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnRestore" runat="server" Text="Restore" OnClick="btnRestore_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnRestoreAll" runat="server" Text="Restore All" OnClick="btnRestoreAll_Click" />
    
</asp:Content>
