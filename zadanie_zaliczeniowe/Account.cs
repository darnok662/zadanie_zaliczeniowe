using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_zaliczeniowe
{
    //klasa abstrakcyjna po której dziedziczą wszystkie klasy reperentujące różne rodzaje kont
    //musimy zaimplementowac interfejs INotifyPropertyChanged który pozwoli nam informować o zmianie właściwości
    //https://docs.microsoft.com/pl-pl/dotnet/framework/wpf/data/how-to-implement-property-change-notification
    public abstract class Account : INotifyPropertyChanged
    {
        private double accountBalance;
        //konstruktor klasy, wowoluje sie przy kazdym tworzeniu nowego konta, dzieki zmiennej statnej UniqueAccount number
        //mamy zapewnioną unikalność numerów kont
        public Account()
        {
            AccountNumber = UniqueAccountNumber;
            UniqueAccountNumber++;
        }
        public static long UniqueAccountNumber = 0;
        public double AccountBalance
        {
            get
            {
                return accountBalance;
            }
            set
            {
                //value to parametr ktory przekazujemy dla seta np. AccountBalance = 5
                //przy ustawianiu zmiennej wywołujemy OnPropertyChanged dzięki temu odświeża nam się widok
                accountBalance = value;
                OnPropertyChanged();
            }
        }
        //prtected - typ konta oraz numer konta możemy ustawiac tylko 'od środka'
        public string AccountType { get; protected set; }
        public long AccountNumber { get; protected set; }

        //deklaracja eventu PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        
        //delegat który pozwala nam uzyć OnPropertyChanged, bez tego binding nie bedzie działać
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        //klasy abstrakcyjne które będzie zawierać każda klasa dziedzicząca
        public abstract void DepositMoney(double jkl);
        public abstract void WithdrawMoney(double jkl);

        public override string ToString()
        {
            return AccountType + "  " + AccountBalance.ToString() + "  " + UniqueAccountNumber.ToString();
        }
    }
}
