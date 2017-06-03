using System;
using System.Runtime.Serialization;

namespace TexasHoldem.GameModule
{
    [Serializable]
    class AlreadyJoinedGameException : DomainException
    {
        public AlreadyJoinedGameException(string message) : base(message)
        {
        }

    }
}