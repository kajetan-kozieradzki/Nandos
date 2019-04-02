using MarsRovers.Enums;
using MarsRovers.Logic;
using System;
using Xunit;

namespace MarsRovers.Tests.Logic
{
    public class RoverShould
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 5)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        public void BeAbleToLandOnThePlateau(uint x0, uint y0)
        {
            var plateau = new Plateau(5, 5);
            var location = new Location(x0, y0);
            var direction = Direction.North;
            var rover = new Rover(plateau, location, direction);

            Assert.NotNull(rover);
        }

        [Theory]
        [InlineData(6, 5)]
        [InlineData(4, 6)]
        [InlineData(7, 7)]
        public void NotBeLocatedOutsideOfThePlateau(uint x0, uint y0)
        {
            var plateau = new Plateau(5, 5);
            var location = new Location(x0, y0);
            var direction = Direction.North;

            Assert.Throws<Exception>(() => new Rover(plateau, location, direction));
        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        public void BeAbleToTurnLeft(Direction initialDirection, Direction finalDirection)
        {
            var plateau = new Plateau(5, 5);
            var location = new Location(1, 1);

            var rover = new Rover(plateau, location, initialDirection);
            rover.TurnLeft();

            Assert.Equal(finalDirection, rover.Direction);
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void BeAbleToTurnRight(Direction initialDirection, Direction finalDirection)
        {
            var plateau = new Plateau(5, 5);
            var location = new Location(1, 1);

            var rover = new Rover(plateau, location, initialDirection);
            rover.TurnRight();

            Assert.Equal(finalDirection, rover.Direction);
        }

        [Fact]
        public void BeAbleToTurnMultipleTimes()
        {
            var plateau = new Plateau(5, 5);
            var location = new Location(1, 1);
            var direction = Direction.South;

            var rover = new Rover(plateau, location, direction);
            rover.TurnRight();
            rover.TurnRight();
            rover.TurnLeft();
            rover.TurnRight();
            rover.TurnRight();

            Assert.Equal(Direction.East, rover.Direction);
        }

        [Theory]
        [InlineData(1, 2, Direction.West, 0, 2)]
        [InlineData(2, 3, Direction.North, 2, 4)]
        [InlineData(2, 1, Direction.South, 2, 0)]
        [InlineData(3, 2, Direction.East, 4, 2)]
        public void ShouldBeAbleToMoveWhenNotOnTheEdge(uint x0, uint y0, Direction direction, uint x1, uint y1)
        {
            var plateau = new Plateau(5, 5);
            var location = new Location(x0, y0);

            var rover = new Rover(plateau, location, direction);
            rover.MoveForward();

            Assert.Equal(rover.Location.X, x1);
            Assert.Equal(rover.Location.Y, y1);
        }

        [Theory]
        [InlineData(0, 0, Direction.West)]
        [InlineData(2, 5, Direction.North)]
        [InlineData(3, 0, Direction.South)]
        [InlineData(5, 4, Direction.East)]
        public void ShouldNotBeAbleToMoveWhenOnTheEdge(uint x0, uint y0, Direction direction)
        {
            var plateau = new Plateau(5, 5);
            var location = new Location(x0, y0);

            var rover = new Rover(plateau, location, direction);
            Assert.Throws<Exception>(() => rover.MoveForward());
        }
    }
}
