using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_zaliczeniowe
{
    class Classes
    {
        public abstract class Account
        {
            public double accountBalance = 0.0;
            public string accountName;

            public abstract double DepositMoney();
            public abstract double WithdrawMoney();

            public override string ToString()
            {
                return accountName + accountBalance.ToString();
            }

        }
        public class ROR : Account
        {
            public ROR()
            {
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
            public List<Account> listOfAccounts = new List<Account>();
            public override string ToString()
            {
                return name + surname;
            }
        }

    }
}
