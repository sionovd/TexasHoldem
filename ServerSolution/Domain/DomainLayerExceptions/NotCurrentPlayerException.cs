using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class NotCurrentPlayerException : DomainException
    {
        public NotCurrentPlayerException()
        {
        }

        public NotCurrentPlayerException(string message) : base(message)
        {
        }
    }
}