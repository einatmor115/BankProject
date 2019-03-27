using System;
using System.Runtime.Serialization;

namespace HomeWork_20Mar19_BankAssignment
{
    [Serializable]
    internal class BalanceException : ApplicationException
    {
        public BalanceException()
        {
        }

        public BalanceException(string message) : base(message)
        {
        }

        public BalanceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BalanceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}