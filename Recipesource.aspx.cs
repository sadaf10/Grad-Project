using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webtest2
{
    public partial class Recipesource : System.Web.UI.Page
    {
        DataClasses1DataContext context = new DataClasses1DataContext();
        string recipename = null;
        string recipeType = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["UserInfo"] == null)
            //{
            //    Response.Redirect("~/login.aspx?Type=Logoff");
            //}

            //if (sessionsUser.EmployeeInfo.AdminType == sVariab.NoEnter)
            //{
            //    Response.Redirect("~/form.aspx");
            //}

            if (!IsPostBack)
            {

                BindGV();
                GetIngredientColumn();

            }
        }
        protected void btnFilterSearch_OnClick(object sender, EventArgs e)
        {
            if (txtrecipename.Text.Trim().Length > 0)
            {
                recipename = txtrecipename.Text.Trim();
            }
            if (txtrecipeType.Text.Trim().Length > 0)
            {
                recipeType = txtrecipeType.Text.Trim();
            }

            BindGV();
            GetIngredientColumn();
        }

        protected void BindGV()
        {

            GridViewAllRecipes.DataSource = context.GetAllRecipe(recipename, recipeType);
            GridViewAllRecipes.DataBind();


        }


        protected void GridviewAllRecipes_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            if (txtrecipename.Text.Trim().Length > 0)
            {
                recipename = txtrecipename.Text.Trim();
            }

            if (txtrecipeType.Text.Trim().Length > 0)
            {
                recipeType = txtrecipeType.Text.Trim();
            }

            GridViewAllRecipes.DataSource = context.GetAllRecipe(recipename, recipeType);
            GridViewAllRecipes.PageIndex = e.NewPageIndex;
            GridViewAllRecipes.DataBind();
            GetIngredientColumn();


        }

        protected void GetIngredientColumn()
        {
            string tempingd = string.Empty;
            Label mylabel;
            LinkButton target = new LinkButton();
            Button btnTemp = new Button();
            int tracker = 0;



            foreach (GridViewRow row in GridViewAllRecipes.Rows)
            {

                tracker = 1;
                tempingd = string.Empty;
                
                mylabel = (Label)row.FindControl("lblRecipeIngredients");
                target = (LinkButton)row.FindControl("lbRecipeID");






                var query = context.GetIngredientsbyRecipeID(Convert.ToInt32(target.CommandArgument));


                foreach (var result in query)
                {
                    tempingd += result.Ingredient.Trim() + "<br/>";


                    tracker++;
                }

                mylabel.Text = tempingd;
               
            }

        }

        protected void GridViewAllRecipes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int tempRecipeID = Convert.ToInt32(e.CommandArgument);
            string tempingID = string.Empty;
            //Response.Redirect(tempRecipeID.ToString());

            if (e.CommandName == "ViewRecipe")
            {
                Response.Redirect("Viewrecipe.aspx?RecipeID=" + tempRecipeID);
            }
           
            else if (e.CommandName == "btnDelete")
            {
                int temprecipeID = Convert.ToInt32(e.CommandArgument);

                var query = context.GetIngredientID(tempRecipeID);
                context.DeleteFromIngredient(temprecipeID);
                context.DeleteFromProcedure(temprecipeID);
                context.DelteFromRecipe(temprecipeID);
                //foreach ( var result in query )
                //{
                //     tempingID += result.IngredientId + "</br>";


                //}
                //Response.Redirect(tempingID);
                //int tempIngredientID = Convert.ToInt32(tempingID);
                //var result = context.GetIngredientID(tempRecipeID).FirstOrDefault();
                //Response.Redirect(result.ToString());
                //var _result = context.GetProcedureID(tempRecipeID).Single();
                //int tempProcedureID = Convert.ToInt32(_result.ProcedureId);
                //int tempIngredientID = Convert.ToInt32(result.IngredientId);
                //context.DeleteTotalrecipe( tempIngredientID, tempProcedureID ,tempRecipeID);
            }

            BindGV();
            GetIngredientColumn();

        }




    }
}