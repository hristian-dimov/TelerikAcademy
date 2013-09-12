﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="formMain" runat="server">
            <asp:ListView ID="ListViewEmployees" runat="server" ItemType="Northwind.Data.Employee">
                <LayoutTemplate>
                    <table>
                        <thead>
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
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                
                <ItemSeparatorTemplate>
                    <tr></tr>
                </ItemSeparatorTemplate>

                <ItemTemplate>
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
                </ItemTemplate>
            </asp:ListView>

            <asp:DataPager ID="DataPagerCustomers" runat="server" PagedControlID="ListViewEmployees" PageSize="5"
                 QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
        </form>
    </body>
</html>
