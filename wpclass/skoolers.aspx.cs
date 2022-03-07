using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace wpclass
{
    public partial class Skoolers : System.Web.UI.Page
    {
        DataAccessModules dbAccess = new DataAccessModules();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divHighSchoolMaint.Visible = divViewSchool.Visible = false;                             
            }

            if(Session["logged in"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button_logoff_Click(object sender, EventArgs e)
        {
            Session["logged in"] = null;
            Response.Redirect("login.aspx");
        }

        void divOff(){
            divMain.Visible = false;
        }

        protected void Button_highSchool_maint_Click(object sender, EventArgs e)
        {
            divOff();
            divHighSchoolMaint.Visible = true;
            populateHighSchools();
        }

        protected void Button_view_school_Click(object sender, EventArgs e)
        {
            divOff();
            divViewSchool.Visible = true;
            populateHighSchoolView();
        }

        void populateHighSchools()
        {
            DropDownList_schoolname.DataSource = dbAccess.getAllHighSchools();
            DropDownList_schoolname.DataBind();
            TextBox_schoolname.Text = DropDownList_schoolname.SelectedItem.ToString();
            DropDownList_headstudent.DataSource = dbAccess.getHighSchoolHeadStudent(int.Parse(DropDownList_schoolname.SelectedValue));
            DropDownList_headstudent.DataBind();
        }

        void populateHighSchoolView()
        {
            DropDownList_view_highschools.DataSource = dbAccess.getAllHighSchools();
            DropDownList_view_highschools.DataBind();
            
            DataTable db = dbAccess.viewHighSchools(int.Parse(DropDownList_view_highschools.SelectedValue));

            TextBox_view_school_name.Text = db.Rows[0]["hs name"].ToString();
            TextBox_view_school_head_student.Text = db.Rows[0]["student"].ToString();            
        }

        protected void DropDownList_schoolname_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox_schoolname.Text = DropDownList_schoolname.SelectedItem.ToString();
            DropDownList_headstudent.DataSource = dbAccess.getHighSchoolHeadStudent(int.Parse(DropDownList_schoolname.SelectedValue));
            DropDownList_headstudent.DataBind();
        }

        protected void Button_schoolname_new_Click(object sender, EventArgs e)
        {
            Button_schoolname_new.Visible = false;
            Button_schoolname_update .Visible = false;
            DropDownList_schoolname.Visible = false;
            TextBox_schoolname.Enabled = true;
            Label_head_student.Visible = true;
            Button_schoolname_edit.Visible = false;
            DropDownList_headstudent.Enabled = true;
            Button_schoolname_add.Visible = true;
            DropDownList_headstudent.DataSource = dbAccess.getEligibleHeadStudents();
            DropDownList_headstudent.DataBind();
            TextBox_schoolname.Text = "";
        }

        protected void Button_schoolname_edit_Click(object sender, EventArgs e)
        {            
            Button_schoolname_new.Visible = false;
            DropDownList_headstudent.Visible = false;
            Button_schoolname_add.Visible = false;
            Button_schoolname_edit.Visible = false;
            TextBox_schoolname.Enabled = true;
            Button_schoolname_update.Visible = true;
        }

        protected void Button_schoolname_update_Click(object sender, EventArgs e)
        {
            if(TextBox_schoolname.Text == "")
            {
                Label_progress_info.Text = "School name field is empty!";
                Label_progress_info.Visible = true;
                return;
            }
            dbAccess.updateHighSchoolName(TextBox_schoolname.Text, int.Parse(DropDownList_schoolname.SelectedValue));
            Label_progress_info.Visible = true;
            Label_progress_info.Text = "Done...";
        }

        protected void Button_schoolname_add_Click(object sender, EventArgs e)
        {
            if (TextBox_schoolname.Text == "" )
            {
                Label_progress_info.Text = "School name field is empty!";
                Label_progress_info.Visible = true;
                return;
            }
            else
            if(dbAccess.checkSchoolNameExits(TextBox_schoolname.Text))
            {
                Label_progress_info.Text = "School name already exists!";
                Label_progress_info.Visible = true;
                return;
            }
            
            dbAccess.addHighSchool(TextBox_schoolname.Text, int.Parse(DropDownList_headstudent.SelectedValue));
            Label_progress_info.Visible = true;
            Label_progress_info.Text = "Done...";
        }

        protected void Button_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("skoolers.aspx");
        }

        protected void DropDownList_view_highschools_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable db = dbAccess.viewHighSchools(int.Parse(DropDownList_view_highschools.SelectedValue));

            TextBox_view_school_name.Text = db.Rows[0]["hs name"].ToString();
            TextBox_view_school_head_student.Text = db.Rows[0]["student"].ToString();
        }
    }
}