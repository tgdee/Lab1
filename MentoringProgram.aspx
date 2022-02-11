<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MentoringProgram.aspx.cs" Inherits="Lab1.MentoringProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
  
    <div>
        <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
                <asp:TableHeaderCell HorizontalAlign="Center">
                    <asp:Label ID="lblHeaderMessage" runat="server" Text="Mentoring Program Information:" Font-Underline="true" Font-Size="Larger"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFirstName" runat="server" Text="Please Choose Mentor:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    <asp:Label ID="MemberName" runat="server" Text="Label"></asp:Label>
                    <asp:DropDownList ID="MentorDropDownList" DataSourceID="MentoringProgramSource" OnSelectedIndexChanged="MentorDropDownList_SelectedIndexChanged" DataTextField="MemberID" Height="30px" Width="200px" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Please Choose Student:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="StudentName" runat="server" Text="Label"></asp:Label>
                    <asp:DropDownList ID="StudentDropDownList" DataSourceID="StudentTableDataSource" OnSelectedIndexChanged="StudentDropDownList_SelectedIndexChanged" DataTextField="StudentID" Height="30px" Width="200px" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
         </asp:Table>
         <div style="-webkit-box-align: center">
            <br />
            <asp:Button ID="PopulateButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Populate ->" OnClick="PopulateButton_Click"  />
            <asp:Button ID="SaveButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Save ->" OnClick="SaveButton_Click" />
            <br />
            <br />
            <asp:Button ID="CommitButton" runat="server" ForeColor="Black" BackColor="SkyBlue" Font-Bold="true" Text="Commit ->" OnClick="CommitButton_Click" />
             <asp:Button ID="ClearButton" runat="server" Text="Clear ->" Font-Bold ="true" ForeColor="Black" BackColor="SkyBlue" OnClick="ClearButton_Click" />
             <br />
            <br />
        </div>
    </div>
    <asp:SqlDataSource 
            ID="MentoringProgramSource" 
            SelectCommand="SELECT Member.MemberID FROM DBO.Member LEFT JOIN Mentorship ON Member.MemberID = Mentorship.MemberID WHERE Mentorship.MemberID IS NULL"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource 
            ID="StudentTableDataSource" 
            SelectCommand="SELECT Student.StudentID FROM DBO.Student LEFT JOIN Mentorship ON Student.StudentID = Mentorship.StudentID WHERE Mentorship.MemberID IS NULL"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server"></asp:SqlDataSource>
</asp:Content>
 