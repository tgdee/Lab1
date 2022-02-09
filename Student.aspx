<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Lab1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtStudFisrtN" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtStudLastN" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="MajorLabel" runat="server" Text="Major"></asp:Label>
        <br />
        <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="GradYearLabel" runat="server" Text="Graduation Year"></asp:Label>
        <br />
        <asp:TextBox ID="intGradYear" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="GradeLabel" runat="server" Text="Grade"></asp:Label>
        <br />
        <asp:TextBox ID="Grade" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="PhNumLabel" runat="server" Text="Phone Number"></asp:Label>
        <br />
        <asp:TextBox ID="intPhoneNumber" runat="server"></asp:TextBox>
        <br />
       <! <asp:Table ID="StudentNames" runat="server" Height="425px" Width="300px"></asp:Table>
        <br />
        <br />
        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click"/>
        <br />
        <asp:Button ID="CommitButton" runat="server" Text="Commit ->" OnClick="CommitButton_Click"/>
        <asp:Button ID="Populate" runat="server" Text="Populate ->" OnClick="PopulateButton_Click"/>
    </div>
     <div>
        <asp:SqlDataSource 
        ID="studentFirstName" 
        runat="server" 
        ConnectionString="<%$ConnectionStrings:Lab1%>" SelectCommand="SELECT FirstName FROM Student;"></asp:SqlDataSource>
    </div>


</asp:Content>
