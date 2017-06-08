using System;
using System.Runtime.Serialization;

namespace Domain.GameModule
{
    [Serializable]
    class AlreadyJoinedGameException : DomainException
    {
        public AlreadyJoinedGameException(string message) : base(message)
        {
        }

    }
}