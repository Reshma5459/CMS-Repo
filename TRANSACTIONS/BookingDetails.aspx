<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="BookingDetails.aspx.cs" Inherits="WebApplication2.TRANSACTIONS.BookingDetails" %>
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
                <asp:Label ID="lblHeading" runat="server" Text="Bookings" CssClass="label-primary" Font-Size="Larger" Font-Italic="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBookingId" runat="server" Text="Booking Id" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
           
                <asp:TextBox ID="txtBookingId" runat="server" OnTextChanged="txtBookingId_TextChanged" AutoPostBack ="true"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rBookingId" runat="server" ControlToValidate="txtBookingId" ErrorMessage="Enter Booking Id" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCustomerId" runat="server" Text="Customer Id" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
           
                <asp:TextBox ID="txtCustomerId" runat="server" OnTextChanged="txtCustomerId_TextChanged" AutoPostBack ="true"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerId" ErrorMessage="Enter Customer Id" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                
                
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblCustomer_Name" runat="server" Text="Customer Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
            
                <asp:TextBox ID="txtCustomer_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblEvent_Name" runat="server" Text=" Event Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
            
                <asp:TextBox ID="txtEvent_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblBooking_Date" runat="server" Text="Booking Date" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
            
                <asp:TextBox ID="txtBooking_Date" TextMode="Date" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBooking_Date" ErrorMessage="Enter Booking Date" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                
                
            </td>
        </tr>
        <tr>
            
            <td>
                <asp:Label ID="lblStartTime" runat="server" Text="Start Time" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="txtStartTime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEndTime" runat="server" Text="End Time" ForeColor="White"  Font-Bold="true"></asp:Label>
             </td>
             <td>

                <asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Booking Status" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
            
                <asp:CheckBox ID="chkStatus" runat="server" Text="Is_Active" ForeColor="White"  Font-Bold="true"/>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="lblPaymentAmount" runat="server" Text="Payment Amount" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
            
                 <asp:TextBox ID="txtPaymentAmount" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPaymentAmount" ErrorMessage="Enter Payment Amount" ForeColor="#ffff00" Font-Size="Large"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
         <tr>
            <td>
                 <asp:Label ID="lblPaymentMethod" runat="server" Text=" Payment Method" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPaymentMethod" runat="server">
                    <asp:ListItem Text="-- PAYMENT METHOD--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Cash" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Credit Card " Value="Male"></asp:ListItem>
                    <asp:ListItem Text=" Debit Card" Value="Female"></asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>

        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btn-primary" OnClick="btnNew_Click"/>
                <asp:Button ID="btnSave" runat="server" Text="Save&Continue" CssClass="btn-primary" OnClick="btnSave_Click"/>
                <asp:Button ID="buttonUpdate" runat="server" Text="Update" CssClass="btn-primary" OnClick="buttonUpdate_Click"/>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-primary" OnClick="btnDelete_Click"/>
                <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="btn-primary" OnClick="btnContinue_Click"/>
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn-primary" OnClick="btnClose_Click" />
            </td>
        </tr>
         <tr>
        <td colspan="2">
              <asp:GridView ID="Gvtbl_BookingDetails" runat="server" CellPadding="4" 
                  ForeColor="#333333" GridLines="None" 
                  onselectedindexchanged="Gvtbl_BookingDetails_SelectedIndexChanged">
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
