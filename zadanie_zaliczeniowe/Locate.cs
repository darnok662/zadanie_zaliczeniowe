using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace zadanie_zaliczeniowe
{
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
            if (FirstDeposit == false)
            {
                AccountBalance += jkl;
                FirstMoneyDeposited = AccountBalance;
                FirstDeposit = true;
            }
            else
            {
                MessageBox.Show("Na konto typu Loktata pieniądze można wpłacić tylko raz.", "Dokonano juz pierwszej wpłaty!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        public override void WithdrawMoney(double jkl)
        {
            //założenie, że po wpłacie poczatkowego kapitału użytkownik może wypłacić maksymalnie 70% wpłaconej kwoty
            if (FirstDeposit == true && ((AccountBalance - jkl) >= (FirstMoneyDeposited * 0.3)))
            {
                AccountBalance -= jkl;
            }
            else
            {
                MessageBox.Show("Zbyt duża kwota, z lokaty możesz wypłacic maksymalnie 70% początkowego kapitału.", "Zbyt duża kwota!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
