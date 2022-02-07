<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffmembers.aspx.cs" Inherits="wpclass.staffmembers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MCLAB1-1703882</title>
    <link href="Styles/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, intial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <asp:CheckBox ID="turnOffCheckBox" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />
                <asp:Label ID="Label1" runat="server" Text="Turn Off"></asp:Label>
                <br /><br />
                <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label>
                <br />
                <asp:DropDownList class="droplist" ID="departmentDropDownList" runat="server" DataTextField="department name" DataValueField="department num" OnSelectedIndexChanged="departmentDropDownList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <br /><br />
                <asp:Label ID="Label3" runat="server" Text="Staff Member"></asp:Label>
                <br />
                <asp:DropDownList ID="staffDropDownList" class="droplist" runat="server" AutoPostBack="true" DataTextField="staff" 
                    DataValueField="member number" OnDataBound="DropDownList_DataBound" OnSelectedIndexChanged="staffDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <br /><br />
                <asp:Label ID="Label4" runat="server" Text="Contact No for Staff Member"></asp:Label>
                <br />
                <asp:Label ID="staffContactLabel" runat="server" Text="-" ForeColor="brown"></asp:Label>
                <br /><br />
                <asp:Label ID="Label6" runat="server" Text="Full Address of Staff Member"></asp:Label>
                <br />
                <asp:Label ID="staffAddressLabel" runat="server" Text="-" ForeColor="brown"></asp:Label>
                <br /><br />
                <asp:Label ID="Label5" runat="server" Text="Countries travelled to in the past by staff member"></asp:Label>
                <br />
                <asp:DropDownList ID="travelledDropDownList" class="droplist" runat="server" DataTextField="country name" AutoPostBack="true"></asp:DropDownList>
            </center>
            
        </div>
    </form>
</body>
</html>
