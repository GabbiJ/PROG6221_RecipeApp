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
            btnShowAllRecipes.Visibility = Visibility.Hidden;
            lblScale.Visibility = Visibility.Hidden;
            cmbFactor.Visibility = Visibility.Hidden;
            btnScale.Visibility = Visibility.Hidden;
            btnClearRecipe.Visibility = Visibility.Hidden;
            btnRevert.Visibility = Visibility.Hidden;
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddRecipeWindow addRecipeWin = new AddRecipeWindow();
                addRecipeWin.Show();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Content = "Error: " + ex.ToString();
            } 
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            displayAllRecipes();
        }
        //method to display all the recipes in the text block
        public void displayAllRecipes()
        {
            try
            {
                foreach (var r in AllRecipes.allRecipes)
                {
                    lbxAllRecipes.Items.Add(r.ToString());
                }

            }
            catch (Exception ex)
            {
                lblErrorMessage.Content = "Error: " + ex.Message;
            }

        }
        //event for when scale button clicked
        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //scaling relevant recipe that is selected in list box
                AllRecipes.allRecipes.ElementAt(lbxAllRecipes.SelectedIndex).scale(Convert.ToDouble(cmbFactor.Text));
            }
            catch (Exception ex)
            {
                lblErrorMessage.Content = "Error: " + ex.Message;
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
                lblErrorMessage.Content = "Error: " + ex.Message;
            }

        }
    }
}
