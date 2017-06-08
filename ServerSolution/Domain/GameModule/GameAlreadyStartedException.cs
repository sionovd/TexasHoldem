using System;
using System.Runtime.Serialization;

namespace Domain.GameModule
{
    [Serializable]
    internal class GameAlreadyStartedException : DomainException
    {

        public GameAlreadyStartedException(string message) : base(message)
        {
        }

        
    }
}