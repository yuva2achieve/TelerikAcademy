<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlEscaping.aspx.cs" Inherits="SimpleWebApplication.HtmlEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label for="TextContainer">Enter dangerous content: </label>
        <input type="text" id="TextContainer" runat="server"/>
        <button runat="server" onserverclick="EscapeContent_Click" id="EscapeContent">Escape content</button>
        <br />
        <label for="ResultContainer" runat="server" id="ResultLabel">Escaped content: </label>
        <input type="text" id="ResultContainer" runat="server" />
    </div>
    </form>
</body>
</html>
