using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace zadanie_zaliczeniowe
{
    public abstract class Account
    {
        public static long UniqueAccountNumber = 0;
        public double AccountBalance {get; set; }
        public string AccountType { get; protected set; }
        public long AccountNumber { get; protected set; }

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


        public abstract void DepositMoney(double jkl);
        public abstract void WithdrawMoney(double jkl);

        public Account()
        {
            ++UniqueAccountNumber;
            AccountNumber = UniqueAccountNumber;
        }

        public override string ToString()
        {
            return AccountType + "  " + AccountBalance.ToString() + "  " + UniqueAccountNumber.ToString();
        }
    }
    public class ROR : Account
    {
        public ROR() 
        {
            AccountType = "Rachunek";
        }

        public override void DepositMoney(double jkl)
        {
            //wplacamy bez limitu
            AccountBalance += jkl;
        }

        public override void WithdrawMoney(double jkl)
        {
            //wyplacamy tylko jesli kwota wyplaty jest mniejsza niz stan konta
            if (jkl < AccountBalance && AccountBalance > 0)
            {
                AccountBalance -= jkl;
            }
            else
            {
                MessageBox.Show("Zbyt duża kwota!", "Nie posiadas tyle pieniędzy na koncie! Spróbuj Wypłacic mniejszą sumę.", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
    public class Locate : Account
    {
        public bool FirstDeposit = false;
        public double FirstMoneyDeposited = 0.0;
        public Locate()
        {
            AccountType = "Lokata";
        }
        public override void DepositMoney(double jkl)
        {
            if(FirstDeposit == false)
            {
                AccountBalance += jkl;
                FirstMoneyDeposited = AccountBalance;
                FirstDeposit = true;
            }
        }

        public override void WithdrawMoney(double jkl)
        {
            if (FirstDeposit == true && (AccountBalance - jkl <= (FirstMoneyDeposited * 0.7)))
            {
                AccountBalance -= jkl;
            }
            else
            {
                MessageBox.Show("Puste konto!", "Najpierw musisz dokonać pierwszej wpłaty! Pamiętaj, że po wpłacie środków, będziesz mógł wypłacic maksymalnie 70%", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

        }
    }
    public class CreditCard : Account
    {
        public CreditCard()
        {
            AccountType = "Karta Kredytowa";
        }
        public override void DepositMoney(double jkl)
        {
            //pozwalamy wpłacać pieniądze tylko do wysokości zaciągniętego kredytu
            if(AccountBalance + jkl <= 0)
            {
                AccountBalance += jkl;
            }
        }
        public override void WithdrawMoney(double jkl)
        {
            //no limits, wypłacamy ile chcemy
            AccountBalance -= jkl;
        }
    }
    public class Client
    {
        public string name;
        public string surname;
        public List<Account> ListOfAccounts = new List<Account>();

        public override string ToString()
        {
            return name + " " + surname;
        }       
    }
}
