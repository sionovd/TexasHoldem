<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication7.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style7 {
            width: 94%;
            height: 145px;
        }
        .auto-style8 {
            color: #FFFFFF;
        }
        .auto-style9 {
            color: #FFFFFF;
            direction: ltr;
            width: 78px;
        }
        .auto-style12 {
            color: #FFFFFF;
            direction: ltr;
            height: 3px;
            width: 78px;
        }
        .auto-style13 {
            color: #FFFFFF;
            height: 3px;
        }
        .auto-style10 {
            color: #FFFFFF;
            direction: ltr;
            height: 1px;
            width: 78px;
        }
        .auto-style11 {
            color: #FFFFFF;
            height: 1px;
        }
        .auto-style14 {
            color: #FFFFFF;
            direction: ltr;
            width: 78px;
            height: 45px;
        }
        .auto-style15 {
            color: #FFFFFF;
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style7">
        <tr>
            <td class="auto-style14"></td>
            <td class="auto-style15"></td>
            <td class="auto-style15"></td>
        </tr>
        <tr>
            <td class="auto-style9">Login</td>
            <td class="auto-style8">
                <asp:Label ID="errorLogin" runat="server" ForeColor="Red" Text="* Please check again" Visible="False"></asp:Label>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12"></td>
            <td class="auto-style13"></td>
            <td class="auto-style13"></td>
        </tr>
        <tr>
            <td class="auto-style9">Username:</td>
            <td class="auto-style8">
                <asp:TextBox ID="username" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style11"></td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style9">Password:</td>
            <td class="auto-style8">
                <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style8">
                <asp:Button ID="Send_Button" runat="server" OnClick="Send_Button_Click" Text="SEND" />
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

