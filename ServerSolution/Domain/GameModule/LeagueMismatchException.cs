using System;
using System.Runtime.Serialization;

namespace TexasHoldem.GameModule
{
    [Serializable]
    class LeagueMismatchException : Exception
    {

        public LeagueMismatchException(string message) : base(message)
        {
        }
    }
}