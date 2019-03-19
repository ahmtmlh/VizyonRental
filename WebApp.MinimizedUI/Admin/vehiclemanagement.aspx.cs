using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.MizimizedUI.Admin
{
    public partial class addvehicle : System.Web.UI.Page
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
                    DropDownOfficeID.DataSource = Business.Office.getAllOffices();
                    DropDownOfficeID.DataBind();
                }
            }
        }

        protected void ButtonInsertVehicle_Click(object sender, EventArgs e)
        {
            if (!TextBoxVehicleID.Text.Equals(String.Empty))
            {
                string brand = TextBoxVehicleBrand.Text;
                string model = TextBoxVehicleModel.Text;
                int vehicleID = Convert.ToInt32(TextBoxVehicleID.Text);
                string economy = TextBoxEconomy.Text;
                decimal price = Convert.ToDecimal(TextBoxPrice.Text);
                int production_year = Convert.ToInt32(TextBoxProductionYear.Text);
                string type = DropDownType.SelectedValue.ToString();
                string tier = DropDownTier.SelectedValue.ToString();
                int size = Convert.ToInt32(TextBoxSize.Text);
                string color = TextBoxColor.Text;
                int office_id = Business.Office.getOfficeIdByName(DropDownOfficeID.SelectedValue.ToString());
                string img = TextBoxFile.Text;
                //Information Gathering is done
                LabelResult.Text = Business.Vehicle.addVehicle(vehicleID, model, true, economy, price, brand, tier, production_year, size, color, type, office_id, img);
            }
            else
            {
                LabelResult.Text = "Vehicle ID is empty";
            }
        }

        protected void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LabelRefreshResult.Visible = true;
            LabelRefreshResult.Text = Business.Rent.endRents();
        }
    }
}