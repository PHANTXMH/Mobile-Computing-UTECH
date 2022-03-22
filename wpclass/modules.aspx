<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modules.aspx.cs" Inherits="wpclass.modules" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formModules" runat="server">
        <center>
        <div id="divMain" class="div" runat="server">
            <br />
            <asp:Button ID="Button_Main_Student_Maintenance" runat="server" Text="Student Maintenance" class="button" OnClick="Button_Main_Student_Maintenance_Click"/>
            <br />
            <asp:Button ID="Button_Main_Module_Maintenance" runat="server" Text="Module Maintenance" class="button" OnClick="Button_Main_Module_Maintenance_Click"/>
            <br />
            <asp:Button ID="Button_Main_Module_Info" runat="server" Text="Module Info" class="button" OnClick="Button_Main_Module_Info_Click"/>
            <br />
        </div>
        <div id="divModuleInfo" runat="server">            
                <asp:Label ID="Label1" runat="server" Text="Module Info"></asp:Label>
                <br /><br />                              
                <asp:GridView ID="GridView_student_info" runat="server" BorderStyle="None" AutoGenerateColumns="false">       
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button_modules_select" runat="server" Text="Select" OnClick="Button_student_select_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField ="student num" />
                        <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="student" HeaderText="Student" HeaderStyle-CssClass="labelstuff" />                        
                    </Columns>
                </asp:GridView>
                 <br />
                <asp:Label ID="Label_selected_student" runat="server" Text="Label"></asp:Label>
                <br /><br />                                    
                <asp:GridView ID="GridView_module_info" runat="server" BorderStyle="None" AutoGenerateColumns="false">       
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button_modules_info" runat="server" Text="Select" OnClick="Button_modules_info_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField ="module num" />
                        <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="module code" HeaderText="Module" HeaderStyle-CssClass="labelstuff" />                        
                    </Columns>
                </asp:GridView>
                 <br />
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
                <br />
                <br />
                <br />
                <asp:Button ID="Button_go_back1" runat="server" Text="Go Back" class="button" OnClick="Button_go_back1_Click"/>
                         
        </div>
        <div id="divStudentMaint" runat="server">
            <br />
            <asp:Label ID="Label4" runat="server" Text="Student" CssClass="label"></asp:Label>
            <br />
            
            <asp:GridView ID="GridView_students" runat="server" BorderStyle="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Button_students_select" runat="server" Text="Select" OnClick="Button_students_select_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField ="student num" />
                    <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="last name" HeaderText="Last Name" HeaderStyle-CssClass="labelstuff" />
                    <asp:BoundField ItemStyle-CssClass="labelstuff" DataField="first name" HeaderText="First Name" HeaderStyle-CssClass="labelstuff" />
                </Columns>
            </asp:GridView>
            <asp:TextBox ID="TextBox_gridviewstudents_selected_num" Visible="false" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="First Name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_studentMaint_firstname" runat="server" MaxLength="17" CssClass="textbox"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label7" runat="server" Text="Last Name" CssClass="label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_studentMaint_lastname" runat="server" CssClass="label" MaxLength="17"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label_studentMain_feedback" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button_studentMaint_new" runat="server" Text="New" OnClick="Button_studentMaint_new_Click" />
            <br />
            <asp:Button ID="Button_studentMaint_add" runat="server" Text="Add" OnClick="Button_studentMaint_add_Click" />
            <br />
            <asp:Button ID="Button_studentMaint_update" runat="server" Text="Update" OnClick="Button_studentMaint_update_Click" />
            <br />
            <asp:Button ID="Button_go_back1a" runat="server" Text="Go Back" OnClick="Button_go_back1a_Click" />
            <br /><br />
        </div>
        <div id="divModuleMaint" runat="server">
            <br />
            <asp:Label ID="Label8" runat="server" Text="Module"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList_ModuleMaint_module" runat="server" CssClass="droplist" DataTextField="module code" DataValueField="module num" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_ModuleMaint_module_SelectedIndexChanged" ></asp:DropDownList>
            <br />
            <asp:Button ID="Button_moduleMaint_edit" runat="server" Text="Edit" OnClick="Button_moduleMaint_edit_Click" />
            <br /><br />
            <asp:Label ID="Label9" runat="server" Text="Module Name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox_moduleMaint_modulename" runat="server" MaxLength="17" CssClass="label"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label10" runat="server" Text="Lecturer Name"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList_ModuleMaint_lectuerername" runat="server" CssClass="droplist"  DataTextField="lecturer" DataValueField="lecturer num"></asp:DropDownList>
            <br /><br />
            <asp:Label ID="Label11" runat="server" Text="Faculty Name"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList_ModuleMaint_facultyname" runat="server" CssClass="droplist" DataTextField="fc name" DataValueField="fc num"></asp:DropDownList>
            <br /><br />
            <asp:Label ID="Label_moduleMaint_feedback" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="Button_moduleMaint_new" runat="server" Text="New" OnClick="Button_moduleMaint_new_Click"/>
            <br />
            <asp:Button ID="Button_moduleMaint_add" runat="server" Text="Add" OnClick="Button_moduleMaint_add_Click"/>
            <br />
            <asp:Button ID="Button_moduleMaint_update" runat="server" Text="Update" OnClick="Button_moduleMaint_update_Click"/>
            <br />
            <asp:Button ID="Button_go_back2a" runat="server" Text="Go Back" OnClick="Button_go_back1a_Click"/>
        </div>
        </center>
    </form>
</body>
</html>
