<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Grid view</h1>
        <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False"
            DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:HyperLinkField Text="Details" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="EmployeeDetails.aspx?id={0}" />
            </Columns>
        </asp:GridView>
        <h1>Repeater</h1>
        <asp:Repeater ID="RepeaterEmployees" runat="server" ItemType="Employees.Data.Employee">
            <ItemTemplate>
                <table border="1">
                    <tr>
                        <td>EmployeeID</td>
                        <td><%#: Item.EmployeeID %></td>
                    </tr>
                    <tr>
                        <td>FirstName</td>
                        <td><%#: Item.FirstName %></td>
                    </tr>
                    <tr>
                        <td>LastName</td>
                        <td><%#: Item.LastName %></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <h1>List view</h1>
        <asp:ListView ID="ListViewEmployees" runat="server" ItemType="Employees.Data.Employee">
            
            <ItemTemplate>
                <table border="1">
                    <tr>
                        <td>EmployeeID</td>
                        <td><%#: Item.EmployeeID %></td>
                    </tr>
                    <tr>
                        <td>FirstName</td>
                        <td><%#: Item.FirstName %></td>
                    </tr>
                    <tr>
                        <td>LastName</td>
                        <td><%#: Item.LastName %></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
