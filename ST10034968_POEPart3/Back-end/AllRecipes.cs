using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author:ST10034968
 */

namespace ST10034968_POEPart3
{
    //this class serves the purpose to store all recipes for the application 
    //this was done in substitute of declaring a list of recipes in the recipes class as for each recipe to have a list I viewed as a waste of memory
    public static class AllRecipes
    {
        public static List<Recipe> allRecipes = new List<Recipe>();
        //temp list of recipes to store filtered and searched recipes
        public static List<Recipe> filteredRecipes = new List<Recipe>(); 
        //temporary ingredient and recipe objects 
        public static Recipe tempRecipe = new Recipe();
        public static Ingredient tempIngredient = new Ingredient();

    }
}
