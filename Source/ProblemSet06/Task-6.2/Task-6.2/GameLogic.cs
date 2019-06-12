namespace Task_6.Problem2
{
    /// <summary>
    /// Encapsulates state of the game and controls player on the map.
    /// </summary>
    public class GameLogic
    {
        private readonly Map _map;
        private readonly EventLoop _gameLoop;
        private readonly IVirtualConsole _vc;
        private Position _currentPosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// Sets up state of the game.
        /// </summary>
        /// <param name="map">game map.</param>
        /// <param name="gameLoop">provides events from keyboard.</param>
        /// <param name="vc">virtual console to draw all objects.</param>
        public GameLogic(Map map, EventLoop gameLoop, IVirtualConsole vc)
        {
            _map = map;
            _currentPosition = map.StartUpPosition;
            _gameLoop = gameLoop;
            _vc = vc;
            _vc.DrawPlayer(_currentPosition, true);

            // Adding event handlers for events: MoveUp, MoveDown, etc.
            _gameLoop.MoveUp += GameLoop_MoveUp;
            _gameLoop.MoveDown += GameLoop_MoveDown;
            _gameLoop.MoveLeft += GameLoop_MoveLeft;
            _gameLoop.MoveRight += GameLoop_MoveRight;
            _gameLoop.Exit += GameLoop_Exit;
        }

        /// <summary>
        /// Shifts current position of the player.
        /// </summary>
        /// <param name="dx">horizontal shift.</param>
        /// <param name="dy">vertical shift.</param>
        private void Shift(int dx, int dy)
        {
            if (_currentPosition.X + dx < 0 || _currentPosition.Y + dy < 0)
            {
                return;
            }

            if (_map.IsWall(_currentPosition.X + dx, _currentPosition.Y + dy))
            {
                return;
            }

            _vc.DrawPlayer(_currentPosition, false);
            _currentPosition = new Position(_currentPosition.X + dx, _currentPosition.Y + dy);
            _vc.DrawPlayer(_currentPosition, true);
        }

        private void GameLoop_MoveUp() => Shift(0, -1);

        private void GameLoop_MoveDown() => Shift(0, 1);

        private void GameLoop_MoveLeft() => Shift(-1, 0);

        private void GameLoop_MoveRight() => Shift(1, 0);

        /// <summary>
        /// Stops all this madness.
        /// </summary>
        private void GameLoop_Exit()
        {
            _gameLoop.MoveUp -= GameLoop_MoveUp;
            _gameLoop.MoveDown -= GameLoop_MoveDown;
            _gameLoop.MoveLeft -= GameLoop_MoveLeft;
            _gameLoop.MoveRight -= GameLoop_MoveRight;
            _gameLoop.Exit -= GameLoop_Exit;
        }
    }
}
