<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="FacilityReport.aspx.cs" Inherits="WebApplication2.REPORTS.FacilityReport" %>
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
                <asp:Label ID="lblHeading" runat="server" Text="Facility Report" CssClass="label-primary" Font-Size="Larger" Font-Italic="false"></asp:Label>

            </td>

        </tr>
    <tr>
         <td>
                <asp:Label ID="lblId" runat="server" Text="Facility Id"  ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFacility_Id" runat="server" ></asp:TextBox>
            </td>
    </tr>
      <tr>
             <td  colspan="2" align="center">
                  <asp:GridView ID="GvFacilityReport" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
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
