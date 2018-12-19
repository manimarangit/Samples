using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DatabaseLayer;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        clsBusinessLayer b1 = new clsBusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseLayer.Users user = new Users();
            user = b1.login(txtUsername.Text, txtPassword.Text);
            if (user == null)
            {
                string re = "Incorrect user name or password changed";
            }
            else
            {

                if (user.IsDefaultPassword == true)
                {
                    pntxtID.Text = user.ID.ToString();
                    popup.Show();
                }
                else
                {
                     Session["UserName"] = user.UserName;
                    Session["Name"] = user.Name;
                    Session["BranchPrefix"] = user.prefix;
                    Session["BranchPrefix1"] = user.prefix1;
                    Server.Transfer("financeYear.aspx", true);
                }

            }
        }

        protected void Save(object sender, EventArgs e)
        {
            DatabaseLayer.Users users = new Users();
            if (PntxtPassword.Text == PntxtPasswordAgain.Text)
            {
                users.ID = Convert.ToInt32(pntxtID.Text);
                users.IsDefaultPassword = false;
                users.Password = PntxtPassword.Text;
                b1.ForcePasswordChange(users);
                popup.Hide();
               // Server.Transfer("financeYear.aspx", true);
            }
            else
            {
                //Pssword not matching
            }

        }
    }
}