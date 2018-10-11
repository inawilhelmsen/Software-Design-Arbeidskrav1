using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

public enum Direction { UP, DOWN, LEFT, RIGHT };

class InputController {    
    public Direction direction;
    public bool gamePaused;

    private Direction _lastDirection;

    public InputController()
    {
        gamePaused = false;
        direction = Direction.DOWN;
        _lastDirection = direction;
    }
    
    public void ProcessInput() {
        if (!Console.KeyAvailable) return;

        ConsoleKeyInfo cki = Console.ReadKey(true);
        switch (cki.Key)
        {
            case ConsoleKey.Spacebar:
                gamePaused = !gamePaused;
            break;

            case ConsoleKey.UpArrow: 
                if (_lastDirection != Direction.DOWN) direction = Direction.UP;
            break;

            case ConsoleKey.DownArrow:
                if (_lastDirection != Direction.UP) direction = Direction.DOWN;
            break;

            case ConsoleKey.LeftArrow:
                if (_lastDirection != Direction.RIGHT) direction = Direction.LEFT;
            break;

            case ConsoleKey.RightArrow:
                if (_lastDirection != Direction.LEFT) direction = Direction.RIGHT;
            break;
        }

        _lastDirection = direction;
    }
}

