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
    public class AllRecipes
    {
        public List<Recipe> allRecipes;
        //temporary ingredient and recipe objects 
        public Recipe tempRecipe;
        public Ingredient tempIngredient;
    }
}
