<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LibrarySystem.Admin.EditCategories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>
    <asp:GridView ID="GridViewCategories" runat="server"
                  ItemType="LibrarySystem.Models.Category" 
                  AutoGenerateColumns="false" DataKeyNames="Id" PageSize="5" AllowPaging="true" AllowSorting="true"
                  SelectMethod="GridViewCategories_GetData"
                  CssClass="table-striped table-hover table table-bordered" >

        <Columns>
            <asp:BoundField HeaderText="Category Name" DataField="CategoryName" SortExpression="CategoryName" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-warning" ID="EditCategoriesPanelButton" 
                                CommandArgument="<%#: Item.Id %>" 
                                OnCommand="EditCategoriesPanelButton_Command" Text="Edit" runat="server">
                    </asp:Button>
                    <asp:Button CssClass="btn btn-danger" ID="DeleteCategoryButton" 
                                CommandArgument="<%#: Item.Id %>"  
                                OnCommand="DeleteCategoryPanelButton_Command" runat="server" Text="Delete">
                    </asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button CssClass="btn btn-warning" id="ShowAddCategoryPanel"
         OnClick="ShowAddCategoryPanel_Click" Text="Create New" runat="server"></asp:Button>
    <br />
    <asp:Panel ID="CreateCategoryPanel" Visible="false" runat="server" >
        <h3>Create New Category</h3><br />
        Category:
        <asp:TextBox ID="CreateCategoryField" runat="server"></asp:TextBox><br />
        <asp:Button CssClass="btn btn-warning" OnCommand="CreateCategoryButton_Command"
                    ID="CreateCategoryButton" Text="Create" runat="server">
        </asp:Button>
        <asp:Button CssClass="btn btn-danger" OnClick="CancelCreateButton_Click" Text="Cancel" runat="server"></asp:Button>
    </asp:Panel>

    <asp:Panel ID="EditCategoryPanel" Visible="false" runat="server" >
        <h3>Edit category</h3><br />
        Category:
        <asp:TextBox ID="EditCategoryField" runat="server"></asp:TextBox><br />
        <asp:Button CssClass="btn btn-warning" OnCommand="EditCategoryButton_Command"
                    ID="EditCategoryButton" Text="Save" runat="server">
        </asp:Button>
        <asp:Button CssClass="btn btn-danger" OnClick="CancelButton_Click" Text="Cancel" runat="server"></asp:Button>
    </asp:Panel>

    <asp:Panel ID="DeleteCategoryPanel" Visible="false" runat="server" >
        <h3>Confirm Category Deletion?</h3><br />
        Category:
        <asp:TextBox ID="DeleteCategoryField" runat="server" Enabled="false"></asp:TextBox><br />
        <asp:Button CssClass="btn btn-warning" OnCommand="DeleteCategoryButton_Command"
                    ID="DeleteCategoryButton" Text="Yes" runat="server">
        </asp:Button>
        <asp:Button CssClass="btn btn-danger" OnClick="NoButton_Click" Text="No" runat="server"></asp:Button>
    </asp:Panel>

    <br />
    <asp:HyperLink NavigateUrl="~/" runat="server" CssClass="btn" Text="Back"></asp:HyperLink>
</asp:Content>