<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGeneratorWithWebControls.aspx.cs" Inherits="SimpleWebApplication.RandomGeneratorWithWebControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="From: " runat="server" />
        <asp:TextBox ID="NumberMin" runat="server" />
        <br />
        <asp:Label Text="To: " runat="server" />
        <asp:TextBox ID="NumberMax" runat="server" />
        <br />
        <asp:Button Text="Generate" ID="RandomGenerate" OnClick="RandomGenerate_Click" runat="server" />
        <asp:Label Text="Result: " runat="server" />
        <asp:TextBox ID="NumberResult" runat="server" />
    </div>
    </form>
</body>
</html>
