<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Internship.aspx.cs" Inherits="Lab1.Internship" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
  
    <div>
        <asp:Table ID="Table1" runat="server">
       <asp:TableHeaderRow>
                <asp:TableHeaderCell HorizontalAlign="Center">
                    <asp:Label ID="lblHeaderMessage" runat="server" Text="Internship Information" Font-Underline="true" Font-Size="Larger"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblInternshipType" runat="server" Text="internship Type:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFieldValidatorType" runat="server" Enabled="false" ControlToValidate="txtType" ErrorMessage="Enter Internship Type"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblInternshipStart" runat="server" Text="Internship Start Date:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFieldValidatorStart" runat="server" Enabled="false" ControlToValidate="txtStart" ErrorMessage="Enter Start Date"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblInternshipCity" runat="server" Text="InternshipCity:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFieldValidatorCity" runat="server" Enabled="false" ControlToValidate="txtCity" ErrorMessage="Enter Internship City"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblStudentID" runat="server" Text="Student ID:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMemberID" runat="server" Text="Member ID:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
           
         </asp:Table>
         <div style="-webkit-box-align: center">
            <br />
            <asp:Button ID="PopulateButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Populate ->" OnClick="PopulateButton_Click"/>
            <asp:Button ID="SaveButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Save ->" OnClick="SaveButton_Click"/>
            <br />
            <br />
            <asp:Button ID="CommitButton" runat="server" ForeColor="Black" BackColor="SkyBlue" Font-Bold="true" Text="Commit ->" OnClick="CommitButton_Click" />
            <asp:Button ID="ClearButton" runat="server" Text="Clear - >" ForeColor="Black" BackColor="SkyBlue" Font-Bold="true" OnClick="ClearButton_Click"/>
            <br />
            <br />
        </div>
    </div>

    <asp:ListBox ID="lstInternList" runat="server" Style="min-width: 600px" size="1"></asp:ListBox>

    <asp:SqlDataSource 
            ID="MentoringProgramSource" 
            SelectCommand="SELECT LastName FROM DBO.Member"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server"></asp:SqlDataSource>
    <asp:SqlDataSource 
            ID="StudentTableDataSource" 
            SelectCommand="SELECT LastName FROM DBO.Student"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server"></asp:SqlDataSource>
</asp:Content>
 
