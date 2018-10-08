using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


struct Point {
    public int x;
    public int y;
}

class Entity {
    public Point position;
}

interface ICollidable<T> {
    bool Collision(T other);
    void OnCollision(T other);
}

class InputController {
    public Direction _direction;

    public void ProcessInput() {
        
    }
}

class GameController {
    public InputController inputController;
    public Board board;
    public Snake snake;
    public Apple apple;
    
    public void GameStart() {
        
    }
    
    public void GameOver() {
        
    }
}

class Apple: Entity {
    public Apple(int x, int y){
        position.x = x;
        position.y = y;
    }
}

class Board: Entity {
    public int width;
    public int height;
    public Board(int width, int height) {
        this.width = width;
        this.height = height;
    }
}

enum Direction {UP, DOWN, lEFT, RIGHT};

class Snake: Entity, ICollidable<Entity> {
    public Point[] parts = new Point[4];
    public int length = 4;
    
    public void Move(Direction direction) {
        switch (direction)
        {
            case Direction.UP:
                break;
            case Direction.DOWN:
                break;
            case Direction.lEFT:
                break;
            case Direction.RIGHT:
                break;
        }
    }

    public void OnCollision(Entity other) {
        
    }

    public bool Collision(Entity other) {
        return false;
    }

    public void Die() {
        
    }
    
    public void Eat() {
        
    }
}

namespace SnakeMess
{
    class Point
    {
        public const string Ok = "Ok";

        public int X;
        public int Y;
        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public Point(Point input)
        {
            X = input.X;
            Y = input.Y;
        }
    }

    class SnakeMess
    {
        public static void Main(string[] arguments)
        {
            bool gg = false,
            pause = false,
            inUse = false;
            short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
            short last = newDir;
            int boardW = Console.WindowWidth,
            boardH = Console.WindowHeight;
            Random rng = new Random();
            Point app = new Point();
            List<Point> snake = new List<Point>();
            snake.Add(new Point(10, 10));
            snake.Add(new Point(10, 10));
            snake.Add(new Point(10, 10));
            snake.Add(new Point(10, 10));
            Console.CursorVisible = false;
            Console.Title = "Høyskolen Kristiania - SNAKE";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");
            while (true)
            {
                app.X = rng.Next(0, boardW);
                app.Y = rng.Next(0, boardH);
                bool spot = true;
                foreach (Point i in snake)
                    if (i.X == app.X && i.Y == app.Y)
                    {
                        spot = false;
                        break;
                    }
                if (spot)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(app.X, app.Y);
                    Console.Write("$");
                    break;
                }
            }
            Stopwatch t = new Stopwatch();
            t.Start();
            while (!gg)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Escape) gg = true;
                    else if (cki.Key == ConsoleKey.Spacebar) pause = !pause;
                    else if (cki.Key == ConsoleKey.UpArrow && last != 2) newDir = 0;
                    else if (cki.Key == ConsoleKey.RightArrow && last != 3) newDir = 1;
                    else if (cki.Key == ConsoleKey.DownArrow && last != 0) newDir = 2;
                    else if (cki.Key == ConsoleKey.LeftArrow && last != 1) newDir = 3;
                }
                if (!pause)
                {
                    if (t.ElapsedMilliseconds < 100) continue;
                    t.Restart();
                    Point tail = new Point(snake.First());
                    Point head = new Point(snake.Last());
                    Point newH = new Point(head);
                    switch (newDir)
                    {
                        case 0:
                            newH.Y -= 1;
                            break;
                        case 1:
                            newH.X += 1;
                            break;
                        case 2:
                            newH.Y += 1;
                            break;
                        default:
                            newH.X -= 1;
                            break;
                    }
                    if (newH.X < 0 || newH.X >= boardW) gg = true;
                    else if (newH.Y < 0 || newH.Y >= boardH) gg = true;
                    if (newH.X == app.X && newH.Y == app.Y)
                    {
                        if (snake.Count + 1 >= boardW * boardH)
                            // No more room to place apples - game over.
                            gg = true;
                        else
                        {
                            while (true)
                            {
                                app.X = rng.Next(0, boardW);
                                app.Y = rng.Next(0, boardH);
                                bool found = true;
                                foreach (Point i in snake)
                                    if (i.X == app.X && i.Y == app.Y)
                                    {
                                        found = false;
                                        break;
                                    }
                                if (found)
                                {
                                    inUse = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!inUse)
                    {
                        snake.RemoveAt(0);
                        foreach (Point x in snake)
                            if (x.X == newH.X && x.Y == newH.Y)
                            {
                                // Death by accidental self-cannibalism.
                                gg = true;
                                break;
                            }
                    }
                    if (!gg)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(head.X, head.Y);
                        Console.Write("0");
                        if (!inUse)
                        {
                            Console.SetCursorPosition(tail.X, tail.Y);
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(app.X, app.Y);
                            Console.Write("$");
                            inUse = false;
                        }
                        snake.Add(newH);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(newH.X, newH.Y);
                        Console.Write("@");
                        last = newDir;
                    }
                }
            }
        }
    }
}
