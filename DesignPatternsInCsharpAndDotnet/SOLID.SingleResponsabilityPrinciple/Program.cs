using System;
using System.Collections.Generic;

namespace SOLID.SingleResponsabilityPrinciple
{
    class Program
    {
        public class Journal
        {
            private readonly List<string> entries = new List<string>();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
