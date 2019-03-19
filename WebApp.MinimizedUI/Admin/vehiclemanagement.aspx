<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="vehiclemanagement.aspx.cs" Inherits="WebApp.MizimizedUI.Admin.addvehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 0px auto">
        <div class="inside">
            <table>
                <tr>
                    <th>
                        REFRESH VEHICLES
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="ButtonRefresh" CausesValidation="false" Text="Refesh Vehicles" OnClick="ButtonRefresh_Click"/>
                    </td>          
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="LabelRefreshResult" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="inside">
            <table>
                <tr>
                    <th colspan="2">
                        ADD VEHICLE
                    </th>
                </tr>
                <tr>
                    <td>
                        Vehicle Brand: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxVehicleBrand" placeholder="Vehicle Brand"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxVehicleBrand" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Vehicle Model:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxVehicleModel" placeholder="Vehicle Model"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxVehicleModel" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Vehicle ID:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxVehicleID" placeholder="Vehicle ID" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxVehicleID" ErrorMessage="Please enter ID"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Economy (L/100Km):
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxEconomy" placeholder="Economy"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEconomy" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Price Per Day: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxPrice" placeholder="Price" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPrice" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Production Year:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxProductionYear" placeholder="Production Year" TextMode="Number"></asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="TextBoxProductionYear" MinimumValue="1950" MaximumValue="2019" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tier:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="DropDownTier">
                            <asp:ListItem>Please Select</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>D</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownTier" InitialValue="Please Select" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Type:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="DropDownType">
                             <asp:ListItem>Please Select</asp:ListItem>
                             <asp:ListItem>Hypercar</asp:ListItem>
                             <asp:ListItem>Sport</asp:ListItem>
                             <asp:ListItem>Sedan</asp:ListItem>
                             <asp:ListItem>Hatchback</asp:ListItem>
                             <asp:ListItem>SUV</asp:ListItem>
                             <asp:ListItem>Minivan</asp:ListItem>
                             <asp:ListItem>Minibus</asp:ListItem>
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownType" InitialValue="Please Select" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Size:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxSize" placeholder="Size" TextMode="Number" MaxLength="1"></asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="TextBoxSize" MinimumValue="2" MaximumValue="8" Type="Integer" ErrorMessage="*"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Color:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TextBoxColor" placeholder="Color"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxColor" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Office:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="DropDownOfficeID"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Image Source:
                    </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBoxFile" TextMode="Url" MaxLength="250"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFile" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label runat="server" ID="LabelResult" Text=""></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Button runat="server" ID="ButtonInsertVehicle" Text="InsertVehicle" OnClick="ButtonInsertVehicle_Click"/>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
