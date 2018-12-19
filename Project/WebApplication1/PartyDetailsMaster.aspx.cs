using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace WebApplication1
{
    public partial class PartyDetailsMaster : System.Web.UI.Page
    {
        clsBusinessLayer b1 = new clsBusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                List<DatabaseLayer.Party> lstItem = new List<DatabaseLayer.Party>();
                lstItem = b1.LoadParty();

                //ViewState["columnNameO"] = "RegDate";
                grdItem.DataSource = lstItem;
                grdItem.DataBind();

                ViewState["lstItem"] = lstItem;
                //upnlOutstanding.Update();
            }

        }
        public void getdata()
        {
            // DataSet s = 
            // St_Dst = s;
            grdItem.DataSource = b1.LoadParty();
            grdItem.DataBind();
        }

        protected void grdItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["lstItem"] != null)
            {
                List<DatabaseLayer.Party> lstItem = (List<DatabaseLayer.Party>)ViewState["lstItem"];
                grdItem.PageIndex = e.NewPageIndex;
                ViewState["lstItem"] = lstItem;
                grdItem.DataSource = lstItem;
                grdItem.DataBind();
                ResetFilterAndValueItem();
                // upnlOutstanding.Update();


            }
        }


        protected void txtItem_TextChanged(object sender, EventArgs e)
        {

            if (sender is TextBox)
            {
                if (ViewState["lstItem"] != null)
                {
                    List<DatabaseLayer.Party> allItem = (List<DatabaseLayer.Party>)ViewState["lstItem"];
                    TextBox txtBox = (TextBox)sender;
                    if (txtBox.ID == "txtName")
                    {
                        allItem = allItem.Where(x => x.Name.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OName"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    #region comment
                    else if (txtBox.ID == "txtPlace")
                    {
                        allItem = allItem.Where(x => x.Place.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OPlace"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }

                    else if (txtBox.ID == "txtPhoneNo")
                    {
                        allItem = allItem.Where(x => x.PhoneNo.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OPhoneNo"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtGSTIN")
                    {
                        allItem = allItem.Where(x => x.GSTIN.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OGSTIN"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    #endregion

                    ViewState["lstItem"] = allItem;
                    grdItem.DataSource = allItem;
                    grdItem.DataBind();

                    ResetFilterAndValueItem();

                }
            }
        }

        protected void ResetFilterAndValueItem()
        {
            if (ViewState["OPartyName"] != null)
                ((TextBox)grdItem.HeaderRow.FindControl("txtName")).Text = ViewState["OPartyName"].ToString().ToUpper();
            if (ViewState["OPlace"] != null)
                ((TextBox)grdItem.HeaderRow.FindControl("txtPlace")).Text = ViewState["OPlace"].ToString().ToUpper();
            if (ViewState["OPhoneNo"] != null)
                ((TextBox)grdItem.HeaderRow.FindControl("txtPhoneNo")).Text = ViewState["OPhoneNo"].ToString().ToUpper();
            if (ViewState["OGSTIN"] != null)
                ((TextBox)grdItem.HeaderRow.FindControl("txtGSTIN")).Text = ViewState["OGSTIN"].ToString().ToUpper();
        }

        protected void Add(object sender, EventArgs e)
        {
            pntxtID.Text = string.Empty;
            PntxtName.Text = string.Empty;
            PntxtPhoneNo.Text = string.Empty;
            PntxtPlace.Text = string.Empty;
            PntxtGSTIN.Text = string.Empty;
            popup.Show(); ;
        }
        protected void Edit(object sender, EventArgs e)
        {
            DatabaseLayer.Item item = new DatabaseLayer.Item();

            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;

            pntxtID.Text = grdItem.DataKeys[gridrow.RowIndex].Value.ToString();
            PntxtName.Text = ((Label)(grdItem.Rows[gridrow.RowIndex].Cells[2].FindControl("lblname"))).Text;
            PntxtPlace.Text = ((Label)(grdItem.Rows[gridrow.RowIndex].Cells[3].FindControl("lblPlace"))).Text;
            PntxtPhoneNo.Text = ((Label)(grdItem.Rows[gridrow.RowIndex].Cells[4].FindControl("lblPhoneNo"))).Text;
            PntxtGSTIN.Text = ((Label)(grdItem.Rows[gridrow.RowIndex].Cells[5].FindControl("lblGSTIN"))).Text;

            // txtName.Text= ((TextBox)(row.Cells[1].Controls[0])).Text;
            popup.Show();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;
            var output = grdItem.DataKeys[gridrow.RowIndex].Value.ToString();
            b1.DeleteParty((Convert.ToInt32(output)));
            getdata();
        }

        protected void lbRemoveFilterItems_Click(object sender, EventArgs e)
        {
            if (ViewState["OName"] != null) ViewState["OName"] = null;
            if (ViewState["OShortName"] != null) ViewState["OShortName"] = null;
            if (ViewState["OSRate"] != null) ViewState["OSRate"] = null;

            List<DatabaseLayer.Item> lstItem = new List<DatabaseLayer.Item>();
            lstItem = b1.LoadItem();

            grdItem.DataSource = lstItem;
            grdItem.DataBind();

            ViewState["lstItem"] = lstItem;
        }

        protected void Save(object sender, EventArgs e)
        {
            DatabaseLayer.Party item = new DatabaseLayer.Party();

            item.Name = PntxtName.Text;
            item.Place = PntxtPlace.Text;
            item.PhoneNo = PntxtPhoneNo.Text;
            item.GSTIN = PntxtGSTIN.Text;

            b1 = new clsBusinessLayer();
            if (pntxtID.Text == string.Empty)
                b1.AddParty(item);
            else
            {
                item.ID = Convert.ToInt32(pntxtID.Text);
                b1.updateParty(item);
            }

            getdata();

        }


    }
}