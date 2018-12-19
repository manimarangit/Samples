using BusinessLayer;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        clsBusinessLayer b1 = new clsBusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLbl.Visible = false;
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            DatabaseLayer.Users user = new Users();
            user = b1.login(email.Value, pwd.Value);
            if (user.UserName == null)
            {
                msgLbl.Visible = true;
                msgLbl.InnerText = "Invalid User Name or Password";
            }
            else
            {
                    Session["UserInfo"] = user;
                    Session["UserName"] = user.UserName;
                    Session["Name"] = user.Name;
                    Session["BranchPrefix"] = user.prefix;
                    Session["BranchPrefix1"] = user.prefix1;
                    Response.Redirect("financeYear.aspx");
            }
           
        }
    }
}