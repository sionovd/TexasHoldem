using System;

namespace Domain.DomainLayerExceptions
{
    public class NoUserNameException : DomainException
    {
        public NoUserNameException(string username)
        {
            Console.Error.WriteLine(username + " this name already exits.");
        }
    }
}
