<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="HeaderTitle">
        <h1>Books</h1>
    </div>
    <div id="SearchBox">
        <asp:TextBox ID="TextBoxSearch" runat="server" placeholder="Search by book title / author..." />
        <asp:Button Text="Search" runat="server" ID="ButtonSearch" OnClick="ButtonSearch_Click"></asp:Button>
    </div>

    <br style="clear: both" />

    <asp:Repeater ID="RepeaterCategories" runat="server" ItemType="LibrarySystem.Models.Category">
        <ItemTemplate>
            <div class="catRow">
                <h2><%#: Item.CategoryName %></h2>
                <asp:ListView ID="ListViewBooksInCategory" runat="server" ItemType="LibrarySystem.Models.Book"
                              DataSource="<%# Item.Books %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:hyperlink NavigateUrl='<%#: "BookDetails?id=" + Item.Id %>' runat="server">
                                    "<%#: Item.Title %>" <i>by <%#: Item.Author %></i>
                                </asp:hyperlink>
                            </li>
                        </ItemTemplate>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <i> No books in this category. </i>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
