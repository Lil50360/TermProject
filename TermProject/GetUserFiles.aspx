<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GetUserFiles.aspx.cs" Inherits="TermProject.GetUserFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Src="~/UserControlLogOut.ascx" TagPrefix="uc1" TagName="UserControlLogOut" %>
    <div runat="server" id="getfiles">
        <asp:GridView ID="gvGetUserFiles" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Extn" HeaderText="Extn" />
                <asp:BoundField DataField="Size" HeaderText="File Size" />
                <asp:BoundField DataField="Date" HeaderText="Upload Date" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
    <br />

    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
</asp:Content>
