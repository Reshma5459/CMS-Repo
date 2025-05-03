<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="WebApplication2.TRANSACTIONS.PaymentProcessing" %>

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
            <td colspan="4" align="center">
                <asp:Label ID="lblHeading" runat="server" Text="Transaction Details" CssClass="label-primary" Font-Size="X-Large" Font-Italic="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTransactionId" runat="server" align="right" Text="Transaction Id" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTransaction_Id" runat="server" CssClass="Textbox" OnTextChanged="txtTransaction_Id_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblCustomerId" runat="server" Text="Customer Id" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomerId" runat="server" OnTextChanged="txtCustomerId_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCustomer_Name" runat="server" Text="Customer Name" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCustomer_Name" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblBookingId" runat="server" Text="Booking Id" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBookingId" runat="server" OnTextChanged="txtBookingId_TextChanged" AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAmount" runat="server" Text=" Payment Amount " ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPaymentAmount" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblPaymentMethod" runat="server" Text=" Payment Method " ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPaymentMethod" runat="server">
                    <asp:ListItem Text="-- Select Payment Method --" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Online Payment" Value="1"></asp:ListItem>
                    <asp:ListItem Text=" Cash Payment" Value="2"></asp:ListItem>
                    <asp:ListItem Text=" check Payment" Value="3"></asp:ListItem>
                    <asp:ListItem Text=" DD Payment" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBankName" runat="server" Text=" Bank Name" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBank_Name" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAccount_Number" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPaymentDate" runat="server" Text=" Payment Date " ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPaymentDate" TextMode ="Date" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblCard_Type" runat="server" Text="Card Type" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>

                <asp:DropDownList ID="ddlCard_Type" runat="server">
                    <asp:ListItem Text="-- Select Card Type --" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Credit Card" Value="1"></asp:ListItem>
                    <asp:ListItem Text=" Debit Card" Value="2"></asp:ListItem>
                    <asp:ListItem Text=" NULL" Value="3"></asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCard_Number" runat="server" Text="Card Number" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCard_Number" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblCard_Holder" runat="server" Text="Card Holder" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCard_Holder" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnNew" runat="server" Text="New" Width="63px" OnClick="btnNew_Click" />
                <asp:Button ID="btnPay" runat="server" Text="Pay" Width="63px" OnClick="btnPay_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="76px" OnClick="btnDelete_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="76px" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:GridView ID="Gvtbl_TransactionDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="Gvtbl_TransactionDetails_SelectedIndexChanged">
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
