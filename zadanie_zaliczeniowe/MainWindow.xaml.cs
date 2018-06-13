using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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


namespace zadanie_zaliczeniowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<Client> listOfClients = new List<Client>();        

        public List<Client> ListOfClients
        {
            get
            {
                return listOfClients;
            }
            set
            {
                listOfClients = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
         //   DataContext = this;

            ROR ror = new ROR();
            ror.accountBalance = 10;
            
            Locate lokata = new Locate();
            Console.WriteLine(lokata.accountBalance.ToString());
            Console.WriteLine(ror.accountBalance.ToString());
            Console.WriteLine(ror.accNum.ToString());
            Console.WriteLine(lokata.accNum.ToString());

            for (int i = 0; i <= 9; i++)
            {
                Client klient = new Client();
                klient.name = i.ToString();
                klient.surname = i.ToString();

                double x = 12.3 * i;

                var accType = new ROR();
                accType.accountBalance = x;

                klient.ListOfAccounts.Add(accType);

                ListOfClients.Add(klient);

                
                
            }

            //customerList.ItemsSource = ListOfClients;
            //customerList.Focus();
            //if (customerList.Items.Count > 0) customerList.SelectedIndex = 0;

           // listaKont[numer_konta]
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }


        private void customerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //customerAccList.ItemsSource = ListOfClients[customerList.SelectedIndex].ListOfAccounts;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var clientWindow = new clientWindow();

            if (clientWindow.ShowDialog() == true)
            {
                string surname = clientWindow.surnameTextbox.Text;

                Client klient = new Client();
                klient.surname = surname;

                ListOfClients.Add(klient);

                customerList.Items.Refresh();
            }

        }

        private void ButtonAddAcc_Click(object sender, RoutedEventArgs e)
        {
            var accountWindow = new accountWindow();

            if (accountWindow.ShowDialog() == true)
            {
                
            }
        }
    }
}
