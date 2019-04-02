using MarsRovers.Enums;
using MarsRovers.Logic;
using System;

namespace MarsRovers.Infrastructure
{
    /// <summary>
    /// Runs a single rover
    /// </summary>
    public class RoverRunner
    {
        private Plateau _plateau;

        private const string UnknownInstructionErrorMessage = "Unknown instruction {0}";

        private const string UnknownDirectionErrorMessage = "Unknown direction {0}";

        /// <summary>
        /// Creates an instance of the runner
        /// </summary>
        /// <param name="plateauWidth">Plateau's width</param>
        /// <param name="plateauHeight">Plateau's hight</param>
        public RoverRunner(uint plateauWidth, uint plateauHeight)
        {
            _plateau = new Plateau(plateauWidth, plateauHeight);
        }

        /// <summary>
        /// Runs the rover
        /// </summary>
        /// <param name="roverDescriptor">Description of the rover</param>
        /// <returns>(X, Y, H) - coordinates and heading</returns>
        public (uint, uint, char) Run(RoverDescriptor roverDescriptor)
        {
            var location = new Location(roverDescriptor.Position.Item1, roverDescriptor.Position.Item2);
            var direction = ParseDirection(roverDescriptor.Direction);
            var rover = new Rover(_plateau, location, direction);

            foreach (char instruction in roverDescriptor.Instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        rover.TurnLeft();
                        break;

                    case 'R':
                        rover.TurnRight();
                        break;

                    case 'M':
                        rover.MoveForward();
                        break;

                    default:
                        throw new Exception(string.Format(UnknownInstructionErrorMessage, instruction));
                }
            }

            return (rover.Location.X, rover.Location.Y, EncodeDirection(rover.Direction));
        }

        private Direction ParseDirection(char direction)
        {
            switch (direction)
            {
                case 'N':
                    return Direction.North;

                case 'W':
                    return Direction.West;

                case 'S':
                    return Direction.South;

                case 'E':
                    return Direction.East;

                default:
                    throw new Exception(string.Format(UnknownDirectionErrorMessage, direction));
            }
        }

        private char EncodeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return 'N';

                case Direction.West:
                    return 'W';

                case Direction.South:
                    return 'S';

                case Direction.East:
                    return 'E';

                default:
                    throw new Exception(string.Format(UnknownDirectionErrorMessage, Enum.GetName(typeof(Direction), direction)));
            }
        }
    }
}
