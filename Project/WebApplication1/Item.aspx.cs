using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
namespace WebApplication1
{
    public partial class Item : System.Web.UI.Page
    {
        clsBusinessLayer b1 = new clsBusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
                List<DatabaseLayer.Item> lstItem = new List<DatabaseLayer.Item>();
                lstItem = b1.LoadItem();

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
            grdItem.DataSource = b1.LoadItem();
            grdItem.DataBind();
        }
        protected void grdItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdItem_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["lstItem"] != null)
            {
                List<DatabaseLayer.Item> lstItem = (List<DatabaseLayer.Item>)ViewState["lstItem"];
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
                    List<DatabaseLayer.Item> allItem = (List<DatabaseLayer.Item>)ViewState["lstItem"];
                    TextBox txtBox = (TextBox)sender;
                    if (txtBox.ID == "txtName")
                    {
                        allItem = allItem.Where(x => x.Name.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OName"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    #region comment
                    else if (txtBox.ID == "txtShortName")
                    {
                        allItem = allItem.Where(x => x.ShortName.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OShortName"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }

                    else if (txtBox.ID == "txtSRate")
                    {
                        string filtrerType = ((DropDownList)grdItem.HeaderRow.FindControl("ddlFilterTypeLine")).SelectedItem.Value;

                        if (filtrerType == "=")
                        {
                            allItem = allItem.Where(x => x.SRate == decimal.Parse(txtBox.Text.Trim())).ToList();
                        }
                        else if (filtrerType == ">")
                        {
                            allItem = allItem.Where(x => x.SRate > decimal.Parse(txtBox.Text.Trim())).ToList();

                        }
                        else if (filtrerType == ">=")
                        {
                            allItem = allItem.Where(x => x.SRate >= decimal.Parse(txtBox.Text.Trim())).ToList();

                        }
                        else if (filtrerType == "<")
                        {
                            allItem = allItem.Where(x => x.SRate < decimal.Parse(txtBox.Text.Trim())).ToList();

                        }
                        else if (filtrerType == "<=")
                        {
                            allItem = allItem.Where(x => x.SRate <= decimal.Parse(txtBox.Text.Trim())).ToList();

                        }
                        ViewState["OFilterLine"] = filtrerType;
                        ViewState["OSRate"] = txtBox.Text.Trim();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                    }
                    //else if (txtBox.ID == "txtStatus")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeStatus")).SelectedItem.Value;
                    //    if (filtrerType == "=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Status == int.Parse(txtBox.Text.Trim())).ToList();
                    //    }
                    //    else if (filtrerType == ">")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Status > int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == ">=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Status >= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Status < int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Status <= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    ViewState["OFilterStatus"] = filtrerType;
                    //    ViewState["OStatus"] = txtBox.Text.Trim();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                    //}
                    //else if (txtBox.ID == "txtToLocation")
                    //{
                    //    allOutstanding = allOutstanding.Where(x => x.ToLocation.Contains(txtBox.Text.Trim().ToUpper())).ToList();
                    //    ViewState["OToLocation"] = txtBox.Text.Trim().ToUpper();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    //}
                    //else if (txtBox.ID == "txtQty")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeQty")).SelectedItem.Value;
                    //    if (filtrerType == "=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Qty == int.Parse(txtBox.Text.Trim())).ToList();
                    //    }
                    //    else if (filtrerType == ">")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Qty > int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == ">=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Qty >= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Qty < int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Qty <= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    ViewState["OFilterQty"] = filtrerType;
                    //    ViewState["OQty"] = txtBox.Text.Trim();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                    //}
                    //else if (txtBox.ID == "txtLocation")
                    //{
                    //    allOutstanding = allOutstanding.Where(x => x.Location.Contains(txtBox.Text.Trim().ToUpper())).ToList();
                    //    ViewState["OLocation"] = txtBox.Text.Trim().ToUpper();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    //}
                    //else if (txtBox.ID == "txtAllocQty")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeAllocQty")).SelectedItem.Value;
                    //    if (filtrerType == "=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.AllocQty == int.Parse(txtBox.Text.Trim())).ToList();
                    //    }
                    //    else if (filtrerType == ">")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.AllocQty > int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == ">=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.AllocQty >= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.AllocQty < int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.AllocQty <= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    ViewState["OFilterAllocQty"] = filtrerType;
                    //    ViewState["OAllocQty"] = txtBox.Text.Trim();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                    //}
                    //else if (txtBox.ID == "txtRegDate")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeRegDate")).SelectedItem.Value;
                    //    if (filtrerType == "=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.RegDate == DateTime.Parse(txtBox.Text.Trim())).ToList();
                    //    }
                    //    else if (filtrerType == ">")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.RegDate > DateTime.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == ">=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.RegDate >= DateTime.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.RegDate < DateTime.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.RegDate <= DateTime.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    ViewState["OFilterRegDate"] = filtrerType;
                    //    ViewState["ORegDate"] = txtBox.Text.Trim();

                    //}
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
            if (ViewState["OName"] != null)
                ((TextBox)grdItem.HeaderRow.FindControl("txtName")).Text = ViewState["OName"].ToString().ToUpper();
            if (ViewState["OShortName"] != null)
                ((TextBox)grdItem.HeaderRow.FindControl("txtShortName")).Text = ViewState["OShortName"].ToString().ToUpper();
            if (ViewState["OSRate"] != null)
                ((TextBox)grdItem.HeaderRow.FindControl("txtSRate")).Text = ViewState["OSRate"].ToString().ToUpper();
        }

        protected void Add(object sender, EventArgs e)
        {
            pntxtID.Text = string.Empty;
            PntxtName.Text = string.Empty;
            PntxtShortName.Text = string.Empty;
            PntxtSRate.Text = string.Empty;      
            popup.Show(); ;
        }
        protected void Edit(object sender, EventArgs e)
        {
            DatabaseLayer.Item item = new DatabaseLayer.Item();

            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;

            pntxtID.Text = grdItem.DataKeys[gridrow.RowIndex].Value.ToString();
            PntxtName.Text = ((Label)(grdItem.Rows[gridrow.RowIndex].Cells[2].FindControl("lblname"))).Text;
            PntxtShortName.Text = ((Label)(grdItem.Rows[gridrow.RowIndex].Cells[3].FindControl("lblShortName"))).Text;
            PntxtSRate.Text = ((Label)(grdItem.Rows[gridrow.RowIndex].Cells[4].FindControl("lblSRate"))).Text;
            
            // txtName.Text= ((TextBox)(row.Cells[1].Controls[0])).Text;
            popup.Show();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;
            var output = grdItem.DataKeys[gridrow.RowIndex].Value.ToString();
            b1.DeleteItem((Convert.ToInt32(output)));
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
            DatabaseLayer.Item item = new DatabaseLayer.Item();

            item.Name = PntxtName.Text;
            item.ShortName = PntxtShortName.Text;
            item.SRate = Convert.ToDecimal(PntxtSRate.Text);

            b1 = new clsBusinessLayer();
            if (pntxtID.Text == string.Empty)
                b1.AddNewItem(item);
            else
            {
                item.ID = Convert.ToInt32(pntxtID.Text);
                b1.updateItem(item);
            }

            getdata();

        }

    }



}