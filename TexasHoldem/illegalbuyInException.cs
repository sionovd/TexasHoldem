using System;
using System.Runtime.Serialization;

namespace TexasHoldem
{
    [Serializable]
    internal class illegalbuyInException : Exception
    {
        public illegalbuyInException()
        : base() { }

        public illegalbuyInException(string message)
        : base(String.Format("Invalid game policy: {0} , expected not negative value." , message)) { }

    }
}