<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="SearchStudents.aspx.cs"
Inherits="APProject.SearchStudents"
MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<h2>Search Students</h2>

<br />

Student ID:
<asp:TextBox ID="txtSearchID"
runat="server"></asp:TextBox>

<br /><br />

Student Name:
<asp:TextBox ID="txtSearchName"
runat="server"></asp:TextBox>

<br /><br />

<asp:Button ID="btnSearch"
runat="server"
Text="Search"
OnClick="btnSearch_Click" />

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