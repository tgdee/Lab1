﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Lab1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Student Information Table</h1>
    <h4>
        <asp:Literal ID="ltError" runat="server"></asp:Literal></h4>
    <asp:GridView ID="gvStudent" CssClass="table table-striped color-table" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvStudent_RowDeleting" OnRowEditing="gvStudent_RowEditing" OnRowUpdating="gvStudent_RowUpdating" OnRowCancelingEdit="gvStudent_RowCancelingEdit">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hdnStudentId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "StudentID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="firstName" HeaderText="First Name" />
            <asp:BoundField DataField="lastName" HeaderText="Last Name" />
            <asp:CommandField ShowEditButton="true" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <div class="row student-table">
        <asp:Button ID="btnAddRow" runat="server" Text="Add New Row" CssClass="btn btn-primary" OnClick="btnAddRow_Click" />
    </div>

   <%-- <div class="jumbotron">
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
        </asp:Table>--%>
<%--        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" />
        <br />
        <asp:Button ID="CommitButton" runat="server" Text="Commit ->" OnClick="CommitButton_Click" />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Manual List Population"></asp:Label>
            <br />
            <asp:Button ID="PopulateButton" runat="server" Text="Populate ->" OnClick="PopulateButton_Click" />
            <br />
            <asp:ListBox ID="lstStudentsManual" runat="server"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="lblAutoPop" runat="server" Text="Auto Populate"></asp:Label>
            <br />
            <asp:ListBox ID="lstStudentsAuto" AutoPostBack="true" runat="server"
                DataSourceID="srcStudentID"
                DataTextField="StudentID" DataValueField="StudentID"
                OnSelectedIndexChanged="lstStudentsAuto_SelectedIndexChanged"></asp:ListBox>
            <br />
            <asp:Label ID="lblSelectedIndex" runat="server" Text="Index"></asp:Label>
        </div>--%>
    <div>
        <asp:SqlDataSource 
            ID="srcStudentID" 
            SelectCommand="SELECT * FROM DBO.Student"
            ConnectionString="<%$ ConnectionStrings:Lab1 %>"
            runat="server"></asp:SqlDataSource>
    </div>


</asp:Content>
