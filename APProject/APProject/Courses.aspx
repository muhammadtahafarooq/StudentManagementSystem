<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Courses.aspx.cs"
Inherits="APProject.Courses"
MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<h2>Courses Management</h2>

<br />

Course ID:
<asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>

<br /><br />

Course Name:
<asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvCourse"
runat="server"
ControlToValidate="txtCourseName"
ErrorMessage="Course Name Required"
ForeColor="Red">
</asp:RequiredFieldValidator>

<br /><br />

<asp:Button ID="btnInsert"
runat="server"
Text="Insert"
OnClick="btnInsert_Click" />

<asp:Button ID="btnUpdate"
runat="server"
Text="Update"
OnClick="btnUpdate_Click" />

<asp:Button ID="btnDelete"
runat="server"
Text="Delete"
OnClick="btnDelete_Click" />

<br /><br />

<asp:Label ID="lblMessage"
runat="server"
ForeColor="Red">
</asp:Label>

<br /><br />

<asp:GridView ID="GridView1"
runat="server"
Width="100%"
CellPadding="10"
GridLines="Both">
</asp:GridView>

</asp:Content>