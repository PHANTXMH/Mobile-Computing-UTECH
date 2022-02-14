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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startUp();
            }
        }

        void divsOff()
        {
            divMain.Visible = divStudentMaint.Visible = divModuleInfo.Visible = false;

        }

        string Empty()
        {
            return string.Empty;
        }

        void clearMessages()
        {
            Label_studentMain_feedback.Text = Empty();
        }

        void startUp()
        {
            DropDownList_students.DataSource = dbAccess.getAllStudents();
            DropDownList_students.DataBind();
            refreshModules();

            divsOff();
            divMain.Visible = true;
        }

        void refreshModules()
        {
            
            DropDownList_modules.DataSource = dbAccess.getModules(int.Parse(DropDownList_students.SelectedValue));
            DropDownList_modules.DataBind();            
            showModuleInfo();
            Label_selected_student.Text = DropDownList_students.SelectedItem.ToString();
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

            if (DropDownList_modules.Items.Count == 0) return;

            populateStudentsDoingSelectedModule();

            DataTable db = dbAccess.getModule(int.Parse(DropDownList_modules.SelectedValue));
            
            if (db.Rows.Count == 0) return;
            Label_lecturer.Text = db.Rows[0]["lecturer"].ToString();
            Label_lecturer_email.Text = db.Rows[0]["email"].ToString();
            Label_faculty_college_owner.Text = db.Rows[0]["fc name"].ToString();

            
        }

        void populateStudentsDoingSelectedModule()
        {            
            DropDownList_students_doing_module.DataSource = dbAccess.getAllStudentsByModule(int.Parse(DropDownList_modules.SelectedValue));
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

        void formsOff()
        {
            formsStudentMaintenanceOff();
        }

        void refreshStudentMaint_students()
        {
            formsOff();
            DropDownList_studentMaint_students.DataSource = dbAccess.getAllStudents();
            DropDownList_studentMaint_students.DataBind();
            showStudent();
        }

        void showStudent()
        {
            DataTable db = dbAccess.getStudent(int.Parse(DropDownList_studentMaint_students.SelectedValue));

            TextBox_studentMaint_firstname.Text = db.Rows[0]["first name"].ToString();
            TextBox_studentMaint_lastname.Text = db.Rows[0]["last name"].ToString();
        }

        protected void DropDownList_studentMaint_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            showStudent();
        }

        protected void Button_studentMaint_edit_Click(object sender, EventArgs e)
        {
            formsOff();
            clearMessages();

            TextBox_studentMaint_firstname.Enabled =
                TextBox_studentMaint_lastname.Enabled =
                Button_studentMaint_update.Enabled = true;

            TextBox_studentMaint_firstname.BackColor =
                TextBox_studentMaint_lastname.BackColor = System.Drawing.Color.LightYellow;

            Button_studentMaint_update.BackColor = System.Drawing.Color.PaleVioletRed;
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

            dbAccess.updateStudent(int.Parse(DropDownList_studentMaint_students.SelectedValue),
                TextBox_studentMaint_firstname.Text, TextBox_studentMaint_lastname.Text);
            refreshStudentMaint_students();
            Label_studentMain_feedback.Text = "<font color='blue'>Done...</font><br/>";
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
    }
}