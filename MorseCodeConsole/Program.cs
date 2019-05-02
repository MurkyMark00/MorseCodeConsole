using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCodeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Morse.Decode(Morse.Encode("Hello World")));
            Console.ReadLine();
        }
    }
}
