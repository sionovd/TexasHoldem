using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    class AlreadyJoinedGameException : DomainException
    {
        public AlreadyJoinedGameException(string message) : base(message)
        {
        }

    }
}