﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexasHoldem
{
    class AlreadyHasNameException : Exception
    {
        public AlreadyHasNameException(string name) : base()
        {
            Console.Error.WriteLine(name + " this name already exits.");

        }
    }
}