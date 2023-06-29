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
    /// Interaction logic for AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        public AddIngredientWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtOtherUnitOfMeasurement_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOtherUnitOfMeasurement.Clear();
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FFF7F4F3");
            txtOtherUnitOfMeasurement.Foreground = brush;
        }

        private void txtOtherUnitOfMeasurement_LostFocus(object sender, RoutedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            Brush brush = (Brush)converter.ConvertFromString("#FF4A4A4A");
            txtOtherUnitOfMeasurement.Foreground = brush;
            txtOtherUnitOfMeasurement.Text = "Other";
        }
    }
}
