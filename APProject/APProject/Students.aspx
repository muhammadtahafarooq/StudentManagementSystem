<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Students.aspx.cs"
Inherits="APProject.Students"
MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<h2>Students Management</h2>

<br />

Student ID:
<asp:TextBox ID="txtID" runat="server"></asp:TextBox>

<br /><br />

Name:
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvName"
runat="server"
ControlToValidate="txtName"
ErrorMessage="Name Required"
ForeColor="Red">
</asp:RequiredFieldValidator>

<br /><br />

Email:
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvEmail"
runat="server"
ControlToValidate="txtEmail"
ErrorMessage="Email Required"
ForeColor="Red">
</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator
ID="revEmail"
runat="server"
ControlToValidate="txtEmail"
ValidationExpression="\w+([-+.’]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
ErrorMessage="Invalid Email"
ForeColor="Red">
</asp:RegularExpressionValidator>

<br /><br />

Phone:
<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvPhone"
runat="server"
ControlToValidate="txtPhone"
ErrorMessage="Phone Required"
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