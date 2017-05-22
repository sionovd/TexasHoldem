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
            Console.WriteLine(new Deck().GetSize());
            Console.Read();

        }
    }
}
