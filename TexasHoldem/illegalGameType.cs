using System;
using System.Runtime.Serialization;

namespace TexasHoldem
{
    public class illegalGameTypeException : Exception
    {
        public illegalGameTypeException()
        : base() { }

        public illegalGameTypeException(string message)
        : base(String.Format("Invalid game type: {0} , expected value between 0 and 2." , message)) { }

    /*    public illegalGameTypeException(string format, params object[] args)
        : base(string.Format(format, args)) { }

        public illegalGameTypeException(string message, Exception innerException)
        : base(message, innerException) { }

        public illegalGameTypeException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }

        protected illegalGameTypeException(SerializationInfo info, StreamingContext context)
        : base(info, context) { } */
    }
}