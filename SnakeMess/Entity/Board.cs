using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


class Board: Entity, ICollidable<Entity> {
    public int width;
    public int height;
    public Board(int width, int height) : base()
    {
        this.width = width;
        this.height = height;
    }
    
    public void OnCollision(Entity other) {
        alive = false;
    }
}

