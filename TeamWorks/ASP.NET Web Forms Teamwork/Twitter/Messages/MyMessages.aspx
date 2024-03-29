﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyMessages.aspx.cs" Inherits="Twitter.Messages.MyMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h1 class="main-content-heading">My Messages</h1>
     <asp:GridView runat="server" ID="GridViewMyMessages"
        AutoGenerateColumns="false"
        ItemType="Twitter.Models.Message" CssClass="table"
        SelectMethod="GridViewChannels_GetData"
        AllowPaging="true" PageSize="5" AllowSorting="true"
         DataKeyNames="MessageId" 
         AutoGenerateDeleteButton="true"
         AutoGenerateEditButton="true"
         UpdateMethod="GridViewMyMessages_UpdateItem"
         DeleteMethod="GridViewMyMessages_DeleteItem"
         EmptyDataText="You haven't posted messages yet.">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    Channel Name
                </HeaderTemplate>
                <ItemTemplate>
                       <asp:LinkButton runat="server" Text="<%#: Item.Channel.Name %>"
                           PostBackUrl='<%# String.Format("~/Messages/ChannelMessages.aspx?channelId={0}", Eval("ChannelId").ToString()) %>'
                         />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Content" SortExpression="MessageContent">
                <ItemTemplate>
                    <asp:Label Text="<%#:Item.MessageContent%>" runat="server"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxUpdateContent" runat="server" Text="<%# BindItem.MessageContent%>"/>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Messages/CreateMessage.aspx" Text="Add New Message" runat="server" />
</asp:Content>
