<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modules.aspx.cs" Inherits="wpclass.modules" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formModules" runat="server">
        <div>
            <center>
                <asp:Label ID="Label1" runat="server" Text="Module Info">
                <br /><br />
                </asp:Label><asp:Label ID="Label2" runat="server" Text="Student"></asp:Label>
                <br /><br />
                <asp:DropDownList ID="DropDownList_students" DataTextField="student" DataValueField="student num" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList_students_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <asp:Label ID="Label_selected_student" runat="server" Text="Label"></asp:Label>
                <br /><br />
                <asp:DropDownList ID="DropDownList_modules" DataTextField="module code" DataValueField="module num" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList_modules_SelectedIndexChanged"></asp:DropDownList>
                <br /><br />
                <asp:Label  runat="server" Text="Lecturer"></asp:Label>
                <br />
                <asp:Label ID="Label_lecturer" runat="server" Text="Label" ForeColor="Brown"></asp:Label>
                <br />
                <asp:Label ID="Label_lecturer_email" runat="server" Text="Label" ForeColor="Brown"></asp:Label>
                <br /><br />
                <asp:Label ID="Label6" runat="server" Text="Faculty/College to which module belongs"></asp:Label>
                <br />
                <asp:Label ID="Label_faculty_college_owner" runat="server" Text="Label" ForeColor="Brown"></asp:Label>
                <br /><br />
                <asp:Label ID="Label3" runat="server" Text="Active Students on Selected Module:"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_students_doing_module" DataTextField="student" DataValueField="selection num" runat="server" AutoPostBack="true"></asp:DropDownList>
             </center>            
        </div>
    </form>
</body>
</html>
