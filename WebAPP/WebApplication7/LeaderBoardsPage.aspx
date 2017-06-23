<%@ Page Async="true"  Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LeaderBoardsPage.aspx.cs" Inherits="WebApplication7.LeaderBoardsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            color: #FFFFFF;
        }
        .auto-style6 {
            color: #FFFFFF;
            text-decoration: underline;
            width: 265px;
        }
        .auto-style7 {
            color: #FFFFFF;
            width: 265px;
        }
        .auto-style9 {
            width: 295px;
            height: 30px;
        }
        .auto-style10 {
            width: 75px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:auto">
        <tr>
            <td class="auto-style6"><strong>LeaderBoards</strong></td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Choose category: </td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"
>
                    <asp:ListItem Text="Select" Value="" />
                    <asp:ListItem>Gross profit</asp:ListItem>
                    <asp:ListItem>Higest cash per game</asp:ListItem>
                    <asp:ListItem>Number of games played</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="2">
                <asp:DataList ID="DataListLeader" runat="server" Visible="False" Width="186px" >
                      <HeaderTemplate>
                          
            <tr>
                <td style="width:auto; text-align:right">Rank</td>
                <td style="width:auto; text-align:right">User Name</td>
                <td  style="width:auto; text-align:center">
                    <asp:Label style="width:auto; text-align:center" ID="userValue" runat="server" Text='<%# DropDownList1.SelectedItem.Text.ToString() %>'></asp:Label></td>
            </tr>
            
            
                                           </HeaderTemplate>
                    <ItemTemplate> 
            <tr>
                <td style="text-align:center; width:auto" ><asp:Label ID="Label1" runat="server"
                    Text='<%# DataListLeader.Items.Count + 1 %>' /></td>
                <td style="text-align:center; width:auto" class="auto-style10"><asp:Label ID="userName" runat="server"
                    Text='    <%# Eval("userName") %>' /></td>
                <td style="text-align:center; width:auto" class="auto-style10"><asp:Label style="width:120px" ID="value" runat="server"
                    Text='<%# Eval("value") %>' /></td>
            </tr>
            
            
        
    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>

</asp:Content>
