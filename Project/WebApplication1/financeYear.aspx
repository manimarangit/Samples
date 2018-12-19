<%@ Page Title="Finance Year" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="financeYear.aspx.cs" Inherits="WebApplication1.financeYear" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script>
        (function () {
            
            $('#liVehcicle').hide();
            $('#liItemization').hide();
            $('#liBranchManagement').hide();
            $('#liLogOut').hide();
        })();
</script>

    <div class="widget" style="background-color:#EFEEEE !important; color:#1D2127;box-shadow:none; padding:0px 10px 0px 10px; margin:0px;height:60px;">
                                <div class="widget-big-int plugin-clock">20<span>:</span>36</div>                            
                                <div class="widget-subtitle plugin-date" style="color:#1D2127;">Sunday, October 28, 2018</div>
                                                          
                            </div>
    <div class="row" id="financeYrContainer" runat="server">
					
					<div class="col-md-4"></div>
                        <div class="col-md-4">
                            <div class="page-title">                    
                    
                </div>    
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title"><b>Finance Year - Selection</b></h3>
                                </div>
                                <div class="panel-body" style="padding:0px; margin:0px; background-color:#EFEEEE">

                                    <div class="tile tile-success tile-valign"><span class="fa fa-calendar"></span>
                                        <div class="form-group">
                                        <button type="button" class="btn btn-lg btn-primary btn-rounded"  onclick="location.href = 'vehicle.aspx';">2018</button>
                                        <button type="button" class="btn btn-lg btn-default  btn-rounded">2017</button>
                                        <button type="button" class="btn  btn-lg btn-default btn-rounded">2016</button>
                                       
                                    </div>

                                    </div>

                                    
                                </div>
                            </div>

                        </div>
						<div class="col-md-4"></div>
                    </div>

    <div class="row" id="changePwdContainer" runat="server">
					
					<div class="col-md-4"></div>
                        <div class="col-md-4">
                            <div class="page-title">                    
                    
                </div>    
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title"><b>Password Change</b></h3>
                                </div>
                                <div class="panel-body" style="padding:0px; margin:0px; background-color:#EFEEEE">

                                  <table class="table" >
                         <tr style="background-color: #1D2127">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                                align="center">
                            </td>
                        </tr>


                        <tr>
                            <td>New Password:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword"  TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Confirm Password:
                            </td>
                            <td>
                               <asp:TextBox ID="txtConfirmPassword"  TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                       <tr class="text-center">
                            <td colspan="2">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn-info" Font-Size="14px"  Text="Update" OnClick="btnSave_Click" />&nbsp;&nbsp;  <asp:Button ID="btnCancel" CssClass="btn-primary" Font-Size="14px"  runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                       
                    </table>

                                    
                                </div>
                            </div>

                        </div>
						<div class="col-md-4"></div>
                    </div>
   
</asp:Content>
