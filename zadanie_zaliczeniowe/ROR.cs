using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace zadanie_zaliczeniowe
{
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
                MessageBox.Show("Nie posiadasz tyle pieniędzy na koncie! Spróbuj Wypłacić mniejszą sumę.", "Zbyt duża kwota!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
