using System;

namespace Domain.DomainLayerExceptions
{
    [Serializable]
    internal class illegalbuyInException : DomainException
    {
        public illegalbuyInException()
        { }

        public illegalbuyInException(string message)
        : base(String.Format("Invalid game policy: {0} , expected not negative value." , message)) { }

    }
}