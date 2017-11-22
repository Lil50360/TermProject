<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="TermProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

    
     <title>Advertisement</title>

     <script type="text/javascript">
        var xmlhttp;
 
        if (window.XMLHttpRequest) {
            // Code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        }
        else {
            // Code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
 
        function getImages() {
            // Open a new asynchronous request, set the callback function, and send the request.
            xmlhttp.open("POST", "Ajax.aspx", true);
            xmlhttp.onreadystatechange = onComplete;
            xmlhttp.send();
        }
 
        // Callback function used to update the page when the server completes a response
        // to an asynchronous request.
        function onComplete() {
            //Response is READY and Status is OK
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                document.getElementById("content_area").innerHTML = xmlhttp.responseText;
            }
 
        }
 
    </script>
        <asp:Button ID="btnImage" runat="server" Text="Submit" OnClick="btnImage_Click" />
        <asp:Label ID="lblDisplay" runat="server" />
         <asp:Image ID="Image1" runat="server" />
        <br />
    </div>
</asp:Content>
