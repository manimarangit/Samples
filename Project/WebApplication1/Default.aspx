<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

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
    <div class="row">
					
					<div class="col-md-4"></div>
                        <div class="col-md-4">
                            <div class="page-title">                    
                    <h2><span class="fa fa-home" style="margin-left:20px;"></span> Parcel Service Portal</h2>
                </div>    
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title"><b>Login</b></h3>
                                </div>
                                <div class="panel-body" style="padding-left:10%; padding-right:10%">
<form >
  <div class="form-group">
    <label for="email"> <b>Email address:</b></label>
    <input type="email" class="form-control" id="email" runat="server">
  </div>
  <div class="form-group">
    <label for="pwd"><b>Password:</b></label>
    <input type="password" class="form-control" id="pwd"  runat="server">
  </div>
  <div class="checkbox">
    <label><input type="checkbox"> Remember me</label><br /><br />
    <label id="msgLbl" style="color:orangered;" runat="server"></label>
  </div>
  <asp:Button type="submit" class="btn btn-primary" id="btnSignIn" style="background-color:#1D2127; color:#fff;" Text="SignIn" runat="server" OnClick="btnSignIn_Click"></asp:Button>
    
</form>

                                </div>
                            </div>

                        </div>
						<div class="col-md-4"></div>
                    </div>
   
</asp:Content>