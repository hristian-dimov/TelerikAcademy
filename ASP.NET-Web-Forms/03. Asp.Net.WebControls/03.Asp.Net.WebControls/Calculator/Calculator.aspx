<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxFirstNum" runat="server">1</asp:TextBox>
        <asp:TextBox ID="TextBoxSecondNum" runat="server">2</asp:TextBox>

        <asp:Button ID="ButtonAdd" Text="+" runat="server" />
        
    </div>
    </form>
</body>
</html>
