using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.ServiceLayer;

namespace Domain
{
    public class AlreadyHasNameException : DomainException
    {
        public AlreadyHasNameException(string name) : base()
        {
            Console.Error.WriteLine(name + " this name already exits.");

        }
    }
}
