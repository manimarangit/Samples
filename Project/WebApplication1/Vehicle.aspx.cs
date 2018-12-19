using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
namespace WebApplication1
{
    public partial class Vehicle : System.Web.UI.Page
    {
        clsBusinessLayer b1 = new clsBusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                List<DatabaseLayer.Vehicle> lstVehicle = new List<DatabaseLayer.Vehicle>();
                lstVehicle = b1.LoadVehicle();

                //ViewState["columnNameO"] = "RegDate";
                grdVehicle.DataSource = lstVehicle;
                grdVehicle.DataBind();

                ViewState["lstVehicle"] = lstVehicle;
                //upnlOutstanding.Update();
            }
        }

        public void getdata()
        {
            // DataSet s = 
            // St_Dst = s;
            grdVehicle.DataSource = b1.LoadVehicle();
            grdVehicle.DataBind();
        }
        protected void grdVehicle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdVehicle_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        protected void gvLoad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            //dt.Rows.RemoveAt(e.RowIndex);
            //gvLoad.DataSource = dt;
            //gvLoad.DataBind();
        }

        protected void grdVehicle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["lstVehicle"] != null)
            {
                List<DatabaseLayer.Vehicle> lstVehicle = (List<DatabaseLayer.Vehicle>)ViewState["lstVehicle"];
                grdVehicle.PageIndex = e.NewPageIndex;
                ViewState["lstVehicle"] = lstVehicle;
                grdVehicle.DataSource = lstVehicle;
                grdVehicle.DataBind();
                ResetFilterAndValueVehicle();
                // upnlOutstanding.Update();


            }
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {

            if (sender is TextBox)
            {
                if (ViewState["lstVehicle"] != null)
                {
                    List<DatabaseLayer.Vehicle> allVehicle = (List<DatabaseLayer.Vehicle>)ViewState["lstVehicle"];
                    TextBox txtBox = (TextBox)sender;
                    if (txtBox.ID == "txtName")
                    {
                        allVehicle = allVehicle.Where(x => x.Name.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OName"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtVehicleNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtNumber")
                    {
                        allVehicle = allVehicle.Where(x => x.Number.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["ONumber"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtVehicleNo")).Text = txtBox.Text.ToUpper();
                    }
                    #region comment
                    //else if (txtBox.ID == "txtShortName")
                    //{
                    //    allVehicle = allVehicle.Where(x => x.ShortName.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                    //    ViewState["OShortName"] = txtBox.Text.Trim().ToUpper();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtVehicleNo")).Text = txtBox.Text.ToUpper();
                    //}



                    //else if (txtBox.ID == "txtStatus")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeStatus")).SelectedVehicle.Value;
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
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtVehicleNo")).Text = txtBox.Text.ToUpper();
                    //}
                    //else if (txtBox.ID == "txtQty")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeQty")).SelectedVehicle.Value;
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
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtVehicleNo")).Text = txtBox.Text.ToUpper();
                    //}
                    //else if (txtBox.ID == "txtAllocQty")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeAllocQty")).SelectedVehicle.Value;
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
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeRegDate")).SelectedVehicle.Value;
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

                    ViewState["lstVehicle"] = allVehicle;
                    grdVehicle.DataSource = allVehicle;
                    grdVehicle.DataBind();

                    ResetFilterAndValueVehicle();

                }
            }
        }

        protected void ResetFilterAndValueVehicle()
        {
            if (ViewState["OName"] != null)
                ((TextBox)grdVehicle.HeaderRow.FindControl("txtName")).Text = ViewState["OName"].ToString().ToUpper();
            //if (ViewState["OShortName"] != null)
            //    ((TextBox)grdVehicle.HeaderRow.FindControl("txtShortName")).Text = ViewState["OShortName"].ToString().ToUpper();
            if (ViewState["ONumber"] != null)
                ((TextBox)grdVehicle.HeaderRow.FindControl("txtNumber")).Text = ViewState["ONumber"].ToString().ToUpper();
        }

        protected void Add(object sender, EventArgs e)
        {
            pntxtID.Text = string.Empty;
            PntxtName.Text = string.Empty;
          //  PntxtShortName.Text = string.Empty;
            PntxtNumber.Text = string.Empty;
            popup.Show(); ;
        }
        protected void Edit(object sender, EventArgs e)
        {
            DatabaseLayer.Vehicle Vehicle = new DatabaseLayer.Vehicle();

            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;

            pntxtID.Text = grdVehicle.DataKeys[gridrow.RowIndex].Value.ToString();
            PntxtName.Text = ((Label)(grdVehicle.Rows[gridrow.RowIndex].Cells[2].FindControl("lblname"))).Text;
          //  PntxtShortName.Text = ((Label)(grdVehicle.Rows[gridrow.RowIndex].Cells[3].FindControl("lblShortName"))).Text;
            PntxtNumber.Text = ((Label)(grdVehicle.Rows[gridrow.RowIndex].Cells[4].FindControl("lblNumber"))).Text;

            // txtName.Text= ((TextBox)(row.Cells[1].Controls[0])).Text;
            popup.Show();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;
            var output= grdVehicle.DataKeys[gridrow.RowIndex].Value.ToString();
            b1.DeleteVehicle((Convert.ToInt32(output)));
            getdata();
            // grdVehicle.DeleteRow(Convert.ToInt32(output));
        }

        protected void lbRemoveFilterVehicles_Click(object sender, EventArgs e)
        {
            if (ViewState["OName"] != null) ViewState["OName"] = null;
           // if (ViewState["OShortName"] != null) ViewState["OShortName"] = null;
            if (ViewState["ONumber"] != null) ViewState["ONumber"] = null;

            List<DatabaseLayer.Vehicle> lstVehicle = new List<DatabaseLayer.Vehicle>();
            lstVehicle = b1.LoadVehicle();

            grdVehicle.DataSource = lstVehicle;
            grdVehicle.DataBind();

            ViewState["lstVehicle"] = lstVehicle;
        }

        protected void Save(object sender, EventArgs e)
        {
            DatabaseLayer.Vehicle Vehicle = new DatabaseLayer.Vehicle();

            Vehicle.Name = PntxtName.Text;
            //Vehicle.STName =.Text;
            Vehicle.Number = PntxtNumber.Text;

            b1 = new clsBusinessLayer();
            if (pntxtID.Text == string.Empty)
                b1.AddNewVehicle(Vehicle);
            else
            {
                Vehicle.ID = Convert.ToInt32(pntxtID.Text);
                b1.updateVehicle(Vehicle);
            }

            getdata();

        }
    }
}