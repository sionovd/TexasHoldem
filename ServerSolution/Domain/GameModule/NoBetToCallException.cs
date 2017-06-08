using System;
using System.Runtime.Serialization;
using Domain.ServiceLayer;

namespace Domain.GameModule
{
    [Serializable]
    internal class NoBetToCallException : DomainException
    {
        public NoBetToCallException()
        {
        }

        public NoBetToCallException(string message) : base(message)
        {
        }
    }
}