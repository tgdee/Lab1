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
                    <asp:DropDownList ID="DropDownList1" DataSourceID="MentoringProgramSource" DataTextField="MemberID" Height="10px" Width="200px" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
         </asp:Table>
        
    </div>
    <asp:SqlDataSource 
            ID="MentoringProgramSource" 
            SelectCommand="SELECT MemberID FROM DBO.Mentorship"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server"></asp:SqlDataSource>
</asp:Content>
 