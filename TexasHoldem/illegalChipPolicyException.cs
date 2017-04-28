using System;
using System.Runtime.Serialization;

namespace TexasHoldem
{
    [Serializable]
    internal class illegalChipPolicyException : Exception
    {
        public illegalChipPolicyException()
        : base() { }

        public illegalChipPolicyException(string message)
        : base(String.Format("Invalid chip policy: {0} , expected not negative value." , message)) { }

    }
}