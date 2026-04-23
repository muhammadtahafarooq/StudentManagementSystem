using System;
using System.Web.UI;

namespace APProject
{
    public partial class BasePage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}