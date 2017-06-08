using System;
using System.Runtime.Serialization;

namespace Domain.GameModule
{
    [Serializable]
    class BetFailedException : DomainException
    {
        public BetFailedException(string message) : base(message)
        {
        }
    }
}