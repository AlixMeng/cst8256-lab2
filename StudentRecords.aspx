<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRecords.aspx.cs" Inherits="Lab_2.StudentRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
</head>
<body>
    <form id="studentRecords" runat="server" class="container">
        <h1>Course Information</h1>
        <div id="divAddStudent" runat="server">
            <div class="form-group">
                <div id="errAddStudent" runat="server" class="alert alert-danger" visible="false"></div>
                <asp:Label runat="server" ID="lblStudentId">Student ID:</asp:Label>
                <asp:TextBox runat="server" ID="txtStudentId" CssClass="form-control"></asp:TextBox>
                <asp:Label runat="server" ID="lblStudentName">Student Name:</asp:Label>
                <asp:TextBox runat="server" ID="txtStudentName" CssClass="form-control"></asp:TextBox>
                <asp:Label runat="server" ID="lblGrade">Grade (0-100):</asp:Label>
                <asp:TextBox runat="server" ID="txtGrade" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnSubmitStudent" Text="Add to Course Record" OnClick="btnSubmitStudent_Click" CssClass="btn btn-primary" />
        </div>
        <p>The following student records have been added:</p>
        <div id="divClassList" runat="server">
            <asp:Label runat="server" ID="lblOrderBy">Order By:</asp:Label>
            <asp:RadioButtonList runat="server" ID="lstOrderBy" OnSelectedIndexChanged="lstOrderBy_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem runat="server" ID="rdbtnId" Value="ID">ID</asp:ListItem>
                <asp:ListItem runat="server" ID="rdbtnName" Value="Name">Name</asp:ListItem>
                <asp:ListItem runat="server" ID="rdbtnGrade" Value="Grade">Grade</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Table runat="server" ID="tblStudentList" CssClass="table table-striped table-bordered table-hover">
                <asp:TableHeaderRow CssClass="thead-inverse">
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Grade</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
