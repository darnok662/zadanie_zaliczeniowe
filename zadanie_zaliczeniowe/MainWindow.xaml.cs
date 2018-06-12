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
using static zadanie_zaliczeniowe.Classes;

namespace zadanie_zaliczeniowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Client> listOfClients = new List<Client>();

        public MainWindow()
        {
            InitializeComponent();

            ROR ror = new ROR();
            ror.accountBalance = 10;

            Locate lokata = new Locate();
            Console.WriteLine(lokata.accountBalance.ToString());
            Console.WriteLine(ror.accountBalance.ToString());

            for(int i = 0; i <= 9; i++)
            {
                Client klient = new Client();
                klient.name = i.ToString();
                klient.surname = i.ToString();

                double x = 12.3 * i;

                var accType = new ROR();
                accType.accountBalance = x;

                klient.listOfAccounts.Add(accType);

                listOfClients.Add(klient);
                
            }

            customerList.ItemsSource = listOfClients;
            customerList.Focus();
            if (customerList.Items.Count > 0) customerList.SelectedIndex = 0;


        }
            

       

        private void customerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customerAccList.ItemsSource = listOfClients[customerList.SelectedIndex].listOfAccounts;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var clientWindow = new clientWindow();

            if (clientWindow.ShowDialog() == true)
            {
                string surname = clientWindow.surnameTextbox.Text;

                Client klient = new Client();
                klient.surname = surname;

                listOfClients.Add(klient);

                customerList.Items.Refresh();
            }

        }
    }
}
