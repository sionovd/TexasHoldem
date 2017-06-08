using System;
using System.Runtime.Serialization;
using Domain.ServiceLayer;

namespace Domain
{
    [Serializable]
    internal class illegalbuyInException : DomainException
    {
        public illegalbuyInException()
        : base() { }

        public illegalbuyInException(string message)
        : base(String.Format("Invalid game policy: {0} , expected not negative value." , message)) { }

    }
}