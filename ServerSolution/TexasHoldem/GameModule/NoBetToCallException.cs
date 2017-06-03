using System;
using System.Runtime.Serialization;

namespace TexasHoldem.GameModule
{
    [Serializable]
    internal class NoBetToCallException : DomainException
    {
        public NoBetToCallException()
        {
        }

        public NoBetToCallException(string message) : base(message)
        {
        }
    }
}