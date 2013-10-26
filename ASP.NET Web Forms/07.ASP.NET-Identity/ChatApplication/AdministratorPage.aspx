<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministratorPage.aspx.cs" Inherits="ChatApplication.AdministratorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server"
        ID="ListViewMessages"
        SelectMethod="ListViewMessages_GetData"
        UpdateMethod="ListViewMessages_UpdateItem"
        DeleteMethod="ListViewMessages_DeleteItem"
        ItemType="ChatApplication.Models.Message"
        DataKeyNames="Id">
        <LayoutTemplate>
            <div>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <p><strong><%#: Item.Author.DisplayName %></strong> said: </p>
                <p><%#: Item.Text %></p>
                <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete" />
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div>
                <asp:TextBox ID="TextEdit" runat="server" Text='<%#: BindItem.Text %>'></asp:TextBox>
                <br />
                <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
            </div>

        </EditItemTemplate>
    </asp:ListView>
    <div>
        Make Post
        <asp:TextBox runat="server" ID="usersPostText" Columns="20" Rows="10"></asp:TextBox>

        <asp:Button ID="makePostBtn" runat="server" OnClick="makePostBtn_Click" Text="Post" />
    </div>
</asp:Content>
