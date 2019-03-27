using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_20Mar19_BankAssignment
{
    public class Account
    {
        private static int numberOfAcc;
        private readonly int accountNumber=0;
        private readonly Customer accountOwner;
        private int maxMinusAllowed = 1;

        public int AccountNumber { get {return accountNumber;} }
        public int Balance { get; private set; }
        public Customer AccountOwner { get {return accountOwner;  } }
        public int MaxMinusAllowed { get; }

        public Account(int monthlyIncpme, Customer cust, int balance)
        {
            MaxMinusAllowed = (monthlyIncpme * 3)*-1;
            accountOwner = cust;
            accountNumber = numberOfAcc++;
            Balance = balance;
        }

        public void Add(int amount)
        {

            Balance = Balance + amount;
        }

        public void Subtract(int amount)
        {
            Balance = Balance - amount;
        }

         public static Account operator  +(Account c1, Account c2)
        {
            Customer newCust = new Customer(c1.accountOwner.Name, c1.AccountOwner.PhNumber, c1.AccountOwner.CustomerID);
            Account newAccount = new Account((c1.maxMinusAllowed / 3) + (c2.maxMinusAllowed / 3), newCust, c1.Balance + c2.Balance);
            
            return newAccount;
        }

        public static bool operator ==(Account c1, Account c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            return c1.AccountNumber == c2.AccountNumber;
        }

        public static bool operator !=(Account c1, Account c2)
        {
            return !(c1 == c2);
        }

        public override int GetHashCode()
        {
            return this.AccountNumber;
        }

        public override bool Equals(object obj)
        {

            Account other = obj as Account;
            return this == other;
        }

        public static int operator +(Account c1, int amount)
        {
            c1.Balance = c1.Balance + amount;

            return c1.Balance;
        }

        public static int operator -(Account c1, int amount)
        {
            c1.Balance = c1.Balance - amount;

            return c1.Balance;
        }
    }
}
