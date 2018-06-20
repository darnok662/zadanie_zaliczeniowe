using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_zaliczeniowe
{
    //class Classes
    //{
    public abstract class Account
    {
        public static long UniqueAccountNumber = 1;

        public double accountBalance = 0.0;
        public string AccountType { get; protected set; }
        public long AccountNumber { get; protected set; }

        public abstract double DepositMoney();
        public abstract double WithdrawMoney();

        public Account()
        {
            UniqueAccountNumber++;
            AccountNumber = UniqueAccountNumber;

        }

        public override string ToString()
        {
            return AccountType + accountBalance.ToString() + UniqueAccountNumber.ToString();
        }

    }
    public class ROR : Account
    {
        public ROR() 
        {
            AccountType = "rachunek";
        }

        public override double DepositMoney()
        {

            return 2.3;
        }

        public override double WithdrawMoney()
        {

            return 3.4;
        }
    }
    public class Locate : Account
    {
        public Locate()
        {
            AccountType = "Lokata";
        }
        public override double DepositMoney()
        {
            return 2.3;
        }

        public override double WithdrawMoney()
        {

            return 3.4;
        }

    }
    public class CreditCard : Account
    {
        public CreditCard()
        {
            AccountType = "Karta Kredytowa";
        }
        public override double DepositMoney()
        {
            return 2.3;
        }

        public override double WithdrawMoney()
        {

            return 3.4;
        }

    }

    public class Client
    {
        public string name;
        public string surname;
        public List<Account> ListOfAccounts = new List<Account>();
        public override string ToString()
        {
            return name + surname;
        }       
    }

    //}
}
