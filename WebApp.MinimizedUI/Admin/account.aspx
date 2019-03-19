<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="WebApp.MizimizedUI.Account" %>

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
        <asp:GridView ID="ManAccount" runat="server" CssClass="grid-style-wrapper" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Manager ID" DataField="ManagerId" ReadOnly="true" />
                <asp:BoundField HeaderText="Manager Name" DataField="ManagerName" ReadOnly="true" />
                <asp:BoundField HeaderText="Manager Surname" DataField="ManagerSurname" ReadOnly="true" />
                <asp:BoundField HeaderText="Manager Birth Date" DataField="ManagerBirthDate" ReadOnly="true" />
                <asp:BoundField HeaderText="Manager Address" DataField="ManagerAddress" ReadOnly="true" />
                <asp:BoundField HeaderText="Manager Phone" DataField="ManagerPhone" ReadOnly="true" />
                <asp:BoundField HeaderText="Manager E-Mail" DataField="ManagerMail" ReadOnly="true" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="inside">
        <table class="master_table">
            <tr>
                <td style="text-align: center">Update Manager
                </td>
            </tr>
            <tr>

                <td style="border: 1px solid black">
                    <table class="jumbo_table">
                        <tr>
                            <td>Attribute:  
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownAttrList" runat="server" OnSelectedIndexChanged="DropDownAttrList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                  
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
                    <asp:Button ID="UpdateButton" runat="server" Text="Update" align="Center" OnClick="UpdateButton_Click" />
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
