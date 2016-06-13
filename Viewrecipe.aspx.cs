using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webtest2
{
    public partial class Viewrecipe : System.Web.UI.Page
    {
        
            DataClasses1DataContext context = new DataClasses1DataContext();
      
            static int RecipeID;
        protected void Page_Load(object sender, EventArgs e)
        {
         


            if (!IsPostBack)
            {

                if (Request.QueryString["RecipeID"] != null)
                {
                    RecipeID = Convert.ToInt32(Request.QueryString["RecipeID"]);
                    Session["RecipeID"] = RecipeID;
                    GetRecipeInfo(RecipeID);
                    GetIngredientInfo();
                    GetProcedureInfo();
                    GetAdditionalIngredient();
                  
                }
                //else
                //{
                //    Response.Redirect("~/login.aspx?Type=Logoff");
                //}
            }


        }
        protected void GetIngredientInfo()
        {
            int tempid = Convert.ToInt32(Session["RecipeID"]);
            GridViewIngredients.DataSource = context.GetRecipeIngredient(tempid);
            GridViewIngredients.DataBind();
        }

        protected void GetProcedureInfo()
        {
            int tempid = Convert.ToInt32(Session["RecipeID"]);
            GridViewProcedure.DataSource = context.GetRecipeProcedures(tempid);
            GridViewProcedure.DataBind();
        }
        protected void btnAddAdditionalIngredient_OnClick(object sender, EventArgs e)
        {
            int tempid = Convert.ToInt32(Session["RecipeID"]);
            //int? ingID = 0;
            context.InsertAdditionalIngredient(txtAddIngredientname.Text.Trim(), txtAddIngredientUnit.Text.Trim(), Convert.ToInt32(txtAddIngredientQuantity.Text.Trim()), tempid);
            GetIngredientInfo();
            txtAddIngredientname.Text = string.Empty;
            txtAddIngredientUnit.Text = string.Empty;
            txtAddIngredientQuantity.Text = string.Empty;
        }


        protected void btnAddAdditionalProcedure_OnClick(object sender, EventArgs e)
        {
            int tempid = Convert.ToInt32(Session["RecipeID"]);
            //int? ingID = 0;
            context.InsertAdditionalProcedure(txtaddAdditionalProcedure.Text.Trim(), tempid);
            GetProcedureInfo();
            txtaddAdditionalProcedure.Text = string.Empty;
            
        }


        protected void GetRecipeInfo(int recipeid)
        {
            int tempid = Convert.ToInt32(Session["RecipeID"]);
            var query = context.GetRecipeInfo(recipeid).SingleOrDefault();
            

            TxtRecipename.Text = query.RecipeName;
            TxtRecipetype.Text = query.RecipeType;
            TxtDifficulty.Text = query.Difficulty;
            Txtcomment.Text = query.Comment;

            
        }

     

        protected void GetAdditionalIngredient()
        {

            int tempid = Convert.ToInt32(Session["RecipeID"]);
            //GridViewAdditionalIngredients.DataSource = context.GetAdditionalIngredientGridView(tempid);
            //GridViewAdditionalIngredients.DataBind();
        }





        protected void GridViewIngredients_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridViewProcedure_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        protected void DeleteRowAddIngredient(object sender, GridViewDeleteEventArgs e)
        {

           
        }


        protected void btnOpenAddingredient_OnClick(object sender, EventArgs e)
        {

        }

        protected void btnEditRecipe_OnClick(object sender, EventArgs e)
        {

        }

        protected void btnSaveRecipe_OnClick(object sender, EventArgs e)
        {
            int recipeid = Convert.ToInt32(Session["RecipeID"]);
            context.UpdateRecipeInfo(TxtRecipename.Text, TxtRecipetype.Text, TxtDifficulty.Text, Txtcomment.Text, recipeid);
        }

        protected void GridViewIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridViewProcedure_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridViewProcedure_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int tempProcedureID = Convert.ToInt32(e.CommandArgument);

            //var query = context.GetIngredientID(tempRecipeID);
            context.DeleteFromaddedProcedure(tempProcedureID);
            GetProcedureInfo();
            //context.DeleteFromProcedure(temprecipeID);
            //context.DelteFromRecipe(temprecipeID);

        }
        protected void GridViewIngredients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int tempIngredientID = Convert.ToInt32(e.CommandArgument);

            //var query = context.GetIngredientID(tempRecipeID);
            context.DeleteFromAddedIngredient(tempIngredientID);
            GetIngredientInfo();
            //context.DeleteFromProcedure(temprecipeID);
            //context.DelteFromRecipe(temprecipeID);

        }
        protected void DeleteRow(object sender, GridViewDeleteEventArgs e)
        {

            //int rowID = Convert.ToInt32(GridViewProcedure.DataKeys[e.RowIndex].Value);
            //context.DeleteFromaddedProcedure(rowID);
            //GetProcedureInfo();
        }

        protected void GridViewProcedure_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void GridViewIngredients_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void DeletingRow(object sender, GridViewDeleteEventArgs e)
        {

            //int rowID = Convert.ToInt32(GridViewIngredients.DataKeys[e.RowIndex].Value);
            //context.DeleteFromAddedIngredient(rowID);
            //GetProcedureInfo();
        }

    }

    


}
    
