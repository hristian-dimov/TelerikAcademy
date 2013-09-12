<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesFormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="formMain" runat="server">
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:HyperLinkField DataTextField="FullName" HeaderText="Full Name"
                         DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Employees.aspx?id={0}" />
                </Columns>
            </asp:GridView>

            <asp:FormView ID="FormViewEmployee" runat="server" AllowPaging="True">
                <ItemTemplate>
                    EmployeeID:
                    <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%# Eval("EmployeeID") %>' />
                    <br />
                    LastName:
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
                    <br />
                    FirstName:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
                    <br />
                    Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Bind("Title") %>' />
                    <br />
                    TitleOfCourtesy:
                    <asp:Label ID="TitleOfCourtesyLabel" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
                    <br />
                    BirthDate:
                    <asp:Label ID="BirthDateLabel" runat="server" Text='<%# Bind("BirthDate") %>' />
                    <br />
                    HireDate:
                    <asp:Label ID="HireDateLabel" runat="server" Text='<%# Bind("HireDate") %>' />
                    <br />
                    Address:
                    <asp:Label ID="AddressLabel" runat="server" Text='<%# Bind("Address") %>' />
                    <br />
                    City:
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>' />
                    <br />
                    Region:
                    <asp:Label ID="RegionLabel" runat="server" Text='<%# Bind("Region") %>' />
                    <br />
                    PostalCode:
                    <asp:Label ID="PostalCodeLabel" runat="server" Text='<%# Bind("PostalCode") %>' />
                    <br />
                    Country:
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Bind("Country") %>' />
                    <br />
                    HomePhone:
                    <asp:Label ID="HomePhoneLabel" runat="server" Text='<%# Bind("HomePhone") %>' />
                    <br />
                    Extension:
                    <asp:Label ID="ExtensionLabel" runat="server" Text='<%# Bind("Extension") %>' />
                    <br />
                    Notes:
                    <asp:Label ID="NotesLabel" runat="server" Text='<%# Bind("Notes") %>' />
                    <br />
                    ReportsTo:
                    <asp:Label ID="ReportsToLabel" runat="server" Text='<%# Bind("ReportsTo") %>' />
                    <br />
                    PhotoPath:
                    <asp:Label ID="PhotoPathLabel" runat="server" Text='<%# Bind("PhotoPath") %>' />
                    <br />
                </ItemTemplate>
            </asp:FormView>
        </form>
    </body>
</html>
