<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="wpclass.Logiin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MCLAB2-1703882</title>
    <link href="Styles/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, intial-scale=1.0" />
</head>
<body class="container">
    <form id="form1" runat="server">
        <div>
            <center>
                <asp:Label ID="Label1" runat="server" Text="WELCOME TO SKOOLERS!"></asp:Label>
                <br /><br />
                <asp:TextBox CssClass="textbox" ID="TextBox_username" runat="server" placeholder="Enter Username"></asp:TextBox>
                <br /><br />
                <asp:TextBox CssClass="textbox" ID="TextBox_password" runat="server" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
                <br /><br />
                <asp:Button CssClass="button" ID="Button_login" runat="server" Text="Login" OnClick="Button_login_Click" />
                <br /><br />
                <asp:Label ID="Label_login_info" runat="server" Text="Label" Visible="false"></asp:Label>
            </center>
        </div>
    </form>
</body>
</html>
