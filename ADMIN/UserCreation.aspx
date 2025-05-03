<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="UserCreation.aspx.cs" Inherits="WebApplication2.ADMIN.UserCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <link href="../Css/Mainmaster.css" rel="stylesheet" />
    <link href="../Css/Controll.css" rel="stylesheet" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <center>
    <table align="center" class="centered-table" >
        <panel>
        <tr>
            <td  colspan="2" align="center" >
                <asp:Label ID="lblHeading" CssClass="label-primary" runat="server" Text="USER CREATION" Font-Size="Larger" Font-Italic="false"></asp:Label>
            </td>
        
        </tr>
       
           <tr>
            <td >
                <asp:Label ID="lblUserId" runat="server" Text="User Id" ForeColor="White"  Font-Bold="true" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserId" runat="server" ></asp:TextBox>
            </td>
        
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblUserName" runat="server" Text="User Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserName"  runat="server" OnTextChanged="txtUserName_TextChanged" AutoPostBack ="true" ></asp:TextBox>
            </td>
        
        </tr>
         <tr>
            <td >
                <asp:Label ID="lblRole"  runat="server" Text="Select Role" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
             <td>
                <asp:DropDownList ID="ddlRole" runat="server" >             
                 </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td >
                <asp:Label ID="lblPassword" runat="server" Text="password" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword"  TextMode="Password" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rpassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                
            </td>
        
        </tr>
         <tr>
            <td >
                <asp:Label ID="lblCpassword" runat="server" Text="Confirm Password" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCpassword" TextMode="Password" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rcpassword" runat="server" ControlToValidate="txtCpassword" ErrorMessage="Enter CPassword" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmppassword" runat="server" ForeColor="#ffff00" Font-Size="Large" ControlToValidate="txtCpassword" ControlToCompare="txtPassword" ErrorMessage="Plzz Enter Correct CPassword"></asp:CompareValidator>
             </td>
        </tr>
         <tr>
            <td >
                <asp:Label ID="lblContactNumber" runat="server" Text="Phone Number" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhoneNumber" TextMode="Number" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$" ErrorMessage="Invalid phone number" ForeColor="#ffff00" Font-Size="Large"></asp:RegularExpressionValidator>
             </td>
        </tr>
         <tr>
            <td >
                <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Email" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rdtxtEmail"  ForeColor="#ffff00" Font-Size="Large" runat="server"  ControlToValidate="txtEmail"  ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"  ErrorMessage="Invalid email address" ></asp:RegularExpressionValidator>
             </td>
        </tr>
        <tr>    
             <td >
                <asp:Label ID="lblGender" runat="server" Text="Gender" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server">
                     <asp:ListItem Text="-- GENDER--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Male " Value="Male"></asp:ListItem>
                    <asp:ListItem Text=" Female" Value="Female"></asp:ListItem>                 

                </asp:DropDownList>
            </td>
                
                
        </tr>
        
                    <br>
        </br>
                    <br>
        </br>
 <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn-primary" OnClick="btnNew_Click"/>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-primary" OnClick="btnSave_Click"/>
                <%--<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-primary" OnClick="btnUpdate_Click" />--%>
                <asp:Button ID="buttonUpdate" runat="server" Text="Update" CssClass="btn-primary" OnClick="buttonUpdate_Click"/>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-primary" OnClick="btnDelete_Click"/>
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn-primary" OnClick="btnClose_Click" />
            </td>
        </tr> 

<tr>
        <td colspan="2">
              <asp:GridView ID="Gvtbl_UserCreation" runat="server" CellPadding="4" 
                  ForeColor="#333333" GridLines="None" 
                  onselectedindexchanged="Gvtbl_UserCreation_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
        </td>
       </tr>
  </table>
  </center>

</asp:Content>
