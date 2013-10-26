<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloSayer.aspx.cs" Inherits="_01.SayHelloApp.HelloSayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">Enter your name:</asp:Label>
        <asp:TextBox runat="server" ID="inputName"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="sayHelloBtn" OnClick="sayHelloBtn_Click" Text="Say hello" />
    </div>
    </form>
</body>
</html>
