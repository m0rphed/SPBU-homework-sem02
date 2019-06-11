namespace Task_6.Problem2
{
    using System;

    /// <summary>
    /// Maps keyboard keys to events.
    /// </summary>
    public class EventLoop
    {
        public event Action MoveUp;

        public event Action MoveDown;

        public event Action MoveLeft;

        public event Action MoveRight;

        public event Action Exit;

        public virtual ConsoleKeyInfo GetKey()
        {
            return Console.ReadKey(true);
        }

        /// <summary>
        /// Starts event loop.
        /// Tracks console input and invokes relevant events.
        /// </summary>
        public void Start()
        {
            while (true)
            {
                var input = GetKey();
                switch (input.Key)
                {
                    case ConsoleKey.DownArrow:
                        MoveDown?.Invoke();
                        break;

                    case ConsoleKey.UpArrow:
                        MoveUp?.Invoke();
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveLeft?.Invoke();
                        break;

                    case ConsoleKey.RightArrow:
                        MoveRight?.Invoke();
                        break;

                    case ConsoleKey.Spacebar:
                        Exit?.Invoke();
                        return;
                }
            }
        }
    }
}
