using System;
using System.Runtime.Serialization;

namespace TexasHoldem.GameModule
{
    [Serializable]
    internal class GameAlreadyStartedException : DomainException
    {

        public GameAlreadyStartedException(string message) : base(message)
        {
        }

        
    }
}