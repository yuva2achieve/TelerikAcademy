<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersPage.aspx.cs" Inherits="ChatApplication.UsersPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:ListView runat="server"
            ID="ListViewMessages"
            SelectMethod="ListViewMessages_GetData"
            ItemType="ChatApplication.Models.Message">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <p><strong><%#: Item.Author.DisplayName %></strong> said: </p>
                    <p><%#: Item.Text %></p>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div>
            Make Post
            <asp:TextBox runat="server" ID="usersPostText" Columns="20" Rows="10"></asp:TextBox>

            <asp:Button ID="makePostBtn" runat="server" OnClick="makePostBtn_Click" Text="Post" />
        </div>
    </div>
</asp:Content>
