using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LREntry : System.Web.UI.Page
    {
        clsBusinessLayer b1 = new clsBusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                List<DatabaseLayer.Particular> lstParticular = new List<DatabaseLayer.Particular>();
                lstParticular = b1.LoadParticular();

                //ViewState["columnNameO"] = "RegDate";
                grdParticulars.DataSource = lstParticular;
                grdParticulars.DataBind();

                ViewState["lstParticular"] = lstParticular;
                //upnlOutstanding.Update();
            }
        }
        public void getdata()
        {
            // DataSet s = 
            // St_Dst = s;
            grdParticulars.DataSource = b1.LoadParticular();
            grdParticulars.DataBind();
        }
        protected void grdParticulars_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void grdParticulars_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void grdParticulars__PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["lstParticular"] != null)
            {
                List<DatabaseLayer.Particular> lstParticular = (List<DatabaseLayer.Particular>)ViewState["lstParticular"];
                grdParticulars.PageIndex = e.NewPageIndex;
                ViewState["lstItem"] = lstParticular;
                grdParticulars.DataSource = lstParticular;
                grdParticulars.DataBind();
                ResetFilterAndValueItem();
                // upnlOutstanding.Update();


            }
        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {

            if (sender is TextBox)
            {
                if (ViewState["lstParticular"] != null)
                {
                    List<DatabaseLayer.Particular> allItem = (List<DatabaseLayer.Particular>)ViewState["lstParticular"];
                    TextBox txtBox = (TextBox)sender;
                    if (txtBox.ID == "txtParticular")
                    {
                        allItem = allItem.Where(x => x.Particulars.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OParticular"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }



                    ViewState["lstParticular"] = allItem;
                    grdParticulars.DataSource = allItem;
                    grdParticulars.DataBind();

                    ResetFilterAndValueItem();

                }
            }
        }
        protected void ResetFilterAndValueItem()
        {
            if (ViewState["OParticular"] != null)
                ((TextBox)grdParticulars.HeaderRow.FindControl("txtParticular")).Text = ViewState["OParticular"].ToString().ToUpper();

        }
        protected void Add(object sender, EventArgs e)
        {
            txtEditSNO.Text = string.Empty;
            txtEditParticular.Text = string.Empty;
            txtEditQuantity.Text = string.Empty;
            txtEditNetRate.Text = string.Empty;
            txtEditAmount.Text = string.Empty;
            popup.Show(); ;
        }
        protected void Edit(object sender, EventArgs e)
        {
            DatabaseLayer.Particular item = new DatabaseLayer.Particular();

            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;

            txtEditID.Text = grdParticulars.DataKeys[gridrow.RowIndex].Value.ToString();
            txtEditSNO.Text = ((Label)(grdParticulars.Rows[gridrow.RowIndex].Cells[2].FindControl("lblSNO"))).Text;
            txtEditParticular.Text = ((Label)(grdParticulars.Rows[gridrow.RowIndex].Cells[2].FindControl("lblParticular"))).Text;
            txtEditQuantity.Text = ((Label)(grdParticulars.Rows[gridrow.RowIndex].Cells[3].FindControl("lblQuantity"))).Text;
            txtEditNetRate.Text = ((Label)(grdParticulars.Rows[gridrow.RowIndex].Cells[3].FindControl("lblNetRate"))).Text;
            txtEditAmount.Text = ((Label)(grdParticulars.Rows[gridrow.RowIndex].Cells[3].FindControl("lblAmount"))).Text;
            // txtName.Text= ((TextBox)(row.Cells[1].Controls[0])).Text;
            popup.Show();
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;
            var output = grdParticulars.DataKeys[gridrow.RowIndex].Value.ToString();
            b1.DeleteParticular((Convert.ToInt32(output)));
            getdata();
        }
        protected void Save(object sender, EventArgs e)
        {
            DatabaseLayer.Particular item = new DatabaseLayer.Particular();

            item.SNO = Convert.ToInt32(txtEditSNO.Text);
            item.Particulars = txtEditParticular.Text;
            item.Quantity = Convert.ToInt32(txtEditQuantity.Text);
            item.NetRate = Convert.ToDecimal(txtEditNetRate.Text);
            item.Amount = Convert.ToDecimal(txtEditAmount.Text);

            b1 = new clsBusinessLayer();
            if (txtEditID.Text == string.Empty)
                b1.AddNewParticular(item);
            else
            {
                item.ID = Convert.ToInt32(txtEditID.Text);
                b1.UpdateParticular(item);
            }

            getdata();

        }
    }
}