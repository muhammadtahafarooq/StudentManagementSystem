using System;
using System.Data;
using System.Data.SqlClient;

namespace APProject
{
    public partial class Courses : System.Web.UI.Page
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
                LoadCourses();
            }
        }

        // LOAD COURSES
        void LoadCourses()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Courses", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // INSERT COURSE
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // 🔥 DUPLICATE CHECK
            SqlCommand checkCmd = new SqlCommand(
                "SELECT COUNT(*) FROM Courses WHERE CourseName=@name", con);

            checkCmd.Parameters.AddWithValue("@name", txtCourseName.Text);

            con.Open();

            int count = (int)checkCmd.ExecuteScalar();

            con.Close();

            if (count > 0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Course already exists!";
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Courses(CourseName) VALUES(@name)", con);

            cmd.Parameters.AddWithValue("@name", txtCourseName.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Course Inserted Successfully";

            LoadCourses();
        }

        // UPDATE COURSE
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE Courses SET CourseName=@name WHERE CourseID=@id", con);

            cmd.Parameters.AddWithValue("@id", txtCourseID.Text);
            cmd.Parameters.AddWithValue("@name", txtCourseName.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Course Updated Successfully";

            LoadCourses();
        }

        // DELETE COURSE
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Courses WHERE CourseID=@id", con);

                cmd.Parameters.AddWithValue("@id", txtCourseID.Text);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Course Deleted Successfully";

                LoadCourses();
            }
            catch
            {
                con.Close();

                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text =
                    "Cannot delete course because it is linked with enrollments.";
            }
        }
    }
}