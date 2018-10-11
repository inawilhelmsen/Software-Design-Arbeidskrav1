using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


class GameController {
    private InputController _inputController;
    private Board _board;
    private Snake _snake;
    private Apple _apple;
    private bool _gameRunning;
    
    public GameController()
    {
        
    }

    public void GameStart() {
        _board = new Board(Console.WindowWidth, Console.WindowHeight);
        _snake = new Snake(new Point(10,10));
        _inputController = new InputController();
        _snake.Draw(Entity.DrawStyle.SNAKE_HEAD);
        SpawnApple();

        Console.CursorVisible = false;
        Console.Title = "Høyskolen Kristiania - SNAKE";
        Console.ForegroundColor = ConsoleColor.Green;
        
        Stopwatch deltaTime = new Stopwatch();
        _gameRunning = true;
        while (_gameRunning)
        {
            _inputController.ProcessInput();
            if (!_inputController.gamePaused)
            {
                deltaTime.Start();

                if (deltaTime.ElapsedMilliseconds > 100)
                {
                    GameLoop();
                    deltaTime.Reset();
                }
            }
        }
    }

    private void GameLoop()
    {
        _snake.CollisionTest(_apple, true);
        _snake.CollisionTest(_board, true);

        if (!_apple.alive) SpawnApple();
        _apple.Draw(Entity.DrawStyle.APPLE);

        if (_snake.alive && _board.alive)
            _snake.Move(_inputController.direction);
        else
            GameOver();

        _snake.CollisionTest(_snake, true);
    }

    private void GameOver() {
        _gameRunning = false;
    }

    private void SpawnApple()
    {
        Random rng = new Random();

        bool foundPosition = false;
        while (!foundPosition)
        {
            int x = rng.Next(0, _board.width);
            int y = rng.Next(0, _board.height);
            _apple = new Apple(new Point(x, y));

            if (!_snake.CollisionTest(_apple))
            {
                foundPosition = true;
            }
        }
    }
}

