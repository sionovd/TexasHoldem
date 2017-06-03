using System;
using System.Runtime.Serialization;

namespace Domain
{
    [Serializable]
    internal class illegalMinPlayersException : DomainException
    {
        public illegalMinPlayersException()
        : base() { }

        public illegalMinPlayersException(string message)
        : base(String.Format("invalid min players: {0}, expected value >= 2",message)) { }
    }
}