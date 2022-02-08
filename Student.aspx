<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Lab1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtStudFirstN" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtStudLastN" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Major"></asp:Label>
        <br />
        <asp:TextBox ID="txtMajor" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Graduation Year"></asp:Label>
        <br />
        <asp:TextBox ID="intGradYear" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Current Year"></asp:Label>
        <br />
        <asp:TextBox ID="intAcademicYear" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Phone Number"></asp:Label>
        <br />
        <asp:TextBox ID="intPhoneNumber" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
       <! <asp:Table ID="StudentNames" runat="server" Height="425px" Width="300px"></asp:Table>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click"/>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Commit ->" OnClick="Button2_Click"/>
    </div>
     <div>
        <asp:SqlDataSource 
        ID="allStudentData" 
        runat="server" 
        ConnectionString="<%$ConnectionStrings:Lab1%>" SelectCommand="INSERT INTO Student (StudentID, FirstName,
            LastName, GraduationYear, AcademicYear, Email, EmployerID, InternshipNumber)
            VALUES (studentId, txtStudFirstN, txtStudLastN, txtMajor ;"></asp:SqlDataSource>
    </div>


</asp:Content>
