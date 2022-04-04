using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace wpclass
{
    public partial class easternchamps : System.Web.UI.Page
    {
        DataAccessModules dbAccess = new DataAccessModules();
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startUp();
            }
        }

        void startUp()
        {
            divsOff();
            divMenu.Visible = true;

            DropDownList_lanenumber.Items.Add(new ListItem("1", "1"));
            DropDownList_lanenumber.Items.Add(new ListItem("2", "2"));
            DropDownList_lanenumber.Items.Add(new ListItem("3", "3"));
            DropDownList_lanenumber.Items.Add(new ListItem("4", "4"));
            DropDownList_lanenumber.Items.Add(new ListItem("5", "5"));
            DropDownList_lanenumber.Items.Add(new ListItem("6", "6"));
            DropDownList_lanenumber.Items.Add(new ListItem("7", "7"));
            DropDownList_lanenumber.Items.Add(new ListItem("8", "8"));

            DropDownList_age.Items.Add(new ListItem("11", "11"));
            DropDownList_age.Items.Add(new ListItem("12", "12"));
            DropDownList_age.Items.Add(new ListItem("13", "13"));
            DropDownList_age.Items.Add(new ListItem("14", "14"));
            DropDownList_age.Items.Add(new ListItem("15", "15"));
            DropDownList_age.Items.Add(new ListItem("16", "16"));
            DropDownList_age.Items.Add(new ListItem("17", "17"));
            DropDownList_age.Items.Add(new ListItem("18", "18"));
            DropDownList_age.Items.Add(new ListItem("19", "19"));

        }

        void divsOff()
        {
            divAthleteMaint.Visible = divEventMaint.Visible = divMaintenanceMenu.Visible = divMenu.Visible = false;            
        }

        protected void Button_remove_Click(object sender, EventArgs e)
        {            
            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex, i;

            dbAccess.clearStartListSingle(int.Parse(GridView_startinglist.Rows[rw].Cells[1].Text));

            Label_event_status.Text = "DONE";
            Label_event_status.ForeColor = System.Drawing.Color.Green;

            GridView_startinglist.Columns[1].Visible = true;
            GridView_startinglist.DataSource = dbAccess.getEventStartList(int.Parse(DropDownList_event.SelectedValue));
            GridView_startinglist.DataBind();
            GridView_startinglist.Columns[1].Visible = false;
        }

        protected void Button_maintenance_menu_Click(object sender, EventArgs e)
        {
            divsOff();
            divMaintenanceMenu.Visible = true;
        }

        protected void Button_maintenance_event_Click(object sender, EventArgs e)
        {
            divsOff();
            divEventMaint.Visible = true;

            DropDownList_event.DataSource = dbAccess.getAllChampsEvent();
            DropDownList_event.DataBind();

            DropDownList_highschools.DataSource = dbAccess.getAllChampsHighSchools();
            DropDownList_highschools.DataBind();

            DropDownList_highschools.Enabled = false;
            DropDownList_elegible_athlete.Enabled = false;
            DropDownList_lanenumber.Enabled = false;
        }

        protected void Button_maintenance_athlete_Click(object sender, EventArgs e)
        {
            divsOff();
            divAthleteMaint.Visible = true;

            DataTable db = dbAccess.getAllAthletes();

            DropDownList_athlete.DataSource = db;
            DropDownList_athlete.DataBind();

            DropDownList_highschool_athlete .DataSource = dbAccess.getAllChampsHighSchools();
            DropDownList_highschool_athlete.DataBind();

            TextBox_firstname.Enabled =
            TextBox_lastname.Enabled =
            CheckBox_gender.Enabled =
            DropDownList_age.Enabled =
            DropDownList_highschool_athlete.Enabled =
            Button_add.Enabled =
            Button_update.Enabled = false;

            TextBox_firstname.Text = db.Rows[int.Parse(DropDownList_athlete.SelectedValue) - 1]["first name"].ToString();
            TextBox_lastname.Text = db.Rows[int.Parse(DropDownList_athlete.SelectedValue) - 1]["last name"].ToString();

            if (db.Rows[int.Parse(DropDownList_athlete.SelectedValue) - 1]["is male"].ToString() == "1")
            {
                CheckBox_gender.Checked = true;
            }
        }

        protected void Button_new_Click(object sender, EventArgs e)
        {
            TextBox_firstname.Enabled = true;
            TextBox_lastname.Enabled = true;
            CheckBox_gender.Enabled = true;
            DropDownList_highschool_athlete.Enabled = true;
            DropDownList_age.Enabled = true;

            TextBox_firstname.Text = TextBox_lastname.Text = "";

            Label_athlete_status.Text = "-";
            Label_athlete_status.ForeColor = System.Drawing.Color.Black;

            Button_add.Enabled = true;
            Button_add.ForeColor = System.Drawing.Color.PaleVioletRed;

            Button_update.Enabled = false;
            Button_update.ForeColor = Button_athlete_edit.ForeColor;
        }

        protected void Button_add_Click(object sender, EventArgs e)
        {            
            dbAccess.addAthlete(TextBox_firstname.Text.Trim(), TextBox_lastname.Text.Trim(), int.Parse(DropDownList_highschool_athlete.SelectedValue),
                CheckBox_gender.Checked.ToString(), int.Parse(DropDownList_age.SelectedValue));

            DropDownList_athlete.DataSource = dbAccess.getAllAthletes();
            DropDownList_athlete.DataBind();

            Label_athlete_status.Text = "DONE";
            Label_athlete_status.ForeColor = System.Drawing.Color.Green;

            DropDownList_highschool_athlete.Enabled =
            DropDownList_age.Enabled =
            TextBox_firstname.Enabled =
            TextBox_lastname.Enabled =
            CheckBox_gender.Enabled = false;

            TextBox_firstname.Text = TextBox_lastname.Text = "";

            Button_add.Enabled = false;
            Button_add.ForeColor = Button_athlete_edit.ForeColor;
        }

        protected void Button_athlete_edit_Click(object sender, EventArgs e)
        {
            TextBox_firstname.Enabled = true;
            TextBox_lastname.Enabled = true;

            Label_athlete_status.Text = "-";
            Label_athlete_status.ForeColor = System.Drawing.Color.Black;

            Button_add.Enabled = false;
            Button_update.Enabled = true;
            Button_add.ForeColor = Button_athlete_edit.ForeColor;
            Button_update.ForeColor = System.Drawing.Color.PaleVioletRed;
        }

        protected void Button_update_Click(object sender, EventArgs e)
        {
            dbAccess.updateAthlete(TextBox_firstname.Text.Trim(), TextBox_lastname.Text.Trim(), int.Parse(DropDownList_athlete.SelectedValue));

            DropDownList_athlete.DataSource = dbAccess.getAllAthletes();
            DropDownList_athlete.DataBind();

            Label_athlete_status.Text = "DONE";
            Label_athlete_status.ForeColor = System.Drawing.Color.Green;

            TextBox_firstname.Text = TextBox_lastname.Text = "";

            Button_update.Enabled = false;
            Button_update.ForeColor = Button_athlete_edit.ForeColor;
        }

        protected void DropDownList_event_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView_startinglist.Columns[1].Visible = true;
            GridView_startinglist.DataSource = dbAccess.getEventStartList(int.Parse(DropDownList_event.SelectedValue));
            GridView_startinglist.DataBind();            

            DropDownList_elegible_athlete.DataSource = dbAccess.getElegibleAthletes(int.Parse(DropDownList_highschools.SelectedValue),
                int.Parse(DropDownList_event.SelectedValue));

            DropDownList_elegible_athlete.DataBind();

            Label_event_status.Text = "-";
            Label_event_status.ForeColor = System.Drawing.Color.Black;

            GridView_startinglist.Columns[1].Visible = false;               //Hides id column for grid view
        }

        protected void DropDownList_highschools_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_elegible_athlete.DataSource = dbAccess.getElegibleAthletes(int.Parse(DropDownList_highschools.SelectedValue),
                int.Parse(DropDownList_event.SelectedValue));
            DropDownList_elegible_athlete.DataBind();
        }        

        protected void Button_event_new_Click(object sender, EventArgs e)
        {
            DropDownList_highschools.Enabled = 
            DropDownList_elegible_athlete.Enabled =
            DropDownList_lanenumber.Enabled = true;

            Label_event_status.Text = "-";
            Label_event_status.ForeColor = System.Drawing.Color.Black;
        }

        protected void Button_event_add_Click(object sender, EventArgs e)
        {
            if (!dbAccess.lanesOccupied(int.Parse(DropDownList_event.SelectedValue), int.Parse(DropDownList_lanenumber.SelectedValue)))
            {
                dbAccess.assignLane(int.Parse(DropDownList_event.SelectedValue), int.Parse(DropDownList_elegible_athlete.SelectedValue),
                int.Parse(DropDownList_lanenumber.SelectedValue));

                GridView_startinglist.DataSource = dbAccess.getEventStartList(int.Parse(DropDownList_event.SelectedValue));
                GridView_startinglist.DataBind();

                DropDownList_elegible_athlete.Enabled = false;
                DropDownList_highschools.Enabled = false;
                DropDownList_lanenumber.Enabled = false;

                Label_event_status.Text = "DONE";
                Label_event_status.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label_event_status.Text = "This lane is already occupied!";
                Label_event_status.ForeColor = System.Drawing.Color.Red;                
            }            
        }        

        protected void DropDownList_athlete_SelectedIndexChanged(object sender, EventArgs e)
        {            
            DataTable db = dbAccess.getAthleteDetails(int.Parse(DropDownList_athlete.SelectedValue));
            
            TextBox_firstname.Text =  db.Rows[0]["first name"].ToString();
            TextBox_lastname.Text = db.Rows[0]["last name"].ToString();
            string male = db.Rows[0]["is male"].ToString();

            if(Boolean.Parse(male)) 
            {
                CheckBox_gender.Checked = true;
            }
            else
            {
                CheckBox_gender.Checked = false;
            }
        }

        protected void Button_goback_Click(object sender, EventArgs e)
        {
            divsOff();
            divMenu.Visible = true;
        }

        protected void Button_goback1_Click(object sender, EventArgs e)
        {
            divsOff();
            divMenu.Visible = true;
        }

        protected void Button_event_empty_Click(object sender, EventArgs e)
        {
            dbAccess.clearStartList(int.Parse(DropDownList_event.SelectedValue));
            Label_event_status.Text = "DONE";
            Label_event_status.ForeColor = System.Drawing.Color.Green;

            GridView_startinglist.DataSource = dbAccess.getEventStartList(int.Parse(DropDownList_event.SelectedValue));
            GridView_startinglist.DataBind();
        }

        protected void GridView_startinglist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList_elegible_athlete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}