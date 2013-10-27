<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Twitter.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="main-content-heading">User Profile</h1>
    <div class="row">
        <div class="span2">   
            <img id="userPhoto" runat="server" class="img-polaroid" />
            <br />
            <asp:LinkButton ID="FollowButton" runat="server" Text="Follow me"
                OnClick="FollowButton_Click" Visible="false" CssClass="btn btn-primary"></asp:LinkButton>
        </div>
        <div class="span6">
            <h3>Username:</h3>
            <asp:Label runat="server" ID="LabelUserName" Font-Size="Large"></asp:Label>
            <h3>Followers:</h3>
            <asp:Label runat="server" ID="followersCount" Font-Size="Large"></asp:Label>
            <h3>Followings:</h3>
            <asp:Label runat="server" ID="followingsCount" Font-Size="Large"></asp:Label>
        </div>
    </div>
</asp:Content>
