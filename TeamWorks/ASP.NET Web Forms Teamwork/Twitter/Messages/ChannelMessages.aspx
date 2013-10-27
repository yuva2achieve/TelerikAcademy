<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChannelMessages.aspx.cs" Inherits="Twitter.Messages.ChannelMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="main-content-heading" runat="server" id="ChannelNameHolder"></h1>

    <asp:UpdatePanel runat="server" ID="UpdatePanelMessageInfo" UpdateMode="Conditional">

        <ContentTemplate>
            <div id="InfoHolder" runat="server"></div>
            <asp:GridView runat="server" ID="GridViewMessages"
                AutoGenerateColumns="false"
                ItemType="Twitter.Models.Message" CssClass="table"
                SelectMethod="GridViewChannels_GetData" ShowFooter="true" ShowHeader="true"
                AllowPaging="true" PageSize="5" AllowSorting="true" ShowHeaderWhenEmpty="true"
                EmptyDataText="No Messages">
                <EmptyDataTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton CssClass="btn btn-primary theMessage" runat="server"
                                ID="HyperLinkAddMessage" OnClick="HyperLinkAddMessage_Click"
                                Text="Add Message" /></FooterTemplate></td>
                        <td>
                            <asp:TextBox ID="MessageContent" runat="server" />
                        </td>
                    </tr>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Creator
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="<%#: Item.AspNetUser.UserName %>"
                                PostBackUrl='<%# String.Format("~/UserProfile.aspx?username={0}", Eval("AspNetUser.UserName").ToString()) %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton CssClass="btn btn-primary" runat="server"
                                ID="HyperLinkAddMessage" OnClick="HyperLinkAddMessage_Click"
                                Text="Add Message" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Content" SortExpression="MessageContent">
                        <ItemTemplate>
                            <asp:LinkButton Text="<%#:Item.MessageContent%>" runat="server" ID="LinkButtonViewMessageDetails"
                                CommandArgument="<%#:Item.MessageId%>" OnCommand="LinkButtonViewMessageDetails_Command" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="MessageContent" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Panel ID="PanelMessageInfoHolder" runat="server">
                <asp:Literal Text="Message Id" runat="server" />
                <asp:Label ID="LabelMessageId" Text="" runat="server" />
                <br />
                <asp:Literal Text="Message Creator" runat="server" />
                <asp:Label ID="LabelMessageCreator" Text="" runat="server" />
                <br />
                <asp:Literal Text="Message Content" runat="server" />
                <asp:Label ID="LabelMessageContent" Text="" runat="server" />
                <br />
                <asp:Literal Text="Message Post Date" runat="server" />
                <asp:Label ID="LabelMessageDate" Text="" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
