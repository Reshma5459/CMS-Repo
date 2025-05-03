<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="CustomerDetailsReport.aspx.cs" Inherits="WebApplication2.REPORTS.CustomerDetailsReport" %>
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
            <td  colspan="2" align="center" >
                <asp:Label ID="lblHeading" CssClass="label-primary" runat="server" Text="USER DETAILS REPORT" Font-Size="Larger" Font-Italic="false"></asp:Label>
            </td>
        
        </tr>
       
           <tr>
            <td >
                <asp:Label ID="lblCustomerId" runat="server" Text="Customer Id1" ForeColor="White"  Font-Bold="true" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomer_Id1" runat="server"  ></asp:TextBox>
            </td>
            <td >
                <asp:Label ID="lblCustomerId2" runat="server" Text="Customer Id2" ForeColor="White"  Font-Bold="true" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomer_Id2"  runat="server"  ></asp:TextBox>
            </td>
        
        </tr>
       
        <tr>
             <td  colspan="2" align="center">
                  <asp:GridView ID="GvCustomerReport" runat="server" CellPadding="4" 
                      ForeColor="#333333" GridLines="None" 
                      onselectedindexchanged="GvCustomerReport_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" />
                   
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
         <tr>
             <td colspan ="2">
                 <asp:Button ID="btnGetdata" runat ="server" Text="GetData" OnClick="btnGetdata_Click" />
                 <asp:Button ID="btnReport" runat ="server" Text="Generate Report" OnClick="btnReport_Click" />
             </td>
         </tr>
    
    </table>
</asp:Content>
