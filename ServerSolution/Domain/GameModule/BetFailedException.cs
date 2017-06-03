using System;
using System.Runtime.Serialization;

namespace TexasHoldem.GameModule
{
    [Serializable]
    class BetFailedException : DomainException
    {
        public BetFailedException(string message) : base(message)
        {
        }
    }
}