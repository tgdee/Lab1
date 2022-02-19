<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="Lab2.Company" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:Table ID="Table1" Height="200px" Width="500px" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label ID="Label1" runat="server" Text="Company Information:" Font-Underline="true" FontSize="Larger"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="lblMeeting" runat="server" Text="Meeting Time:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="txtMeeting" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="lblCmpName" runat="server" Text="Company Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtName" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Company Email:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="txtFirstName" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="LblLastName" runat="server" Text="Last Name:"></asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="txtLastName" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="lblMemberID" runat="server" Text="Member Last Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" DataSourceID="memberIDsrc" DataTextField="LastName" Height="30px" Width="150px"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="lblStudentID" runat="server" Text="Student Last Name:" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" DataSourceID="srcStudentID" Height="30px" Width="150px" DataTextField="LastName"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:ListBox ID="CompanyListBox" runat="server"></asp:ListBox>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
         <div style="-webkit-box-align: center">
            <br />
            <asp:Button ID="PopulateButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Populate ->" OnClick="PopulateButton_Click"/>
            <asp:Button ID="SaveButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Save ->" OnClick="SaveButton_Click"/>
            <br />
            <br />
            <asp:Button ID="CommitButton" runat="server" ForeColor="Black" BackColor="SkyBlue" Font-Bold="true" Text="Commit ->" OnClick="CommitButton_Click"/>
            <asp:Button ID="ClearButton" runat="server" Text="Clear ->" ForeColor="Black" BackColor="SkyBlue" Font-Bold="true" OnClick="ClearButton_Click"/>
            <br />
            <br />
        </div>

    </div>
    <asp:SqlDataSource
         ID="srcStudentID"
            SelectCommand="SELECT * FROM DBO.Student"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server">
    </asp:SqlDataSource>
    <asp:SqlDataSource
         ID="memberIDsrc"
            SelectCommand="SELECT * FROM DBO.Member"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server">
    </asp:SqlDataSource>

</asp:Content>


