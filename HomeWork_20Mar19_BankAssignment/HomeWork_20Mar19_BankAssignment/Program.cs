using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_20Mar19_BankAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer adam = new Customer("Adam", 0508312222, 406573892);
            Customer adi = new Customer("adi", 0543456678, 987309877);
            Customer yonatan = new Customer("yonatan", 0509876666, 334455678);

            Account a = new Account(5500, adam, 0);
            Account b = new Account(16_000, adi, 2000);
            Account c = new Account(33_000, yonatan, 40_000);
            Account d = new Account(33_000, adam, 40_000);


            Bank bank = new Bank();

            bank.AddNewCustomer(adam);
            try
            {
                bank.OpenNewAccount(adam, a);
            }
            catch (AccountAlreadyExistException e)
            {
                
                Console.WriteLine("Account Already Exist in The Bank", e);
            }

            try
            {
                bank.OpenNewAccount(adam, d);
            }
            catch (AccountAlreadyExistException e)
            {

                Console.WriteLine("Account Already Exist in The Bank", e);
            }

            Console.WriteLine($"acoount number:{d.AccountNumber}, with balance: {d.Balance} balance after addint $$$: {d + 70_000}");
            Console.WriteLine($"acoount number:{d.AccountNumber}, with balance: {d.Balance} balance after reduce $$$: {d - 70_000}");


            try
            {
                bank.OpenNewAccount(adam, a);
            }
            catch (AccountAlreadyExistException e)
            {

                Console.WriteLine("Account Already Exist in The Bank", e);
            }

            bank.Deposit(a, 4567);
            bank.Withdrow(a,88);

            bank.PrintMapCustIdToCust();
            try
            {
                Console.WriteLine($"the balance is: {bank.GetCustomerTotalBalance(adam)}");
            }
            catch (CustomerNotFoundException e)
            {

                Console.WriteLine("cust have no accounts in the bank", e);
            }

            try
            {
                bank.GetCustomerByINumber(adam.CustomerNumber);
               
            }
            catch (CustomerNotFoundException e)
            {

                Console.WriteLine("cust have no accounts in the bank, yet ", e);
            }

            bank.AddNewCustomer(adi);

            try
            {
                bank.OpenNewAccount(adi, b);
            }
            catch (AccountAlreadyExistException e)
            {

                Console.WriteLine("Account Already Exist in The Bank", e);
            }

            try
            {
                bank.JoinAccounts(a,d);
            }
            catch (NotSameCustomerException e)
            {
                Console.WriteLine("not same cust");
            }

            bank.ChargeAnnualCommossion(0.5f);

            Console.WriteLine( bank.GetCustomerTotalBalance(adam));
            bank.PrintMapCustIdToCust();
        }
    }
}
