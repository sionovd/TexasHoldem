using System;
using System.Runtime.Serialization;
using TexasHoldem.GameModule;

namespace TexasHoldem.GameCenterModule
{
    [Serializable]
    public class NotEnoughPlayersException : DomainException
    {
        public NotEnoughPlayersException(string message) : base(message)
        {
        }
    }
}