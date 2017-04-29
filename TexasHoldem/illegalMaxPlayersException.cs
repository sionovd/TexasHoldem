using System;
using System.Runtime.Serialization;

namespace TexasHoldem
{
    [Serializable]
    internal class illegalMaxPlayersException : DomainException
    {
        public illegalMaxPlayersException()
        : base() { }

        public illegalMaxPlayersException(string message)
        : base(String.Format("invalid max bet: {0}, expected value <= 9",message)) { }
    }
}