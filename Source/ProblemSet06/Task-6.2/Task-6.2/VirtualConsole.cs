namespace Task_6.Problem2
{
    using System;

    /// <summary>
    /// Represents console GUI.
    /// </summary>
    public class VirtualConsole : IVirtualConsole
    {
        /// <summary>
        /// Draws the map with borders.
        /// </summary>
        /// <param name="map">instance of a map.</param>
        public void RenderMap(Map map)
        {
            Console.CursorVisible = false;
            Console.WindowHeight = map.Height + 1;
            Console.WindowWidth = map.Width + 1;

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth + 1;

            Console.Title = "The Adventures Of Brave @";
            Console.Clear();

            Console.CursorLeft = 0;
            Console.CursorTop = 1;

            for (var y = 0; y < map.Height; ++y)
            {
                for (var x = 0; x < map.Width; ++x)
                {
                    Console.Write(map.GetSymbol(x, y));
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Draws or hides player "@".
        /// </summary>
        /// <param name="position">player's position on the map.</param>
        /// <param name="isVisible">boolean flag.</param>
        public void DrawPlayer(Position position, bool isVisible)
        {
            var color = Console.ForegroundColor;
            Console.CursorLeft = position.X;
            Console.CursorTop = position.Y;
            Console.ForegroundColor = isVisible ? ConsoleColor.DarkRed : color;
            Console.Write(isVisible ? "@" : " ");
            Console.ForegroundColor = color;
        }
    }
}
