using System;
using System.Runtime.Serialization;
using Domain.ServiceLayer;

namespace Domain.GameModule
{
    [Serializable]
    internal class NotEnoughChipsException : DomainException
    {
        public NotEnoughChipsException()
        {
        }

        public NotEnoughChipsException(string message) : base(message)
        {
        }
    }
}