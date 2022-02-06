using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wpclass
{
    public partial class halls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*athleteCheckbox.Visible = false;
            hallLabel.Visible = false;
            DropDownList1.Visible = false;
            resetButton.Visible = false;*/
        }

        protected void studentCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (studentCheckbox.Checked)
            {
                athleteCheckbox.Visible = true;
                hallLabel.Visible = true;
                DropDownList1.Visible = true;
                resetButton.Visible = true;

                DropDownList1.Items.Clear();

                DropDownList1.Items.Add("Peter's");
                DropDownList1.Items.Add("Jaban");
                DropDownList1.Items.Add("Manning");
                DropDownList1.Items.Add("Alfred Sangster");
            }
            else
            {
                athleteCheckbox.Visible = false;
                hallLabel.Visible = false;
                DropDownList1.Visible = false;
                resetButton.Visible = false;

                DropDownList1.Items.Clear();
            }
            
        }

        protected void athleteCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (athleteCheckbox.Checked)
            {
                DropDownList1.Items.Clear();

                DropDownList1.Items.Add("Jaban");
                DropDownList1.Items.Add("Manning");
            }
            else
            {
                DropDownList1.Items.Clear();

                DropDownList1.Items.Add("Peter's");
                DropDownList1.Items.Add("Jaban");
                DropDownList1.Items.Add("Manning");
                DropDownList1.Items.Add("Alfred Sangster");
            }
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            studentCheckbox.Checked = false;
            athleteCheckbox.Checked = false;
            athleteCheckbox.Visible = false;
            hallLabel.Visible = false;
            DropDownList1.Visible = false;
            resetButton.Visible = false;

            DropDownList1.Items.Clear();
        }
    }
}