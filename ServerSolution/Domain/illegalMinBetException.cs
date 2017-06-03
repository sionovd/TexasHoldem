using System;
using System.Runtime.Serialization;

namespace Domain
{
    [Serializable]
    internal class illegalMinBetException : DomainException
    {
        public illegalMinBetException()
        : base() { }

        public illegalMinBetException(string message)
        : base(String.Format("invalid min bet: {0}, expected positive value",message)) { }

    }
}