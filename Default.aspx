<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Information</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
</head>
<body>
    <form id="addCourse" runat="server" class="container">
		<h1>Course Information</h1>
        <div class="form-group">
            <div class="alert alert-danger" id="errorAddCourse" runat="server" visible="false">
                All fields are required
            </div>
            <asp:Label id="lblCourseNumber" runat="server">Course Number:</asp:Label>
		    <asp:TextBox id="txtCourseNumber" runat="server" CssClass="form-control"></asp:TextBox>
		    <asp:Label id="lblCourseName" runat="server">Course Name:</asp:Label>
            <asp:TextBox id="txtCourseName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
		<asp:Button id="btnSubmit" runat="server" Text="Submit Course Information" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
	</form>
</body>
</html>
