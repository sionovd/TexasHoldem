using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    public class NotEnoughPlayersException : DomainException
    {
        public NotEnoughPlayersException(string message) : base(message)
        {
        }
    }
}