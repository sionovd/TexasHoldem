using System;
using System.Runtime.Serialization;

namespace TexasHoldem
{
    [Serializable]
    internal class illegalGapPlayersException : DomainException
    {
        public illegalGapPlayersException()
        : base() { }

        public illegalGapPlayersException(string message1, string message2)
        : base(String.Format("Invalid amount of players: maxinmum players {0} has to be greater than minimum players {1}", message1,message2)) { }
    }
}