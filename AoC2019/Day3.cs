using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AoC2019
{

    class Day3
    {
        private List<Point> Wire1 = new List<Point>();
        private List<Point> Wire2 = new List<Point>();

        public string FindSolution(string wire1, string wire2)
        {
            BuildWireDiagram(wire1, wire2);

            var intersections = Wire1.Intersect(Wire2).Select( x => x).ToList();

            var totalSteps = Wire1.Intersect(Wire2).Select(x => Wire1.IndexOf(x) + Wire2.IndexOf(x))
                                       .OrderBy(w => w).ToList();

            var leastTotalSteps = totalSteps.First() + 2;

            var closestIntersection = intersections.Select(x => Math.Abs(x.X) + Math.Abs(x.Y)).Min();

            return $"The Closest Intersection is {closestIntersection} Units Away from the origin. The Fewest Steps is {leastTotalSteps}.";
        }


        private void BuildWireDiagram(string wire1, string wire2)
        {
            var wire1List = wire1.Split(',').ToList();
            var wire2List = wire2.Split(',').ToList();

            Wire1 = ParseWire(wire1List);
            Wire2 = ParseWire(wire2List);
        }

        private List<Point> ParseWire(List<string> wire1List)
        {
            var returnList = new List<Point>();
            var point = new Point(0,0);
            
            foreach (var vector in wire1List)
            {
                var direction = vector[0];
                var magnitude = int.Parse(vector.Substring(1));

                switch (direction)
                {
                    case 'U':
                        returnList.AddRange(MoveInY(point, 1, magnitude));
                        point.Y += magnitude;
                        break;

                    case 'D':
                        returnList.AddRange(MoveInY(point, -1, magnitude));
                        point.Y -= magnitude;
                        break;

                    case 'L':
                        returnList.AddRange(MoveInX(point, -1, magnitude));
                        point.X -= magnitude;
                        break;

                    case 'R':
                        returnList.AddRange(MoveInX(point, 1, magnitude));
                        point.X += magnitude;
                        break;

                    default:
                        Console.WriteLine($"Error, can't parse this value.");
                        break;
                }
            }

            return returnList;
        }

        private List<Point> MoveInX(Point point, int direction, int amount)
        {
            var movement = new List<Point>();

            for (int i = 0; i < amount; i++)
            {
                point.X += direction;
                movement.Add(point);
            }

            return movement;
        }

        private List<Point> MoveInY(Point point, int direction, int amount)
        {
            var movement = new List<Point>();

            for (int i = 0; i < amount; i++)
            {
                point.Y += direction;
                movement.Add(point);
            }

            return movement;
        }

    }
}
