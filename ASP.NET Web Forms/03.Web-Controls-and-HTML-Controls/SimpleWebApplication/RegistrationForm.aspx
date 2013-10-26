<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="SimpleWebApplication.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server">
            <asp:Label Text="First name: " runat="server" />
            <asp:TextBox ID="FirstNameTextBox" runat="server" />
            <br />
            <asp:Label Text="Last name: " runat="server" />
            <asp:TextBox ID="LastNameTextBox" runat="server" />
            <br />
            <asp:Label Text="Faculty number: " runat="server" />
            <asp:TextBox ID="FacultyNumberTextBox" runat="server" />
            <br />
            <asp:Label Text="University: " runat="server" />
            <asp:DropDownList ID="UniversityDropDown" runat="server">
                <asp:ListItem Text="СУ" Value="СУ" />
                <asp:ListItem Text="ТУ - София" Value="ТУ - София" />
                <asp:ListItem Text="ТУ - Пловдив" Value="ТУ - Пловдив" />
                <asp:ListItem Text="Нов Български" Value="Нов Български" />
            </asp:DropDownList>
            <br />
            <asp:Label Text="Specialty: " runat="server" />
            <asp:DropDownList ID="SpecialtyDropDown" runat="server">
                <asp:ListItem Text="Computer Science" />
                <asp:ListItem Text="Software Engineering" />
                <asp:ListItem Text="Informatics" />
            </asp:DropDownList>
            <br />
            <asp:Label Text="Courses: " runat="server" />
            <asp:ListBox runat="server" ID="CoursesListBox" SelectionMode="Multiple" AutoPostBack="false">
                <asp:ListItem Text="Linear Algebra" />
                <asp:ListItem Text="Introduction to programming" />
                <asp:ListItem Text="Calculus" />
            </asp:ListBox>
            <br />
            <asp:Button Text="Register" ID="RegisterStudentButton" runat="server" />
            <br />
            <h3>Registration details: </h3>
            <asp:TextBox runat="server" ID="FormSelectionContainer" TextMode="MultiLine"></asp:TextBox>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
