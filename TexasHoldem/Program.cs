using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("HUMUS!");
                Console.WriteLine("Y/n?");
                string c = Console.ReadLine();
                if (c.Equals("Y") || c.Equals("y")) break;
                else
                {
                    Console.WriteLine("Wrong!\n");
                }
            }
        }
    }
}
