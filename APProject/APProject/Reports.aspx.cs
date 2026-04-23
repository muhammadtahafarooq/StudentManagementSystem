using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace APProject
{
    public partial class Reports : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString
        );

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadStudents();
                LoadCourses();
                LoadEnrollments();
            }
        }

        void LoadStudents()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Students", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvStudents.DataSource = dt;
            gvStudents.DataBind();
        }

        void LoadCourses()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Courses", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvCourses.DataSource = dt;
            gvCourses.DataBind();
        }

        void LoadEnrollments()
        {
            string query = @"
                SELECT e.EnrollmentID,
                       s.Name AS StudentName,
                       c.CourseName
                FROM Enrollments e
                INNER JOIN Students s ON e.StudentID = s.StudentID
                INNER JOIN Courses c ON e.CourseID = c.CourseID";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvEnrollments.DataSource = dt;
            gvEnrollments.DataBind();
        }

        protected void btnExportStudents_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition",
                "attachment;filename=StudentsReport.xls");

            Response.ContentType = "application/vnd.ms-excel";

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);

            gvStudents.RenderControl(hw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            // Required for export
        }
    }
}