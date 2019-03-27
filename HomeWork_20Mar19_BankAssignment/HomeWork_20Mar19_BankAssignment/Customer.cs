using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_20Mar19_BankAssignment
{
    public class Customer
    {
        private static int numberOfCust;

        private readonly int customerID = 0;
        private readonly int customerNumber = 0;

        public string Name { get; private set; }
        public int PhNumber { get; private set; }
        public int CustomerID { get { return customerID; } }
        public int CustomerNumber { get { return customerNumber; } }

        public Customer(string name, int phNumber, int customerID)
        {
            Name = name;
            PhNumber = phNumber;
            this.customerID = customerID;
            this.customerNumber = ++numberOfCust;

        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            return c1.CustomerID == c2.CustomerID;
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !(c1 == c2);
        }

        public override int GetHashCode()
        {
            return this.customerID;
        }
        public override bool Equals(object obj)
        {
            //if (ReferenceEquals(obj, null))
            //    return false;

            Customer other = obj as Customer;
            return this == other;
        }

    }
}
