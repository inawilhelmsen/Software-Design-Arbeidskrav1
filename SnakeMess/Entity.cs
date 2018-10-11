using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;


class Entity {
    public Point position;
    public bool alive;
    public enum DrawStyle { EMPTY, SNAKE_HEAD, SNAKE_BODY, APPLE };

    public Entity(Point position)
    {
        alive = true;
        this.position = position;
    }

    public Entity() : this(new Point(0, 0))
    {

    }

    public void Draw(DrawStyle drawStyle)
    {
        Draw(position, drawStyle);
    }
     
    public void Draw(Point position, DrawStyle drawStyle)
    {
        char character = ' ';
        switch (drawStyle)
        {
            case DrawStyle.SNAKE_HEAD:
                character = '@';
                break;
            case DrawStyle.SNAKE_BODY:
                character = '0';
                break;
            case DrawStyle.APPLE:
                character = '$';
                break;
        }

        Console.SetCursorPosition(position.x, position.y);
        Console.Write(character);
    }
}

