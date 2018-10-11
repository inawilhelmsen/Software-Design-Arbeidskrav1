using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


class Snake : Entity, ICollidable<Entity> {
    private List<Point> _parts = new List<Point>();

    public Snake(Point position) : base(position)
    {
        for (int i = 0; i < 4; i++)
        {
            addPart(position);
        }
    }

    public void addPart(Point position)
    {
        _parts.Add(position);
    }

    public void Move(Direction direction) {
        Draw(GetTail(), DrawStyle.EMPTY);
        Draw(GetHead(), DrawStyle.SNAKE_BODY);
        _parts.RemoveAt(0);

        switch (direction)
        {
            case Direction.UP:
                position.y -= 1;
            break;
            case Direction.DOWN:
                position.y += 1;
            break;
            case Direction.LEFT:
                position.x -= 1;
           break;
            case Direction.RIGHT:
                position.x += 1;
            break;
        }

        _parts.Add(new Point(position.x, position.y));
        Draw(GetHead(), DrawStyle.SNAKE_HEAD);
    } 

    public bool CollisionTest(Entity other, bool FireCollisionEvent = false) {
        switch (other)
        {
            case Apple _:
                if (position.x == other.position.x && position.y == other.position.y)
                {
                    if (FireCollisionEvent) (other as Apple).OnCollision(this);
                    addPart(other.position);

                    return true;
                }

                break;
            case Board _:
                if (position.x >= (other as Board).width
                   || position.y >= (other as Board).height
                   || position.x <= 0
                   || position.y <= 0)
                {
                    if (FireCollisionEvent) (other as Board).OnCollision(this);
                    return true;
                }

                break;
            case Snake _ when other.Equals(this):
                {
                    Point head = GetHead();
                    foreach (Point part in _parts)
                    {
                        if (part.Equals(head)) continue;

                        if (part.x == other.position.x && part.y == other.position.y)
                        {
                            if (FireCollisionEvent) (other as Snake).OnCollision(this);
                            return true;
                        }
                    }

                    break;
                }
        }

        return false;
    }

    private Point GetTail()
    {
        return _parts.FirstOrDefault();
    }

    private Point GetHead()
    {
        return _parts.LastOrDefault();
    }
    
    public void OnCollision(Entity other) {
        alive = false;
    }
}

