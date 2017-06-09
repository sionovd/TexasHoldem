using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    class BetFailedException : DomainException
    {
        public BetFailedException(string message) : base(message)
        {
        }
    }
}