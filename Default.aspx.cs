using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webtest2
{
    public partial class Default : System.Web.UI.Page
    {
       
        List<IngredientClass> IngredientList = new List<IngredientClass>();
        List<ProcedureClass> ProcedureList = new List<ProcedureClass>();
        DataClasses1DataContext context = new DataClasses1DataContext();

        //create a session for procedure list
        private List<ProcedureClass> ProcedureSession
        {

            get
            {
                HttpSessionState mSession = HttpContext.Current.Session;
                return (List<ProcedureClass>)(Session["ProcedureClass"]);

            }
            set
            {
                HttpSessionState mSession = HttpContext.Current.Session;
                mSession["ProcedureClass"] = value;
            }

        }
        //create a session for the Ingredient lists
        private List<IngredientClass> IngredientSession
        {

            get
            {
                HttpSessionState oSession = HttpContext.Current.Session;
                return (List<IngredientClass>)(Session["IngredientClass"]);
            }
            set
            {
                HttpSessionState oSession = HttpContext.Current.Session;
                oSession["IngredientClass"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {


                if (IngredientSession != null)
                {
                    IngredientSession.Clear();
                }

                if (ProcedureSession != null)
                {
                    ProcedureSession.Clear();
                }


            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string recipeName = TextBoxRecipeName.Text;
            string difficulty = DropDownListDifficulty.SelectedItem.Text;
            string recipeType = TextBoxRecipeType.Text;
            string comment = TextBoxComment.Text;
            string procedure = TextBoxProcedure.Text;

            int? recipeId;
            int? ingredientId = 0;
            int? procedureId = 0;

            if (PrepValues())
            {

                if (IngredientSession != null || ProcedureSession != null)
                {

                    IngredientList = IngredientSession;
                    //insert the recipe request
                    recipeId = context.InsertIntoRecipe(recipeName, difficulty, recipeType, comment).Single().RecipeId;

                    //if (ProcedureSession != null)
                    //{
                    //    for (int j = 0; j < ProcedureList.Count; j++)
                    //    {
                    //        context.InsertIntoProcedure(recipeId, ProcedureList[j]._procedure, ref procedureId);
                    //    }
                    //}

                    if (IngredientSession == null || IngredientSession.Count <= 0)
                    {
                        CustomValidatorIngredient.IsValid = false;
                    }

                    if (ProcedureSession == null || ProcedureSession.Count <= 0)
                    {
                        CustomValidatorProcedure.IsValid = false;
                    }

                    if (DropDownListDifficulty.SelectedItem.Text == "-1" || TextBoxRecipeType.Text == string.Empty || TextBoxRecipeName.Text == string.Empty || TextBoxComment.Text == string.Empty)
                    {
                        Page.Validate("test");
                    }


                    else if (DropDownListDifficulty.SelectedItem.Text != "-1" && TextBoxRecipeType.Text != string.Empty && TextBoxRecipeName.Text != string.Empty && TextBoxComment.Text != string.Empty && CustomValidatorIngredient.IsValid == true && CustomValidatorProcedure.IsValid == true)
                    {
                        //inserts ingredients by looping through list
                        for (int j = 0; j < IngredientList.Count; j++)
                        {

                            context.InsertIntoIngredients(recipeId, IngredientList[j]._quantity, IngredientList[j]._unit, IngredientList[j]._ingredient, ref ingredientId);
                        }
                        //insert procedures by looping through the list
                        for (int j = 0; j < ProcedureList.Count; j++)
                        {
                            context.InsertIntoProcedure(recipeId, ProcedureList[j]._procedure, ref procedureId);
                        }

                        IngredientSession.Clear();
                        TextBoxRecipeName.Text = "";
                        TextBoxRecipeType.Text = "";
                        DropDownListDifficulty.SelectedItem.Text = "";
                        TextBoxComment.Text = "";
                        
                        //lblsuccessmessage.Visible = true;
                        //lblsuccessmessage.Text = "Your Recipe Created successfully";

                        //Page.ClientScript.RegisterStartupScript(this.GetType(),"CallMyFunction","MyFunction()",true);

                        //window.setTimeout(function(){location.href = 'http://localhost:28901/Default.aspx';}, 5000);

                        Response.Redirect("http://localhost:5515/Confirmation.aspx");
                        IngredientSession.Clear();
                    }
                }

            }
        }
    
        protected void AddButton_Click(object sender, EventArgs e)
        {

            bool ingredientExist = false;

            if (!ingredientExist)
            {

                IngredientClass myingredient = new IngredientClass(TextBoxIngredient.Text, Convert.ToInt32(TextBoxQuantity.Text), TextBoxUnit.Text);
                if (IngredientSession != null)
                {

                    IngredientList = IngredientSession;
                }
                IngredientList.Add(myingredient);
                //Response.Redirect(IngredientList.Last().ToString());

                //IngredientList = IngredientSession;
                GridViewIngredients.DataSource = IngredientList;
                GridViewIngredients.DataBind();
                IngredientSession = IngredientList;
                //Response.Redirect(IngredientList.Count().ToString());

                TextBoxIngredient.Text = "";
                TextBoxQuantity.Text = "";
                TextBoxUnit.Text = "";
                //allIngredients();
            }
            else
            {
                Response.Redirect("HTIEJWOK");
            }



        }

        protected void GridViewIngredients_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int tempIngredientID = Convert.ToInt32(e.CommandArgument);
            int mycount = IngredientList.Count();
            //Response.Redirect(IngredientList.Count().ToString());

            if (e.CommandName == "Delete")
            {
                if (IngredientSession != null)
                {
                    IngredientList = IngredientSession;

                    //context.DeleteFromIngredient(tempIngredientID);
                    IngredientList.RemoveAt(tempIngredientID);
                    IngredientSession = IngredientList;


                }
            }
            GridViewIngredients.DataSource = IngredientList;
            GridViewIngredients.DataBind();

            if (IngredientList.Count() == 0)
            {
                IngredientSession.Clear();
                //Response.Redirect("http://localhost:28901/Default.aspx");
            }

        }

        protected void AddButtonProcedure_Click(object sender, EventArgs e)
        {

            string procedure = TextBoxProcedure.Text;

            bool procedureExist = false;

            if (!procedureExist)
            {

                ProcedureClass thisprocedure = new ProcedureClass(TextBoxProcedure.Text);
                if (ProcedureSession != null)
                {

                    ProcedureList = ProcedureSession;
                }
                ProcedureList.Add(thisprocedure);

                GridViewProcedures.DataSource = ProcedureList;
                GridViewProcedures.DataBind();
                ProcedureSession = ProcedureList;


                TextBoxProcedure.Text = "";

            }
            else
            {
                Response.Redirect("HTIEJWOK");
            }


        }

        protected void GridViewProcedures_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int tempProcedureID = Convert.ToInt32(e.CommandArgument);
            int mycount = ProcedureList.Count();



            //Response.Redirect(IngredientList.Count().ToString());

            if (e.CommandName == "Delete")
            {
                if (ProcedureSession != null)
                {
                    ProcedureList = ProcedureSession;

                    //context.DeleteFromIngredient(tempIngredientID);
                    ProcedureList.RemoveAt(tempProcedureID);
                    ProcedureSession = ProcedureList;


                }
            }
            GridViewProcedures.DataSource = ProcedureList;
            GridViewProcedures.DataBind();

            if (ProcedureList.Count() == 0)
            {
                //Response.Redirect("http://localhost:28901/Default.aspx");
                ProcedureSession.Clear();
            }
        }

        protected void GridViewIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridViewProcedures_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridViewIngredients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


        }
        protected void GridViewProcedures_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


        }

        protected bool PrepValues()
        {

            //panelError.Visible = false;
            bool goodOrNo = true;

            string ErrorList = "<ul class = 'errorUL'>";
            //"<ol class= \"ErrorListOL\" style= \" font-size:15px;   font-weight:bold; margin-top: 15px; color:#fff;\">";

            //if (DropDownListDifficulty.SelectedItem.Text == "-1")
            //{
            //    ErrorList += "<Li>Please choose the difficulty of your recipe</li>";
            //    goodOrNo = false;
            //}

            if (DropDownListDifficulty.SelectedValue == "-1")
            {

                ErrorList += "<Li>Please choose the difficulty</Li>";
                goodOrNo = false;
            }

            if (TextBoxRecipeName.Text.Trim() == String.Empty)
            {
                ErrorList += "<Li> Please make sure the recipe name is inserted</li>";
                goodOrNo = false;

            }

            if (TextBoxRecipeType.Text.Trim() == String.Empty)
            {
                ErrorList += "<Li> Please make sure the recipe type is inserted</li>";
                goodOrNo = false;
            }

            if (TextBoxComment.Text.Trim() == String.Empty)
            {
                ErrorList += "<Li> Please make sure the recipe comment is inserted</li>";
                goodOrNo = false;
            }


            bool noprocedure = true;
            ProcedureList = ProcedureSession;

            try
            {
                for (int j = 0; j < ProcedureList.Count; j++)
                {
                    noprocedure = false;

                }

            }
            catch
            {
                if (noprocedure)
                {
                    ErrorList += "<li>There are no procedure.Please make sure you have added procedures</li>";
                    goodOrNo = false;

                }
            }


            bool noingredient = true;

            IngredientList = IngredientSession;

            try
            {
                for (int j = 0; j < IngredientList.Count; j++)
                {

                    noingredient = false;
                }


            }
            catch
            {
                if (noingredient)
                {
                    //labelError.Visible = true;
                    //labelError.Text = "There are no ingrediet chosen. Please make sure you have added ingredients";
                    //return false;
                    ErrorList += "<li>There are no ingrediet chosen. Please make sure you have added ingredients</li>";
                    goodOrNo = false;

                }

            }
            ErrorList += "</ul>";
            if (!goodOrNo)
            {
                labelError.Visible = true;
            }

            labelError.Text = ErrorList;


            return goodOrNo;
        }

    }
}