using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class illegalChipPolicyException : DomainException
    {
        public illegalChipPolicyException()
        : base() { }

        public illegalChipPolicyException(string message)
        : base(String.Format("Invalid chip policy: {0} , expected not negative value." , message)) { }

    }
}