using System;

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