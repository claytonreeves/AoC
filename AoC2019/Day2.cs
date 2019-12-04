using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC2019.Day2
{
    class Day2
    {
        private int[] _input;
        private readonly int[] _inputBak;

        public Day2(string[] input)
        {
            if ((input.Length-1)%4 == 0)
            {
                _input = Array.ConvertAll(input, s => int.Parse(s));
                _inputBak = (int[])_input.Clone();
            }
            else
            {
                throw new InvalidDataException();
            }
        }

        public int Calculate(int noun = 12, int verb = 2)
        {
            _input[1] = noun;
            _input[2] = verb;
            for (int i = 0; i < _input.Length-1; i+=4)
            {
                var left = _input[_input[i + 1]];
                var right = _input[_input[i + 2]];
                var res = _input[i + 3];

                switch (_input[i])
                {
                    case 1:
                        _input[res] = CalculateSum(left, right);
                        break;
                    case 2:
                        _input[res] = CalculateMultiple(left, right);
                        break;
                    case 99:
                        return _input[0];
                    default:
                        throw new InvalidOperationException();
                }
            }
            throw new InvalidOperationException();
        }

        public int FindCalculatedValue(int valueToFind, int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                for (int j = min; j < max; j++)
                {
                    var value = Calculate(i, j);
                    if (value == valueToFind)
                    {
                        Console.WriteLine($"The Values are {i} and {j} They come to {100*i+j}");
                        return value;
                    }
                    Console.WriteLine(valueToFind - value);
                    reset();
                }
            }
            Console.WriteLine($"No Values Found!!!");
            return 0;
        }

        private void reset()
        {
            _input = (int[])_inputBak.Clone();
        }

        private int CalculateMultiple(int l, int r)
        {
            return l * r;
        }

        private int CalculateSum(int l, int r)
        {
            return l + r;
        }

        
    }
}
