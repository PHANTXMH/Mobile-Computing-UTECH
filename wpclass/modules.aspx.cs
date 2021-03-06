using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace wpclass
{
    public partial class modules : System.Web.UI.Page
    {
        DataAccessModules dbAccess = new DataAccessModules();
        int selectedGrid, selectedGridNum;
        string gridData;        

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["selectedGrid"] = 0;

            if (!IsPostBack)
            {
                startUp();
            }
        }

        void divsOff()
        {
            divMain.Visible = divStudentMaint.Visible = divModuleInfo.Visible = divModuleMaint.Visible = divLecturerMaint.Visible = false;

        }

        string Empty()
        {
            return string.Empty;
        }

        void clearMessages()
        {
            Label_studentMain_feedback.Text = Empty();
            Label_moduleMaint_feedback.Text = Empty();
        }

        void startUp()
        {            
            //refreshModules();
            GridView_student_info.DataSource = dbAccess.getAllStudents();
            GridView_student_info.DataBind();
            GridView_student_info.Columns[1].Visible = false;

            GridView_lecturer.DataSource = dbAccess.getAllLecturerDetails();
            GridView_lecturer.DataBind();
            //GridView_lecturer.Columns[1].Visible = false;

            divsOff();
            divMain.Visible = true;

            Label_faculty_college_owner.Text =
                Label_lecturer.Text =
                Label_lecturer_email.Text = string.Empty;
            DropDownList_students_doing_module.Items.Clear();
            Button_lecturer_confirm_update.Visible = false;
        }

        void refreshModules()
        {            
            GridView_module_info.DataSource = dbAccess.getModules(selectedGrid);
            GridView_module_info.DataBind();

            Label_faculty_college_owner.Text =
                Label_lecturer.Text =
                Label_lecturer_email.Text = string.Empty;
            DropDownList_students_doing_module.Items.Clear();

            Label_selected_student.Text = gridData;
        }

        protected void DropDownList_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshModules();
        }

        void showModuleInfo()
        {
            Label_faculty_college_owner.Text =
                Label_lecturer.Text =
                Label_lecturer_email.Text = string.Empty;
            DropDownList_students_doing_module.Items.Clear();
                        
            if (GridView_module_info.Rows.Count == 0) return;

            populateStudentsDoingSelectedModule();

            DataTable db = dbAccess.getModule(selectedGridNum);
            
            if (db.Rows.Count == 0) return;
            Label_lecturer.Text = db.Rows[0]["lecturer"].ToString();
            Label_lecturer_email.Text = db.Rows[0]["email"].ToString();
            Label_faculty_college_owner.Text = db.Rows[0]["fc name"].ToString();
            
        }

        void populateStudentsDoingSelectedModule()
        {            
            DropDownList_students_doing_module.DataSource = dbAccess.getAllStudentsByModule(selectedGridNum);
            DropDownList_students_doing_module.DataBind();
        }

        protected void DropDownList_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            showModuleInfo();
        }

        protected void Button_go_back1_Click(object sender, EventArgs e)
        {
            divsOff();
            divMain.Visible = true;
        }

        protected void Button_Main_Module_Info_Click(object sender, EventArgs e)
        {
            divsOff();
            divModuleInfo.Visible = true;
        }

        protected void Button_Main_Student_Maintenance_Click(object sender, EventArgs e)
        {
            divsOff();
            divStudentMaint.Visible = true;
            clearMessages();
            refreshStudentMaint_students();
        }

        protected void Button_Main_Module_Maintenance_Click(object sender, EventArgs e)
        {
            divsOff();
            divModuleMaint.Visible = true;
            clearMessages();
            refreshModuleMaint_modules();
            populateModuleDetails();
        }

        protected void Button_Main_Lecturer_Maintenance_Click(object sender, EventArgs e)
        {
            divsOff();
            divLecturerMaint.Visible = true;
        }

        void BackToMain()
        {
            divsOff();
            divMain.Visible = true;
        }
        protected void Button_go_back1a_Click(object sender, EventArgs e)
        {
            BackToMain();
        }

        void formsStudentMaintenanceOff()
        {
            TextBox_studentMaint_firstname.Enabled =
                TextBox_studentMaint_lastname.Enabled =
                Button_studentMaint_add.Enabled =
                Button_studentMaint_update.Enabled = false;

            TextBox_studentMaint_firstname.BackColor =
                Button_studentMaint_add.BackColor =
                Button_studentMaint_update.BackColor =
                TextBox_studentMaint_lastname.BackColor = System.Drawing.Color.LightGray;
        }

        void formsModuleMaintenanceOff()
        {
            TextBox_moduleMaint_modulename.Enabled =
                DropDownList_ModuleMaint_lectuerername.Enabled =
                DropDownList_ModuleMaint_facultyname.Enabled =
                Button_moduleMaint_add.Enabled =
                Button_moduleMaint_update.Enabled = false;

            TextBox_moduleMaint_modulename.BackColor =
                Button_moduleMaint_add.BackColor =
                Button_moduleMaint_update.BackColor = System.Drawing.Color.LightGray;
        }

        void formsOff()
        {
            formsStudentMaintenanceOff();
            formsModuleMaintenanceOff();
        }

        void refreshStudentMaint_students()
        {
            formsOff();
            GridView_students.Columns[1].Visible = true;
            GridView_students.DataSource = dbAccess.getAllStudents();
            GridView_students.DataBind();
            GridView_students.Columns[1].Visible = false;            
            showStudent();
        }        

        void refreshModuleMaint_modules()
        {            
            formsModuleMaintenanceOff();
            DropDownList_ModuleMaint_module.DataSource = dbAccess.getAllModules();
            DropDownList_ModuleMaint_module.DataBind();            
        }


        void showStudent()
        {
            formsOff();
            if (TextBox_gridviewstudents_selected_num.Text == Empty()) return;
            DataTable db = dbAccess.getStudent(int.Parse(TextBox_gridviewstudents_selected_num.Text));

            TextBox_studentMaint_firstname.Text = db.Rows[0]["first name"].ToString().Trim();
            TextBox_studentMaint_lastname.Text = db.Rows[0]["last name"].ToString().Trim();

            TextBox_studentMaint_firstname.Enabled = true;
            TextBox_studentMaint_lastname.Enabled = true;
            TextBox_studentMaint_firstname.BackColor = System.Drawing.Color.White;
            TextBox_studentMaint_lastname.BackColor = System.Drawing.Color.White;

            Button_studentMaint_update.Enabled = true;
            Button_studentMaint_update.BackColor = System.Drawing.Color.PaleVioletRed;
        }
        
        void populateModuleDetails()
        {            
            int modulenum = int.Parse(DropDownList_ModuleMaint_module.SelectedValue);
            
            DropDownList_ModuleMaint_lectuerername.DataSource = dbAccess.getModuleLecturer(modulenum);
            DropDownList_ModuleMaint_facultyname.DataSource = dbAccess.getModuleFacultyName(modulenum);
            
            DropDownList_ModuleMaint_lectuerername.DataBind();
            DropDownList_ModuleMaint_facultyname.DataBind();
            TextBox_moduleMaint_modulename.Text = dbAccess.getModuleModuleName(modulenum).Rows[0]["module code"].ToString();           
        }

        bool inputDataEmpty()
        {
            if((TextBox_lecturer_firstname.Text == "" ) || (TextBox_lecturer_lastname.Text == "") || (TextBox_lecturer_email.Text == ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void DropDownList_studentMaint_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            showStudent();
        }

        protected void Button_studentMaint_edit_Click(object sender, EventArgs e)
        {
            formsOff();
            clearMessages();

            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox_gridviewstudents_selected_num.Text = GridView_students.Rows[rw].Cells[2].Text;
            showStudent();

            TextBox_studentMaint_firstname.Enabled =
                TextBox_studentMaint_lastname.Enabled =
                Button_studentMaint_update.Enabled = true;

            TextBox_studentMaint_firstname.BackColor =
                TextBox_studentMaint_lastname.BackColor = System.Drawing.Color.LightYellow;

            Button_studentMaint_update.BackColor = System.Drawing.Color.PaleVioletRed;
        }

        protected void Button_moduleMaint_edit_Click(object sender, EventArgs e)
        {
            formsOff();
            clearMessages();

            DropDownList_ModuleMaint_lectuerername.DataSource = dbAccess.getAllLecturerNames();
            DropDownList_ModuleMaint_facultyname.DataSource = dbAccess.getAllFacultyNames();

            DropDownList_ModuleMaint_lectuerername.DataBind();
            DropDownList_ModuleMaint_facultyname.DataBind();

            TextBox_moduleMaint_modulename.Enabled =
                Button_moduleMaint_update.Enabled =
                DropDownList_ModuleMaint_lectuerername.Enabled = 
                DropDownList_ModuleMaint_facultyname.Enabled =  true;

            TextBox_moduleMaint_modulename.BackColor = System.Drawing.Color.LightYellow;

            Button_moduleMaint_update.BackColor = System.Drawing.Color.PaleVioletRed;
        }

        protected void Button_studentMaint_update_Click(object sender, EventArgs e)
        {
            clearMessages();

            if(TextBox_studentMaint_firstname.Text == Empty())
            {
                Label_studentMain_feedback.Text = "<font color='red'>A first name is still required...</font>br/>";
                return;
            }
            if(TextBox_studentMaint_lastname.Text == Empty())
            {
                Label_studentMain_feedback.Text = ",font color='red'>A last name is still required...</font><br/>";
                return;
            }            

            dbAccess.updateStudent(int.Parse(TextBox_gridviewstudents_selected_num.Text),
                TextBox_studentMaint_firstname.Text, TextBox_studentMaint_lastname.Text);
            refreshStudentMaint_students();
            Label_studentMain_feedback.Text = "<font color='blue'>UPDATED</font><br/>";

            Button_studentMaint_update.BackColor = Button_go_back1a.BackColor;
            Button_studentMaint_update.Enabled = false;

            TextBox_studentMaint_firstname.Text = "";
            TextBox_studentMaint_lastname.Text = "";
        }

        protected void Button_moduleMaint_update_Click(object sender, EventArgs e)
        {
            clearMessages();

            if(TextBox_moduleMaint_modulename.Text == Empty())
            {
                Label_moduleMaint_feedback.Text = "<font color='red'>A module name is still required...</font>br/>";
                return;
            }            

            dbAccess.updateModule(int.Parse(DropDownList_ModuleMaint_module.SelectedValue), TextBox_moduleMaint_modulename.Text,
                int.Parse(DropDownList_ModuleMaint_lectuerername.SelectedValue), int.Parse(DropDownList_ModuleMaint_facultyname.SelectedValue));
            Label_moduleMaint_feedback.Text = "<font color='blue'>Done...</font><br/>";
        }

        protected void Button_studentMaint_new_Click(object sender, EventArgs e)
        {
            clearMessages();
            formsOff();
            TextBox_studentMaint_firstname.Enabled =
                TextBox_studentMaint_lastname.Enabled =
                Button_studentMaint_add.Enabled = true;

            TextBox_studentMaint_firstname.BackColor =
                TextBox_studentMaint_lastname.BackColor = System.Drawing.Color.LightYellow;

            Button_studentMaint_add.BackColor = System.Drawing.Color.PaleVioletRed;
            TextBox_studentMaint_firstname.Text = TextBox_studentMaint_lastname.Text = Empty();
        }
        protected void Button_moduleMaint_new_Click(object sender, EventArgs e)
        {
            clearMessages();
            formsOff();

            DropDownList_ModuleMaint_facultyname.DataSource = dbAccess.getAllFacultyNames();
            DropDownList_ModuleMaint_lectuerername.DataSource = dbAccess.getAllLecturerNames();
            DropDownList_ModuleMaint_facultyname.DataBind();
            DropDownList_ModuleMaint_lectuerername.DataBind();

            TextBox_moduleMaint_modulename.Enabled =
                DropDownList_ModuleMaint_lectuerername.Enabled =
                DropDownList_ModuleMaint_facultyname.Enabled =
                Button_moduleMaint_add.Enabled = true;

            TextBox_moduleMaint_modulename.BackColor = System.Drawing.Color.LightYellow;

            Button_moduleMaint_add.BackColor = System.Drawing.Color.PaleVioletRed;
            TextBox_moduleMaint_modulename.Text = Empty();
        }

        protected void Button_studentMaint_add_Click(object sender, EventArgs e)
        {
            clearMessages();
            if(TextBox_studentMaint_firstname.Text == Empty())
            {
                Label_studentMain_feedback.Text = "<font color='red'>A first name is required...</font><br/>";
                return;
            }
            if(TextBox_studentMaint_lastname.Text == Empty())
            {
                Label_studentMain_feedback.Text = "<font color='red'>A last name is required...</font><br/>";
                return;
            }

            dbAccess.addStudent(TextBox_studentMaint_firstname.Text, TextBox_studentMaint_lastname.Text);
            refreshStudentMaint_students();
            Label_studentMain_feedback.Text = "<font color='blue'>Done...</font><br/>";
        }

        protected void Button_moduleMaint_add_Click(object sender, EventArgs e)
        {
            clearMessages();
            if (TextBox_moduleMaint_modulename.Text == Empty())
            {
                Label_moduleMaint_feedback.Text = "<font color='red'>A module name is required...</font><br/>";
                return;
            }

            dbAccess.addModule(TextBox_moduleMaint_modulename.Text, int.Parse(DropDownList_ModuleMaint_lectuerername.SelectedValue),
                int.Parse(DropDownList_ModuleMaint_facultyname.SelectedValue));
            Label_moduleMaint_feedback.Text = "<font color='blue'>Done...</font><br/>";
        }

        protected void DropDownList_ModuleMaint_module_SelectedIndexChanged(object sender, EventArgs e)
        {            
            populateModuleDetails();
        }

        protected void Button_students_select_Click(object sender, EventArgs e)
        {
            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex, i;
            TextBox_gridviewstudents_selected_num.Text = GridView_students.Rows[rw].Cells[1].Text;

            //highlights the row just selected
            for (i = 0; i < GridView_students.Rows.Count; i++)
                GridView_students.Rows[i].BackColor = System.Drawing.Color.White;
            GridView_students.Rows[rw].BackColor = System.Drawing.Color.LightGreen;

            showStudent();
        }

        protected void Button_student_select_Click(object sender, EventArgs e)
        {
            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex, i;
            selectedGrid = int.Parse(GridView_student_info.Rows[rw].Cells[1].Text);
            gridData = GridView_student_info.Rows[rw].Cells[2].Text;

            //highlights the row just selected
            for (i = 0; i < GridView_student_info.Rows.Count; i++)
                GridView_student_info.Rows[i].BackColor = System.Drawing.Color.White;
            GridView_student_info.Rows[rw].BackColor = System.Drawing.Color.LightGreen;
            //GridView_module_info.Columns[1].Visible = false;
            refreshModules();
        }        

        protected void Button_modules_info_Click(object sender, EventArgs e)
        {            
            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex, i;
            selectedGridNum = int.Parse(GridView_module_info.Rows[rw].Cells[1].Text);            

            //highlights the row just selected
            for (i = 0; i < GridView_module_info.Rows.Count; i++)
                GridView_module_info.Rows[i].BackColor = System.Drawing.Color.White;
            GridView_module_info.Rows[rw].BackColor = System.Drawing.Color.LightGreen;

            //populateModuleDetails();
            showModuleInfo(); 
        }        

        protected void Button_lecturer_edit_Click(object sender, EventArgs e)
        {
            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex, i;            
            Session["editLecturer"] = int.Parse(GridView_lecturer.Rows[rw].Cells[1].Text);            

            //highlights the row just selected
            for (i = 0; i < GridView_lecturer.Rows.Count; i++)
                GridView_lecturer.Rows[i].BackColor = System.Drawing.Color.White;
            GridView_lecturer.Rows[rw].BackColor = System.Drawing.Color.LightGreen;

            TextBox_lecturer_firstname.Text = GridView_lecturer.Rows[rw].Cells[3].Text;
            TextBox_lecturer_lastname.Text = GridView_lecturer.Rows[rw].Cells[2].Text;
            TextBox_lecturer_email.Text = GridView_lecturer.Rows[rw].Cells[4].Text;

            Button_lecturer_add.Visible = false;
            Button_lecturer_confirm_update.BackColor = System.Drawing.Color.Indigo;
            Button_lecturer_confirm_update.ForeColor = System.Drawing.Color.White;

            Button_lecturer_confirm_update.Visible = true;            
        }

        protected void Button_lecturer_add_Click(object sender, EventArgs e)
        {
            if (inputDataEmpty())
            {
                Label_lecturer_status.Text = "Please enter all required information!";
                Label_lecturer_status.ForeColor = System.Drawing.Color.Red;
                Label_lecturer_status.Visible = true;
                return;
            }
            if(!dbAccess.addLecturer(TextBox_lecturer_firstname.Text.Trim(), TextBox_lecturer_lastname.Text.Trim(), TextBox_lecturer_email.Text.Trim()))
            {
                Label_lecturer_status.Text = "ADDED";
                Label_lecturer_status.ForeColor = System.Drawing.Color.Blue;
                Label_lecturer_status.Visible = true;
            }
            else
            {
                Label_lecturer_status.Text = "An error occured adding a lecturer, please try again!";
                Label_lecturer_status.ForeColor = System.Drawing.Color.Red;
                Label_lecturer_status.Visible = true;
            }
            TextBox_lecturer_firstname.Text =
            TextBox_lecturer_lastname.Text =
            TextBox_lecturer_email.Text = Empty();

            GridView_lecturer.DataSource = dbAccess.getAllLecturerDetails();
            GridView_lecturer.DataBind();           
        }        

        protected void Button_lecturer_confirm_update_Click(object sender, EventArgs e)
        {
            if(!dbAccess.updateLecturer((int)Session["editLecturer"], TextBox_lecturer_firstname.Text.Trim(), TextBox_lecturer_lastname.Text.Trim(), TextBox_lecturer_email.Text.Trim())){            
                Label_lecturer_status.Text = "UPDATED";
                Label_lecturer_status.ForeColor = System.Drawing.Color.Blue;
                Label_lecturer_status.Visible = true;
                GridView_lecturer.DataSource = dbAccess.getAllLecturerDetails();
                GridView_lecturer.DataBind();
            }
            else
            {
                Label_lecturer_status.Text = "An error occured adding a lecturer, please try again!";
                Label_lecturer_status.ForeColor = System.Drawing.Color.Red;
                Label_lecturer_status.Visible = true;
            }

            Button_lecturer_add.Visible = true;

            TextBox_lecturer_firstname.Text =  
                TextBox_lecturer_lastname.Text = 
                TextBox_lecturer_email.Text = Empty();

            Button_lecturer_confirm_update.Visible = false;
        }
    }
}