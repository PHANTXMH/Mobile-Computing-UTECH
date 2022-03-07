using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wpclass
{
    public partial class Logiin : System.Web.UI.Page
    {
        DataAccessModules dbAccess = new DataAccessModules();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            if (dbAccess.checkUserLogin(TextBox_username.Text, TextBox_password.Text)){
                Session["logged in"] = true;
                Response.Redirect("skoolers.aspx");
            }
            else
            {
                Label_login_info.Text = "Invalid Login! Please try again.";
                Label_login_info.ForeColor = System.Drawing.Color.Red;
                Label_login_info.Visible = true;
            }
        }
    }
}