<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InternationalCompany.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderPlaceHolder" runat="server">
    <a href="English/Home.aspx">English</a>
    <a href="Bulgarian/Home.aspx">Български</a>
</asp:Content>
<asp:Content ID="DefaultContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <p>This is default content</p>
</asp:Content>
