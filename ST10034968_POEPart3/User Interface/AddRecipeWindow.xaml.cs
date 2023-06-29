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
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        public AddRecipeWindow()
        {
            InitializeComponent();
            tbDisplayRecipe.Text = AllRecipes.tempRecipe.ToString();
        }
        //method for when buttons are clicked
        //add ingredient button
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddIngredientWindow ai = new AddIngredientWindow();
            ai.Show();
            tbDisplayRecipe.Text = AllRecipes.tempRecipe.ToString();
        }
        //add step button
        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //adding step to step list in recipe
                string step = txtAddStep.Text;
                AllRecipes.tempRecipe.steps.Add("step");
            }
            catch (FormatException)
            {
                lblErrorMessage.Content = "Please check that all the values have been entered and that they are entered correctly.";
            }
            catch (Exception ex)
            {
                lblErrorMessage.Content = ex.Message;
            }
            tbDisplayRecipe.Text = AllRecipes.tempRecipe.ToString();
        }
        

    }
}
