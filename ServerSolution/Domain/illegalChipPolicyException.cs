using System;
using System.Runtime.Serialization;
using Domain.ServiceLayer;

namespace Domain
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