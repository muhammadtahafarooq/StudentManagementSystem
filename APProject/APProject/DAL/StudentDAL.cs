using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace APProject.DAL
{
    public class StudentDAL
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString
        );

        // ADD STUDENT
        public void AddStudent(string name, string email, string phone)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO dbo.Students(Name,Email,Phone) VALUES(@Name,@Email,@Phone)", con);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Phone", phone);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // GET ALL STUDENTS
        public DataTable GetStudents()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.Students", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}