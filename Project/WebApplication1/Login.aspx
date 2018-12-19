<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/CSS.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
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

            BlockUI("<%=pnlReset.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function Hidepopup() {
            $find("popup").hide();
            return false;
        }
    </script>
</head>
<body>
   
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="upnlLogin" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                  <table>
            <tr>
                <td>
                    UserName: 
                </td>
                <td>
                    "<asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password: 
                </td>
                <td>
                    "<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   
                    <asp:Button ID="btnLogin" runat="server" Text="Login"  OnClick="btnLogin_Click"/>
                </td>
                <td>
                   
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
      
                   <asp:Panel ID="pnlReset" runat="server" BackColor="White" Height="400px"
                    Width="300px" Style="z-index: 111; background-color: White; position: absolute; left: 35%; top: 12%; border: outset 2px gray; padding: 5px; display: none">
                    <table style="width: 100%; height: 100%;" >
                        <tr style="background-color: #0924BC">
                            <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                                align="center">Reset Password <a id="closebtn" style="color: white; float: right; text-decoration: none" class="btnClose" href="#">X</a>
                            </td>
                        </tr>

                        >

                        <tr>
                            <td align="right">Password
                            </td>
                            <td>
                                <asp:TextBox ID="pntxtID" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="PntxtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Password Again:
                            </td>
                            <td>
                                <asp:TextBox ID="PntxtPasswordAgain" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>           

                        <tr>
                            <td>
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="Save" />
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Cancel" OnClientClick="return Hidepopup()" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
                    PopupControlID="pnlReset" TargetControlID="lnkFake"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                   </ContentTemplate>
                </asp:UpdatePanel>
             
    </form>
</body>
</html>
