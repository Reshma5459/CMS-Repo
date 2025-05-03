<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true" CodeBehind="UserPermission.aspx.cs" Inherits="WebApplication2.ADMIN.UserPermission" %>
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
                <asp:Label ID="lblHeading" runat="server" Text="User Permission" CssClass="label-primary"
                    Font-Size="Larger"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRole" runat="server" Text="Role Name" ForeColor="White" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlRole" Width="100px" CssClass="dropdown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUserName" runat="server" Text="User Name" ForeColor="White"  Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlUserName" Width="100px" CssClass="dropdown" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td colspan="2">
                <asp:GridView ID="GvUserPermission" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRoleName" runat="server" Text='<%# Bind("RoleName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRoleName" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ScreenName">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtScreenName" runat="server" Text='<%# Bind("ScreenName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblScreenName" runat="server" Text='<%# Bind("ScreenName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is_Create">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIs_Create" Checked='<%# Eval("Is_Create") %>' runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckIs_Create" Checked='<%# Eval("Is_Create") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is_Edit">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIs_Edit" Checked='<%# Eval("Is_Update") %>' runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckIs_Edit" Checked='<%# Eval("Is_Update") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is_Delete">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIs_Delete" Checked='<%# Eval("Is_Delete") %>' runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckIs_Delete" Checked='<%# Eval("Is_Delete") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is_View">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIs_view" Checked='<%# Eval("Is_View") %>' runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckIs_View" Checked='<%# Eval("Is_View") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </td>
        </tr>
      
    </table>
</asp:Content>
