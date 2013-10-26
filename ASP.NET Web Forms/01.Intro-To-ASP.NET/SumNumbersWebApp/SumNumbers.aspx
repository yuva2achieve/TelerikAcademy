<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumNumbers.aspx.cs" Inherits="SumNumbersWebApp.SumNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        span{
            padding:5px;
            width:100px;
            display: inline-block;
        }
        #panel{
            width:280px;
            border:1px solid blue;
            border-radius:5px;
            padding:5px;
        }
    </style>
</head>
<body>
    <form id="sumNumbers" runat="server">
        <h1>Sum two numbers</h1>
        <asp:Panel runat="server" ID="panel">
            <div>
                <asp:Label Text="First number" runat="server" ID="LabelFirstNumber" />
                <asp:TextBox runat="server" ID="TextBoxFirstNumber" />
            </div>
            <div>
                <asp:Label Text="Second number" runat="server" ID="LabelSecondNumber" />
                <asp:TextBox runat="server" ID="TextBoxSecondNumber" />
            </div>
            <asp:Button Width="80px" Text="Sum" runat="server" ID="ButtonSum" OnClick="ButtonSum_Click" />
            <div>
                <asp:Label Text="Sum" runat="server" ID="LabelSum" />
                <asp:TextBox runat="server" ID="TextBoxSum" />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
