<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="MembershipTypeDetails.aspx.cs" Inherits="WebApplication2.MASTER.MembershipTypeDetails" %>
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
            <td align="center" colspan="2">
                <asp:Label ID="lblHeading" runat="server" Text="Membership Type Details" CssClass="label-primary" Font-Italic="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblId" runat="server" Text="Membership Id" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMembership_Id" runat="server" OnTextChanged="txtMembership_Id_TextChanged" AutoPostBack ="true"></asp:TextBox>
            </td>
      </tr>
      <tr>
        <td>
            <asp:Label ID="lblType" runat="server" Text="Membership Type" ForeColor="White"  Font-Bold="true"></asp:Label>
        </td>
        <td>
             <asp:DropDownList ID="ddlMembership_Type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMembership_Type_SelectedIndexChanged">
                     <asp:ListItem Text="-- Select Type--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Basic Type " Value="1"></asp:ListItem>
                    <asp:ListItem Text="Premium Type " Value="2"></asp:ListItem>
                   
                </asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td>
            <asp:Label ID="lblFees" runat="server" Text="Fees" ForeColor="White"  Font-Bold="true"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txtFees"  runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td>
            <asp:Label ID="lblBenefits" runat="server" Text="Benefits" ForeColor="White"  Font-Bold="true"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txtBenefits" TextMode="MultiLine"  runat="server"> </asp:TextBox>
        </td>
      </tr>
      <tr>
        <td>
             <asp:Label ID="lblMembership_Status" runat="server" Text="Membership Status" ForeColor="White"  Font-Bold="true"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkMembership_Status" runat="server" Text="Membership Status" ForeColor="White"  Font-Bold="true" />
        </td>
      </tr>
      <tr>
       <td align="center" colspan="2">
                 
            
                <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn-primary" OnClick="btnNew_Click"/>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-primary" OnClick="btnSave_Click"/>
                <asp:Button ID="buttonUpdate" runat="server" Text="Update" CssClass="btn-primary" OnClick="buttonUpdate_Click"/>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-primary" OnClick="btnDelete_Click"/>
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn-primary" OnClick="btnClose_Click" />
            
            </td>
      </tr>
       <tr>
        <td colspan="2">
              <asp:GridView ID="Gvtbl_MembershipTypeDetails" runat="server" CellPadding="4" 
                  ForeColor="#333333" GridLines="None" 
                  onselectedindexchanged="Gvtbl_MembershipTypeDetails_SelectedIndexChanged">
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
