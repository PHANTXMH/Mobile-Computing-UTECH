<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prison.aspx.cs" Inherits="wpclass.prison" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prison</title>
    <link href="Style/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, intial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="PRISON ENROLMENT"></asp:Label>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
            <br />
            <asp:TextBox ID="lastNameTextBox" width="120" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="First Name"></asp:Label>
            <br />
            <asp:TextBox ID="firstNameTextBox" Width="120" runat="server"></asp:TextBox>
            <br /><br />
            <asp:CheckBox ID="maleCheckbox" Text="Male" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"/>
            <br /><br />
            <asp:Label ID="Label4" runat="server" Text="Prison"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList_prisons" runat="server"></asp:DropDownList>

        </div>
    </form>
</body>
</html>
