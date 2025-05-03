<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="FacilityTypeDetails.aspx.cs" Inherits="WebApplication2.MASTER.FacilityTypeDetails" %>
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
            <asp:Label ID="lblHeading" runat="server" Text="Facility Details" CssClass="label-primary" Font-Italic="true"></asp:Label>
        </td>
    </tr>
        <tr>
            <td>
                <asp:Label ID="lblFacilityId" runat="server" Text="Facility Id" OnTextChanged="txtFacilityId_TextChanged" AutoPostBack ="true" ForeColor="White"  Font-Bold="true"></asp:Label>
            
            </td>
            <td>
                <asp:TextBox ID="txtFacilityId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFacilityName" runat="server" Text="Facility Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFacility" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFacility_SelectedIndexChanged">
                     <asp:ListItem Text="-- Select Facility--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Banquet Hall " Value="1"></asp:ListItem>
                    <asp:ListItem Text="Conference Room " Value="2"></asp:ListItem>
                    <asp:ListItem Text="Library " Value="3"></asp:ListItem>
                   
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" Text="Description" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                 <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAvailable" runat="server" Text="Available" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
              
                <asp:RadioButton ID="rdoYes" runat="server" Text="Yes" ForeColor="White"  Font-Bold="true" />
                <asp:RadioButton ID="rdoNo" runat="server" Text="No"  ForeColor="White"  Font-Bold="true"/>
          
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
              <asp:GridView ID="Gvtbl_FacilityTypeDetails" runat="server" CellPadding="4" 
                  ForeColor="#333333" GridLines="None" 
                  onselectedindexchanged="Gvtbl_FacilityTypeDetails_SelectedIndexChanged">
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
