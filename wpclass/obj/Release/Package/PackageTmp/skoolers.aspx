<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="skoolers.aspx.cs" Inherits="wpclass.Skoolers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MCLAB2-1703882</title>
    <link href="Styles/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, intial-scale=1.0" />
</head>
<body class="container">
    <form id="formSkoolers" runat="server" >
        <asp:Button ID="Button_back" runat="server" Text="Go Back" OnClick="Button_back_Click" />
        <br /><br />
        <br />
        <center>
            <div id="divMain" class="div" runat="server">
                <br />
                <asp:Button class="button" ID="Button_highSchool_maint" runat="server" Text="High School Maintainance" OnClick="Button_highSchool_maint_Click" />
                <br /><br />
                <asp:Button CssClass="button" ID="Button_view_school" runat="server" Text="View Schools" OnClick="Button_view_school_Click" />
                <br /><br />
                <asp:Button CssClass="button" ID="Button_logoff" runat="server" Text="Log Off" OnClick="Button_logoff_Click" />
            </div>
            <div id="divHighSchoolMaint" class="div" runat="server">
                <br />
                <asp:Label ID="Label1" runat="server" Text="High School"></asp:Label>
                <br /><br />
                <asp:DropDownList CssClass="droplist" ID="DropDownList_schoolname" runat="server" OnSelectedIndexChanged="DropDownList_schoolname_SelectedIndexChanged"
                    DataValueField="hs num" DataTextField="hs name" AutoPostBack="true"></asp:DropDownList>
                <br /><br />
                <asp:TextBox CssClass="textbox" ID="TextBox_schoolname" runat="server" Enabled="false" placeholder="Enter school name here" Width="260px"></asp:TextBox>
                <br />
                <asp:Label ID="Label_head_student" runat="server" Text="Choose Head Student:" Visible="false"></asp:Label>
                <asp:DropDownList CssClass="droplist" ID="DropDownList_headstudent" runat="server" Enabled="false" DataValueField="student num" DataTextField="student"
                    AutoPostBack="true"></asp:DropDownList>
                <br /><br />
                <asp:Button CssClass="button" ID="Button_schoolname_new" runat="server" Text="New" OnClick="Button_schoolname_new_Click" />
                <br />                
                <asp:Button CssClass="button" ID="Button_schoolname_update" runat="server" Text="Update" Visible="false" OnClick="Button_schoolname_update_Click" />        
                <br />
                <asp:Button CssClass="button" ID="Button_schoolname_add" runat="server" Text="Add" Visible="false" OnClick="Button_schoolname_add_Click"/>
                <br />
                <asp:Button CssClass="button" ID="Button_schoolname_edit" runat="server" Text="Edit"  OnClick="Button_schoolname_edit_Click"/>
                <br />
                <asp:Label ID="Label_progress_info" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <div id="divViewSchool" class="div" runat="server">
                <asp:Label ID="Label2" runat="server" Text="View High Schools"></asp:Label>
                <br />
                <br />
                <asp:DropDownList CssClass="droplist" ID="DropDownList_view_highschools" DataValueField="hs num" DataTextField="hs name" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_view_highschools_SelectedIndexChanged"></asp:DropDownList>
                <br /><br />
                <asp:Label ID="Label3" runat="server" Text="School Name: "></asp:Label>
                <asp:TextBox CssClass="textbox" ID="TextBox_view_school_name" runat="server" Enabled="false"></asp:TextBox>
                <br /><br />
                <asp:Label ID="Label4" runat="server" Text="Head Student: "></asp:Label>
                <asp:TextBox CssClass="textbox" ID="TextBox_view_school_head_student" runat="server" Enabled="false"></asp:TextBox>
            </div>            
        </center>
                
    </form>
</body>
</html>
