<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="WebApp.MizimizedUI.CustAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%=TextBoxBirthDate.ClientID %>").datepicker({
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
        <asp:GridView ID="CstAccount" runat="server" CssClass="grid-style-wrapper" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" ReadOnly="true" />
                <asp:BoundField HeaderText="Customer Surname" DataField="CustomerSurname" ReadOnly="true" />
                <asp:BoundField HeaderText="Customer Birth Date" DataField="CustomerBirthDay" ReadOnly="true" />
                <asp:BoundField HeaderText="Customer Address" DataField="CustomerAddress" ReadOnly="true" />
                <asp:BoundField HeaderText="Customer Phone" DataField="CustomerPhone" ReadOnly="true" />
                <asp:BoundField HeaderText="Customer E-Mail" DataField="CustomerMail" ReadOnly="true" />
            </Columns>
        </asp:GridView>

    </div>
    <div class="inside">
        <table class="master_table">
            <tr>
                <td style="text-align: center">Update Customer
                </td>
            </tr>
            <tr>

                <td style="border: 1px solid black">
                    <table class="jumbo_table">
                        <tr>
                            <td>Attribute:  
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownAttrList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownAttrList_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>New Data:  
                            </td>
                            <td>
                                <asp:Panel runat="server" ID="NormalData" Visible="true">
                                    <asp:TextBox ID="TextBoxNewData" runat="server" Visible="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxNewData" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="DateData" Visible="false">
                                    <asp:TextBox runat="server" ID="TextBoxBirthDate" TextMode="DateTime"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxBirthDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </asp:Panel>
                            </td>
                        </tr>

                    </table>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Update" align="Center" CssClass="auto-style1" Width="149px" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
               <td>
                   <asp:Label runat="server" ID="ResultLabelUpdate" Text="" text-align="center" Visible="false"></asp:Label>
               </td> 
            </tr>

        </table>
    </div>
    <div class="row">
    </div>

</asp:Content>
