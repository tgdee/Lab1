<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MentoringProgram.aspx.cs" Inherits="Lab1.MentoringProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <asp:ListBox ID="ListBox1" runat="server" DataSourceID="firstNameData" DataTextField="FirstName" DataValueField="FirstName" Width="500px"></asp:ListBox>
     
    <div>
        <asp:SqlDataSource 
        ID="firstNameData" 
        runat="server" 
        ConnectionString="<%$ConnectionStrings:Lab1%>" SelectCommand="SELECT * FROM ;"></asp:SqlDataSource>
    </div>
</asp:Content>
 