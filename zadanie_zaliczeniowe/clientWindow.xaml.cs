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
using static zadanie_zaliczeniowe.Classes;

namespace zadanie_zaliczeniowe
{
    /// <summary>
    /// Interaction logic for clientWindow.xaml
    /// </summary>
    public partial class clientWindow : Window
    {
        public clientWindow()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(surnameTextbox.Text))
            {
                MessageBox.Show("Musisz podać jakąś wartość!", "Błędne nazwisko", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;

            
        }
    }
}
