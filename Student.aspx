<%@ Page Title="Student Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Lab2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Student Information Page</h1>
    <h4>
        <asp:Literal ID="ltError" runat="server"></asp:Literal>
    </h4>
    <asp:GridView ID="gvStudent" CssClass="table" runat="server" AutoGenerateColumns="false" OnRowEditing="gvStudent_RowEditing" OnRowUpdating="gvStudent_RowUpdating" OnRowCancelingEdit="gvStudent_RowCancelingEdit">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hdnStudentId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "StudentID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField />
        </Columns>


    </asp:GridView>
    
    
    
    
    <div class="jumbotron">
        <asp:Table runat="server" Height="200px" Width="500px">
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
                    <asp:TextBox ID="txtStudFirstN" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFieldValidatorFirstName" runat="server" Enabled="false" ControlToValidate="txtStudFirstN" ErrorMessage="Enter First Name"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtStudLastN" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" Enabled="false" runat="server" ControlToValidate="txtStudLastN" ErrorMessage="Enter Last Name"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMajor" runat="server" Text="Major:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtMajor" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMajor" runat="server" Enabled="false" ControlToValidate="txtMajor" ErrorMessage="Enter Major"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGrade" runat="server" Text="Grade:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtGrade" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGrade" runat="server" ControlToValidate="txtGrade" Enabled="false" ErrorMessage="Enter Grade"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGraduationYear" runat="server" Text="Graduation Year:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtGradYear" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGradYear" runat="server" ControlToValidate="txtGradYear" Enabled="false" ErrorMessage="Enter Graduation Year"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEmail" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="txtEmail" Enabled="false" ErrorMessage="Enter Email"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" Enabled="false" ErrorMessage="Enter Phone Number"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div style="-webkit-box-align: center">
            <br />
            <asp:Button ID="PopulateButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Populate ->" OnClick="PopulateButton_Click" />
            <asp:Button ID="SaveButton" runat="server" ForeColor="Black" BackColor="YellowGreen" Font-Bold="true" Text="Save ->" OnClick="SaveButton_Click" />
            <br />
            <br />
            <asp:Button ID="CommitButton" runat="server" ForeColor="Black" BackColor="SkyBlue" Font-Bold="true" Text="Commit ->" OnClick="CommitButton_Click" />
            <asp:Button ID="ClearButton" runat="server" Text="Clear ->" ForeColor="Black" BackColor="SkyBlue" Font-Bold="true" OnClick="ClearButton_Click" />
            <asp:Button ID="ClearListBoxButton" runat="server" Text="Clear List ->" ForeColor="Black" BackColor="SkyBlue" Font-Bold="true" OnClick="ClearListBoxButton_Click" />
            <br />
            <br />
        </div>

        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>

        <asp:ListBox ID="lstStudentList" runat="server" Style="min-width: 600px" size="1"></asp:ListBox>

        <br />
        <br />


    </div>
    <div>
        <asp:SqlDataSource
            ID="srcStudentID"
            SelectCommand="SELECT * FROM DBO.Student"
            ConnectionString="<%$ ConnectionStrings:Lab2 %>"
            runat="server"></asp:SqlDataSource>
    </div>
</asp:Content>
