using System;
using System.Runtime.Serialization;

namespace TexasHoldem.GameModule
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