using System;
using System.Runtime.Serialization;

namespace HomeWork_20Mar19_BankAssignment
{
    [Serializable]
    internal class CustomerNotFoundException : ApplicationException
    {
        public CustomerNotFoundException()
        {
        }

        public CustomerNotFoundException(string message) : base(message)
        {
        }

        public CustomerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}