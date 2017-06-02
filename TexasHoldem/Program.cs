using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.GameModule;

namespace TexasHoldem
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("hi");
            Console.ReadKey();
            ErrorLogger.LogError(new DomainException());

        }
    }
}
