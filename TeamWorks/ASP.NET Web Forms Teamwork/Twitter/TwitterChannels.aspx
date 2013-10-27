<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TwitterChannels.aspx.cs" Inherits="Twitter.TwitterChannels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="main-content-heading">All Channels</h1>
    <asp:GridView runat="server" ID="GridViewChannels"
        OnDataBinding="GridViewChannels_DataBinding" CssClass="table"
        AllowPaging="true" PageSize="3" SelectMethod="GridViewChannels_GetData"
        ItemType="Twitter.Models.Channel" AutoGenerateColumns="false"
        AllowSorting="true">
        <Columns>
            <asp:TemplateField HeaderText="Creator">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="<%#: Item.AspNetUser.UserName %>" 
                        PostBackUrl='<%# String.Format("~/UserProfile.aspx?username={0}", Eval("AspNetUser.UserName").ToString()) %>'
                        />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Channel Name" SortExpression="Name">
                <ItemTemplate>
                    <asp:HyperLink Text="<%#:Item.Name%>" runat="server"
                        NavigateUrl='<%# String.Format("~/Messages/ChannelMessages.aspx?channelId={0}", Eval("ChannelId").ToString()) %>'
                        DataNavigateUrlFields="ChannelId" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Channels/CreateChannel.aspx" Text="Create channel" runat="server" />
    <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Messages/CreateMessage.aspx" Text="Add New Message" runat="server" />
</asp:Content>
