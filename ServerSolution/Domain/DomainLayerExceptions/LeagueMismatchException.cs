using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    class LeagueMismatchException : Exception
    {

        public LeagueMismatchException(string message) : base(message)
        {
        }
    }
}