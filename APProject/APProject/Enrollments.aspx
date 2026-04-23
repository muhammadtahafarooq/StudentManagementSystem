<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Enrollments.aspx.cs"
Inherits="APProject.Enrollments"
MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Enrollment Module</h2>

<br />

Student:
<asp:DropDownList ID="ddlStudents" runat="server"></asp:DropDownList>

<br /><br />

Course:
<asp:DropDownList ID="ddlCourses" runat="server"></asp:DropDownList>

<br /><br />

<asp:Button ID="btnEnroll" runat="server"
Text="Enroll Student"
OnClick="btnEnroll_Click" />

<br /><br />

<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

<br /><br />

<asp:GridView ID="GridView1" runat="server"
AutoGenerateColumns="False"
DataKeyNames="EnrollmentID"
OnRowDeleting="GridView1_RowDeleting"
Width="100%"
CellPadding="10">

    <Columns>

        <asp:BoundField DataField="EnrollmentID" HeaderText="ID" />
        <asp:BoundField DataField="StudentName" HeaderText="Student" />
        <asp:BoundField DataField="CourseName" HeaderText="Course" />

        <asp:CommandField ShowDeleteButton="True" />

    </Columns>

</asp:GridView>

</asp:Content>