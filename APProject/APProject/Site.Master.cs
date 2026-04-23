using System;

namespace APProject
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                lblUser.Text = Session["User"].ToString();
            }
        }
    }
}