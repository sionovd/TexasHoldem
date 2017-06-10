using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class GameAlreadyStartedException : DomainException
    {

        public GameAlreadyStartedException(string message) : base(message)
        {
        }

        
    }
}