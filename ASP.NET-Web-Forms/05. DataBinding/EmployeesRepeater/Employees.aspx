<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="formRepeater" runat="server">
            <asp:Repeater ID="RepeaterEmployees" runat="server" ItemType="Northwind.Data.Employee">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>FirstName</th>
                            <th>LastName</th>
                            <th>Title</th>
                            <th>BirthDate</th>
                            <th>HireDate</th>
                            <th>Region</th>
                            <th>Country</th>
                            <th>City</th>
                            <th>Address</th>
                            <th>HomePhone</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.FirstName %></td>
                        <td><%#: Item.LastName %></td>
                        <td><%#: Item.Title %></td>
                        <td><%#: Item.BirthDate %></td>
                        <td><%#: Item.HireDate %></td>
                        <td><%#: Item.Region %></td>
                        <td><%#: Item.Country %></td>
                        <td><%#: Item.City %></td>
                        <td><%#: Item.Address %></td>
                        <td><%#: Item.HomePhone %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </form>
    </body>
</html>
