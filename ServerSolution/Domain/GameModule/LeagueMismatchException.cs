using System;
using System.Runtime.Serialization;

namespace Domain.GameModule
{
    [Serializable]
    class LeagueMismatchException : Exception
    {

        public LeagueMismatchException(string message) : base(message)
        {
        }
    }
}