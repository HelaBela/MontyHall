using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameSimulator = new GameSimulator();

            var result = gameSimulator.SimulateGame();
            
            Console.WriteLine(result);
        }

    }
}