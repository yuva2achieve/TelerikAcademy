<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Followers.aspx.cs" Inherits="Twitter.Followers" %>

<%@ Register Src="~/Controls/Twitter/UsersControl.ascx" TagPrefix="twitter" TagName="UsersControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <twitter:UsersControl runat="server" ID="UsersControlFollowers" />
</asp:Content>
