namespace MarsRovers.Logic
{
    /// <summary>
    /// Represents a location
    /// </summary>
    public struct Location
    {
        /// <summary>
        /// Construct a new location
        /// </summary>
        /// <param name="longitude">The X coordinate</param>
        /// <param name="latitude">The Y coordinate</param>
        public Location(uint longitude, uint latitude)
        {
            X = longitude;
            Y = latitude;
        }

        /// <summary>
        /// Gets or sets the X coordinate
        /// </summary>
        public uint X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate
        /// </summary>
        public uint Y { get; set; }
    }
}
