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
            public double accountBalance = 0.0;
            public string accountName;
            public long accNum;
            public static long accNumber = 0;

            public abstract double DepositMoney();
            public abstract double WithdrawMoney();

            public override string ToString()
            {
                return accountName + accountBalance.ToString() + accNumber.ToString();
            }

        }
        public class ROR : Account
        {
            public ROR()
            {
                this.accNum = ++accNumber;
                accountName = "rachunek";
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
            public Locate ()
            {
                this.accNum = ++accNumber;
                accountName = "Lokata";
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
                this.accNum = ++accNumber;
                accountName = "Karta Kredytowa";
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

            public void AddAccount(Account account) 
            {
                account.accNum = Account.accNumber++;

                ListOfAccounts.Add(account);
            }

            public void RemoveAccount(Account account)
            {
                if(ListOfAccounts.Contains(account))
                {
                    ListOfAccounts.Remove(account);
                    
                }
            }
        }

    //}
}
