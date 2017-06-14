using System;
using Domain.DomainLayerExceptions;

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
