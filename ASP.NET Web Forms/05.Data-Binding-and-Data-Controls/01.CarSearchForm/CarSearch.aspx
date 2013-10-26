<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSearch.aspx.cs" Inherits="_01.CarSearchForm.CarSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Producer: " runat="server" />
        <asp:DropDownList ID="ddlProducers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducers_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label Text="Model: " runat="server" />
        <asp:DropDownList ID="ddlModels" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label Text="Engine: " runat="server"/>
        <asp:RadioButtonList ID="rblEngines" runat="server" >
        </asp:RadioButtonList>
        <br />
        <asp:Label Text="Extras: " runat="server"/>
        <asp:CheckBoxList ID="cblExtras" runat="server">
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="btnSearch" Text="Search" OnClick="btnSearch_Click" runat="server" />
        <br />
        <asp:Literal ID="searchResult" runat="server" />
    </form>
</body>
</html>
