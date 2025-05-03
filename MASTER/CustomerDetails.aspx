<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="CustomerDetails.aspx.cs" Inherits="WebApplication2.MASTER.CustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Css/Mainmaster.css" rel="stylesheet" />
    <link href="../Css/Controll.css" rel="stylesheet" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <table align="center" class="centered-table">
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblHeading" runat="server" CssClass="label-primary" Text="Customer Details"
                    Font-Size="Larger"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCustomerId" runat="server" Text="Customer Id" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomerId" runat="server" OnTextChanged="txtCustomerId_TextChanged" AutoPostBack="true"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rCustomerId" runat="server" ControlToValidate="txtCustomerId" ErrorMessage="Enter Customer Id" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCustomerName" ErrorMessage="Enter Customer Name" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDate_Of_Birth" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblGender" runat="server" Text="Gender" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:RadioButton ID="rdoMale" runat="server" GroupName="rdogender" Text="Male" ForeColor="White"  Font-Bold="true" />
                <asp:RadioButton ID="rdoFemale" runat="server" GroupName="rdogender" Text="Female" ForeColor="White"  Font-Bold="true" />
                 
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text="Phone Number" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$" ErrorMessage="Invalid phone number" ForeColor="#ffff00" Font-Size="Large"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"  ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Email" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rdtxtEmail"  ForeColor="#ffff00" Font-Size="Large" runat="server"  ControlToValidate="txtEmail"  ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"  ErrorMessage="Invalid email address" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="Address" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEventName" runat="server" Text="Event Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlEvent_Name" runat="server">
                    <asp:ListItem Text="-- Select Events--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Cultural Events " Value="1"></asp:ListItem>
                    <asp:ListItem Text="Social Events " Value="2"></asp:ListItem>
                    <asp:ListItem Text="Meetings " Value="3"></asp:ListItem>
                    <asp:ListItem Text="Seminars " Value="4"></asp:ListItem>
                    <asp:ListItem Text="Conference " Value="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFacility" runat="server" Text="Facility Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFacility_Name" runat="server">
                    <asp:ListItem Text="-- Select Facility--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Banquet Hall " Value="1"></asp:ListItem>
                    <asp:ListItem Text="Conference Room " Value="2"></asp:ListItem>
                    <asp:ListItem Text="Library " Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMembershipType" runat="server" Text="Membership Type" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMembership_Type" runat="server">
                    <asp:ListItem Text="-- Select Type--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Basic Type " Value="1"></asp:ListItem>
                    <asp:ListItem Text="Premium Type " Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMembershipStatus" runat="server" Text="Membership Status" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkMembershipStatus" runat="server" Text="Is_Active" ForeColor="White"  Font-Bold="true" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn-primary" Width="78px"
                    OnClick="btnNew_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Save&Book" CssClass="btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="buttonUpdate" runat="server" Text="Update" CssClass="btn-primary"
                    OnClick="buttonUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-primary" OnClick="btnDelete_Click" />
                
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn-primary" OnClick="btnClose_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="Gvtbl_CustomerDetails" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnSelectedIndexChanged="Gvtbl_CustomerDetails_SelectedIndexChanged1">
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
</asp:Content>
