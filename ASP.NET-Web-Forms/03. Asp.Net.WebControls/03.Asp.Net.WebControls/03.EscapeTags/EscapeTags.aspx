<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscapeTags.aspx.cs" Inherits="_03.EscapeTags.EscapeTags"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="LabelEnterText" AssociatedControlID="TextBoxEnterText" Text="Enter text:" runat="server" />
        <asp:TextBox ID="TextBoxEnterText" runat="server" />
        <br />

        <asp:Button ID="ButtonSubmit" OnClick="ButtonSubmit_Click" Text="Submit" runat="server" />
        <br />

        <asp:Label ID="LabelResult" Text="" runat="server" />
        <br />
        <asp:TextBox ID="TextBoxResult" runat="server" />
    </form>
</body>
</html>
