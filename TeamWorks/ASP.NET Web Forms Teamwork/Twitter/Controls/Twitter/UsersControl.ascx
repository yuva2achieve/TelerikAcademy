<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersControl.ascx.cs" Inherits="Twitter.Controls.Twitter.Followers" %>

<h1 class="main-content-heading">My followers</h1>

<asp:ListView runat="server" ID="ListViewFollowers" ItemType="Twitter.Models.AspNetUser">
    <ItemTemplate>
        <li>
            <asp:LinkButton runat="server" Text="<%#: Item.UserName %>"
                OnCommand="SeeFriend_Command" CommandArgument="<%#: Item.UserName %>" />
        </li>
    </ItemTemplate>
</asp:ListView>