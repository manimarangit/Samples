<%@ Page Title="Vehicle"  Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehicle.aspx.cs" Inherits="WebApplication1.Vehicle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
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
    </script>


     <div class="row">
                        <div class="col-md-12">

                            <!-- START DEFAULT DATATABLE -->
                            <div class="panel panel-default">
                                <div class="panel-heading">   
                                     <h2 class="panel-title"><b>Vehicle Registration</b></h2>
                                    <ul class="panel-controls">
                                        <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a></li>
                                        <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>
                                        <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></li>
                                    </ul>
                                    

                                    </div>
                                <div class="panel-body">

                                    <asp:LinkButton ID="lbRemoveFilterVehicles" runat="server" Text="Remove Filter"
            OnClick="lbRemoveFilterVehicles_Click"></asp:LinkButton>
        <asp:UpdatePanel ID="upnlVehicle" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
               
                <asp:GridView ID="grdVehicle" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="5" ForeColor="#1D2127"
                    GridLines="Both" AllowPaging="True" CellSpacing="1"
                    CssClass="table" PageSize="10" AllowSorting="true" OnPageIndexChanging="grdVehicle_PageIndexChanging"
                    OnRowDataBound="grdVehicle_RowDataBound" OnSorting="grdVehicle_Sorting" DataKeyNames="Id">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" Visible="false" />
                        <asp:TemplateField SortExpression="Name">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnName" runat="server" Text="Vehicle Service Name" CommandName="Sort" Font-Size="13px" CommandArgument="Vehicle"></asp:LinkButton>
                                <br />  <br /> 
                                <asp:TextBox runat="server" ID="txtName" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name")%>'></asp:Label>

                            </ItemTemplate>

                        </asp:TemplateField>
                 <%--       <asp:TemplateField SortExpression="STName">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnSTName" runat="server" Text="ShortName" CommandName="Sort" CommandArgument="Order"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtShortName" AutoPostBack="true" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblShortName" runat="server" Text='<%#Eval("ShortName")%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>--%>

                        <asp:TemplateField SortExpression="Number">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnNumber" runat="server" Text="Vehicle Reg.Number" CommandName="Sort" Font-Size="13px" CommandArgument="Item"></asp:LinkButton>
                                <br />  <br />                    
                                   
                                     
                                            <asp:TextBox runat="server" ID="txtNumber" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                                      
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNumber" runat="server" Text='<%#Eval("Number")%>'></asp:Label>

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

                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn-primary" OnClick="Add" />
                <asp:Panel ID="pnlAddEdit" runat="server" BackColor="White" Height="400px"
                    Width="300px" Style="z-index: 111; background-color: White; position: absolute; left: 35%; top: 12%; border: outset 2px gray; padding: 5px; display: none">
                    <table class="table">
                        <tr style="background-color: #1D2127">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                                align="center">Vehicle Details
                            </td>
                        </tr>
                        <tr>
                            <td>Vehicle Name:
                            </td>
                            <td>
                                <asp:TextBox ID="pntxtID" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="PntxtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>                   
                        <tr>

                            <td >Reg.Number:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtNumber" runat="server" />
                            </td>
                        </tr>
                        <tr class="text-center">
                            <td colspan="2" >
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-info" Font-Size="14px" OnClick="Save" />&nbsp;&nbsp; <asp:Button ID="btnCancel" Font-Size="14px" runat="server" Text="Close" CssClass="btn-primary" OnClientClick="return Hidepopup()" />
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
                <asp:AsyncPostBackTrigger ControlID="grdVehicle" />
                <asp:AsyncPostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
                                </div>
                                </div>
                            </div>
         </div>
        
       <script>
       
          
              $(".x-navigation li").removeClass("active");
               $('#liVehcicle').addClass('active');
      
    </script>
 </asp:Content>
<%--<!DOCTYPE html>

<script>

</script>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link href="CSS/CSS.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>

   
    
</head>
<body>
    
</body>
</html>--%>