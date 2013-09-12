<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="CarsStore.Store" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:DropDownList ID="DropDownProducers" DataTextField="Name" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownProducers_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:DropDownList ID="DropDownModels" runat="server" AutoPostBack="True">
            </asp:DropDownList>

            <br />
            <asp:CheckBoxList ID="CheckBoxListExtras" runat="server" DataTextField="Name"></asp:CheckBoxList>

            <br />
            <asp:RadioButtonList ID="RadioButtonsEngines" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>

            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />

            <br /><br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </form>
    </body>
</html>
