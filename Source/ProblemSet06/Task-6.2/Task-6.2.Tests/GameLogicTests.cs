namespace Task_6.Problem2.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class GameLogicTests
    {
        public class SimulatedEventLoop : EventLoop
        {
            private readonly List<ConsoleKeyInfo> _sequence;

            public SimulatedEventLoop(List<ConsoleKeyInfo> sequence)
            {
                _sequence = sequence;
            }

            public override ConsoleKeyInfo GetKey()
            {
                if (_sequence.Count <= 0)
                {
                    throw new IndexOutOfRangeException();
                }

                var simulatedKey = _sequence[0];
                _sequence.RemoveAt(0);
                return simulatedKey;
            }
        }

        public struct PlayerState
        {
            public Position Position { get; set; }

            public bool IsVisible { get; set; }
        }

        public class SimulatedConsole : IVirtualConsole
        {
            private readonly List<PlayerState> _recordedState = new List<PlayerState>();

            public List<PlayerState> GetRecordedState() => _recordedState;

            public void DrawPlayer(Position position, bool isVisible)
            {
                _recordedState.Add(new PlayerState() { Position = position, IsVisible = isVisible });
            }
        }

        [Test]
        public void GameLogicCanMoveRight()
        {
            var testMap = new string[]
            {
                "####",
                "#  #",
                "####",
                "1,1",
            };

            var expectedResults = new List<PlayerState>()
            {
                new PlayerState() { IsVisible = true, Position = new Position(1, 1) },
                new PlayerState() { IsVisible = false, Position = new Position(1, 1) },
                new PlayerState() { IsVisible = true, Position = new Position(2, 1) },
            };

            var map = new Map(testMap);
            var testConsole = new SimulatedConsole();

            var testLoop = new SimulatedEventLoop(new List<ConsoleKeyInfo>()
            {
                new ConsoleKeyInfo('r', ConsoleKey.RightArrow, false, false, false),
                new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false),
            });

            var gameLogic = new GameLogic(map, testLoop, testConsole);

            testLoop.Start();
            Assert.AreEqual(testConsole.GetRecordedState(), expectedResults);
        }

        [Test]
        public void GameLogicFailedMoveRightBecauseOfWall()
        {
            var testMap = new string[]
            {
                "####",
                "# ##", // player cannot move right
                "####",
                "1,1",
            };

            var expectedResults = new List<PlayerState>()
            {
                new PlayerState() { IsVisible = true, Position = new Position(1, 1) },
            };

            var map = new Map(testMap);
            var testConsole = new SimulatedConsole();

            var testLoop = new SimulatedEventLoop(new List<ConsoleKeyInfo>()
            {
                new ConsoleKeyInfo('r', ConsoleKey.RightArrow, false, false, false),
                new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false),
            });

            var gameLogic = new GameLogic(map, testLoop, testConsole);

            testLoop.Start();
            Assert.AreEqual(testConsole.GetRecordedState(), expectedResults);
        }

        [Test]
        public void GameLogicAttemptMoveOutsideMap()
        {
            var testMap = new string[]
            {
                "####",
                "  ##",
                "# ##",
                "1,1",
            };

            var expectedResults = new List<PlayerState>()
            {
                new PlayerState() { IsVisible = true, Position = new Position(1, 1) },
                new PlayerState() { IsVisible = false, Position = new Position(1, 1) },
                new PlayerState() { IsVisible = true, Position = new Position(0, 1) },
            };

            var map = new Map(testMap);
            var testConsole = new SimulatedConsole();

            var testLoop = new SimulatedEventLoop(new List<ConsoleKeyInfo>()
            {
                new ConsoleKeyInfo('l', ConsoleKey.LeftArrow, false, false, false),
                new ConsoleKeyInfo('l', ConsoleKey.LeftArrow, false, false, false),
                new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false),
            });

            var gameLogic = new GameLogic(map, testLoop, testConsole);

            testLoop.Start();
            Assert.AreEqual(testConsole.GetRecordedState(), expectedResults);
        }
    }
}
