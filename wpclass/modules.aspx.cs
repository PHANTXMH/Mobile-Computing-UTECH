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

        void startUp()
        {
            DropDownList_students.DataSource = dbAccess.getAllStudents();
            DropDownList_students.DataBind();
            refreshModules();
        }

        void refreshModules()
        {
            //DataTable dbStudents = dbAccess.getAllStudentsByModule(int.Parse(DropDownList_modules.SelectedValue));
            //DataTable dbStudentsAll = dbAccess.getAllStudentsByModule(int.Parse(DropDownList_modules.SelectedValue));
            DropDownList_modules.DataSource = dbAccess.getModules(int.Parse(DropDownList_students.SelectedValue));
            DropDownList_modules.DataBind();
            //DropDownList_students_doing_module.DataSource = dbAccess.getAllStudentsByModule(int.Parse(DropDownList_modules.SelectedValue));
            //DropDownList_students_doing_module.DataBind();
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

            if (DropDownList_modules.Items.Count == 0) return;
           
            DataTable db = dbAccess.getModule(int.Parse(DropDownList_modules.SelectedValue));
            
            if (db.Rows.Count == 0) return;
            Label_lecturer.Text = db.Rows[0]["lecturer"].ToString();
            Label_lecturer_email.Text = db.Rows[0]["email"].ToString();
            Label_faculty_college_owner.Text = db.Rows[0]["fc name"].ToString();
        }

        protected void DropDownList_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            showModuleInfo();
        }

        protected void DropDownList_students_doing_module_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}