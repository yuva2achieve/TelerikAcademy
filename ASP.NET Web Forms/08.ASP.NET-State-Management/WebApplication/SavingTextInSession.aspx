<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SavingTextInSession.aspx.cs" Inherits="WebApplication.SavingTextInSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <textarea><%= GetMessages() %></textarea>
        <asp:TextBox ID="MessageText" runat="server" />
        <asp:Button ID="SubmitMessageBtn" Text="Post" OnClick="SubmitMessageBtn_Click" runat="server" />
    </div>
    </form>
</body>
</html>
