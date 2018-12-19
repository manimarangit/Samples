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
    public partial class financeYear : System.Web.UI.Page
    {
        clsBusinessLayer b1 = new clsBusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Users userInfo = (Users)Session["UserInfo"];
                if (userInfo.IsDefaultPassword)
                {
                    changePwdContainer.Visible = true;
                    financeYrContainer.Visible = false;
                }
                else
                {
                    changePwdContainer.Visible = false;
                    financeYrContainer.Visible = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtNewPassword.Text == txtConfirmPassword.Text)
            {
                // DatabaseLayer.Users user = new Users();
                Users userInfo = (Users)Session["UserInfo"];
                userInfo.Password = txtConfirmPassword.Text;
                userInfo.IsDefaultPassword =false;
                b1.ForcePasswordChange(userInfo);
                changePwdContainer.Visible = false;
                financeYrContainer.Visible = true;
                Response.Cookies.Remove("forcePwdChange");
            }
        }
    }
}