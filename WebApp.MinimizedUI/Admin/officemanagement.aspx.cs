using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.MizimizedUI.Admin
{
    public partial class officemanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If login 
            if (Session["username"] == null || Session["loginType"].ToString().Equals("0"))
            {
                Response.Redirect("/");
            }
            else
            {
                if (!Page.IsPostBack)
                {

                }
                dataBind();
            }
        }

        protected void ButtonAddOffice_Click(object sender, EventArgs e)
        {
            int officeID = Convert.ToInt32(TextBoxAddOfficeID.Text);
            string officename = TextBoxOfficeName.Text;
            string address = TextBoxOfficeAddress.Text;
            LabelResultAddOffice.Visible = true;
            LabelResultAddOffice.Text = Business.Office.addOffice(officeID, officename, address);
            dataBind();
        }

        protected void ButtonUpdateOffice_Click(object sender, EventArgs e)
        {
            int officeID = Convert.ToInt32(TextBoxUpdateOfficeID.Text);
            string attribute = DropDownAttrList.SelectedValue.ToString();
            string data = TextBoxNewData.Text;
            LabelUpdateResult.Visible = true;
            LabelUpdateResult.Text = Business.Office.updateOffice(officeID, attribute, data);
            dataBind();   
        }

        protected void ButtonDeleteOffice_Click(object sender, EventArgs e)
        {
            int officeID = Convert.ToInt32(TextBoxDeleteOfficeID.Text);
            LabelDeleteResult.Visible = true;
            LabelDeleteResult.Text = Business.Office.deleteOffice(officeID);
            dataBind();
        }
        private void dataBind()
        {
            GridOfficeInfo.DataSource = Business.Office.getAllOffices();
            GridOfficeInfo.DataBind();
        }
    }
}