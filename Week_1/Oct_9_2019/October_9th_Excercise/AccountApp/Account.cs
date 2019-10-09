using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AccountApp
{
    /// <summary>
    /// Class account
    /// Purpose:
    /// Datamembers:B
    /// </summary>
    public class Account
    {

        #region DataMembers
        /// <summary>
        /// Datamembers
        /// </summary>
        private decimal anualInterestRate;

        private decimal balance;
        private string dateCreated;
        private int id;

        #endregion

        #region Constructor


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Account()
        {
            DateCreated = "Missing";
        }

        public Account(decimal anualInterestRate, decimal balance, string dateCreated, int id)
        {
            AnualInterestRate = anualInterestRate;
            Balance = balance;
            DateCreated = dateCreated;
        }

        #endregion

        #region Properties

        public decimal AnualInterestRate
        {
            get => default;
            set
            {
            }
        }

        public decimal Balance
        {
            get => default;
            set
            {
                if (value >= balance)
                {
                    balance = value;
                }
                else
                {
                    balance = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DateCreated
        {
            get { return dateCreated; }
            set
            {
                if (value != null)
                {
                    dateCreated = value;
                }
                else
                {
                    dateCreated = "Missing";
                }
            }
        }

        public int Id
        {
            get => default;
            set
            {
            }
        }

        #endregion

        #region Utility methods

        public void Deposit()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// </returns>
        public decimal Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }

            return balance;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Account:\nalance: {0}, ID: {1} \n ", balance, id);

        }
    }
}