namespace MarsRovers.Infrastructure
{
    /// <summary>
    /// Describes a rover
    /// </summary>
    public class RoverDescriptor
    {
        /// <summary>
        /// Initial position of the rover
        /// </summary>
        public (uint, uint) Position { get; set; }

        /// <summary>
        /// Initial direction the rover is facing
        /// </summary>
        public char Direction { get; set; }

        /// <summary>
        /// Set of instructions to be executed
        /// </summary>
        public char[] Instructions { get; set; }
    }
}
