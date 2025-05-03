<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="SignUpfrm.aspx.cs" Inherits="WebApplication2.SignUpfrm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Css/Mainmaster.css" rel="stylesheet" />
    <link href="../Css/Controll.css" rel="stylesheet" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/styles.css" rel="stylesheet" type="text/css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <table align="center" class="centered-table">
        
        <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblHeading" Text="Registration" runat="server" CssClass="label-primary"  Font-Size="Larger"  > </asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUserID" Text="User ID:" runat="server" CssClass="Label"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserID" runat="server" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ControlToValidate="txtUserName" ErrorMessage="Required">   
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUserName" Text="User Name:" runat="server" CssClass="Label"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"  AutoPostBack="true" OnTextChanged="txtUserName_TextChanged"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtUserName" ErrorMessage="Required">   
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMobileNo" Text="Mobile Number:" runat="server" CssClass="Label"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobileNumber" runat="server"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Required">   
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEMail" Text="E-Mail:" runat="server" CssClass="Label"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEMail" runat="server" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ControlToValidate="txtEMail" ErrorMessage="Required">   
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" Text="Password:" runat="server" CssClass="Label"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ControlToValidate="txtPassword" ErrorMessage="Required">   
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblConfirmPassword" Text="Confirm Password:" runat="server" CssClass="Label"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" > </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Required">   
                    </asp:RequiredFieldValidator>
                </td>
            </tr>




            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn-primary" OnClick="btnNew_Click" CausesValidation="false"></asp:Button>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-primary" OnClick="btnRegister_Click" CausesValidation="true"></asp:Button>
                    <asp:Button ID="btnLogin" runat="server" Text="GoTo Login" CssClass="btn-primary" OnClick="btnLogin_Click" CausesValidation="false"></asp:Button>
                    <asp:Button ID="btnHome" runat="server" Text="Home" CssClass="btn-primary" OnClick="btnHome_Click" CausesValidation="false"></asp:Button>


                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>


    </table>
</asp:Content>
