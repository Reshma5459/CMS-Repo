<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="WebApplication2.MASTER.Role" %>
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
            <td>
                <asp:Label ID="lblRole_Id" runat="server" Text="Role Id" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRole_Id" runat="server" OnTextChanged="txtRoleId_TextChanged" AutoPostBack ="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRole_Name" runat="server" Text="Role Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRole_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblIsActive" runat="server" Text="IsActive" ForeColor="White"  Font-Bold="true"></asp:Label>
          </td>
          <td>
       
                <asp:CheckBox ID="chkIsActive" runat="server" Text="Is_Active" ForeColor="White"  Font-Bold="true" />
            </td>
        </tr>
       
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn-primary" OnClick="btnNew_Click"/>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-primary" OnClick="btnSave_Click"/>
                <asp:Button ID="buttonUpdate" runat="server" Text="Update" CssClass="btn-primary" OnClick="buttonUpdate_Click"/>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-primary" OnClick="btnDelete_Click"/>
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn-primary" OnClick="btnClose_Click" />
            </td>
        </tr> 
         <tr>
        <td colspan="2">
              <asp:GridView ID="Gvtbl_Role" runat="server" CellPadding="4" 
                  ForeColor="#333333" GridLines="None" 
                  onselectedindexchanged="Gvtbl_Role_SelectedIndexChanged">
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
