using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webtest2
{
    public partial class controller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateRecipe_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:5515/Default.aspx");
        }

        protected void SearchRecipeViewSource_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:5515/Viewrecipe.aspx");
        }

        protected void SearchRecipeAPI_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:5515/Default.aspx");
        }
    }
}