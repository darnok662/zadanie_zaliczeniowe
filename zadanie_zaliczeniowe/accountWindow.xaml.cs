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
using System.Windows.Shapes;

namespace zadanie_zaliczeniowe
{
    //klasa abstrakcyjna po której dziedziczą wszystkie klasy reperentujące różne rodzaje kont
    //musimy zaimplementowac interfejs INotifyPropertyChanged który pozwoli nam informować o zmianie właściwości
    //https://docs.microsoft.com/pl-pl/dotnet/framework/wpf/data/how-to-implement-property-change-notification
    public partial class accountWindow : Window, INotifyPropertyChanged
    {
        private long accountNumber;
        public accountWindow()
        {
            InitializeComponent();
            AccountNumber = Account.UniqueAccountNumber;
        }
        public long AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                //value to parametr ktory przekazujemy dla seta np. AccountBalance = 5
                //przy ustawianiu zmiennej wywołujemy OnPropertyChanged dzięki temu odświeża nam się widok
                accountNumber = value;
                OnPropertyChanged();
            }
        }
        //delagat ktory pozwala nam uzyc OnPropertyChanged, bez tego binding nie będzie działać
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
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
