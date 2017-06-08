using System;
using System.Runtime.Serialization;
using Domain.ServiceLayer;

namespace Domain.GameModule
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