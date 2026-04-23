using System;
using System.Data;
using System.Data.SqlClient;

namespace APProject
{
    public partial class Students : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString
        );

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null ||
    Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        void LoadStudents()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Students", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // INSERT
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // DUPLICATE EMAIL CHECK
            SqlCommand checkCmd = new SqlCommand(
                "SELECT COUNT(*) FROM Students WHERE Email=@e", con);

            checkCmd.Parameters.AddWithValue("@e", txtEmail.Text);

            con.Open();

            int count = (int)checkCmd.ExecuteScalar();

            con.Close();

            if (count > 0)
            {
                lblMessage.Text = "Email already exists!";
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Students(Name,Email,Phone) VALUES(@n,@e,@p)", con);

            cmd.Parameters.AddWithValue("@n", txtName.Text);
            cmd.Parameters.AddWithValue("@e", txtEmail.Text);
            cmd.Parameters.AddWithValue("@p", txtPhone.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Student Inserted Successfully";

            LoadStudents();
        }

        // UPDATE
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE Students SET Name=@n, Email=@e, Phone=@p WHERE StudentID=@id", con);

            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@n", txtName.Text);
            cmd.Parameters.AddWithValue("@e", txtEmail.Text);
            cmd.Parameters.AddWithValue("@p", txtPhone.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Student Updated Successfully";

            LoadStudents();
        }

        // DELETE
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Students WHERE StudentID=@id", con);

                cmd.Parameters.AddWithValue("@id", txtID.Text);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Student Deleted Successfully";

                LoadStudents();
            }
            catch
            {
                con.Close();

                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text =
                    "Cannot delete student because it is linked with enrollments.";
            }
        }
    }
}