using System;
using System.ComponentModel;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var running = true;

            if (args.Length != 0)
            {
                input = args[0];
            }
            else
            {
                Console.WriteLine(Resource.Request);
                input = Console.ReadLine();
            }

            while (running)
            {
                switch (input)
                {
                    case "2.1":
                        var stringArray2_1 = Resource.day2.Split(',');
                        
                        try
                        {
                            var d2_1 = new Day2.Day2(stringArray2_1);
                            Console.WriteLine(Resource.Output, input, d2_1.Calculate());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(Resource.Error, input, Environment.NewLine, e.Message, Environment.NewLine, e.StackTrace);
                        }
                        break;

                    case "2.2":

                        var stringArray2_2 = Resource.day2.Split(',');

                        try
                        {
                            var d2_2 = new Day2.Day2(stringArray2_2);
                            var calculate = d2_2.FindCalculatedValue(19690720,0,99);

                            Console.WriteLine(Resource.Output, input, calculate);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(Resource.Error, input, Environment.NewLine, e.Message, Environment.NewLine, e.StackTrace);
                        }
                        break;

                    case "3.1":
                        try
                        {
                            var d3_1 = new Day3();
                            Console.WriteLine(d3_1.FindSolution(Resource.Wire1, Resource.Wire2));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(Resource.Error, input, Environment.NewLine, e.Message, Environment.NewLine, e.StackTrace);
                            throw;
                        }

                        break;

                    case "finish":
                        running = false;
                        break;

                    default:
                        Console.WriteLine(Resource.Invalid, Environment.NewLine);
                        break;
                        
                }

                Console.WriteLine(Resource.Request);
                input = Console.ReadLine();
            }
            
        }
    }
}
