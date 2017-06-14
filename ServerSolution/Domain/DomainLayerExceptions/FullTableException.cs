using System;

namespace Domain.DomainLayerExceptions
{
    public class FullTableException : DomainException
    {
        public FullTableException()
        : base("table is full") { }

        public FullTableException(string message)
        : base(String.Format(message)) { }
    }
}
