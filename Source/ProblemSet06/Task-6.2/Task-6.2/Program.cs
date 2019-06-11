namespace Task_6.Problem2
{
    using System.IO;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("map.txt");
            var map = new Map(lines);
            var vc = new VirtualConsole();
            vc.RenderMap(map);

            var gameLoop = new EventLoop();
            var gameLogic = new GameLogic(map, gameLoop, vc);

            gameLoop.Start();
        }
    }
}
