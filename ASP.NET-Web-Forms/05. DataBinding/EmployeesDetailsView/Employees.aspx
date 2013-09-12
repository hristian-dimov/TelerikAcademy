<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesDetailsView.Employees" %>

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
                        DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/EmpDetails.aspx?id={0}" />
                </Columns>
            </asp:GridView>
        </form>
    </body>
</html>
