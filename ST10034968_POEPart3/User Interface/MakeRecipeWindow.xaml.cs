using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MakeRecipeWindow.xaml
    /// </summary>
    public partial class MakeRecipeWindow : Window
    {
        public MakeRecipeWindow()
        {
            InitializeComponent();
            //binding the list of steps to the list box so that they can be checked off once completed
            DataContext = AllRecipes.tempRecipe.steps;
            //setting heading to name of recipe
            lblName.Content = AllRecipes.tempRecipe.name;
            //adding ingredients to textblock
            addTotxtBlockIngredients();
        }

        //method that adds the list of ingredients to the ingredient textblock
        private void addTotxtBlockIngredients()
        {
            txtBlockIngredients.Text = "";
            foreach (Ingredient i in AllRecipes.tempRecipe.ingredients)
            {
                txtBlockIngredients.Text += i.printIngredient() + "\n";
            }
        }
        //event for when back button is pressed
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        

    }
}
