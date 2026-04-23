using System;
using System.Data.SqlClient;

namespace APProject
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(
                    System.Configuration.ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString
                );

                con.Open();
                lblStatus.Text = "Database Connected Successfully 🚀";
                con.Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Connection Failed ❌ " + ex.Message;
            }
        }
    }
}