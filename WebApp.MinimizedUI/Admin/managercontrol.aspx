<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="managercontrol.aspx.cs" Inherits="WebApp.MizimizedUI.Admin.managercontrol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css"/>
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%=TextBoxBirthDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy",
                yearRange: '1950:2018'
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 0px auto">
        <div class="inside">
            <p style="text-align:left">Register New Manager</p>
            <table class="jumbo_table">
                <tr>
                    <td>Name:* 
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Surname:* 
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxSurname"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>BirthDate:*
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxBirthDate" TextMode="DateTime"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxBirthDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Address:*  
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxAddr" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddr"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Phone Number:*  
                    </td>
                    <td>
                        <asp:TextBox ID="PhoneNumberBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumberBox"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>E-Mail:*  
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxMail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxMail"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Username:*
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxUsername" ></asp:TextBox>
                        ,<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxUsername"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password:*
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxPassword" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" Text="Register Manager" ID="ButtonManagerRegister" OnClick="ButtonManagerRegister_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" Text="" ID="LabelResult"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
