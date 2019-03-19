<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="officemanagement.aspx.cs" Inherits="WebApp.MizimizedUI.Admin.officemanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 0px auto">
        <div class="inside">
            <p style="text-align:center">Office Informations</p>
            <div style="margin:0px auto; margin-bottom: 30px">
                 <asp:GridView runat="server" ID="GridOfficeInfo" CssClass="grid-style-wrapper"></asp:GridView>
            </div>
            <div>
                <table style="border:1px solid black; margin:0px auto">
                    <tr>
                        <td>
                            <div>
                                <table>
                                    <tr>
                                        <th colspan="2" style="text-align:center">
                                            Add Office
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            OfficeID:
                                        </td>
                                        <td>
                                            
                                            <asp:TextBox runat="server" ID="TextBoxAddOfficeID" TextMode="Number" placeholder="Office ID"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddOfficeID" ValidationGroup="Add" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Name
                                        </td>
                                        <td>
                                            
                                            <asp:TextBox runat="server" ID="TextBoxOfficeName" placeholder="Office Name" ></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxOfficeName" ErrorMessage="*" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address
                                        </td>
                                        <td>                                           
                                            <asp:TextBox runat="server" ID="TextBoxOfficeAddress" placeholder="Office Address" ></asp:TextBox>                                          
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxOfficeAddress" ErrorMessage="*" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button runat="server" ID="ButtonAddOffice" Text="Add Office" Width="100%" ValidationGroup="Add" OnClick="ButtonAddOffice_Click"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label runat="server" Visible="false" ID="LabelResultAddOffice" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <div>
                                <table>
                                    <tr>
                                        <th colspan="2">
                                            Update Office
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            Office ID:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TextBoxUpdateOfficeID"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxUpdateOfficeID" ErrorMessage="*" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Attribute:
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="DropDownAttrList">
                                                <asp:ListItem Text="Name" Value="name">Name</asp:ListItem>
                                                <asp:ListItem Text="Address" Value="address">Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            NewData:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TextBoxNewData"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxNewData" ErrorMessage="*" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button runat="server" ID="ButtonUpdateOffice" Text="Update Office" Width="100%" ValidationGroup="Update" OnClick="ButtonUpdateOffice_Click"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label runat="server" ID="LabelUpdateResult" Visible="false" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <div>
                                <table>
                                    <tr>
                                        <th colspan="2">
                                            Delete Office
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            Office ID:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TextBoxDeleteOfficeID"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxDeleteOfficeID" ErrorMessage="*" ValidationGroup="Delete"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button runat="server" ID="ButtonDeleteOffice" Text="Delete Office" Width="100%" ValidationGroup="Delete" OnClick="ButtonDeleteOffice_Click"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label runat="server" ID="LabelDeleteResult" Text="" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </div>
</asp:Content>
