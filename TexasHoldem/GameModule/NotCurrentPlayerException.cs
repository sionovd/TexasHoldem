using System;
using System.Runtime.Serialization;

namespace TexasHoldem.GameModule
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