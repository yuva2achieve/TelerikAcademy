<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateChannel.aspx.cs" Inherits="Twitter.Channels.CreateChannel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1></h1>
    <div class="row-fluid">
        <div class="span7">
            <section id="loginForm">
                <fieldset class="form-horizontal">
                    <legend>Create new channel.</legend>
                    <div class="control-group">
                        <asp:Label runat="server" AssociatedControlID="ChannelName" CssClass="control-label">Channel name</asp:Label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="ChannelName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ChannelName"
                                CssClass="text-error" ErrorMessage="The channel name field is required." />
                        </div>
                        <div class="controls">
                            <asp:Button ID="ButtonCreateChannel" Text="Create" OnClick="ButtonCreateChannel_Click" runat="server" />
                        </div>
                    </div>
                </fieldset>
            </section>
        </div>
    </div>
</asp:Content>
