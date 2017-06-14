using System;

namespace Domain.DomainLayerExceptions
{
    public class AlreadyHasNameException : DomainException
    {
        public AlreadyHasNameException(string name)
        {
            Console.Error.WriteLine(name + " this name already exits.");

        }
    }
}
