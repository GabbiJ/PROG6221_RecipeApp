using ST10034968_POEPart3.User_Interface;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10034968_POEPart3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //method for when button is clicked the user is taken to Add Recipe Window
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow ar = new AddRecipeWindow();
            ar.Show();
            this.Close();
        }
    }
}
