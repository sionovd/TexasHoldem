using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class NoMoreChipsException : DomainException
    {
        public NoMoreChipsException()
        {
        }

        public NoMoreChipsException(string message) : base(message)
        {
        }
    }
}