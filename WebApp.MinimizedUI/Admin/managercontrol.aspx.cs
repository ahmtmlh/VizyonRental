using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.MizimizedUI.Admin
{
    public partial class managercontrol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["loginType"].ToString().Equals("0"))
            {
                Response.Redirect("/");
            }
        }

        protected void ButtonManagerRegister_Click(object sender, EventArgs e)
        {
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;
            DateTime bDate = DateTime.ParseExact(TextBoxBirthDate.Text, "dd-MM-yyyy", null);
            string address = TextBoxAddr.Text;
            string phone = PhoneNumberBox.Text;
            string mail = TextBoxMail.Text;
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;
            //Information gathering is done
            LabelResult.Text = Business.Managers.addManager(username, password, name, surname, bDate, address, phone, mail);
        }
    }
}