using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace WebApp.MizimizedUI
{
    public partial class WebForm1 : System.Web.UI.Page
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
                    dataBind();
                } 
            }
        }
        protected void resDel_Click(object sender, EventArgs e)
        {
            if (!TextResID.Text.Equals(String.Empty) && TextResDate.Text.Equals(String.Empty))
            {
                int check = Business.Rezervation.deleteRezervation(Convert.ToInt32(TextResID.Text));
                if (check == 0)
                {
                    LabelDeleteReservationResult.Text = "Delete operation is failed";
                }
                else
                {
                    LabelDeleteReservationResult.Text = "Delete operation is successful";
                    dataBind();
                }
            }
            else if (TextResID.Text.Equals(String.Empty) && !TextResDate.Text.Equals(String.Empty))
            {
                int check = Business.Rezervation.deleteReservationsOlderThan(DateTime.ParseExact(TextResDate.Text, "dd-MM-yyyy", null));
                if (check == 0)
                {
                    LabelDeleteReservationResult.Text = ("Delete operation is failed");
                }
                else
                {
                    LabelDeleteReservationResult.Text = ("Delete operation is successful");
                    dataBind();
                }
            }
            else
            {
                LabelDeleteReservationResult.Text = "Failed";
            }

        }

        protected void delRent_Click(object sender, EventArgs e)
        {
            if (!TextRentID.Text.Equals(String.Empty))
            {
                int check = Business.Rent.deleteRentById(Convert.ToInt32(TextRentID.Text));
                if (check == 0)
                {
                    LabelDeleteRentResult.Text = ("Delete operation is failed");
                }
                else
                {
                    LabelDeleteRentResult.Text = ("Delete operation is successful");
                    dataBind();
                }
            }
            else
            {
                LabelDeleteRentResult.Text = ("failed");
            }
        }

        protected void ButtonDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (TextBoxCustomerID.Text.Equals(String.Empty))
            {
                LabelDeleteResult.Text = "Enter a customer id";
            }
            else
            {
                LabelDeleteResult.Text = Business.Customers.deleteCustomer(Convert.ToInt32(TextBoxCustomerID.Text));
                dataBind();
            }
        }
        private void dataBind()
        {
            reserveView.DataSource = Business.View.getReservationViewDataSet();
            reserveView.DataBind();
            rentView.DataSource = Business.View.getRentViewDataSet();
            rentView.DataBind();
            GridViewCustomers.DataSource = Business.View.getCustomerViewDataSet();
            GridViewCustomers.DataBind();
            GridManagerInfo.DataSource = Business.View.getManagerViewDataSet();
            GridManagerInfo.DataBind();
            GridViewBill.DataSource = Business.View.getBillViewDataSet();
            GridViewBill.DataBind();
        }
    }
}