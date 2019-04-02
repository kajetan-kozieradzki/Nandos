using MarsRovers.Infrastructure;
using System;
using System.Text;

namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("5 5");
            stringBuilder.AppendLine("1 2 N");
            stringBuilder.AppendLine("LMLMLMLMM");
            stringBuilder.AppendLine("3 3 E");
            stringBuilder.AppendLine("MMRMMRMRRM");

            var inputString = stringBuilder.ToString();
            var inputParser = new InputParser(inputString);
            var plateauSize = inputParser.ParsePlateauSize();
            var roverDescriptors = inputParser.ParseRoverDescriptors();

            var roverRunner = new RoverRunner(plateauSize.Item1, plateauSize.Item2);
            var result1 = roverRunner.Run(roverDescriptors[0]);
            var result2 = roverRunner.Run(roverDescriptors[1]);

            Console.WriteLine($"{result1.Item1} {result1.Item2} {result1.Item3}");
            Console.WriteLine($"{result2.Item1} {result2.Item2} {result2.Item3}");

            Console.ReadLine();

            /*** More test scenarios can be found in the MarsRovers.IntegrationTets project ***/
        }
    }
}
