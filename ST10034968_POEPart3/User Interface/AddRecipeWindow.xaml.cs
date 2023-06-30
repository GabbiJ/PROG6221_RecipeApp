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
            lbxDisplayRecipe.Items.Clear();
        }
        //method for when buttons are clicked
        //event for add ingredient button
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            lbxDisplayRecipe.Items.Clear();
            try
            {
                //opening add ingredient window and displaying updated recipe
                AddIngredientWindow ai = new AddIngredientWindow();
                ai.Show();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Content = ex.Message;
            }

        }
        //event for add step button
        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            lbxDisplayRecipe.Items.Clear();
            try
            {
                //adding step to step list in recipe
                string step = txtAddStep.Text;
                AllRecipes.tempRecipe.steps.Add(step);
            }
            catch (FormatException)
            {
                lblErrorMessage.Content = "Please check that all the values have been entered and that they are entered correctly.";
            }
            catch (Exception ex)
            {
                lblErrorMessage.Content = ex.Message;
            }
            txtAddStep.Clear();
            lbxDisplayRecipe.Items.Add(AllRecipes.tempRecipe.ToString());
        }
        //event for when add recipe button is clicked
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //adding recipe name
                string name = txtName.Text; 
                AllRecipes.tempRecipe.name = name;
                //adding recipe to list of all recipes
                AllRecipes.allRecipes.Add(AllRecipes.tempRecipe);
                this.Close();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Content = ex.Message;
            }

        }
        //event for when refresh button is clicked
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            lbxDisplayRecipe.Items.Add(AllRecipes.tempRecipe.ToString());
        }
    }
}
