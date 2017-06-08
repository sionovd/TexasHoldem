using System;
using System.Runtime.Serialization;
using Domain.ServiceLayer;

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