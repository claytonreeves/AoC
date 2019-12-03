using System;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var running = true;
            while (running)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter the Unit to Run.");
                    input = Console.ReadLine();
                }
                else
                {
                    input = args[0];
                }

                switch (input)
                {
                    case "2.1":

                        break;

                    default:
                        running = false;
                        break;
                        
                }
            }
            
        }
    }
}
