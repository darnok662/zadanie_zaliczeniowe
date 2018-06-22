using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_zaliczeniowe
{
    public abstract class Account : INotifyPropertyChanged
    {
        private double accountBalance;
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
                accountBalance = value;
                OnPropertyChanged();
            }
        }
        public string AccountType { get; protected set; }
        public long AccountNumber { get; protected set; }

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
        public abstract void DepositMoney(double jkl);
        public abstract void WithdrawMoney(double jkl);

        public override string ToString()
        {
            return AccountType + "  " + AccountBalance.ToString() + "  " + UniqueAccountNumber.ToString();
        }
    }
}
