<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="Lab1.Company" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:Table ID="Table1" Height="200px" Width="500px" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label ID="Label1" runat="server" Text="Company Information:" Font-Underline="true" FontSize="Larger"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="lblMeeting" runat="server" Text="Meeting Time:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="txtMeeting" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Meeting Time:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Meeting Time:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="TextBox2" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Meeting Time:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="TextBox3" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Meeting Time:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="TextBox4" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label6" runat="server" Text="Meeting Time:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="TextBox5" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </div>


</asp:Content>


