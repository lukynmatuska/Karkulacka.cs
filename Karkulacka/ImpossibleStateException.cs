using System;
using System.Runtime.Serialization;

namespace Karkulacka
{
    [Serializable]
    internal class ImpossibleStateException : Exception
    {
        public ImpossibleStateException()
        {
        }

        public ImpossibleStateException(string message) : base(message)
        {
        }

        public ImpossibleStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImpossibleStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}