using System;
using System.Runtime.Serialization;

namespace HomeWork_20Mar19_BankAssignment
{
    [Serializable]
    internal class NotSameCustomerException : ApplicationException
    {
        public NotSameCustomerException()
        {
        }

        public NotSameCustomerException(string message) : base(message)
        {
        }

        public NotSameCustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSameCustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}