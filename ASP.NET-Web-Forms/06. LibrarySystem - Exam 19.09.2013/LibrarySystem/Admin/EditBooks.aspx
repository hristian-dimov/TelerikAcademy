<%@ Page Title="Edit books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Admin.EditBooks" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>
    <asp:GridView ID="GridViewBooks" runat="server"
                  ItemType="LibrarySystem.Models.Book" 
                  AutoGenerateColumns="false" DataKeyNames="Id" PageSize="5" AllowPaging="true" AllowSorting="true"
                  SelectMethod="GridViewBooks_GetData"
                  CssClass="table-striped table-hover table table-bordered" OnRowDataBound="GridViewBooks_RowDataBound">

        <Columns>
            <asp:BoundField HeaderText="Title" DataField="Title" SortExpression="Title" />
            <asp:BoundField HeaderText="Author" DataField="Author" SortExpression="Author" />
            <asp:BoundField HeaderText="ISBN" DataField="ISBN" SortExpression="ISBN" />
            <asp:HyperLinkField DataTextField="WebSite" HeaderText="WebSite" DataNavigateUrlFields="WebSite" SortExpression="WebSite" />
            <asp:BoundField HeaderText="Category" DataField="Category.CategoryName" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-warning" ID="EditBooksPanelButton" 
                                CommandArgument="<%#: Item.Id %>" 
                                OnCommand="EditBooksPanelButton_Command" Text="Edit" runat="server">
                    </asp:Button>
                    <asp:Button CssClass="btn btn-danger" ID="DeleteBooksButton" 
                                CommandArgument="<%#: Item.Id %>"  
                                OnCommand="DeleteBooksButton_Command" Text="Delete" runat="server">
                    </asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button CssClass="btn btn-warning" id="ShowAddBookPanel"
                OnClick="ShowAddBookPanel_Click" Text="Create New" runat="server"></asp:Button>
    <br />
    <asp:Panel ID="CreateBookPanel" Visible="false" runat="server">
        <h3>Create New Book</h3><br />
        <asp:Label Text="Title" AssociatedControlID="TextBoxTitle" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox><br />

        <asp:Label Text="Author(s)" AssociatedControlID="TextBoxAuthor" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxAuthor" runat="server"></asp:TextBox><br />

        <asp:Label Text="ISBN" AssociatedControlID="TextBoxISBN" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxISBN" runat="server"></asp:TextBox><br />

        <asp:Label Text="Web Site" AssociatedControlID="TextBoxWebSite" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxWebSite" runat="server"></asp:TextBox><br />

        <asp:Label Text="Description" AssociatedControlID="TextBoxDescription" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxDescription" TextMode="MultiLine" runat="server"></asp:TextBox><br />

        <asp:Label Text="Category" AssociatedControlID="DropDownListCategory" runat="server"></asp:Label>
        <asp:DropDownList ID="DropDownListCategory" runat="server" ItemType="LibrarySystem.Models.Category"
                          DataTextField="CategoryName" DataValueField="Id"></asp:DropDownList><br />

        <asp:Button CssClass="btn btn-warning" OnCommand="CreateBookButton_Command"
                    ID="CreateBookButton" Text="Create" runat="server">
        </asp:Button>
        <asp:Button CssClass="btn btn-danger" OnClick="CancelCreateButton_Click" Text="Cancel" runat="server"></asp:Button>
    </asp:Panel>

    <asp:Panel ID="EditBookPanel" Visible="false" runat="server" >
        <h3>Edit Book</h3><br />
        <asp:Label Text="Title" AssociatedControlID="TextBoxEditTitle" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxEditTitle" runat="server"></asp:TextBox><br />

        <asp:Label Text="Author(s)" AssociatedControlID="TextBoxEditAuthor" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxEditAuthor" runat="server"></asp:TextBox><br />

        <asp:Label Text="ISBN" AssociatedControlID="TextBoxEditISBN" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxEditISBN" runat="server"></asp:TextBox><br />

        <asp:Label Text="Web Site" AssociatedControlID="TextBoxEditWebSite" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxEditWebSite" runat="server"></asp:TextBox><br />

        <asp:Label Text="Description" AssociatedControlID="TextBoxEditDescription" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxEditDescription" TextMode="MultiLine" runat="server"></asp:TextBox><br />

        <asp:Label Text="Category" AssociatedControlID="DropDownListEditCategory" runat="server"></asp:Label>
        <asp:DropDownList ID="DropDownListEditCategory" runat="server" ItemType="LibrarySystem.Models.Category"
                          DataTextField="CategoryName" DataValueField="Id"></asp:DropDownList><br />

        <asp:Button CssClass="btn btn-warning" OnCommand="EditBookButton_Command"
                    ID="EditBookButton" Text="Edit" runat="server">
        </asp:Button>
        <asp:Button CssClass="btn btn-danger" OnClick="CancelButton_Click" Text="Cancel" runat="server"></asp:Button>
    </asp:Panel>

    <asp:Panel ID="DeleteBookPanel" Visible="false" runat="server" >
        <h3>Confirm Book Deletion?</h3><br />
        Title:
        <asp:TextBox ID="DeleteBookField" runat="server" Enabled="false"></asp:TextBox><br />
        <asp:Button CssClass="btn btn-warning" OnCommand="DeleteBookButton_Command"
                    ID="DeleteBookButton" Text="Yes" runat="server">
        </asp:Button>
        <asp:Button CssClass="btn btn-danger" OnClick="NoButton_Click" Text="No" runat="server"></asp:Button>
    </asp:Panel>

    <br />
    <asp:HyperLink NavigateUrl="~/" runat="server" CssClass="btn" Text="Back"></asp:HyperLink>
</asp:Content>