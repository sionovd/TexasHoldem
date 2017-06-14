using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class illegalGapPlayersException : DomainException
    {
        public illegalGapPlayersException()
        { }

        public illegalGapPlayersException(string message1, string message2)
        : base(String.Format("Invalid amount of players: minimum players {0} has to be smaller than maximum players {1}", message1,message2)) { }
    }
}