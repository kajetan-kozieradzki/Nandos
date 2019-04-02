namespace MarsRovers.Logic
{
    /// <summary>
    /// Represents a plateau
    /// </summary>
    public class Plateau
    {
        private readonly uint _width;

        private readonly uint _height;

        /// <summary>
        /// Constructs a new plateau
        /// </summary>
        /// <param name="width">Width of the plateau</param>
        /// <param name="height">Height of the plateau</param>
        public Plateau(uint width, uint height)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Gets the width of the plateau
        /// </summary>
        public uint Width { get => _width; }

        /// <summary>
        /// Gets the height of the plateau
        /// </summary>
        public uint Height { get => _height; }
    }
}
