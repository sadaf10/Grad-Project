using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webtest2
{
    public class IngredientClass
    {

        public string _ingredient;
        public int _quantity;
        public string _unit;
        public int _ingredientID;
        public int _recipeID;


        public IngredientClass(string ingredient, int quantity, string unit, int ingredientID)
        {
            _ingredient = ingredient;
            _quantity = quantity;
            _unit = unit;
            _ingredientID = ingredientID;

        }
        public IngredientClass(string ingredient, int quantity, string unit)
        {
            _ingredient = ingredient;
            _quantity = quantity;
            _unit = unit;
        }

        public IngredientClass(string ingredient, int quantity, string unit, int ingredientID, int recipeID)
        {
            _ingredient = ingredient;
            _quantity = quantity;
            _unit = unit;
            _ingredientID = ingredientID;
            _recipeID = recipeID;

        }


        public string Ingredient
        {
            get { return _ingredient; }
            set { _ingredient = value; }
        }

        public int RecipeID
        {
            get { return _recipeID; }
            set { _recipeID = value; }
        }

        public int IngredientID
        {
            get { return _ingredientID; }
            set { _ingredientID = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

    }
}