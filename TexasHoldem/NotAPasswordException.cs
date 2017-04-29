﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexasHoldem
{
    class NotAPasswordException : DomainException
    {
        public NotAPasswordException (string password) :base()
        {
            Console.Error.WriteLine("Invalid password: " +password);
        }
    }
}
