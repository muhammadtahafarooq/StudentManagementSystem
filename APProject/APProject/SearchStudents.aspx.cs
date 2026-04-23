using System;
using System.Data;
using System.Data.SqlClient;

namespace APProject
{
    public partial class SearchStudents : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString
        );

        protected void Page_Load(object sender, EventArgs e)
        {
            // 🔐 LOGIN CHECK
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        // LOAD ALL STUDENTS
        void LoadStudents()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Students", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // SEARCH
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT * FROM Students WHERE 1=1";

            // SEARCH BY ID
            if (txtSearchID.Text != "")
            {
                query += " AND StudentID='" + txtSearchID.Text + "'";
            }

            // SEARCH BY NAME
            if (txtSearchName.Text != "")
            {
                query += " AND Name LIKE '%" + txtSearchName.Text + "%'";
            }

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            // NO RECORD FOUND
            if (dt.Rows.Count == 0)
            {
                lblMessage.Text = "No student found.";
            }
            else
            {
                lblMessage.Text = "";
            }
        }
    }
}