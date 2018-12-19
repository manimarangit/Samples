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
    public partial class Branch : System.Web.UI.Page
    {

        clsBusinessLayer b1 = new clsBusinessLayer();
        ClsDataLayer d1 = new ClsDataLayer();
  
        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }
        private string columnName = "";
        private int doneColouring = 0;
        private int doneColouring2 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                DatabaseLayer.Branch objOutstanding = new DatabaseLayer.Branch();

                List<DatabaseLayer.Branch> lstBranch = new List<DatabaseLayer.Branch>();
                lstBranch = b1.LoadBranch();

                //ViewState["columnNameO"] = "RegDate";
                grdBranch.DataSource = lstBranch;
                grdBranch.DataBind();

                ViewState["lstBranch"] = lstBranch;
                //upnlOutstanding.Update();
            }

        }

        private void SortGridViewBranch(string sortExpression, string direction)
        {
            if (ViewState["lstBranch"] != null)
            {

                List<DatabaseLayer.Branch> lstBranch = (List<DatabaseLayer.Branch>)ViewState["lstBranch"];

                var param = Expression.Parameter(typeof(DatabaseLayer.Branch), sortExpression);
                var sortby = Expression.Lambda<Func<DatabaseLayer.Branch, object>>(Expression.Convert(Expression.Property(param, sortExpression), typeof(object)), param);
                if (direction == "ASC")
                {
                    lstBranch = lstBranch.AsQueryable<DatabaseLayer.Branch>().OrderBy(sortby).ToList();
                }
                else
                {
                    lstBranch = lstBranch.AsQueryable<DatabaseLayer.Branch>().OrderByDescending(sortby).ToList();
                }
                ViewState["lstBranch"] = lstBranch;
                grdBranch.DataSource = lstBranch;
                grdBranch.DataBind();

                upnlOutstanding.Update();
                ResetFilterAndValueBranch();
            }
        }

        protected void grdBranch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && doneColouring2 == 0)
            {
                GridViewRow headerRow = grdBranch.HeaderRow;
                if (ViewState["columnNameO"] != null) columnName = ViewState["columnNameO"].ToString();
                for (int i = 0; i < headerRow.Cells.Count; i++)
                {
                    if (headerRow.Cells[i].Controls.Count != 0)
                    {
                        //if (!(headerRow.Cells[i].Controls[0] is System.Web.UI.LiteralControl))
                        //{
                        if (((LinkButton)headerRow.Cells[i].Controls[1]).Text == columnName)
                        {
                            headerRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#2F8CDE");
                            Image img = new Image();
                            img.CssClass = "imgClass";
                            if (GridViewSortDirection == SortDirection.Ascending)
                            {
                                img.ImageUrl = "./Images/up.png";

                            }
                            if (GridViewSortDirection == SortDirection.Descending)
                            {
                                img.ImageUrl = "./Images/down.png";
                            }

                            headerRow.Cells[i].Controls.Add(img);
                            doneColouring2 = 1;
                        }
                        //}
                    }
                }
            }
        }

        protected void grdBranch_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            columnName = e.SortExpression;
            ViewState["columnNameO"] = columnName;
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridViewBranch(sortExpression, "DESC");
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridViewBranch(sortExpression, "ASC");
            }

        }

        protected void grdBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["lstBranch"] != null)
            {
                List<DatabaseLayer.Branch> lstBranch = (List<DatabaseLayer.Branch>)ViewState["lstBranch"];
                grdBranch.PageIndex = e.NewPageIndex;
                ViewState["lstBranch"] = lstBranch;
                grdBranch.DataSource = lstBranch;
                grdBranch.DataBind();
                ResetFilterAndValueBranch();
                // upnlOutstanding.Update();


            }
        }
        // For Outstanding Orders - Single Event bound  to all textboxes
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {


            if (sender is TextBox)
            {
                if (ViewState["lstBranch"] != null)
                {
                    List<DatabaseLayer.Branch> allBranch = (List<DatabaseLayer.Branch>)ViewState["lstBranch"];
                    TextBox txtBox = (TextBox)sender;
                    if (txtBox.ID == "txtName")
                    {
                        allBranch = allBranch.Where(x => x.Name.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OName"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    #region comment
                    else if (txtBox.ID == "txtSTName")
                    {
                        allBranch = allBranch.Where(x => x.STName.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OSTName"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtAddress1")
                    {
                        allBranch = allBranch.Where(x => x.Address1.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OAddress1"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtAddress2")
                    {
                        allBranch = allBranch.Where(x => x.Address2.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OAddress2"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtAddress3")
                    {
                        allBranch = allBranch.Where(x => x.Address3.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OAddress3"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtAddress4")
                    {
                        allBranch = allBranch.Where(x => x.Address4.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OAddress4"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtPhoneNo")
                    {
                        allBranch = allBranch.Where(x => x.PhoneNo.Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OPhoneNo"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtEmail")
                    {
                        allBranch = allBranch.Where(x => x.Email.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OEmail"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtPrefix1")
                    {
                        allBranch = allBranch.Where(x => x.Prefix1.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OPrefix1"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtPrefix2")
                    {
                        allBranch = allBranch.Where(x => x.Prefix2.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OPrefix2"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    else if (txtBox.ID == "txtGSTIN")
                    {
                        allBranch = allBranch.Where(x => x.GSTIN.ToUpper().Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["OGSTIN"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    //else if (txtBox.ID == "txtLine")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeLine")).SelectedItem.Value;

                    //    if (filtrerType == "=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line == int.Parse(txtBox.Text.Trim())).ToList();
                    //    }
                    //    else if (filtrerType == ">")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line > int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == ">=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line >= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line < int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line <= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    ViewState["OFilterLine"] = filtrerType;
                    //    ViewState["OLine"] = txtBox.Text.Trim();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                    //}
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

                    ViewState["lstBranch"] = allBranch;
                    grdBranch.DataSource = allBranch;
                    grdBranch.DataBind();

                     ResetFilterAndValueBranch();

                }
            }
        }

        protected void ResetFilterAndValueBranch()
        {
            if (ViewState["OName"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtName")).Text = ViewState["OName"].ToString().ToUpper();
            if (ViewState["OSTName"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtSTName")).Text = ViewState["OSTName"].ToString().ToUpper();
            if (ViewState["OAddress1"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtAddress1")).Text = ViewState["OAddress1"].ToString().ToUpper();
            if (ViewState["OAddress2"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtAddress2")).Text = ViewState["OAddress2"].ToString().ToUpper();
            if (ViewState["OAddress3"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtAddress3")).Text = ViewState["OAddress3"].ToString().ToUpper();
            if (ViewState["OAddress4"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtAddress4")).Text = ViewState["OAddress4"].ToString().ToUpper();
            if (ViewState["OPhoneNo"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtPhoneNo")).Text = ViewState["OPhoneNo"].ToString().ToUpper();
            if (ViewState["OEmail"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtEmail")).Text = ViewState["OEmail"].ToString().ToUpper();
            if (ViewState["OPrefix1"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtPrefix1")).Text = ViewState["OPrefix1"].ToString().ToUpper();
            if (ViewState["OPrefix2"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtPrefix2")).Text = ViewState["OPrefix2"].ToString().ToUpper();
            if (ViewState["OGSTIN"] != null)
                ((TextBox)grdBranch.HeaderRow.FindControl("txtGSTIN")).Text = ViewState["OGSTIN"].ToString().ToUpper();



        }

        protected void lbRemoveFilterBranch_Click(object sender, EventArgs e)
        {
            if (ViewState["OName"] != null) ViewState["OName"] = null;
            if (ViewState["OSTName"] != null) ViewState["OSTName"] = null;
            if (ViewState["OAddress1"] != null) ViewState["OAddress1"] = null;
            if (ViewState["OAddress2"] != null) ViewState["OAddress2"] = null;
            if (ViewState["OAddress3"] != null) ViewState["OAddress3"] = null;
            if (ViewState["OAddress4"] != null) ViewState["OAddress4"] = null;
            if (ViewState["OPhoneNo"] != null) ViewState["OPhoneNo"] = null;
            if (ViewState["OEmail"] != null) ViewState["OEmail"] = null;
            if (ViewState["OPrefix1"] != null) ViewState["OPrefix1"] = null;
            if (ViewState["OPrefix2"] != null) ViewState["OPrefix2"] = null;
            if (ViewState["OGSTIN"] != null) ViewState["OGSTIN"] = null;
           

           // Branch objOutstanding = new Outstanding();
            List<DatabaseLayer.Branch> lstBranch = new List<DatabaseLayer.Branch>();
            lstBranch = b1.LoadBranch();

            grdBranch.DataSource = lstBranch;
            grdBranch.DataBind();

            ViewState["lstBranch"] = lstBranch;
        }


        public void getdata()
        {
           // DataSet s = 
            // St_Dst = s;
            grdBranch.DataSource = b1.LoadBranch();
            grdBranch.DataBind();
        }



        protected void txtName_TextChanged(object sender, EventArgs e)
        {

            if (sender is TextBox)
            {
                if (ViewState["lstBranch"] != null)
                {
                    List<DatabaseLayer.Branch> allBranch = (List<DatabaseLayer.Branch>)ViewState["lstBranch"];
                    TextBox txtBox = (TextBox)sender;
                    if (txtBox.ID == "txtName")
                    {
                        allBranch = allBranch.Where(x => x.Name.Contains(txtBox.Text.Trim().ToUpper())).ToList();
                        ViewState["txtName"] = txtBox.Text.Trim().ToUpper();
                        //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    }
                    #region comment
                    //else if (txtBox.ID == "txtOrder")
                    //{
                    //    allOutstanding = allOutstanding.Where(x => x.Order.Contains(txtBox.Text.Trim().ToUpper())).ToList();
                    //    ViewState["OOrder"] = txtBox.Text.Trim().ToUpper();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtItemNo")).Text = txtBox.Text.ToUpper();
                    //}
                    //else if (txtBox.ID == "txtLine")
                    //{
                    //    string filtrerType = ((DropDownList)grdBranch.HeaderRow.FindControl("ddlFilterTypeLine")).SelectedItem.Value;

                    //    if (filtrerType == "=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line == int.Parse(txtBox.Text.Trim())).ToList();
                    //    }
                    //    else if (filtrerType == ">")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line > int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == ">=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line >= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line < int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    else if (filtrerType == "<=")
                    //    {
                    //        allOutstanding = allOutstanding.Where(x => x.Line <= int.Parse(txtBox.Text.Trim())).ToList();

                    //    }
                    //    ViewState["OFilterLine"] = filtrerType;
                    //    ViewState["OLine"] = txtBox.Text.Trim();
                    //    //((TextBox)grdViewProposal.HeaderRow.FindControl("txtTriggerPt")).Text = txtBox.Text.ToUpper();
                    //}
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

                    ViewState["lstBranch"] = allBranch;
                    grdBranch.DataSource = allBranch;
                    grdBranch.DataBind();

                  //  ResetFilterAndValueOutstanding();

                }
            }

        }
        protected void Add(object sender, EventArgs e)
        {
            pntxtID.Text = string.Empty;
            PntxtName.Text = string.Empty;
            PntxtSTName.Text = string.Empty;
            PntxtAddress1.Text = string.Empty;
            PntxtAddress2.Text = string.Empty;
            PntxtAddress3.Text = string.Empty;
            PntxtAddress4.Text = string.Empty;
            PntxtPhoneNo.Text = string.Empty;
            PntxtEmail.Text = string.Empty;
            PntxtPrefix1.Text = string.Empty;
            PntxtPrefix2.Text = string.Empty;
            PntxtGSTIN.Text = string.Empty;

            popup.Show(); ;
        }

        //protected void Edit(object sender, EventArgs e)
        //{
        //    GridViewRow n = grdBranch.SelectedRow;
        //    using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        //    {

        //        txtName.Text= n.Cells[1].Text;
        //        txtSTName.Text= row.Cells[2].Text;
        //        txtAddress1.Text= row.Cells[3].Text;
        //        txtAddress2.Text = row.Cells[4].Text;
        //        txtAddress3.Text = row.Cells[5].Text;
        //        txtAddress4.Text = row.Cells[6].Text;
        //        txtPhoneNo.Text = row.Cells[7].Text;
        //        txtEmail.Text = row.Cells[8].Text;
        //        txtPrefix1.Text = row.Cells[9].Text;
        //        txtPrefix2.Text = row.Cells[10].Text;
        //        txtGSTIN.Text = row.Cells[11].Text;

        //        //txtCustomerID.ReadOnly = true;
        //        //txtCustomerID.Text = row.Cells[0].Text;
        //        //txtContactName.Text = row.Cells[1].Text;
        //        //txtCompany.Text = row.Cells[2].Text;
        //        //  txtName = (row.Cells[0] as TextBox).Text; ;
        //        popup.Show();
        //    }
        //}


        //protected void Edit(object sender, GridViewEditEventArgs e)
        //{
        //    var row = grdBranch.Rows[e.NewEditIndex];
        //    // branch.ID = int.Parse(grdBranch.DataKeys[e.NewEditIndex].Value.ToString());
        //    pntxtID.Text = grdBranch.DataKeys[e.NewEditIndex].Value.ToString();
        //    PntxtName.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblname"))).Text;
        //    PntxtSTName.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblSTName"))).Text;
        //    PntxtAddress1.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblAddress1"))).Text;
        //    PntxtAddress2.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblAddress2"))).Text;
        //    PntxtAddress3.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblAddress3"))).Text;
        //    PntxtAddress4.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblAddress4"))).Text;
        //    PntxtPhoneNo.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblPhoneNo"))).Text;
        //    PntxtEmail.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblEmail"))).Text;
        //    PntxtPrefix1.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblPrefix1"))).Text;
        //    PntxtPrefix2.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblPrefix2"))).Text;
        //    PntxtGSTIN.Text = ((Label)(grdBranch.Rows[e.NewEditIndex].FindControl("lblGSTIN"))).Text;
        //    // txtName.Text= ((TextBox)(row.Cells[1].Controls[0])).Text;
        //    popup.Show();
        //}

        protected void Save(object sender, EventArgs e)
        {
            DatabaseLayer.Branch branch = new DatabaseLayer.Branch();

            branch.Name = PntxtName.Text;
            branch.STName = PntxtSTName.Text;
            branch.Address1 = PntxtAddress1.Text;
            branch.Address2 = PntxtAddress2.Text;
            branch.Address3 = PntxtAddress3.Text;
            branch.Address4 = PntxtAddress4.Text;
            branch.PhoneNo = PntxtPhoneNo.Text;
            branch.Email = PntxtEmail.Text;
            branch.Prefix1 = PntxtPrefix1.Text;
            branch.Prefix1 = PntxtPrefix2.Text;
            branch.GSTIN = PntxtGSTIN.Text;
            b1 = new clsBusinessLayer();
            if (pntxtID.Text == string.Empty)
                b1.AddNewBranchName(branch);
            else
            {
                branch.ID = Convert.ToInt32(pntxtID.Text);
                b1.updateBranch(branch);
            }

            getdata();

        }

        protected void Edit(object sender, EventArgs e)
        {
            DatabaseLayer.Branch branch = new DatabaseLayer.Branch();

            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;
            // int id = Convert.ToInt32(GridView1.DataKeys[gridrow.RowIndex].Value.ToString());
            //var row = grdBranch.Rows[e.NewEditIndex];
            branch.ID = int.Parse(grdBranch.DataKeys[gridrow.RowIndex].Value.ToString());
            pntxtID.Text = grdBranch.DataKeys[gridrow.RowIndex].Value.ToString();
            PntxtName.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[2].FindControl("lblname"))).Text;
            PntxtSTName.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[3].FindControl("lblSTName"))).Text;
            PntxtAddress1.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[4].FindControl("lblAddress1"))).Text;
            PntxtAddress2.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[5].FindControl("lblAddress2"))).Text;
            PntxtAddress3.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[6].FindControl("lblAddress3"))).Text;
            PntxtAddress4.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[7].FindControl("lblAddress4"))).Text;
            PntxtPhoneNo.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[8].FindControl("lblPhoneNo"))).Text;
            PntxtEmail.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[9].FindControl("lblEmail"))).Text;
            PntxtPrefix1.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[10].FindControl("lblPrefix1"))).Text;
            PntxtPrefix2.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[11].FindControl("lblPrefix2"))).Text;
            PntxtGSTIN.Text = ((Label)(grdBranch.Rows[gridrow.RowIndex].Cells[12].FindControl("lblGSTIN"))).Text;
            // txtName.Text= ((TextBox)(row.Cells[1].Controls[0])).Text;
            popup.Show();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            GridViewRow gridrow = btn.NamingContainer as GridViewRow;
            var output = grdBranch.DataKeys[gridrow.RowIndex].Value.ToString();
            b1.DeleteBranch((Convert.ToInt32(output)));
            getdata();
        }
    }
}