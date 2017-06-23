<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StatisticsPage.aspx.cs" Inherits="WebApplication7.StatisticsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        width: 100%;
    }
    .auto-style4 {
        color: #FFFFFF;
    }
    .auto-style5 {
        color: #FFFFFF;
        height: 18px;
    }
    .auto-style6 {
        color: #FFFFFF;
        width: 336px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style3">
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4" colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>STATISTICS</strong>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4" colspan="3">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Points</td>
        <td class="auto-style4">
            <asp:Label ID="pointsLabel" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Number of games</td>
        <td class="auto-style4">
            <asp:Label ID="numberOfGamesLabel" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Total profit</td>
        <td class="auto-style4">
            <asp:Label ID="totalProfitLabel" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Highest cash gain</td>
        <td class="auto-style4">
            <asp:Label ID="HighestCashGainLabel" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Averege profit</td>
        <td class="auto-style4">
            <asp:Label ID="AverageProfitLabel" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Averegae cash gain</td>
        <td class="auto-style4">
            <asp:Label ID="AverageCashGainLabel" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
    </tr>
</table>
</asp:Content>
