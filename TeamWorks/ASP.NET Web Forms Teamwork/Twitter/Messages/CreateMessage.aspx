<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateMessage.aspx.cs" Inherits="Twitter.Messages.CreateMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1></h1>
    <div class="row-fluid">
        <div class="span7">
            <section id="createMessageForm">
                <fieldset class="form-horizontal">
                    <legend>Create new message.</legend>
                    <div class="control-group">
                        <asp:Label runat="server" AssociatedControlID="MessageContent" CssClass="control-label">Message content</asp:Label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="MessageContent" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="MessageContent"
                                CssClass="text-error" ErrorMessage="The channel name field is required." />
                            <asp:DropDownList runat="server" ID="DropDownListChannels"/>
                        </div>
                        <div class="controls">
                            <asp:Button CssClass="btn btn-primary" ID="ButtonCreateMessage" Text="Create" OnClick="ButtonCreateMessage_Click" runat="server" />
                        </div>
                    </div>
                </fieldset>
            </section>
        </div>
    </div>
</asp:Content>
