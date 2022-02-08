using System;

namespace SOLID.InterfaceSegregation
{
    public class SimplePrinter : ICanPrint
    {

        public void Print()
        {
            Console.WriteLine("Print pages");
        }

    }

}
