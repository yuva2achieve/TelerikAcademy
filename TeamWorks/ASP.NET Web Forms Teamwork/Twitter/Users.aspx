<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Twitter.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="main-content-heading">All Users</h1>
    <asp:ListView runat="server" ID="ListViewAllUsers" ItemType="Twitter.Models.AspNetUser">
        <ItemTemplate>
            <li>
                <asp:LinkButton runat="server" Text="<%#: Item.UserName %>"
                    PostBackUrl='<%# String.Format("~/UserProfile.aspx?username={0}", Eval("UserName").ToString()) %>' />
            </li>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
