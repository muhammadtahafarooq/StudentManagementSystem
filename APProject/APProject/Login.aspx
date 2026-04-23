<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Login.aspx.cs"
Inherits="APProject.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login Page</title>
</head>

<body>
    <form runat="server">

        <h2>Login System</h2>

        Username:
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br /><br />

        Password:
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />

        <asp:Button ID="btnLogin" runat="server"
            Text="Login"
            OnClick="btnLogin_Click" />

        <br /><br />

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

    </form>
</body>
</html>