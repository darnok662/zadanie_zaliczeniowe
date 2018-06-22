using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace zadanie_zaliczeniowe
{
    public class CreditCard : Account
    {
        public CreditCard()
        {
            AccountType = "Karta Kredytowa";
        }
        public override void DepositMoney(double jkl)
        {
            //pozwalamy wpłacać pieniądze tylko do wysokości zaciągniętego kredytu
            if (AccountBalance + jkl <= 0)
            {
                AccountBalance += jkl;
            }
            else
            {
                MessageBox.Show("Kartę kredytową możesz spłacać tylko do wysokości zaciągnietego kredytu", "Zbyt duża kwota!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        public override void WithdrawMoney(double jkl)
        {
            //no limits, wypłacamy ile chcemy
            AccountBalance -= jkl;
        }
    }
}
