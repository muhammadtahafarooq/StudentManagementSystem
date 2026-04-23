using System;
using System.Data;
using System.Data.SqlClient;

namespace APProject
{
    public partial class Enrollments : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString
        );

        protected void Page_Load(object sender, EventArgs e)
        {
            // 🔐 LOGIN CHECK
            if (Session["Role"] == null ||
     Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                LoadStudents();
                LoadCourses();
                LoadEnrollments();
            }
        }

        // LOAD STUDENTS DROPDOWN
        void LoadStudents()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT StudentID, Name FROM dbo.Students", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlStudents.DataSource = dt;
            ddlStudents.DataTextField = "Name";
            ddlStudents.DataValueField = "StudentID";
            ddlStudents.DataBind();
        }

        // LOAD COURSES DROPDOWN
        void LoadCourses()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT CourseID, CourseName FROM dbo.Courses", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlCourses.DataSource = dt;
            ddlCourses.DataTextField = "CourseName";
            ddlCourses.DataValueField = "CourseID";
            ddlCourses.DataBind();
        }

        // LOAD GRIDVIEW (JOIN QUERY)
        void LoadEnrollments()
        {
            string query = @"
            SELECT 
                e.EnrollmentID,
                s.Name AS StudentName,
                c.CourseName
            FROM dbo.Enrollments e
            INNER JOIN dbo.Students s ON e.StudentID = s.StudentID
            INNER JOIN dbo.Courses c ON e.CourseID = c.CourseID";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // INSERT ENROLLMENT
        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            // check duplicate
            SqlCommand check = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.Enrollments WHERE StudentID=@sid AND CourseID=@cid", con);

            check.Parameters.AddWithValue("@sid", ddlStudents.SelectedValue);
            check.Parameters.AddWithValue("@cid", ddlCourses.SelectedValue);

            con.Open();
            int count = (int)check.ExecuteScalar();
            con.Close();

            if (count > 0)
            {
                lblMessage.Text = "Student already enrolled!";
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO dbo.Enrollments(StudentID, CourseID) VALUES(@sid,@cid)", con);

            cmd.Parameters.AddWithValue("@sid", ddlStudents.SelectedValue);
            cmd.Parameters.AddWithValue("@cid", ddlCourses.SelectedValue);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Enrollment Successful";

            LoadEnrollments();
        }

        // DELETE ENROLLMENT
        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo.Enrollments WHERE EnrollmentID=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            lblMessage.Text = "Enrollment Deleted";

            LoadEnrollments();
        }
    }
}