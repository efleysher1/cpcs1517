<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasicControls.aspx.cs" Inherits="WebApp.SamplePages.BasicControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" style="width: 80%; border: 1px solid #9900FF">
        <tr>
            <td align="right" style="height: 42px">TextBox</td>
            <td style="height: 42px">
                <asp:TextBox ID="TextBoxNumberChoice" ToolTip="Enter a choice of one to four" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="SubmitButtonChoice" runat="server" Text="Submit Choice" OnClick="SubmitButtonChoice_Click" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="Choice (RadioButtonList):" Font-Size="Medium" ForeColor="#33cc33" Font-Bold="true"></asp:Label>
            </td>
            <td >
                <asp:RadioButtonList ID="RadioButtonListChoice" runat="server" OnSelectedIndexChanged="RadioButtonListChoice_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">COMP1008</asp:ListItem>
                    <asp:ListItem Value="2">CPSC1517</asp:ListItem>
                    <asp:ListItem Value="3">DMIT2018</asp:ListItem>
                    <asp:ListItem Value="4">DMIT1508</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Literal ID="Literal1" runat="server" Text="Choice (Check Box):"></asp:Literal>
            </td>
            <td style="height: 42px">
                <asp:CheckBox ID="CheckBoxChoice" runat="server"  Font-Bold="true" Text="Programming Course if active"/>
            </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="Label2" runat="server" Text="Display Label:"></asp:Label>
            </td>
            <td style="height: 42px">
                <asp:Label ID="DisplayReadOnly" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="Label4" runat="server" Text="View Collection:"></asp:Label>
            </td>
            <td >
                <asp:DropDownList ID="CollectionList" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" ></td>
            <td></td>
        </tr>
        <tr>
            <td align="center" colspan="2" >
                <asp:Label ID="MessageLabel" runat="server"></asp:Label></td>
        </tr>
        
    </table>
    </table>
    </table>
    </table>
    </table>
</asp:Content>
