﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexasHoldem
{
    public class allreadyHasNameException : DomainException
    {
        public allreadyHasNameException(string name) : base()
        {
            Console.Error.WriteLine(name + " this name already exits.");

        }
    }
}
