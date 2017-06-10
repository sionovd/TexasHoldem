using System;

namespace Domain.DomainLayerExceptions
{
    public class AlreadyHasNameException : DomainException
    {
        public AlreadyHasNameException(string name) : base()
        {
            Console.Error.WriteLine(name + " this name already exits.");

        }
    }
}
