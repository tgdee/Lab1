<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Lab1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Table runat="server" Height="187px" Width="365px">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell HorizontalAlign="Center">
                    <asp:Label ID="lblHeaderMessage" runat="server" Text="Student Information" Font-Underline="true" Font-Size="Larger"></asp:Label> 
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtStudFirstN" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtStudLastN" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMajor" runat="server" Text="Major:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGrade" runat="server" Text="Grade:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGraduationYear" runat="server" Text="Graduation Year:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="intGradYear" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="intPhoneNumber" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" />
        <br />
        <asp:Button ID="CommitButton" runat="server" Text="Commit ->" OnClick="CommitButton_Click" />
        <asp:Button ID="Populate" runat="server" Text="Populate ->" OnClick="PopulateButton_Click" />
    </div>
    <div>
        <asp:SqlDataSource 
            ID="srcStudent" 
            SelectCommand="SELECT * FROM Student"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server"></asp:SqlDataSource>
    </div>


</asp:Content>
