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
    public partial class MainWindow : Window
    {
        //używamy ObserveableCollection, to taki 'specialny' rodzaj listy który pozwala nam obserwować zmiany wybranej kolekcji(listy)
        //https://social.msdn.microsoft.com/Forums/vstudio/en-US/f677fb36-6085-4efd-8438-4e8bbeb6f6c6/what-is-the-difference-between-list-vs-observablecollection-and-which-one-is-the-faster?forum=csharpgeneral
        private Client selectedClient;

        public ObservableCollection<Client> ListOfClients { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Account> UserAccountList { get; set; } = new ObservableCollection<Account>();

        public MainWindow()
        {
            //Date Context mamy ustawiony w XAMLU
            InitializeComponent();
        }

        //Co ma sie dziać kiedy zmieniamu klienta w comboBoxie?
        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ustawiamy 'szczytywanie' danych na naszego ComboBoxa
            var element = sender as ComboBox;
            if (element != null)
            {
                //tworzymy nowy element i przypisujemy mu obecnie wybranego usera
                var selected = element.SelectedItem;
                this.selectedClient = selected as Client;
                //dla kazdego klienta tworzymy jego własną listę kont
                customerAccList.ItemsSource = selectedClient.ListOfAccounts;
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
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
                if (client != null)
                {
                    ListOfClients.Add(client);
                }
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
        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            Account selectedAccount = customerAccList.SelectedItem as Account;
            if (selectedAccount != null)
            {
                if (UserAccountList.Contains(selectedAccount))
                {
                   
                    if (!Double.TryParse(accServiceTextbox.Text, out double jkl) || jkl == 0)
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
            //po każdym wcisnieciu guzika odświeżamy listę
            customerAccList.Items.Refresh();
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            //tworzymy nowy obiekt klasy account i przypisujemy mu element listy (który jest również obiektem)
            Account selectedAccount = customerAccList.SelectedItem as Account;
            if (selectedAccount != null)
            {
                if (UserAccountList.Contains(selectedAccount))
                {
                    if (!Double.TryParse(accServiceTextbox.Text, out double jkl) || jkl == 0)
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
            //po każdym wcisnieciu guzika odświeżamy listę
            customerAccList.Items.Refresh();
        }
    }
}
