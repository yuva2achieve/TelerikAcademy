<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomGeneratorWithHtmlControls.aspx.cs" Inherits="SimpleWebApplication.RandomGeneratorWithHtmlControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>This application will generate random number in given interval.</p>
        <label for="numMin">From: </label>
        <input id="numMin" runat="server" type="number" />
        <br />
        <label for="numMax">To: </label>
        <input id="numMax" type="number" runat="server" />
        <br />
        <button runat="server" id="randomGenerate" onserverclick="RandomGenerate_Click">Generate</button>
        <br />
        <label for="numResult">Result: </label>
        <input runat="server" type="text" id="numResult" />
    </div>
    </form>
</body>
</html>
