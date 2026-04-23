<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Reports.aspx.cs"
Inherits="APProject.Reports"
MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>📊 Reports Dashboard</h2>

<!-- MUST HAVE SERVER FORM CONTROLS INSIDE THIS -->

<asp:Button ID="btnExportStudents" runat="server"
    Text="Export Students to Excel"
    CssClass="btn btn-success mb-3"
    OnClick="btnExportStudents_Click" />

<asp:Button ID="btnPrint" runat="server"
    Text="Print Report"
    CssClass="btn btn-primary mb-3"
    OnClientClick="window.print(); return false;" />

<br />

<h4>Students Report</h4>
<asp:GridView ID="gvStudents" runat="server"
    CssClass="table table-bordered table-striped" />

<br />

<h4>Courses Report</h4>
<asp:GridView ID="gvCourses" runat="server"
    CssClass="table table-bordered table-striped" />

<br />

<h4>Enrollments Report</h4>
<asp:GridView ID="gvEnrollments" runat="server"
    CssClass="table table-bordered table-striped" />

</asp:Content>