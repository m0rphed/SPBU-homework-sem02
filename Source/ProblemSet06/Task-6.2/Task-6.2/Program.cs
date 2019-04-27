namespace Task_6.Problem2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var map = new Map("map.txt");
            var vc = new VirtualConsole();
            vc.RenderMap(map);

            var gameLoop = new EventLoop();
            var gameLogic = new GameLogic(map, gameLoop, vc);

            gameLoop.Start();
        }
    }
}
