<%@ Page  Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication7.WelcomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
    <style type="text/css">
    .auto-style2 {
        width: 65%;
    }
    .auto-style3 {
        width: 656px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style2">
    <tr>
        <td class="auto-style3">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Welcome.png" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
