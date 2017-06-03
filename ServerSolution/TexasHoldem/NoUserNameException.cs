﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexasHoldem
{
    public class NoUserNameException : DomainException
    {
        public NoUserNameException(string username)
        {
            Console.Error.WriteLine(username + " this name already exits.");
        }
    }
}