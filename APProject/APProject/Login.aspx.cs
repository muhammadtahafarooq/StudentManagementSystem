using System;
using System.Data.SqlClient;

namespace APProject
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString
        );

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
    "SELECT * FROM dbo.Users WHERE Username=@u AND Password=@p", con);

            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["User"] = dr["Username"].ToString();

                Session["Role"] = dr["Role"].ToString();

                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Username or Password";
            }

            con.Close();
        }
    }
}