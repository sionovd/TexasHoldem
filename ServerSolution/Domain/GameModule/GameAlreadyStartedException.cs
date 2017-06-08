using System;
using System.Runtime.Serialization;
using Domain.ServiceLayer;

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