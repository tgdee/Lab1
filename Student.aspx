<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Lab1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        <br />
        <asp:TextBox ID="SearchStudentName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
        <br />
        <asp:TextBox ID="SearchStudentID" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Major"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Graduation Year"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Current Year"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Phone Number"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
       <! <asp:Table ID="StudentNames" runat="server" Height="425px" Width="300px"></asp:Table>
    </div>

</asp:Content>
