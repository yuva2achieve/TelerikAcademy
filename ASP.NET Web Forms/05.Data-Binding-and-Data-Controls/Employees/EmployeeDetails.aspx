<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Employees.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Details view</h3>
        <asp:DetailsView ID="EmployeeDetailsView" runat="server" />
        <h3>Form view</h3>
        <asp:FormView ID="EmployeeFormView" runat="server" ItemType="Employees.Data.Employee">
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
                    <tr>
                        <td>Title</td>
                        <td><%#: Item.Title %></td>
                    </tr>
                    <tr>
                        <td>TitleOfCourtesy</td>
                        <td><%#: Item.TitleOfCourtesy %></td>
                    </tr>
                    <tr>
                        <td>BirthDate</td>
                        <td><%#: Item.BirthDate %></td>
                    </tr>
                    <tr>
                        <td>HireDate</td>
                        <td><%#: Item.HireDate %></td>
                    </tr>
                    <tr>
                        <td>Address</td>
                        <td><%#: Item.Address %></td>
                    </tr>
                    <tr>
                        <td>City</td>
                        <td><%#: Item.City %></td>
                    </tr>
                    <tr>
                        <td>Region</td>
                        <td><%#: Item.Region %></td>
                    </tr>
                    <tr>
                        <td>PostalCode</td>
                        <td><%#: Item.PostalCode %></td>
                    </tr>
                    <tr>
                        <td>Country</td>
                        <td><%#: Item.Country %></td>
                    </tr>
                    <tr>
                        <td>HomePhone</td>
                        <td><%#: Item.HomePhone %></td>
                    </tr>
                    <tr>
                        <td>Extension</td>
                        <td><%#: Item.Extension %></td>
                    </tr>
                    <tr>
                        <td>Notes</td>
                        <td><%#: Item.Notes %></td>
                    </tr>
                    <tr>
                        <td>ReportsTo</td>
                        <td><%#: Item.ReportsTo %></td>
                    </tr>
                    <tr>
                        <td>PhotoPath</td>
                        <td><%#: Item.PhotoPath %></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
