using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_zaliczeniowe
{
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
