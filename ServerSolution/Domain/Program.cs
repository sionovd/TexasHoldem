using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.GameModule;
using Domain.ServiceLayer;

namespace Domain
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
