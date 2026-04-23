<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Default.aspx.cs"
Inherits="APProject._Default"
MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-4">

    <h2>📊 Admin Dashboard</h2>

    <!-- CARDS -->
    <div class="row">

        <div class="col-md-4">
            <div class="card bg-primary text-white p-3">
                <h5>Students</h5>
                <h2><asp:Label ID="lblStudents" runat="server" /></h2>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card bg-success text-white p-3">
                <h5>Courses</h5>
                <h2><asp:Label ID="lblCourses" runat="server" /></h2>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card bg-warning text-white p-3">
                <h5>Enrollments</h5>
                <h2><asp:Label ID="lblEnrollments" runat="server" /></h2>
            </div>
        </div>

    </div>

    <!-- CHART -->
    <div class="mt-4">
        <asp:Chart ID="Chart1" runat="server" Width="700px" Height="350px">

            <Series>
                <asp:Series Name="Series1" ChartType="Column"></asp:Series>
            </Series>

            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>

            <Titles>
                <asp:Title Text="System Overview"></asp:Title>
            </Titles>

        </asp:Chart>
    </div>

</div>

</asp:Content>