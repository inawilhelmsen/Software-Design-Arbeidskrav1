using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;


interface ICollidable<T> {
    void OnCollision(T other);
}

