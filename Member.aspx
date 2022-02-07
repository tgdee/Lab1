<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Lab1.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MemberPage">
        <br />
        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        <br />
        <asp:TextBox ID="SearchStudentName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
        <br />
        <asp:TextBox ID="SearchStudentID" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Phone Number"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />

        <asp:Button ID="Button1" runat="server" Text="Save" />
    </div>
</asp:Content>
