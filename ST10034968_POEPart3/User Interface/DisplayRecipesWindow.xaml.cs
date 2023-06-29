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
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWin = new AddRecipeWindow();
            addRecipeWin.Show();
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
                string output = "";

                foreach (var r in AllRecipes.allRecipes)
                {
                    r.ToString();
                }

                tbAllRecipes.Text = output;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Content = "Error: " + ex.Message;
            }

        }

        private void btnScale_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
