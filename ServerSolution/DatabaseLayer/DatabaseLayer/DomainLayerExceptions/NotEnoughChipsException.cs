using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class NotEnoughChipsException : DomainException
    {
        public NotEnoughChipsException()
        {
        }

        public NotEnoughChipsException(string message) : base(message)
        {
        }
    }
}