<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="WebApplication2.frmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <link href="../Css/Mainmaster.css" rel="stylesheet" />
        <link href="../Css/Controll.css" rel="stylesheet" />
        <link href="../Css/styles.css" rel="stylesheet" type="text/css" />
        <link href="../Css/bootstrap.min.css" rel="stylesheet" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <table align="center"  class ="centered-table" style="margin-top:300px"  >
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblHeading" CssClass="label-primary" runat="server" Text="LOGIN" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text="User Name" ForeColor="White" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rusername" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter User Name" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="White" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rpassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnOk" CssClass="btn-primary" runat="server" Text="Login" OnClick="btnOk_Click" />
                    <asp:Button ID="btnSignUp" CssClass="btn-primary" runat="server" Text="SignUp" OnClick="btnSignUp_Click" />
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/SignUpfrm.aspx" ForeColor="White" runat="server">forgot password</asp:HyperLink>
                </td>
            </tr>

        </table>

    </form>

</body>
</html>
