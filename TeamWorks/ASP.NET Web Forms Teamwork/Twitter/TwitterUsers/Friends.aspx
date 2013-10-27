<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="Twitter.Friends" %>

<%@ Register Src="~/Controls/Twitter/UsersControl.ascx" TagPrefix="uc1" TagName="UsersControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:UsersControl runat="server" ID="UsersControlFriends" />
</asp:Content>
