<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPicture.aspx.cs" Inherits="Twitter.Account.UploadPicture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" method="post" enctype="multipart/form-data" runat="server">
        <%--<input type="file" id="profilePicture" name="profilePicture" runat="server" />
        <br/>
        <input type="submit" id="UploadPicture" value="Upload" runat="server" />--%>
        <input type="file" id="avatarPicture" name="avatarPicture" runat="server" />
        <br/>
        <input type="submit" id="pictureUpload" value="Upload" onserverclick="UploadPicture_ServerClick" runat="server" />
    </form>
</body>
</html>
