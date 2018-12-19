using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace WebApplication1
{
    public partial class Company : System.Web.UI.Page
    {

        string BranchPre = string.Empty;
        string BranchPre1 = string.Empty;
        string year = string.Empty;

        clsBusinessLayer b1 = new clsBusinessLayer();
        static List<DatabaseLayer.Party> lstParty = new List<DatabaseLayer.Party>();
        static List<DatabaseLayer.Branch> lstBranch = new List<DatabaseLayer.Branch>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<BillDetails> obj = new List<BillDetails>();
            //obj = new List<BillDetails> { new BillDetails { SlNo = 1, Particulars = "aa", Quantity = 1, Price = 1, Amount = 1 } };
            //GridView1.DataSource = obj;
            //GridView1.DataBind();
            DataTable dt = new DataTable();
            DataRow row = dt.NewRow();
            //row["S.No"] = "1";
            dt.Rows.InsertAt(row, 0);

            grdParticular.DataSource = dt;
            grdParticular.DataBind();
            // grdParticular.Rows[0]

            lstParty = new List<DatabaseLayer.Party>();
            lstParty = b1.LoadParty();
            drpFromParty.DataTextField = "Name";
            drpFromParty.DataValueField = "ID";
            drpFromParty.DataSource = lstParty;
            drpFromParty.DataBind();


            drpToParty.DataTextField = "Name";
            drpToParty.DataValueField = "ID";
            drpToParty.DataSource = lstParty;
            drpToParty.DataBind();

            lstBranch = new List<DatabaseLayer.Branch>();
            lstBranch = b1.LoadBranch();
            ddlBranch.DataTextField = "Name";
            ddlBranch.DataValueField = "ID";
            ddlBranch.DataSource = lstBranch;
            ddlBranch.DataBind();
        }

        protected void grdParticular_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void drpFromParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseLayer.Party part = new DatabaseLayer.Party();
            part = lstParty.Where(P => P.ID.Equals(Convert.ToInt32(drpFromParty.SelectedValue))).FirstOrDefault();
            txtFPlace.Text = part.Place;
            txtFMobile.Text = part.PhoneNo;
            txtFGSTIN.Text = part.GSTIN;

        }

        protected void drpToParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseLayer.Party part = new DatabaseLayer.Party();

            part = lstParty.Where(P => P.ID.Equals(Convert.ToInt32(drpFromParty.SelectedValue))).FirstOrDefault();
            txtTPlace.Text = part.Place;
            txtTMobileNo.Text = part.PhoneNo;
            txtTGSTIN.Text = part.GSTIN;
        }

        protected void chkDirect_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkGST_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseLayer.LREntry lre = new DatabaseLayer.LREntry();
            lre.BrachID = Convert.ToInt32(ddlBranch.SelectedValue);

            lre.LRNO = txtLRNo.Text;
            lre.LRDateTime = DateTime.Now;
            lre.FromParty = drpFromParty.SelectedValue.ToString();
            lre.F_Place = txtFPlace.Text; ;
            lre.F_MobileNo = txtFMobile.Text;
            lre.F_GSTIN = txtFGSTIN.Text;
            lre.ToParty = drpToParty.SelectedValue.ToString();
            lre.T_Place = txtTPlace.Text;
            lre.T_MobileNo = txtTMobileNo.Text;
            lre.T_GSTIN = txtTGSTIN.Text;
            lre.BaleNo =Convert.ToInt32(txtBaleNo.Text);
            lre.NatureOfGoods = txtNature.Text;
            lre.Others = txtOthers.Text;
            lre.No_Of_Articles =Convert.ToInt32( txtNoOfArticles.Text);
            lre.Frieght = Convert.ToDecimal( txtFreight.Text);
            lre.LoadingCharge = Convert.ToDecimal(txtLoadingCharge.Text);
            lre.UnloadingCharge = Convert.ToDecimal(txtUnloadingCharge.Text);
            lre.DDCharge = Convert.ToDecimal(txtddCharge.Text);
            lre.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
            lre.SGST =  Convert.ToDecimal(txtSGST.Text);
            lre.CGST =  Convert.ToDecimal(txtCGST.Text);
            lre.RoundOf = txtRoundoff.Text;
            lre.NetAmount = Convert.ToInt32(txtNetAmount.Text);
            lre.Weight = txtWeight.Text;
            lre.Pay = txtToPay.Text;
            lre.DeliveryType = txtDeliveryType.Text;
        }
    }

    public class BillDetails
    {
        public int SlNo { get; set; }
        public string Particulars { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }

}