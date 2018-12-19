<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication1.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table1" runat="server">
                <tr>
                    <td>Name : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>UserName : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtUName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Branch : 
                    </td>
                    <td>
                        <asp:DropDownList ID ="ddlBranch" runat="server"></asp:DropDownList>
                    </td>
                 
                </tr>

                <tr>
                    <td>Role : 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRole" runat="server">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                            <asp:ListItem Selected="True">User</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>Permission:
                    </td>
                    <td>
                        <asp:CheckBoxList ID="cblPermissions" runat="server">
                            <asp:ListItem>Item </asp:ListItem>
                            <asp:ListItem>Branch </asp:ListItem>
                            <asp:ListItem>Vehicle </asp:ListItem>
                            <asp:ListItem>LREntry </asp:ListItem>
                            <asp:ListItem>LoadingSheet </asp:ListItem>
                            <asp:ListItem>Report1 </asp:ListItem>
                            <asp:ListItem>Report2 </asp:ListItem>
                            <asp:ListItem>Report3 </asp:ListItem>
                        </asp:CheckBoxList>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>


    </form>
</body>
</html>
