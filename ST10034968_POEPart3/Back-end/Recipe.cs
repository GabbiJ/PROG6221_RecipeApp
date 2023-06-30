using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*
 * Author: ST10034968
 */

namespace ST10034968_POEPart3
{
    public class Recipe
    {
        //declarations
        public string name;
        public List<string> steps = new List<string>();
        public List<Ingredient> ingredients = new List<Ingredient>();
        public List<Ingredient> oldIngredients;
        public bool quantitiesAltered = false;
        public double totalCalories = 0;
        //delegate for event
        public event EventHandler<double> OnCalorieOver300;

        //Constructor
        public Recipe(string nameEntered, List<string> stepsEntered, List<Ingredient> ingredientsEntered)
            {
                name = nameEntered;
                steps = stepsEntered;
                ingredients = ingredientsEntered;
                oldIngredients = new List<Ingredient>();
                //calculate total calories
                calcTotalCalories();
            }
        //default constructor
        public Recipe()
        {
        }

        //methods
        //method that scales the recipe by designated factors
        public void scale(double factor)
        {
            if (quantitiesAltered == false)
            {
                for (int i = 0; i < ingredients.Count; i++)
                {
                    oldIngredients.Add(makeCopy(ingredients.ElementAt(i)));
                }
             }
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients.ElementAt(i).Quantity *= factor;
                ingredients.ElementAt(i).RQuantity *= factor;
                ingredients.ElementAt(i).Calories *= factor;
                ingredients.ElementAt(i).convertUp();
                ingredients.ElementAt(i).convertDown();
            }

            calcTotalCalories();

            quantitiesAltered = true;
            
        }
        
        //method to reset previosly scaled values to original measurements
        public void reset()
        {
            //clearing ingredients list
            ingredients.Clear();
            //copying data from old ingredients list to ingredients list
            for (int i = 0; i < oldIngredients.Count; i++)
            {
                ingredients.Add(makeCopy(oldIngredients.ElementAt(i)));
            }
            //clearing old ingredients list
            oldIngredients.Clear();

            quantitiesAltered = false;
        }
        //overriding toString method 
        public override string ToString()
        {
            string output = ($"{name}\n");

            //printing ingredients and numbered steps
            output += ("Ingredients:\n");
            for (int i = 0; i < ingredients.Count; i++)
            {
                output += (ingredients[i].printIngredient() + "\n");
            }
            output += ("Steps:\n");
            for (int i = 0; i < steps.Count; i++)
            {
                output += ($"Step {i + 1}:\n" +
                    $"{steps[i]}\n");
            }

            output += ($"Total calories: {this.calcTotalCalories()}\n");

            // values for recommended amount of calories were found at
            // https://www.nhs.uk/live-well/healthy-weight/managing-your-weight/understanding-calories/
            if (totalCalories > 2500)
            {
                output += ("Total calories exceed the recommended daily calories for an adult male.\n");
            }
            else if (totalCalories > 2000)
            {
                output += ("Total calories exceed the recommended daily calories for an adult female.\n");
            }
            else if (totalCalories > 1250)
            {
                output += ("Total calories exceed half the recommended daily calories for an adult male.\n");
            }
            else if (totalCalories > 1000)
            {
                output += ("Total calories exceed half the recommended daily calories for an adult female.\n");
            }

            output += ($"\n");

            return output;
        }
        //method to calculate total calories which invokes event if total calories are over 300
        public double calcTotalCalories()
        {
            double totalCal = 0;
            foreach (Ingredient ing in ingredients)
            {
                totalCal += ing.Calories;
            }
            totalCalories = totalCal;
            //invoking event if calories are over 300
            if (totalCal > 300)
            {
                this.OnCalorieOver300?.Invoke(this,totalCalories);
            }
            return totalCal;
        }
        //method that returns a copy of an ingredient inputted
        public Ingredient makeCopy(Ingredient original)
        {
            //individually hard copies each property and variable of original ingredient
            string name = original.Name;
            string unit = original.Unit;
            string rUnit = original.RUnit;
            double quantity = original.Quantity;
            double rQuantity = original.RQuantity;
            double calories = original.Calories;
            string foodGroup = original.FoodGroup;

            Ingredient copy = new Ingredient(name, unit, quantity, calories, foodGroup);
            copy.RUnit = rUnit;
            copy.RQuantity = rQuantity;

            return copy;
        }
    }
}
