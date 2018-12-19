using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Linq.Expressions;
using DatabaseLayer;
namespace WebApplication1
{
    public partial class User : System.Web.UI.Page
    {
        clsBusinessLayer b1 = new clsBusinessLayer();
        ClsDataLayer d1 = new ClsDataLayer();
        List<DatabaseLayer.Branch> lstBranch = new List<DatabaseLayer.Branch>();
        protected void Page_Load(object sender, EventArgs e)
        {
            lstBranch = new List<DatabaseLayer.Branch>();
            lstBranch = b1.LoadBranch();
            ddlBranch.DataTextField = "Name";
            ddlBranch.DataValueField = "ID";
            ddlBranch.DataSource = lstBranch;
            ddlBranch.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

           // string Permission = string.Empty;
            Users user = new Users();
            user.Name = txtName.Text;
            user.UserName = txtUName.Text;
            user.Password = txtUName.Text;
            user.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
            user.Role = ddlRole.SelectedValue;
            user.Permission = String.Join(", ", cblPermissions.Items.Cast<ListItem>()
                                             .Where(i => i.Selected));
            user.IsDefaultPassword = true;
            string Result = b1.AddNewUser(user);
            if(Result == "SUCCESS")
            {
                
            }
            else if(Result == "USER ALREADY EXIST") 
            {

            }
            else
            {

            }
        }
    }
}