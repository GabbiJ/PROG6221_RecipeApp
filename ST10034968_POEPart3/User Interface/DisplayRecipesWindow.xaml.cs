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

namespace ST10034968_POEPart3.User_Interface
{
    /// <summary>
    /// Interaction logic for DisplayRecipesWindow.xaml
    /// </summary>
    public partial class DisplayRecipesWindow : Window
    {
        public DisplayRecipesWindow()
        {
            InitializeComponent();
            //hide relevant fields
            btnShowAllRecipes.Visibility = Visibility.Hidden;
            lblScale.Visibility = Visibility.Hidden;
            cmbFactor.Visibility = Visibility.Hidden;
            btnScale.Visibility = Visibility.Hidden;
            btnClearRecipe.Visibility = Visibility.Hidden;
            btnRevert.Visibility = Visibility.Hidden;
            //filling combo boxes
            fillcmbFactor();
            fillcmbFilter();
            //adding addiotnal info
            addToLblAdditionalInfo();
        }
        //events for various fields
        //event for when add recipe button is clicked
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddRecipeWindow addRecipeWin = new AddRecipeWindow();
                addRecipeWin.Show();
            }
            catch (Exception ex)
            {
                txtBlockError.Text = "Error: " + ex.ToString();
            } 
        }
        //event for when refresh button is clicked
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            displayRecipesInListBox(AllRecipes.allRecipes);
            btnShowAllRecipes.Visibility = Visibility.Hidden;
        }
        //event for when scale button clicked
        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //scaling relevant recipe that is selected in list box
                if (cmbFactor.Text.Equals("Double"))
                {
                    AllRecipes.allRecipes.ElementAt(lbxAllRecipes.SelectedIndex).scale(2);
                }
                else if (cmbFactor.Text.Equals("Triple"))
                {
                    AllRecipes.allRecipes.ElementAt(lbxAllRecipes.SelectedIndex).scale(3);
                }
                else if (cmbFactor.Equals("Half"))
                {
                    AllRecipes.allRecipes.ElementAt(lbxAllRecipes.SelectedIndex).scale(0.5);
                }

            }
            catch (IndexOutOfRangeException)
            {

            }
            catch (Exception ex)
            {
                txtBlockError.Text = "Error: " + ex.Message;
            }


        }
        //event for when an item is selected or deselected in the list box the relevant fields show
        private void lbxAllRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //if an item is selected then display relevant buttons
                if (lbxAllRecipes.SelectedItems != null)
                {
                    lblScale.Visibility = Visibility.Visible;
                    cmbFactor.Visibility = Visibility.Visible;
                    btnScale.Visibility = Visibility.Visible;
                    btnClearRecipe.Visibility = Visibility.Visible;
                    //if recipe has been scaled, show revert button
                    if (AllRecipes.allRecipes.ElementAt(lbxAllRecipes.SelectedIndex).quantitiesAltered == true)
                    {
                        btnRevert.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    lblScale.Visibility = Visibility.Hidden;
                    cmbFactor.Visibility = Visibility.Hidden;
                    btnScale.Visibility = Visibility.Hidden;
                    btnClearRecipe.Visibility = Visibility.Hidden;
                    btnRevert.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                txtBlockError.Text = "Error: " + ex.Message;
            }

        }
        //event for when revert button is clicked
        private void btnRevert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllRecipes.allRecipes.ElementAt(lbxAllRecipes.SelectedIndex).reset();
            }
            catch (Exception ex)
            {
                txtBlockError.Text = "Error: " + ex.Message;
            }
        }
        //event for when filter button is clicked
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            AllRecipes.filteredRecipes = new List<Recipe>();
            if (cmbFilter.Text.Equals("Ingredient in the recipe"))
            {
                foreach (Recipe r in AllRecipes.allRecipes)
                {
                    foreach (Ingredient i in r.ingredients)
                    {
                        if(i.Name.Equals(txtFilterInfo.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            AllRecipes.filteredRecipes.Add(r);
                        }
                    }
                }
            }
            else if (cmbFilter.Text.Equals("Food group in the recipe"))
            {
                foreach (Recipe r in AllRecipes.allRecipes)
                {
                    foreach (Ingredient i in r.ingredients)
                    {
                        if (i.FoodGroup.Equals(txtFilterInfo.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            AllRecipes.filteredRecipes.Add(r);
                        }
                    }
                }
            }
            else if (cmbFilter.Text.Equals("Maximum amount of calories"))
            {
                foreach (Recipe r in AllRecipes.allRecipes)
                {
                    if (r.totalCalories <= Convert.ToDouble(txtFilterInfo.Text))
                    {
                        AllRecipes.filteredRecipes.Add(r);
                    }
                }
            }
            displayRecipesInListBox(AllRecipes.filteredRecipes);
            btnShowAllRecipes.Visibility = Visibility.Visible;
        }
        //event for when search button is clicked
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //clearing filtered recipes list
            AllRecipes.filteredRecipes = new List<Recipe>();
            //searching for a recipe that maches the inputted recipe
            foreach (Recipe r in AllRecipes.allRecipes)
            {
                if(r.name.Equals(txtSearch.Text, StringComparison.OrdinalIgnoreCase))
                {
                    AllRecipes.filteredRecipes.Add(r);
                }
            }
            displayRecipesInListBox(AllRecipes.filteredRecipes);
            btnShowAllRecipes.Visibility = Visibility.Visible;
        }
        //event for when clear recipe button is clicked
        private void btnClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            int index = lbxAllRecipes.SelectedIndex;
            //asks user if they are sure if they want to clear recipes data
           if(MessageBox.Show($"Are you sure you want to clear the recipe named {AllRecipes.allRecipes.ElementAt(index).name}?",
               "Clearing Recipe", MessageBoxButton.YesNo, MessageBoxImage.Question ) == MessageBoxResult.Yes)
            {
                AllRecipes.allRecipes.RemoveAt(index);
            }
            displayRecipesInListBox(AllRecipes.allRecipes);
        }
        //event for exit button
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //event for when show all recipes is clicked
        private void btnShowAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            displayRecipesInListBox(AllRecipes.allRecipes);
            btnShowAllRecipes.Visibility = Visibility.Hidden;
        }


        //methods
        //method to fill scale factor combo box
        private void fillcmbFactor()
        {
            cmbFactor.Items.Add("Double");
            cmbFactor.Items.Add("Triple");
            cmbFactor.Items.Add("Half");
        }
        //method to fill filter combo box
        private void fillcmbFilter()
        {
            cmbFilter.Items.Add("Ingredient in the recipe");
            cmbFilter.Items.Add("Food group in the recipe");
            cmbFilter.Items.Add("Maximum amount of calories");
        }
        //method to add content to label for addtional info
        private void addToLblAdditionalInfo()
        {
            lblAdditionalInfo.Content = "The recommended daily amount of calories for an adult male:\t\t2500 calories\n" +
                                        "The recommended daily amount of calories for an adult female:\t\t2000 calories\n" +
                                        "However many other factors such as age and exercise can change these recommended daily calory amounts\n";
        }
        //method to display all the recipes in the text block
        public void displayRecipesInListBox(List<Recipe> recipeList)
        {
            lbxAllRecipes.Items.Clear();
            try
            {
                foreach (var r in recipeList)
                {
                    lbxAllRecipes.Items.Add(r.ToString());
                }

            }
            catch (Exception ex)
            {
                txtBlockError.Text = "Error: " + ex.Message;
            }

        }


    }
}
