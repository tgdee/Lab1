<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberTest.aspx.cs" Inherits="Lab1.MemberTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server" Height="200px" Width="500px">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell HorizontalAlign="Center">
                <asp:Label ID="lblHeaderMessage" runat="server" Text="Member Information" Font-Underline="true" Font-Size="Larger"></asp:Label>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:">
                </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLastName" runat="server" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Email" runat="server" Text="Member Email:">
                </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="lblError" runat="server" Text="Error"></asp:Label>
    <br />
    <asp:Button ID="PopulateButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Populate" OnClick="PopulateButton_Click" />
    <asp:Button ID="SaveButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Save" OnClick="SaveButton_Click" />
    <asp:Button ID="CommitButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Commit" OnClick="CommitButton_Click" />
    <asp:Button ID="ClearButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Clear" OnClick="ClearButton_Click" />
    <asp:ListBox ID="lbMember" runat="server" Style="min-width:600px" size="1"></asp:ListBox>
</asp:Content>
