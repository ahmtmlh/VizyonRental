using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.MizimizedUI
{
    public partial class Account : System.Web.UI.Page
    {
        private static Dictionary<string, string> map;
        protected void Page_Load(object sender, EventArgs e)
        {
            //If login 
            if (Session["username"] == null || Session["loginType"].ToString().Equals("0"))
            {
                Response.Redirect("/");
            }
            else
            {
                if (!IsPostBack)
                {
                    map = new Dictionary<string, string>();
                    List<string> attrList = new List<string>();
                    map.Add("Name", "name");
                    attrList.Add("Name");
                    map.Add("Surname", "surname");
                    attrList.Add("Surname");
                    map.Add("Birthday", "birthDate");
                    attrList.Add("Birthday");
                    map.Add("Address", "address");
                    attrList.Add("Address");
                    map.Add("Phone Number", "phone_number");
                    attrList.Add("Phone Number");
                    map.Add("Email", "mail");
                    attrList.Add("Email");

                    DropDownAttrList.DataSource = attrList;
                    DropDownAttrList.DataBind();
                }
                List<object> lst = new List<object>();
                lst.Add(Business.Managers.getManagerById(Convert.ToInt32(Session["loginID"].ToString())));
                ManAccount.DataSource = lst;
                ManAccount.DataBind();
            }        
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (DropDownAttrList.SelectedValue.Equals("Birthday"))
            {
                ResultLabelUpdate.Text = Business.Managers.updateManager(Convert.ToInt32(Session["loginID"]), map[DropDownAttrList.SelectedValue], TextBoxBirthDate.Text);       
            }
            else
            {
                ResultLabelUpdate.Text = Business.Managers.updateManager(Convert.ToInt32(Session["loginID"]), map[DropDownAttrList.SelectedValue], TextBoxNewData.Text);
            }
            Page_Load(null, null);
        }

        protected void DropDownAttrList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownAttrList.SelectedValue.Equals("Birthday"))
            {
                NormalData.Visible = false;
                DateData.Visible = true;
            }
            else
            {
                DateData.Visible = false;
                NormalData.Visible = true;                
            }
            
        }
    }
}