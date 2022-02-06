<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="halls.aspx.cs" Inherits="wpclass.halls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Utech Residential Halls Application</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="titleLabel" runat="server" Text="Utech Residential Halls Application"></asp:Label>
            <br /><br />
            <asp:CheckBox ID="studentCheckbox" Text="Student" runat="server" OnCheckedChanged="studentCheckbox_CheckedChanged" AutoPostBack="true"/>
            <br />
            <asp:CheckBox ID="athleteCheckbox" Text="Is an athlete" runat="server" AutoPostBack="true" OnCheckedChanged="athleteCheckbox_CheckedChanged" Visible="false"/>
            <br /><br />
            <asp:Label ID="hallLabel" runat="server" Text="Hall" Visible="false"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Visible="false"></asp:DropDownList>
            <br /><br />
            <asp:Button ID="resetButton" runat="server" Text="Reset" Visible="false" OnClick="resetButton_Click"/>

        </div>
    </form>
</body>
</html>
