using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_zaliczeniowe
{
    public class Client
    {
        public string name;
        public string surname;
        //dzieki uzyciu ObservableCollection program bedzie widział zmiany w kolekcji
        public ObservableCollection<Account> ListOfAccounts { get; set; } = new ObservableCollection<Account>();

        public override string ToString()
        {
            return name + " " + surname;
        }       
    }
}
