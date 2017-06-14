using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class illegalMaxPlayersException : DomainException
    {
        public illegalMaxPlayersException()
        { }

        public illegalMaxPlayersException(string message)
        : base(String.Format("invalid max bet: {0}, expected value <= 9",message)) { }
    }
}