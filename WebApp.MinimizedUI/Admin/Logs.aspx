<%@ Page Title="Vision Car Rental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="WebApp.MizimizedUI.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%=TextResDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy",
                yearRange: '1960:2018'
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="inside">
        <p style="text-align:left"> Reservation Informations</p>
        <div class="grid-style-wrapper">
            <asp:GridView runat="server" ID="reserveView"></asp:GridView>
        </div>
        <div style="margin:6px -1px">
            <table style="border:1px double black">
                <tr>
                    <td>Id:                             
                    </td>
                    <td>
                        <asp:TextBox ID="TextResID" runat="server" CssClass="auto-style6" Width="134px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Date: 
                                
                    </td>
                    <td>
                        <asp:TextBox ID="TextResDate" runat="server" Width="132px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="resDel" runat="server" Text="Delete Reservation" Width="100%" CausesValidation="false" OnClick="resDel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="LabelDeleteReservationResult" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="inside">
        <p style="text-align:left">Rent Informations</p>
        <div class="grid-style-wrapper">
            <asp:GridView runat="server" ID="rentView"></asp:GridView>
        </div>
        <div style="margin: 6px -1px">
            <table style="border:1px double black">
                <tr>
                    <td colspan="2">
                        Delete Rent
                    </td>
                </tr>
                <tr>
                    <td>Id:          
                    </td>
                    <td>
                        <asp:TextBox ID="TextRentID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="delRent" runat="server" Text="Delete Rent" Width="100%" CausesValidation="false" OnClick="delRent_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="LabelDeleteRentResult" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

    </div>
    <div class="inside">
        <p>Bill Informations</p>
        <div class="grid-style-wrapper">
            <asp:GridView runat="server" ID="GridViewBill"></asp:GridView>
        </div>
    </div>
    <div class="inside">
        <p>Manager Informations</p>
        <div class="grid-style-wrapper">
            <asp:GridView runat="server" ID="GridManagerInfo"></asp:GridView>
        </div>
    </div>
    <div class="inside">
        <p style="text-align:left">Customer Informations</p>
        <div class ="grid-style-wrapper">
            <asp:GridView runat="server" ID="GridViewCustomers"></asp:GridView>
        </div>     
        <div style="margin:6px -1px">
            <table style="border:1px double black">
                <tr>
                    <td colspan="2"">
                        Delete Customer
                    </td>
                </tr>
                <tr>
                    <td>
                        ID: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxCustomerID" placeholder="CustomerID"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="ButtonDeleteCustomer" Text="Delete Customer" Width="100%" OnClick="ButtonDeleteCustomer_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="LabelDeleteResult" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>