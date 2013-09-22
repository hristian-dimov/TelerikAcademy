<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Search Results for Query "<i runat="server" ID="IQuery"></i>":
    </h1>

    <asp:ListView ID="ListViewSearchResult" runat="server" ItemType="LibrarySystem.Models.Book">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink NavigateUrl='<%#: "BookDetails?id=" + Item.Id %>' runat="server">
                    <%#: Item.Title %> by <%#: Item.Author %>
                    </asp:HyperLink> ( Category: <%#: Item.Category.CategoryName %> )
                </li>
            </ItemTemplate>
        </ItemTemplate>
    </asp:ListView>

    <br />
    <asp:HyperLink NavigateUrl="~/" runat="server" CssClass="btn" Text="Back"></asp:HyperLink>
</asp:Content>