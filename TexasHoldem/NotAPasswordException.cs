using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TexasHoldem
{
    [Serializable]
    public  class NotAPasswordException : DomainException
    {
        public NotAPasswordException (string password) 
        {
            Console.Error.WriteLine("Invalid password: " +password);
         
        }
    }
}
