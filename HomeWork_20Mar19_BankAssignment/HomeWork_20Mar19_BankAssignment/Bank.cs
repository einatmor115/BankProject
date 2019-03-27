using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_20Mar19_BankAssignment
{
    public class Bank
    {
        private List<Account> accountList = new List<Account>();
        private List<Customer> customersList = new List<Customer>();

        private Dictionary<int, Customer> mapCustIdToCust = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> mapCustNumberToCust = new Dictionary<int, Customer>();
        private Dictionary<int, Account> mapAccountNumberToAccount = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> mapCustToListAccount = new Dictionary<Customer, List<Account>>();

        private int totalMoneyInBank;
        private int profits;

        public Bank()
        {
        }

        public void PrintMapCustIdToCust()
        {
            foreach (KeyValuePair<int, Customer> c in mapCustIdToCust)
            {
                Console.WriteLine($"{c.Key} , {c.Value.Name}");
            }
        }

        internal Customer GetCustomerByID(int customerID)
        {
            if (mapCustIdToCust.TryGetValue(customerID, out Customer c))
            {
                return c;
            }
            else
            {
                throw new CustomerNotFoundException($"{c}");
            }
        }

        internal Customer GetCustomerByINumber(int customerNum)
        {
            if (mapCustNumberToCust.TryGetValue(customerNum, out Customer c))
            {
                return c;
            }
            else
            {
                throw new CustomerNotFoundException();
            }
        }

        internal Account GetAccountByINumber(int accountNum)
        {
            if (mapAccountNumberToAccount.TryGetValue(accountNum, out Account a))
            {
                return a;
            }
            else
            {
                throw new AccountNotFoundException();
            }

        }

        internal List<Account> GetAccountByCustomer(Customer cust)
        {
            if (mapCustToListAccount.TryGetValue(cust, out List<Account> a))
            {
                return a;
            }
            else
            {
                throw new AccountNotFoundException();
            }
        }

        internal void AddNewCustomer(Customer cust)
        {
            if (customersList.Contains(cust))
            {
                throw new CustomerAlreadyExistException();
            }
            customersList.Add(cust);
            mapCustIdToCust.Add(cust.CustomerID, cust);
            mapCustNumberToCust.Add(cust.CustomerNumber, cust);
           
        }

        internal void OpenNewAccount(Customer cust, Account acc)
        {
            if (this.accountList.Contains(acc))
            {
                throw new AccountAlreadyExistException();
            }
                this.accountList.Add(acc);
                mapAccountNumberToAccount.Add(acc.AccountNumber, acc);
                totalMoneyInBank = totalMoneyInBank + acc.Balance;
            if ((mapCustToListAccount.TryGetValue(cust, out List<Account> b)))
                {
                  b.Add(acc);
                  mapCustToListAccount[cust].Add(acc);
                }
            else
                {
                 //mapCustToListAccount.Add(cust, b);
                 mapCustToListAccount[cust] = new List<Account> {acc};
                }
        }

        internal int Deposit(Account account, int amount)
        {
            account.Add(amount);
            totalMoneyInBank = totalMoneyInBank + amount;
            Console.WriteLine($"deposit of {amount} to {account.AccountOwner.Name}'s Account");
            return account.Balance;
        }

        internal int Withdrow(Account account, int amount)
        {
            if (account.MaxMinusAllowed > amount)
            {
                throw new BalanceException();
            }
            account.Subtract(amount);
            totalMoneyInBank = totalMoneyInBank - amount;
            Console.WriteLine($"Withdrow of {amount} from {account.AccountOwner.Name}'s Account");
            return account.Balance;
        }

        internal int GetCustomerTotalBalance(Customer cust)
        {
            int totalBalane = 0;
            mapCustToListAccount.TryGetValue(cust, out List<Account> a);
            if (a == null)
            {
                throw new CustomerNotFoundException();
            }
            foreach (Account acc in a)
                {
                totalBalane += acc.Balance;
                }
            return totalBalane;
        }

        internal void ChargeAnnualCommossion(float percentage)
        {
            foreach (Account account in accountList)
            {
                if (account.Balance > 0)
                {
                    int subtractAmount = (int)Math.Ceiling(account.Balance * percentage);
                    account.Subtract(subtractAmount);
                    profits += subtractAmount;
                }
                else
                {
                    int subtractAmount = (int)Math.Ceiling(account.Balance * percentage);
                    account.Subtract(subtractAmount *2);
                    profits += subtractAmount;
                }
            
            }
        }

        internal void JoinAccounts(Account account1, Account account2)
        {
            if (account1.AccountOwner != account2.AccountOwner)
            {
                throw new NotSameCustomerException();
            }
            Account newaccount;
            newaccount = account1 + account2;
            accountList.Remove(account1);
            accountList.Remove(account2);

            mapAccountNumberToAccount.Remove(account1.AccountNumber);
            mapAccountNumberToAccount.Remove(account2.AccountNumber);
            mapCustToListAccount.Remove(account1.AccountOwner);
            mapCustToListAccount.Remove(account2.AccountOwner);

            accountList.Add(newaccount);
            mapAccountNumberToAccount.Add(newaccount.AccountNumber, newaccount);

            // mapCustToListAccount.Add(newaccount.AccountOwner, newaccount);

            if ((mapCustToListAccount.TryGetValue(newaccount.AccountOwner, out List<Account> b) == true))
            {
                b.Add(newaccount);
                mapCustToListAccount[newaccount.AccountOwner].Add(newaccount);
            }
            else
            {
                mapCustToListAccount.Add(newaccount.AccountOwner, b);
                mapCustToListAccount[newaccount.AccountOwner] = new List<Account> { newaccount };
            }

            Console.WriteLine($"new account number: {newaccount.AccountNumber}, new account owner number: {newaccount.AccountOwner.CustomerNumber}, " +
                $"new account owner id: {newaccount.AccountOwner.CustomerID}");
        }
    }
}
