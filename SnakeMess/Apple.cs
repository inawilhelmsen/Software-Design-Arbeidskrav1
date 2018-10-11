using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

class Apple: Entity, ICollidable<Entity> {
    public Apple() : base()
    {

    }

    public Apple(Point position) : base(position)
    {
 
    }

    public void OnCollision(Entity other) {
        alive = false;
    }
}

