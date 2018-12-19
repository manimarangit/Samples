<%@ Page Title="Branch" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Branch.aspx.cs" Inherits="WebApplication1.Branch" %>

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
    </script>
      <div class="row">
                        <div class="col-md-12">

                            <!-- START DEFAULT DATATABLE -->
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h2 class="panel-title"><b>Branch Management</b></h2>
                                    <ul class="panel-controls">
                                        <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span></a></li>
                                        <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>
                                        <li><a href="#" class="panel-remove"><span class="fa fa-times"></span></a></li>
                                    </ul>
                                    

                                    </div>
                                <div class="panel-body" style="overflow:scroll;">
                                    
        <asp:LinkButton ID="lbRemoveFilterBranch" runat="server" Text="Remove Filter"
            OnClick="lbRemoveFilterBranch_Click"></asp:LinkButton>
        <asp:UpdatePanel ID="upnlOutstanding" runat="server" ChildrenAsTriggers="true"  UpdateMode="Conditional">
            <ContentTemplate>
               
                <asp:GridView ID="grdBranch" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" CellPadding="5" ForeColor="Black"
                    GridLines="Both" AllowPaging="True" CellSpacing="1" 
                    CssClass="table" PageSize="10" AllowSorting="true" OnPageIndexChanging="grdBranch_PageIndexChanging"
                    OnRowDataBound="grdBranch_RowDataBound" OnSorting="grdBranch_Sorting" DataKeyNames="Id">
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" Visible="false" />
                        <asp:TemplateField SortExpression="Name">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnName" runat="server" Text="Name" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtName" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name")%>'></asp:Label>

                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="STName">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnSTName" runat="server" Text="STName" CommandName="Sort" CommandArgument="Order"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtSTName" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSTName" runat="server" Text='<%#Eval("STName")%>'></asp:Label>
                            </ItemTemplate>
                            <%--      <EditItemTemplate>
                                <asp:TextBox ID="txtSTName1" runat="server" Text='<%# Bind("STName") %>'> </asp:TextBox>  
                            </EditItemTemplate>--%>
                        </asp:TemplateField>

                        <asp:TemplateField SortExpression="Address1">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnAddress1" runat="server" Text="Address1" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtAddress1" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Address1")%>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Address2">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnAddress2" runat="server" Text="Address2" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtAddress2" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAddress2" runat="server" Text='<%#Eval("Address2")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Address3">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnAddress3" runat="server" Text="Address3" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtAddress3" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAddress3" runat="server" Text='<%#Eval("Address3")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Address4">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnAddress4" runat="server" Text="Address4" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtAddress4" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAddress4" runat="server" Text='<%#Eval("Address4")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField SortExpression="PhoneNo">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnPhoneNo" runat="server" Text="PhoneNo" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtPhoneNo" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPhoneNo" runat="server" Text='<%#Eval("PhoneNo")%>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Email">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnEmail" runat="server" Text="Email" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtEmail" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Prefix1">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnPrefix1" runat="server" Text="Prefix1" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtPrefix1" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPrefix1" runat="server" Text='<%#Eval("Prefix1")%>'></asp:Label>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Prefix2">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnPrefix2" runat="server" Text="Prefix2" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtPrefix2" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPrefix2" runat="server" Text='<%#Eval("Prefix2")%>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField SortExpression="GSTIN">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnGSTTN" runat="server" Text="GSTIN" CommandName="Sort" CommandArgument="Item"></asp:LinkButton>
                                <br />
                                <asp:TextBox runat="server" ID="txtGSTIN" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGSTIN" runat="server" Text='<%#Eval("GSTIN")%>'></asp:Label>

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
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" onclick="lnkDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this event?');"></asp:LinkButton>
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
                <asp:Button ID="btnAdd" runat="server" CssClass="btn-primary" Font-Size="14px" Text="Add" OnClick = "Add" />

                <asp:Panel ID="pnlAddEdit" runat="server" BackColor="White" Height="550px"
                    Width="400px" Style="z-index: 111; background-color: White; position: absolute; left: 35%; top: 12%; border: outset 2px gray; padding: 5px; display: none">
                    <table class="table" >
                         <tr style="background-color: #1D2127">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                                align="center">Branch Details
                            </td>
                        </tr>


                        <tr>
                            <td>Branch Name:
                            </td>
                            <td>
                                <asp:TextBox ID="pntxtID" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="PntxtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>STName:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtSTName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Address 1:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtAddress1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Address 2:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtAddress2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Address 3:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtAddress3" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Address 4:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtAddress4" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Phone No:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtPhoneNo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Email:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtEmail" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Prefix1:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtPrefix1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Prefix2:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtPrefix2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>GSTIN:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtGSTIN" runat="server" />
                            </td>
                        </tr>
                        <tr class="text-center">
                            <td colspan="2">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn-info" Font-Size="14px"  Text="Save" OnClick="Save" />&nbsp;&nbsp;  <asp:Button ID="btnCancel" CssClass="btn-primary" Font-Size="14px"  runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                            </td>
                            <td>
                                
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
                <asp:AsyncPostBackTrigger ControlID="grdBranch" />
                <asp:AsyncPostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
                                      </div>
                                </div>
                            </div>
         </div>
      <script>
        $(".x-navigation li").removeClass("active");
        $('#liBranchManagement').addClass('active');
    </script>
</asp:Content>