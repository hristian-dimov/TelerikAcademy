<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="EmployeesDetailsView.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="formMain" runat="server">
            <asp:DetailsView ID="DetailsViewEmployee" runat="server" AutoGenerateRows="true">
            </asp:DetailsView>
            <br />
            <asp:HyperLink NavigateUrl="~/Employees.aspx" runat="server" Text="[ Back ]" />
        </form> 
    </body>
</html>
