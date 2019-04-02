using MarsRovers.Infrastructure;
using Xunit;

namespace MarsRovers.IntegrationTests.Infrastructure
{
    public class TestScenarios
    {
        [Fact]
        public void Scenario1()
        {
            var inputString = @"5 5
                                1 2 N
                                LMLMLMLMM
                                3 3 E
                                MMRMMRMRRM";

            var inputParser = new InputParser(inputString);
            var plateauSize = inputParser.ParsePlateauSize();
            var roverDescriptors = inputParser.ParseRoverDescriptors();

            Assert.Equal(2, roverDescriptors.Length);

            var roverRunner = new RoverRunner(plateauSize.Item1, plateauSize.Item2);
            var result1 = roverRunner.Run(roverDescriptors[0]);

            Assert.Equal(1u, result1.Item1);
            Assert.Equal(3u, result1.Item2);
            Assert.Equal('N', result1.Item3);

            var result2 = roverRunner.Run(roverDescriptors[1]);

            Assert.Equal(5u, result2.Item1);
            Assert.Equal(1u, result2.Item2);
            Assert.Equal('E', result2.Item3);
        }

        [Fact]
        public void Scenario2()
        {
            var inputString = @"7 8
                                2 4 N
                                MMLMLMMLM
                                0 0 S
                                RRMMRMM";

            var inputParser = new InputParser(inputString);
            var plateauSize = inputParser.ParsePlateauSize();
            var roverDescriptors = inputParser.ParseRoverDescriptors();

            Assert.Equal(2, roverDescriptors.Length);

            var roverRunner = new RoverRunner(plateauSize.Item1, plateauSize.Item2);
            var result1 = roverRunner.Run(roverDescriptors[0]);

            Assert.Equal(2u, result1.Item1);
            Assert.Equal(4u, result1.Item2);
            Assert.Equal('E', result1.Item3);

            var result2 = roverRunner.Run(roverDescriptors[1]);

            Assert.Equal(2u, result2.Item1);
            Assert.Equal(2u, result2.Item2);
            Assert.Equal('E', result2.Item3);
        }
    }
}
