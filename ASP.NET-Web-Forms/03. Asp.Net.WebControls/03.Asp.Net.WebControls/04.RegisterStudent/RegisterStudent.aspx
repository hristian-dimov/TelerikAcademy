<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="_04.RegisterStudent.RegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:Label ID="LabelFirstName" Text="First Name" AssociatedControlID="TextBoxFirstName" runat="server" />
            <asp:TextBox ID="TextBoxFirstName" runat="server" />
            <br />

            <asp:Label ID="LabelLastName" Text="Last Name" AssociatedControlID="TextBoxLastName" runat="server" />
            <asp:TextBox ID="TextBoxLastName" runat="server" />
            <br />

            <asp:Label ID="LabelFacultyNumber" Text="Faculty Number" AssociatedControlID="TextBoxFacultyNumber" runat="server" />
            <asp:TextBox ID="TextBoxFacultyNumber" runat="server" />
            <br />

            <asp:Label ID="LabelUniversity" Text="University" AssociatedControlID="DropDownListUniversity" runat="server" />
            <asp:DropDownList ID="DropDownListUniversity" runat="server">
                <asp:ListItem Value="1" Text="NBU" />
                <asp:ListItem Value="2" Text="SU" />
                <asp:ListItem Value="3" Text="TU" />
            </asp:DropDownList>
            <br />

            <asp:Label ID="LabelSpecialty" Text="Specialty" AssociatedControlID="DropDownListSpecialty" runat="server" />
            <asp:DropDownList ID="DropDownListSpecialty" runat="server">
                <asp:ListItem Value="1" Text="Software Engeneering" />
                <asp:ListItem Value="2" Text="Arts" />
                <asp:ListItem Value="3" Text="Economics" />
            </asp:DropDownList>
            <br />

            <asp:Label ID="LabelCourses" Text="Courses" AssociatedControlID="ListBoxCourses" runat="server" />
            <asp:ListBox ID="ListBoxCourses" SelectionMode="Multiple" runat="server">
                 <asp:ListItem Value="1" Text=".NET Essentials" />
                <asp:ListItem Value="2" Text="Java 101" />
                <asp:ListItem Value="3" Text="Javascript for pros" />
                <asp:ListItem Value="4" Text="Math" />
            </asp:ListBox>
            <br />

            <asp:Button ID="ButtonSubmit" OnClick="ButtonSubmit_Click" Text="Submit" runat="server" />

            <asp:Panel ID="PanelResult" runat="server"></asp:Panel>
        </form>
    </body>
</html>
