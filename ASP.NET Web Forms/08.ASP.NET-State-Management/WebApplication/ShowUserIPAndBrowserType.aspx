<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUserIPAndBrowserType.aspx.cs" Inherits="WebApplication.ShowUserIPAndBrowserType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>IP address: <%= GetIPAddress() %></h3>
        <h3>Lan IP address: <%= GetLanIPAddress() %></h3>
        <h3>Browser type: <%= GetBrowser() %></h3>
    </div>
    </form>
</body>
</html>
