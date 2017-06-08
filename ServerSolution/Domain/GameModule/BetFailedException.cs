using System;
using System.Runtime.Serialization;
using Domain.ServiceLayer;

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