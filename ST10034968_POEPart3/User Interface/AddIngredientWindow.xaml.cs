using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

/*
 * Author: ST10034968
 */

namespace ST10034968_POEPart3.User_Interface
{
    /// <summary>
    /// Interaction logic for AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        public AddIngredientWindow()
        {
            InitializeComponent();
            fillcmbUnitOfMeasurement();
            fillcmbFoodGroup();
            addInfoToLblFoodGroupInfo();
        }
        //event for when add button is clicked
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //taking input from fields
                string name = txtName.Text;
                double quantity = Convert.ToDouble(txtQuantity.Text);
                string unitOfMeasurement = "";
                double calories = Convert.ToDouble(txtCalories.Text);
                string foodGroup = cmbFoodGroup.Text;
                //if something is wrtten in textbox then that info is used, otherwise use combobox
                if (txtOtherUnitOfMeasurement.Text != "Other")
                {
                    unitOfMeasurement = cmbUnitOfMeasurement.Text;
                }
                //creating ingredient and adding it to recipe list
                AllRecipes.tempIngredient = new Ingredient(name, unitOfMeasurement, quantity, calories, foodGroup);
                AllRecipes.tempRecipe.ingredients.Add(AllRecipes.tempIngredient);
                this.Close();
            }
            catch (FormatException)
            {
                lblErrorMessage.Content = "Please check that all the values have been entered and that they are entered correctly.";
            }
            catch (Exception error)
            {
                lblErrorMessage.Content = error.Message;
            } 

        }
        //when user selects the textbox for another unit of measurement it clears the combo box and changes whats displayed in textbox
        private void txtOtherUnitOfMeasurement_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOtherUnitOfMeasurement.Clear();
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFF7F4F3");
            txtOtherUnitOfMeasurement.Foreground = brush;
            cmbUnitOfMeasurement.SelectedItem = null;
        }
        //when user deselects the textbox for unit of measurement it returns to default
        private void txtOtherUnitOfMeasurement_LostFocus(object sender, RoutedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FF4A4A4A");
            txtOtherUnitOfMeasurement.Foreground = brush;
            txtOtherUnitOfMeasurement.Text = "Other";
        }
        //methods to add options to comboboxes
        private void fillcmbUnitOfMeasurement()
        {
            cmbUnitOfMeasurement.Items.Add("teaspoons");
            cmbUnitOfMeasurement.Items.Add("tablespoons");
            cmbUnitOfMeasurement.Items.Add("ounces");
            cmbUnitOfMeasurement.Items.Add("cups");
            cmbUnitOfMeasurement.Items.Add("grams");
            cmbUnitOfMeasurement.Items.Add("kilograms");
            cmbUnitOfMeasurement.Items.Add("millilitres");
            cmbUnitOfMeasurement.Items.Add("litres");
        }
        private void fillcmbFoodGroup()
        {
            cmbFoodGroup.Items.Add("Starchy food");
            cmbFoodGroup.Items.Add("Vegetables and fruits");
            cmbFoodGroup.Items.Add("Dry beans, peas, lentils and soya");
            cmbFoodGroup.Items.Add("Meat");
            cmbFoodGroup.Items.Add("Dairy");
            cmbFoodGroup.Items.Add("Fats and oils");
            cmbFoodGroup.Items.Add("Sugars");
            cmbFoodGroup.Items.Add("Water");
        }
        //mehtod to add content to food group examples label
        private void addInfoToLblFoodGroupInfo()
        {
            lblFoodGroupInfo.Content =  "Starchy foods:\t\t\tExamples: rice, pasta, bread\n" +
                                        "Vegetables and fruits\t\tExamples: spinach, orange, tomato\n" +
                                        "Dry beans, peas, lentils and soya:\tExamples: soy beans, chickpeas\n" +
                                        "Meat:\t\t\t\tExamples: chicken, beef, fish\n" +
                                        "Dairy:\t\t\t\tExamples: milk, cheese, amasi\n" +
                                        "Fats and oils:\t\t\tExamples: Olive oil, nuts, sunflower oil\n" +
                                        "Sugars:\t\t\t\tExamples: Candy, chocolates, syrup\n";
        }
    }
}
