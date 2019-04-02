using MarsRovers.Enums;
using System;

namespace MarsRovers.Logic
{
    /// <summary>
    /// Represents a rover
    /// </summary>
    public class Rover
    {
        private Plateau _plateau;

        private Location _currentLocation;

        private Direction _currentDirection;

        private const string RoverCannotLeavePlateauErrorMessage = "Rover cannot leave the plateau";

        private const string RoverCannotBeLocatedOutsideOfPlateauErrorMessage = "Rover cannot be located outside of the plateau"; 

        /// <summary>
        /// Constructs a new rover
        /// </summary>
        /// <param name="plateau">The plateau to land on</param>
        /// <param name="initialLocation">Initial rover's location</param>
        /// <param name="initialDirection">Initial direction the rover is facing</param>
        public Rover(Plateau plateau, Location initialLocation, Direction initialDirection)
        {
            _plateau = plateau;
            _currentLocation = initialLocation;
            _currentDirection = initialDirection;

            ValidateCurrentLocation();
        }

        /// <summary>
        /// Makes the rover spin 90 degrees left
        /// </summary>
        public void TurnLeft()
        {
            _currentDirection++;

            if (!Enum.IsDefined(typeof(Direction), _currentDirection))
            {
                _currentDirection = Direction.North;
            }
        }

        /// <summary>
        /// Makes the rover spin 90 degrees right
        /// </summary>
        public void TurnRight()
        {
            _currentDirection--;

            if (!Enum.IsDefined(typeof(Direction), _currentDirection))
            {
                _currentDirection = Direction.East;
            }
        }

        /// <summary>
        /// Moves the rover forward one grid point 
        /// </summary>
        public void MoveForward()
        {
            switch (_currentDirection)
            {
                case Direction.North:
                    MoveNorth();
                    break;

                case Direction.West:
                    MoveWest();
                    break;

                case Direction.South:
                    MoveSouth();
                    break;

                case Direction.East:
                    MoveEast();
                    break;
            }
        }

        /// <summary>
        /// Returns the current location of the rover
        /// </summary>
        public Location Location
        {
            get => _currentLocation;
        }

        /// <summary>
        /// Returns the current direction the rover is facing
        /// </summary>
        public Direction Direction
        {
            get => _currentDirection;
        }

        private void MoveNorth()
        {
            ValidateIfMoveIsPossible(() => _currentLocation.Y + 1 > _plateau.Height);
            
            _currentLocation.Y++;
        }

        private void MoveWest()
        {
            ValidateIfMoveIsPossible(() => _currentLocation.X == 0);

            _currentLocation.X--;
        }

        private void MoveSouth()
        {
            ValidateIfMoveIsPossible(() => _currentLocation.Y == 0);

            _currentLocation.Y--;
        }

        private void MoveEast()
        {
            ValidateIfMoveIsPossible(() => _currentLocation.X == _plateau.Width);

            _currentLocation.X++;
        }

        private void ValidateIfMoveIsPossible(Func<bool> isOnTheEdge)
        {
            if (isOnTheEdge())
            {
                throw new Exception(RoverCannotLeavePlateauErrorMessage);
            }
        }

        private void ValidateCurrentLocation()
        {
            if (_currentLocation.X > _plateau.Width || _currentLocation.Y > _plateau.Height)
            {
                throw new Exception(RoverCannotBeLocatedOutsideOfPlateauErrorMessage);
            }
        }
    }
}
