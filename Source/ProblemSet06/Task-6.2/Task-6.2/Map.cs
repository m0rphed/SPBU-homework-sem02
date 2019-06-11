namespace Task_6.Problem2
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Represents map of the game.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Stores structure of the map.
        /// </summary>
        private readonly string[] _cells;

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// Reads map and startup position from the configuration file.
        /// </summary>
        /// <param name="lines">content of map configuration file.</param>
        public Map(string[] lines)
        {
            _cells = lines
                .Select(x => x.Replace("\t", string.Empty.PadRight(4)))
                .ToArray();

            Height = _cells.Length - 1;
            Width = _cells.Select(x => x.Length).Max();
            var playerPosition = _cells[_cells.Length - 1].Split(',');
            StartUpPosition = new Position(Convert.ToInt32(playerPosition[0]), Convert.ToInt32(playerPosition[1]));
        }

        public int Height { get; private set; }

        public int Width { get; private set; }

        /// <summary>
        /// Gets startup position of the player.
        /// </summary>
        public Position StartUpPosition { get; private set; }

        /// <summary>
        /// Gets symbol of the map on specified position.
        /// </summary>
        /// <param name="x">x coordinate to check.</param>
        /// <param name="y">y coordinate to check.</param>
        /// <returns>symbol on specified position.</returns>
        public char GetSymbol(int x, int y) => _cells[y][x];

        /// <summary>
        /// Checks if there is a wall on the map.
        /// </summary>
        /// <param name="x">x coordinate to check.</param>
        /// <param name="y">y coordinate to check.</param>
        /// <returns>true if there is a wall on specified position.</returns>
        public bool IsWall(int x, int y) => _cells[y][x] != ' ';
    }
}
