using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using zadanie_zaliczeniowe.Enums;

namespace zadanie_zaliczeniowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Client> listOfClients = new ObservableCollection<Client>();

        private Client selectedClient;

        private ObservableCollection<Account> userAccountList = new ObservableCollection<Account>();

        public ObservableCollection<Client> ListOfClients
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

        public ObservableCollection<Account> UserAccountList
        {
            get
            {
                return userAccountList;
            }
            set
            {
                userAccountList = value;
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
            var element = sender as ComboBox;

            if(element != null)
            {
                var selected = element.SelectedItem; 

                this.selectedClient = selected as Client;
                UserAccountList = new ObservableCollection<Account>(selectedClient.ListOfAccounts);
            }
            //customerAccList.ItemsSource = ListOfClients[customerList.SelectedIndex].ListOfAccounts;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var clientWindow = new clientWindow();

            if (clientWindow.ShowDialog() == true)
            {
                Client client = new Client()
                {
                    name=clientWindow.nameTextbox.Text,
                    surname = clientWindow.surnameTextbox.Text
                };

                ListOfClients.Add(client);
            }

        }

        private void ButtonAddAcc_Click(object sender, RoutedEventArgs e)
        {
            var accountWindow = new accountWindow();

            if (accountWindow.ShowDialog() == true)
            {
                int selectedIndex = accountWindow.AccTypeComboBox.SelectedIndex;

                if(selectedIndex >= 0)
                {
                    Account account = null;

                    switch (selectedIndex)
                    {
                        case (int)AccountTypeEnum.CreditCard:
                            account = new CreditCard();

                            break;

                        case (int)AccountTypeEnum.DepositAccount:
                            account = new Locate();

                            break;

                        case (int)AccountTypeEnum.PersonalAccount:
                            account = new ROR();

                            break;
                    }

                    if(account != null)
                    {
                        selectedClient.ListOfAccounts.Add(account);
                        UserAccountList.Add(account);
                    }
                }
            }
        }

        private void ButtonDeleteAcc_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = customerAccList.SelectedItem as Account;

            if(selectedAccount != null)
            {
                if(UserAccountList.Contains(selectedAccount))
                {
                    UserAccountList.Remove(selectedAccount);
                    selectedClient.ListOfAccounts.Remove(selectedAccount);
                }
            }
        }
    }
}
