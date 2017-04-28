using System;
using System.Runtime.Serialization;

namespace TexasHoldem
{
    [Serializable]
    internal class illegalMinBetException : Exception
    {
        public illegalMinBetException()
        : base() { }

        public illegalMinBetException(string message)
        : base(String.Format("invalid min bet: {0}, expected positive value",message)) { }

    }
}