<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Twitter.Admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="main-content-heading">Users Manager Page</h1>
    <div class="alert alert-success" runat="server" id="messageDiv">
        <strong runat="server" id="messageText"></strong>
    </div>
    <h2>All Users</h2>
    <asp:ListView runat="server" ID="ListViewUsers" ItemType="Twitter.Models.AspNetUser" DataKeyNames="Id"
        UpdateMethod="ListViewAllUsers_UpdateItem" DeleteMethod="ListViewAllUsers_DeleteItem"
        SelectMethod="ListViewUsers_GetData">
        <ItemTemplate>
            <li>
                <asp:Label runat="server" Text="<%#: Item.UserName %>" />
                <asp:LinkButton ID="EditButton" CommandName="Edit" Text="Edit" runat="server"></asp:LinkButton>
                <asp:LinkButton ID="DeleteButton" CommandName="Delete" Text="Delete" runat="server"></asp:LinkButton>
                
            </li>
        </ItemTemplate>

        <EditItemTemplate>
            <li>
                <asp:LinkButton ID="UpdateButton" CommandName="Update" Text="Update" runat="server"></asp:LinkButton>
                <asp:TextBox ID="TextBoxUpdateUsername" Text="<%# BindItem.UserName %>" runat="server"></asp:TextBox>
            </li>
        </EditItemTemplate>
    </asp:ListView>
    <h2>Regular Users</h2>
    <asp:ListView runat="server" ID="ListViewRegularUsers" 
        ItemType="Twitter.Models.AspNetUser" DataKeyNames="Id"
        SelectMethod="ListViewRegularUsers_GetData">
        <ItemTemplate>
            <li>
                <asp:Label runat="server" Text="<%#: Item.UserName %>" />
                <asp:LinkButton ID="MakeAdmin" OnCommand="MakeAdmin_Command"
                    CommandArgument="<%#: Item.Id %>" Text="Promote" runat="server"></asp:LinkButton>
            </li>
        </ItemTemplate>

        <EditItemTemplate>
            <li>
                <asp:LinkButton ID="UpdateButton" CommandName="Update" Text="Update" runat="server"></asp:LinkButton>
                <asp:TextBox ID="TextBoxUpdateUsername" Text="<%# BindItem.UserName %>" runat="server"></asp:TextBox>
            </li>
        </EditItemTemplate>
    </asp:ListView>
    <h2>Admins</h2>
    <asp:ListView runat="server" ID="ListViewAdmins" 
        ItemType="Twitter.Models.AspNetUser" DataKeyNames="Id"
        SelectMethod="ListViewAdmins_GetData">
        <ItemTemplate>
            <li>
                <asp:Label runat="server" Text="<%#: Item.UserName %>" />
                <asp:LinkButton ID="DemoteAdmin" OnCommand="DemoteAdmin_Command"
                    CommandArgument="<%#: Item.Id %>" Text="Demote" runat="server"></asp:LinkButton>
            </li>
        </ItemTemplate>

        <EditItemTemplate>
            <li>
                <asp:LinkButton ID="UpdateButton" CommandName="Update" Text="Update" runat="server"></asp:LinkButton>
                <asp:TextBox ID="TextBoxUpdateUsername" Text="<%# BindItem.UserName %>" runat="server"></asp:TextBox>
            </li>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
