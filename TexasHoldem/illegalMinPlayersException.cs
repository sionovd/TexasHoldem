using System;
using System.Runtime.Serialization;

namespace TexasHoldem
{
    [Serializable]
    internal class illegalMinPlayersException : Exception
    {
        public illegalMinPlayersException()
        : base() { }

        public illegalMinPlayersException(string message)
        : base(String.Format("invalid min players: {0}, expected value >= 2",message)) { }
    }
}