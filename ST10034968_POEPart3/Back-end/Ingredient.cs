using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author: ST10034968
 */

namespace ST10034968_POEPart3
{
    public class Ingredient
    {
        //declarations
        //properties
        public string Name { get; set; }
        public string Unit { get; set; }
        public string RUnit { get; set; }
        public double Quantity { get; set; }
        public double RQuantity { get; set; } = 0;
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
        

        //constructors
        public Ingredient(string name, string unitOfMeasurement, double quantity, double calories, string foodGroup)
        {
            this.Name = name;
            this.Unit = unitOfMeasurement;
            this.Quantity = quantity;
            this.Calories = calories;
            FoodGroup = foodGroup;
            this.convertUp();
            this.convertDown();
        }
        //default constructor
        public Ingredient()
        {
            this.Name = "DefaultName";
            this.Unit = "DefaultUnit";
            this.Quantity = 0;
        }

        //print number of ingredients
        public string printIngredient()
        {
            string output;
            output = $"{Quantity} {Unit} of {Name}\t\tCalories: {Calories},\tFood group: {FoodGroup}";

            if(RQuantity > 0)
            {
                output = $"{Quantity} {Unit} and {RQuantity} {RUnit} of {Name}\t\tCalories: {Calories},\tFood group: {FoodGroup}";
            }
            return output;
        }

        //methods to convert units
        //method converts units up to a larger unit
        //Imperial unit conversions done according to https://keeshaskitchen.com/kitchen-conversion-charts/
        public void convertUp()
        {
            bool end = false;
            //detecting what type of unit measurement is the ingredient and converting accordingly
            while(end == false)
            {
                if (Unit.Equals("tablespoons") && Quantity >= 16)
                {
                    conversion("tablespoons", "cups", 16);
                }
                else if (Unit.Equals("teaspoons") && Quantity >= 3)
                {
                    conversion("teaspoons", "tablespoons", 3);
                }
                else if (Unit.Equals("ounces") && Quantity >= 8)
                {
                    conversion("ounces", "cups", 8);
                }
                else if (Unit.Equals("grams") && Quantity >= 1000)
                {
                    conversion("grams", "kilograms", 1000);
                }
                else if (Unit.Equals("millilitres") && Quantity >= 1000)
                {
                    conversion("millilitres", "litres", 1000);
                }
                else
                {
                    end = true;
                }
            }
            
        }
        //method converts units down to smaller units
        public void convertDown()
        {
            bool end = false;
            //detecting what type of unit measurement is the ingredient and converting accordingly
            while (end == false && Quantity < 1)
            {
                if (Unit.Equals("cups"))
                {
                    Quantity = 16 * Quantity + RQuantity;
                    Unit = "tablespoons";
                    RUnit = " ";

                    RQuantity = Quantity - Math.Round(Quantity);
                    Quantity -= RQuantity;
                    if (RQuantity > 0)
                    {
                        RUnit = "teaspoons";
                        RQuantity *= 3;
                    }
                }
                else if (Unit.Equals("tablespoons"))
                {
                    Quantity = 3 * Quantity + RQuantity;
                    Unit = "teaspoons";
                    RUnit = " ";
                    RQuantity = 0;
                }
                else if (Unit.Equals("kilograms"))
                {
                    Quantity = 1000 * Quantity + RQuantity;
                    Unit = "grams";
                    RUnit = " ";
                    RQuantity = 0;
                }
                else if (Unit.Equals("litres"))
                {
                    Quantity *= 1000 * Quantity + RQuantity;
                    Unit = "millilitres";
                    RUnit = " ";
                    RQuantity = 0;
                }
                else
                {
                    end = true;
                }
            }
        }
        //following method is called within convertUp() method
        public void conversion(string unit, string cUnit, double divisor) 
        {
            RQuantity = Quantity % divisor;
            RUnit = unit;
            Quantity = Math.Round(Quantity / divisor);
            Unit = cUnit;
        }
    }
}
