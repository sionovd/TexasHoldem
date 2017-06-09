using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class AlreadyParticipatingException : Exception
    {
        public AlreadyParticipatingException()
        {
        }

        public AlreadyParticipatingException(string message) : base(message)
        {
        }
    }
}