<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LREntry.aspx.cs" Inherits="WebApplication1.LREntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
                    '<img src="Images/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.6
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        }
        $(document).ready(function () {

            BlockUI("<%=pnlAddEdit.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function Hidepopup() {
            $find("popup").hide();
            return false;
        }
        function createLRNo() {
            var toBranch = $('#<%= txtToBranch.ClientID%>').val();
           // var toParty = $('#<%= txtToBranch.ClientID%>').val();
            $('#<%= lblLRNo.ClientID%>').html(toBranch.slice(0,2).toUpperCase() + Math.floor(Math.random()*1111));
        }
      
    </script>
     <div class="panel panel-default">
                                <div class="panel-heading">   
                                     <h2 class="panel-title"><b>L.R.Booking Entry Management</b></h2>
                                    <ul class="panel-controls">
                                    <%--    <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a></li>
                                        <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>
                                        <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></l--%>i>
                                    </ul>
                                    

                                    </div>

         <div class="panel-body" style="overflow:scroll;">
   <div class="row">
       <div class="col-lg-5">

           <table class="table" >
                <th style="width: 30%"></th>
  <th style="width: 70%"></th>
  
                         <tr style="background-color: #1D2127">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                                >LR Service - From Details
                            </td>
                        </tr>


                        <tr>
                            <td>To Branch:
                            </td>
                            <td>
                                <asp:TextBox ID="txtToBranch" runat="server" onchange = "createLRNo(this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>LR No.:
                            </td>
                            <td>
                               <b># <asp:Label ID="lblLRNo" runat="server"></asp:Label></b> 
                             <%--   <asp:TextBox ID="txtLRNo" runat="server"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>LR Date:
                            </td>
                            <td>
                                  <asp:TextBox ID="txtLRDate" runat="server"></asp:TextBox>  
                    <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtLRDate" Format="dd/MM/yyyy"> </cc1:CalendarExtender> 
                                L.R Ttime
                                 <asp:TextBox ID="txtLRTime" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>From Party:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromParty" TextMode="MultiLine" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Place:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPlace" TextMode="MultiLine" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>GSITN:
                            </td>
                            <td>
                                <asp:TextBox ID="txtGSITNo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Mobile No:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileNo" runat="server" />
                            </td>
                        </tr>
                      
                    </table>

           <table class="table" >
                <th style="width: 30%"></th>
  <th style="width: 70%"></th>
                         <tr style="background-color: #1D2127">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                               >LR Service - To Details
                            </td>
                        </tr>


                        <tr>
                            <td>To Party:
                            </td>
                            <td>
                                <asp:TextBox ID="txtToParty" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Place:
                            </td>
                            <td>
                                <asp:TextBox ID="txtToPlace" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>GSITN:
                            </td>
                            <td>
                                <asp:TextBox ID="txtToPartyGSITN" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Mobile No:
                            </td>
                            <td>
                                <asp:TextBox ID="txtToPartyMobileNo" runat="server" />
                            </td>
                        </tr>
                        
                    </table>
           <table class="table" >
                <th style="width: 30%"></th>
  <th style="width: 70%"></th>
                         <tr style="background-color: #1D2127">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                               >
                            </td>
                        </tr>


                        <tr>
                            <td>Bale No:
                            </td>
                            <td>
                                <asp:TextBox ID="txtBaleNo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Nature Of Goods:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNatureOfGoods" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>If any Others:
                            </td>
                            <td>
                                <asp:TextBox ID="txtOthers" TextMode="MultiLine" runat="server" />
                            </td>
                        </tr>
                        
                        
                    </table>
       </div>
         <div class="col-lg-7">
             <div><input type="checkbox" runat="server" id="chkSaveBookingAddress" /> Save Booking Address &nbsp;&nbsp; <input type="checkbox" runat="server" id="chckSaveDelieveryAddress" /> Save Delivery Address</div><br />
           
             <asp:UpdatePanel ID="upnlItem" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
               
                 <asp:GridView ID="grdParticulars" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="5" ForeColor="Black"
                    GridLines="Both" AllowPaging="True" CellSpacing="1"
                   CssClass="table" PageSize="10" AllowSorting="true" OnPageIndexChanging="grdParticulars__PageIndexChanging"
                    OnRowDataBound="grdParticulars_RowDataBound" OnSorting="grdParticulars_Sorting" DataKeyNames="Id">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" Visible="false" />
                        <asp:TemplateField SortExpression="S.No">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnSNo" runat="server" Text="S.No" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                               <%-- <br />
                                <asp:TextBox runat="server" ID="txtSNO" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSNO" runat="server" Text='<%#Eval("SNO")%>'></asp:Label>

                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Particular">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnParticular" runat="server" Text="Particular" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                              <%--  <br />
                                <asp:TextBox runat="server" ID="txtParticular" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblParticular" runat="server" Text='<%#Eval("Particulars")%>'></asp:Label>

                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Quantity">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnQuantity" runat="server" Text="Quantity" CommandName="Sort" CommandArgument="Order"></asp:LinkButton>
                               <%-- <br />
                                <asp:TextBox runat="server" ID="txtQuantity" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                          <asp:TemplateField SortExpression="Netrate">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnNetrate" runat="server" Text="Netrate" CommandName="Sort" CommandArgument="Order"></asp:LinkButton>
                              <%--  <br />
                                <asp:TextBox runat="server" ID="txtNetrate" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNetrate" runat="server" Text='<%#Eval("Netrate")%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                         <asp:TemplateField SortExpression="Amount">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnAmount" runat="server" Text="Amount" CommandName="Sort" CommandArgument="Order"></asp:LinkButton>
                              <%--  <br />
                                <asp:TextBox runat="server" ID="txtAmount" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        

                        <%--  <asp:CommandField ShowEditButton="True" />--%>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClick="lnkDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this event?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" CssClass="pgr" />


                       <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#F1F5F9" Font-Bold="True" ForeColor="#1D2127" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
               
                <asp:Button ID="btnAdd" runat="server" Text=" + Add Particular" OnClick="Add" CssClass="btn-primary btn-md" />

                <asp:Panel ID="pnlAddEdit" runat="server" BackColor="White" Height="400px"
                    Width="300px" Style="z-index: 111; background-color: White; position: absolute; left: 35%; top: 12%; border: outset 2px gray; padding: 5px; display: none">
                    <table class="table">
                        <tr style="background-color: #1D2127">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                                align="center">Particular Details
                            </td>
                        </tr>

                        <tr>
                            <td>S.NO:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditID" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtEditSNO" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Particular:
                            </td>
                            <td>
                              
                                <asp:TextBox ID="txtEditParticular" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >Quantity:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditQuantity" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>

                            <td >Net Rate:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditNetRate" runat="server" />
                            </td>
                        </tr>
                        <tr>

                            <td >Amount:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditAmount" runat="server" />
                            </td>
                        </tr>

                        <tr class="text-center">
                            <td colspan="2">
                                <asp:Button ID="btnEditGridSave" runat="server" Text="Save" CssClass="btn-info" Font-Size="14px"  OnClick="Save" />&nbsp;&nbsp;  <asp:Button ID="Button2" runat="server" CssClass="btn-primary" Font-Size="14px"  Text="Close" OnClientClick="return Hidepopup()" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
                    PopupControlID="pnlAddEdit" TargetControlID="lnkFake"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="grdParticulars" />
                <asp:AsyncPostBackTrigger ControlID="btnEditGridSave" />
            </Triggers>
        </asp:UpdatePanel>
             
             <%--<table class="table" >
                <th style="width: 10%">S.NO</th>
                <th style="width: 40%">Particulars</th>
                 <th style="width: 10%">Qty</th>
                <th style="width: 20%">Net Rate</th>
                   <th style="width: 20%">Amount</th>
                         <tr style="background-color: #1D2127">
                            <td colspan="5" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px" >
                            </td>
                        </tr>


                        <tr>
                            <td>Bale No:
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                             <td>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </td>
                             <td>
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            </td>
                             <td>
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            </td>
                        </tr>                     
                    </table>--%>
             <table class="table" >
                <th style="width: 30%"></th>
  <th style="width: 70%"></th>
                         <tr style="background-color: #1D2127">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                               >
                            </td>
                        </tr>


                        <tr>
                            <td>No.Of Articals:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNoOfArticals" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Freight:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFreight" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>Loading Charge:
                            </td>
                            <td>
                                <asp:TextBox ID="txtLoadingCharge" runat="server" />
                            </td>
                        </tr>
                       <tr>
                            <td>UnLoading Charge:
                            </td>
                            <td>
                                <asp:TextBox ID="txtUnloadingCharge" runat="server" />
                            </td>
                        </tr>
                      <tr>
                            <td>D.D.Charge:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDDCharge" runat="server" />
                            </td>
                        </tr>
                     <tr>
                            <td>Total Amount:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalAmount" runat="server" />
                            </td>
                        </tr>
                     <tr>
                            <td>CGST%:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCGST" runat="server" />   <asp:TextBox ID="txtCGSTValue" runat="server" />
                            </td>
                        </tr>
                     <tr>
                            <td>SGST%:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSCGST" runat="server" />   <asp:TextBox ID="txtSCGSTValue" runat="server" />
                            </td>
                        </tr>
                      <tr>
                            <td>Round Off
                            </td>
                            <td>
                                <asp:TextBox ID="txtRoundOff" runat="server" />
                            </td>
                        </tr>
                         <tr>
                            <td>NetAmount
                            </td>
                            <td>
                                <asp:TextBox ID="txtNetAmount" runat="server" /> 
                            </td>
                        </tr>
                          <tr>
                            <td>Weight in Kgs
                            </td>
                            <td>
                                <asp:TextBox ID="txtWeightInKgs" runat="server" /> 
                            </td>
                        </tr>
                         <tr>
                            <td>Pay /To Pay
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPayorToPay" runat="server">
                                    <asp:ListItem>Pay</asp:ListItem>
                                     <asp:ListItem>To Pay</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td>Delivery Type
                            </td>
                            <td>
                               <asp:DropDownList ID="ddlDeliveryType" runat="server">
                                    <asp:ListItem>Door Delivery</asp:ListItem>
                                    
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                    </table>
         </div>

   </div>

             <div class="row">
                 <div class="col-lg-12" style="text-align:center;">
                     <asp:Button ID="btnSave" runat="server" CssClass="btn-info" Font-Size="18px"  Text="Save" />&nbsp;&nbsp;  <asp:Button ID="btnCancel" CssClass="btn-primary" Font-Size="18px"  runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                 </div>
             </div>
             </div>

         </div>
        <style>
.table{
outline-style: solid;
outline-width: 2px;
</style>
    <script>
        $(".x-navigation li").removeClass("active");
        $('#liLREntry').addClass('active');
    </script>
</asp:Content>