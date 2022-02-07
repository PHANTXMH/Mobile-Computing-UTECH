using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace wpclass
{
    public partial class staffmembers : System.Web.UI.Page
    {
        DataAccessModules dbAccess = new DataAccessModules();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDepartment();
            }
            
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (turnOffCheckBox.Checked)
            {
                turnOffDropList();
            }
            else
            {
                turnOnDropList();
            }
            
        }

        void turnOffDropList()
        {
            departmentDropDownList.Enabled = false;
            staffDropDownList.Enabled = false;
            travelledDropDownList.Enabled = false;
        }

        void turnOnDropList()
        {
            departmentDropDownList.Enabled = true;
            staffDropDownList.Enabled = true;
            travelledDropDownList.Enabled = true;
        }

        void populateDepartment()
        {
            
            departmentDropDownList.DataSource = dbAccess.getDepartmentNames();
            departmentDropDownList.DataBind();            
        }

        void populateStaff()
        {            
            staffDropDownList.DataSource = dbAccess.getStaffByDepartmentNum(int.Parse(departmentDropDownList.SelectedValue));
            staffDropDownList.DataBind();
            
        }

        void showStaffInfo()
        {
            if(staffDropDownList.SelectedValue == "")
            {
                //refreshInfo();
                return;
            }
                

            DataTable db = dbAccess.getStaffInfo(int.Parse(staffDropDownList.SelectedValue));
            
            if (db.Rows.Count == 0) return;

            staffContactLabel.Text = db.Rows[0]["contact no"].ToString();
            staffAddressLabel.Text = db.Rows[0]["full address"].ToString();     
            
            travelledDropDownList.DataSource = dbAccess.getStaffCountriesVisited(int.Parse(staffDropDownList.SelectedValue));
            travelledDropDownList.DataBind();
        }

        protected void departmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshInfo();
            populateStaff();
            showStaffInfo();
            
        }

        protected void staffDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {            
            showStaffInfo();
        }

        void refreshInfo()
        {
            travelledDropDownList.Items.Clear();
            staffContactLabel.Text = "-";
            staffAddressLabel.Text = "-";
        }
        protected void DropDownList_DataBound(object sender, EventArgs e)
        {
            //refreshInfo();
        }
    }
}