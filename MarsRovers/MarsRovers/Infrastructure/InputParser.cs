using System;
using System.Collections.Generic;
using System.IO;

namespace MarsRovers.Infrastructure
{
    /// <summary>
    /// Parses the input string
    /// </summary>
    public class InputParser : IDisposable
    {
        private StringReader _stringReader;

        private bool _parsePlateauSizeHasBeenCalled;

        private const string CallParsePlateauSizeFirstErrorMessage = "You must call the ParsePlateauSize method first";

        /// <summary>
        /// Initialises the parser with the input string
        /// </summary>
        /// <param name="input">The input string</param>
        public InputParser(string input)
        {
            _stringReader = new StringReader(input);
        }

        /// <summary>
        /// Releases all resources used by the InputParser object
        /// </summary>
        public void Dispose()
        {
            if (_stringReader != null)
            {
                _stringReader.Dispose();
            }
        }

        /// <summary>
        /// Parses plateau's size from the first line of the input
        /// </summary>
        /// <returns>(width, height) of the plateau</returns>
        public (uint, uint) ParsePlateauSize()
        {
            var firstLine = _stringReader.ReadLine().Trim();
            var chunks = firstLine.Split(' ');

            _parsePlateauSizeHasBeenCalled = true;

            return (uint.Parse(chunks[0]), uint.Parse(chunks[1]));
        }

        /// <summary>
        /// Parses rover descriptors from the rest of the input file
        /// </summary>
        /// <returns>Rover descriptors</returns>
        public RoverDescriptor[] ParseRoverDescriptors()
        {
            if (!_parsePlateauSizeHasBeenCalled)
            {
                throw new Exception(CallParsePlateauSizeFirstErrorMessage);
            }

            var result = new List<RoverDescriptor>();
            while (_stringReader.Peek() != -1)
            {
                var firstLine = _stringReader.ReadLine().Trim();
                var firstLineChunks = firstLine.Split(' ');

                var secondLine = _stringReader.ReadLine().Trim();
                var roverDescriptor = new RoverDescriptor
                {
                    Position = (uint.Parse(firstLineChunks[0]), uint.Parse(firstLineChunks[1])),
                    Direction = firstLineChunks[2][0],
                    Instructions = secondLine.ToCharArray()
                };

                result.Add(roverDescriptor);
            }

            return result.ToArray();
        }
    }
}
