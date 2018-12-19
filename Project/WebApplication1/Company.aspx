<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="WebApplication1.Company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/CSS.css" rel="stylesheet" / >
    <div class="col-md-12">
        <div class="row">
            <div class="text-center">
                <h1>L.R.Booking Entry</h1>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">To Branch</asp:Label>
                    <div class="col-md-6">
                        <%--<asp:TextBox ID="txtToBranch" runat="server" class="form-control"></asp:TextBox>--%>
                        <asp:DropDownList ID ="ddlBranch" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">L.R.No.</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtLRNo" runat="server" Style="width: 60%" Enabled="False"></asp:TextBox>
                        <asp:CheckBox runat="server" ID="chkGST" OnCheckedChanged="chkGST_CheckedChanged" />
                        GST
                            <asp:CheckBox runat="server" ID="chkDirect" OnCheckedChanged="chkDirect_CheckedChanged" />
                        Direct
                    </div>
                </div>
                 <%--<div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">L.R. Date</asp:Label>
                    <div class="col-md-6">
                        <cc1:toolkitscriptmanager id="ToolkitScriptManager1" runat="server">
                        </cc1:toolkitscriptmanager>
                        <asp:TextBox ID="txtDate" runat="server" ReadOnly="true"></asp:TextBox>
<asp:ImageButton ID="imgPopup" ImageUrl="images/CalendarImage.png" ImageAlign="Bottom"
    runat="server" />
<cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDate"
    Format="dd/MM/yyyy">
</cc1:CalendarExtender>
                    </div>--%>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">From Party</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="drpFromParty" AutoPostBack="True"  OnSelectedIndexChanged="drpFromParty_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Place</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtFPlace" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">GSTIN</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtFGSTIN" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Mobile No.</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtFMobile" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <%--           <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">GSTIn</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>--%>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">To Party</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="drpToParty" AutoPostBack="True" OnSelectedIndexChanged="drpToParty_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Place</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtTPlace" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">GSTIN</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtTGSTIN" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Mobile No.</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtTMobileNo" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Bale No.</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtBaleNo" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Nature of Goods</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNature" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">If any others</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtOthers" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group row">
                    <asp:CheckBox runat="server" />
                    Save Booking Party Address
                            <asp:CheckBox runat="server" />
                    Save Delivery Party Address
                </div>

                <%--<div id="panel" style="height: 500px; background-color: White; padding: 10px; overflow: auto">--%>
                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                         PageSize="10">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="40px"  HeaderText="S.No" />
                            <asp:BoundField ItemStyle-Width="150px" HeaderText="Particulars" />
                            <asp:BoundField ItemStyle-Width="150px" HeaderText="Qty" />
                            <asp:BoundField ItemStyle-Width="150px" HeaderText="Net Rate" />
                            <asp:BoundField ItemStyle-Width="150px" HeaderText="Amount" />
                        </Columns>
                    </asp:GridView>--%>
                <div class="row">
                  <%--  <asp:GridView ID="grdParticular" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">--%>
                      <asp:GridView ID="grdParticular" runat="server" CssClass="mydatagrid" 
                        HeaderStyle-CssClass="header" OnRowDataBound="grdParticular_RowDataBound" AutoGenerateColumns="False" Width="10px">
                           <Columns>
                                <asp:BoundField ItemStyle-Width="20"  HeaderText="S.No" />
                                <asp:TemplateField HeaderText="Particular" ItemStyle-Width="100">
                                    <ItemTemplate>
                                         <asp:TextBox ID="txtParticulars" runat="server" Width="100" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Qty" ItemStyle-Width="30px">
                                    <ItemTemplate>
                                         <asp:TextBox ID="txtQty" runat="server" Width="30px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Net Rate" ItemStyle-Width="60">
                                    <ItemTemplate>
                                         <asp:TextBox ID="txtNR" runat="server" Width="60"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Amount" ItemStyle-Width="80" >
                                    <ItemTemplate >
                                         <asp:TextBox ID="txtAmt" runat="server" Width="80"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                        </Columns>
                    </asp:GridView>
                </div>
                <%--</div>--%>

                <%--<div class="col-md-6">--%>
                    <br />
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">No.Of Articles</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNoOfArticles" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                     <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Freight</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtFreight" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Loading Charge</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtLoadingCharge" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Unloading Charge</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtUnloadingCharge" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">D.D Charge</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtddCharge" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Total Amount</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtTotalAmount" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                     

                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">CGST%</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtCGST" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">SGST%</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtSGST" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Round off</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtRoundoff" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Net Amount</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNetAmount" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Weight in Kgs</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtWeight" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">To Pay</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtToPay" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server">Delivery Type</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtDeliveryType" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <asp:Label class="col-md-3 col-form-label text-md-right" runat="server"></asp:Label>
                    <div class="col-md-6">
                        <asp:Button runat="server" Text="Save" CssClass="btn btn-primary" ID="btnSave" OnClick="btnSave_Click" />
                        <asp:Button runat="server" Text="Cancel" CssClass="btn btn-primary" />
                    </div>
                    </div>
               <%-- <div class="col-md-6">
                     <br />
                    
                    </div>--%>
                <%--</div>--%>

            </div>
        </div>
    </div>


</asp:Content>
