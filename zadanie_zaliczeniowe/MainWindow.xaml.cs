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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Client> listOfClients = new ObservableCollection<Client>();
        private ObservableCollection<Account> userAccountList = new ObservableCollection<Account>();
        private Client selectedClient;

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
        }

        public event PropertyChangedEventHandler PropertyChanged;
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

            if (element != null)
            {
                var selected = element.SelectedItem;
                this.selectedClient = selected as Client;
                UserAccountList = new ObservableCollection<Account>(selectedClient.ListOfAccounts);
            }
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            //otwarcie nowego okna klienta
            var clientWindow = new clientWindow();

            if (clientWindow.ShowDialog() == true)
            {
                //szczytanie i przypisanie wartosci do nowej instancji klasy typu client
                Client client = new Client()
                {
                    name = clientWindow.nameTextbox.Text,
                    surname = clientWindow.surnameTextbox.Text
                };
                ListOfClients.Add(client);
            }
        }
        private void ButtonAddAcc_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null)
            {
                MessageBox.Show("Wybrano niewłasciwego użytkownika.", "Najpierw musisz stworzyć jakiegos użytkownika!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //otwarcie nowego okna tworzenia konta
            var accountWindow = new accountWindow();

            if (accountWindow.ShowDialog() == true)
            {
                int selectedIndex = accountWindow.AccTypeComboBox.SelectedIndex;

                if (selectedIndex >= 0)
                {
                    Account account = null;
                    //tworzenie nowego konta
                    switch (selectedIndex)
                    {
                        case (int)AccountTypeEnum.PersonalAccount:
                            account = new ROR();
                            break;

                        case (int)AccountTypeEnum.DepositAccount:
                            account = new Locate();
                            break;

                        case (int)AccountTypeEnum.CreditCard:
                            account = new CreditCard();
                            break;
                    }
                    if (account != null)
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

            if (selectedAccount != null)
            {
                if (UserAccountList.Contains(selectedAccount))
                {
                    UserAccountList.Remove(selectedAccount);
                    selectedClient.ListOfAccounts.Remove(selectedAccount);
                }
            }
            else
            {
                MessageBox.Show("Wybrano niewłasciwe konto.", "Wybierz konto które chcesz usunąc!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void depositButton_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = customerAccList.SelectedItem as Account;

            if (selectedAccount != null)
            {
                if (UserAccountList.Contains(selectedAccount))
                {
                    bool help = Double.TryParse(accServiceTextbox.Text, out double jkl);
                    if (help == false || jkl == 0)
                    {
                        MessageBox.Show("Podaj prawidłową wartość!", "Błędna kwota.", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        selectedAccount.DepositMoney(jkl);
                        accServiceTextbox.Text = String.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz konto na które chcesz wpłacić pieniądze!", "Wybierz konto!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void withdrawButton_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = customerAccList.SelectedItem as Account;

            if (selectedAccount != null)
            {
                if (UserAccountList.Contains(selectedAccount))
                {
                    bool help = Double.TryParse(accServiceTextbox.Text, out double jkl);
                    if (help == false || jkl == 0)
                    {
                        MessageBox.Show("Podaj prawidłową wartość!", "Błędna kwota.", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        selectedAccount.WithdrawMoney(jkl);
                        accServiceTextbox.Text = String.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz konto z którego chcesz wpłacić pieniądze!", "Wybierz konto!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
