using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountApp
{
    /// <summary>
    /// Class account
    /// Purpose:
    /// Datamembers:B
    /// </summary>
    public class Account
    {
        private decimal anualInterestRate;

        private decimal balance;
        private int dateCreated;
        private int id;

        public int AnualInterestRate
        {
            get => default;
            set
            {
            }
        }

        public int Balance
        {
            get => default;
            set
            {
            }
        }

        public int DateCreated
        {
            get => default;
            set
            {
            }
        }

        public int Id
        {
            get => default;
            set
            {
            }
        }

        public void Deposit()
        {
            throw new System.NotImplementedException();
        }

        public void Withdraw()
        {
            throw new System.NotImplementedException();
        }
    }
}