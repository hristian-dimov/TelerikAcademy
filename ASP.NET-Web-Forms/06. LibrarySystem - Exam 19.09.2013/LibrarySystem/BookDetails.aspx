<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>
    
    <div id="BookTitle" runat="server"></div>
    <div id="BookAuthor" runat="server"></div>
    <div id="BookISBN" runat="server"></div>
    <div id="BookWebSite">Web site: <a ID="BookWebSiteURL" runat="server"></a></div>
    <div id="BookDescription" runat="server"></div>

    <br />
    <asp:HyperLink NavigateUrl="~/" runat="server" CssClass="btn" Text="Back"></asp:HyperLink>
</asp:Content>