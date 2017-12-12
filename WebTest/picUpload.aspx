<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="picUpload.aspx.cs" Inherits="WebTest.picUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="pic" runat="server" />
        <asp:Button ID="Upload" runat="server" Text="Upload" OnClick="Upload_Click" />
    </div>
    </form>
        </center>
</body>
</html>
