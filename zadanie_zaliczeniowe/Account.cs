using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_zaliczeniowe
{
    public abstract class Account
    {
        //konstruktor klasy, wowoluje sie przy kazdym tworzeniu nowego konta, dzieki zmiennej statnej UniqueAccount number
        //mamy zapewnioną unikalność numerów kont
        public Account()
        {
            AccountNumber = UniqueAccountNumber;
            UniqueAccountNumber++;
        }
        public static long UniqueAccountNumber = 0;

        //protected - typ konta oraz numer konta możemy ustawiac tylko 'od środka'
        public double AccountBalance { get; protected set; }
        public string AccountType { get; protected set; }
        public long AccountNumber { get; protected set; }

        //klasy abstrakcyjne które będzie zawierać każda klasa dziedzicząca
        public abstract void DepositMoney(double jkl);
        public abstract void WithdrawMoney(double jkl);

        public override string ToString()
        {
            return AccountType + "  " + AccountBalance.ToString() + "  " + UniqueAccountNumber.ToString();
        }
    }
}
