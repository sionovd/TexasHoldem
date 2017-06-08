using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class NoBetToCallException : DomainException
    {
        public NoBetToCallException()
        {
        }

        public NoBetToCallException(string message) : base(message)
        {
        }
    }
}