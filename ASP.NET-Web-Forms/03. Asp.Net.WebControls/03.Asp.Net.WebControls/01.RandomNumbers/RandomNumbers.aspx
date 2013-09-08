<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="_01.RandomNumbers.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>Generate random number</p>
        <asp:Label ID="LabelFirstNumber" Text="From" AssociatedControlID="TextBoxFirstNumber" runat="server" />
        <asp:TextBox ID="TextBoxFirstNumber" runat="server" />  
        <br />

        <asp:Label ID="LabelSecondNumber" Text="To" AssociatedControlID="TextBoxSecondNumber" runat="server" />
        <asp:TextBox ID="TextBoxSecondNumber" runat="server" />  
        <br />

        <asp:Button ID="ButtonGenerateRandom" OnClick="ButtonGenerateRando_Click" Text="Generate Number" runat="server" />
        <br />
        <h2 id="result" runat="server"></h2>

    </form>
</body>
</html>
