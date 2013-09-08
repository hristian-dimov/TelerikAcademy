<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="_01.HelloName.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
    <div>
        <asp:Label Text="Name:" AssociatedControlID="TextBoxName" ID="LabelName" runat="server" />
        <asp:TextBox ID="TextBoxName" runat="server" />
        <asp:Button Text="Submit" runat="server" OnClick="ButtonDisplayName_Click" />

        <h1 runat="server" id="Result"></h1>
    </div>
    </form>
</body>
</html>
