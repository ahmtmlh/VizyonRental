<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="management.aspx.cs" Inherits="WebApp.MizimizedUI.Admin.management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 0px auto">
        <div class ="inside">
            <ul>
                <li><a href="Logs.aspx">LOGS</a></li>
                <li><a href="managercontrol.aspx">MANAGER CONTROL</a></li>
                <li><a href="officemanagement.aspx">OFFICES</a></li>
                <li><a href ="vehiclemanagement.aspx">VEHICLES</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
