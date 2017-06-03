using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class NoUserNameException : DomainException
    {
        public NoUserNameException(string username)
        {
            Console.Error.WriteLine(username + " this name already exits.");
        }
    }
}
