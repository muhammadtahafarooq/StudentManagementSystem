using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace APProject
{
    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 🔐 LOGIN CHECK
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            // 🔗 CONNECTION INIT (SAFE)
            con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString);

            if (!IsPostBack)
            {
                LoadDashboard();
                LoadChart();
            }
        }

        // 📊 DASHBOARD COUNTS
        void LoadDashboard()
        {
            con.Open();

            lblStudents.Text = new SqlCommand("SELECT COUNT(*) FROM Students", con).ExecuteScalar().ToString();
            lblCourses.Text = new SqlCommand("SELECT COUNT(*) FROM Courses", con).ExecuteScalar().ToString();
            lblEnrollments.Text = new SqlCommand("SELECT COUNT(*) FROM Enrollments", con).ExecuteScalar().ToString();

            con.Close();
        }

        // 📈 CHART DATA
        void LoadChart()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(@"
                SELECT 'Students' AS Name, COUNT(*) AS Total FROM Students
                UNION
                SELECT 'Courses', COUNT(*) FROM Courses
                UNION
                SELECT 'Enrollments', COUNT(*) FROM Enrollments
            ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            Chart1.Series["Series1"].Points.Clear();

            while (dr.Read())
            {
                Chart1.Series["Series1"].Points.AddXY(
                    dr["Name"].ToString(),
                    Convert.ToInt32(dr["Total"])
                );
            }

            con.Close();
        }
    }
}