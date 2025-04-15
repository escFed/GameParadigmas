using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public struct Vector2
    {
        // Fields to store the x and y coordinates
        public float x;
        public float y;

        // Constructor to initialize the vector with x and y values
        public Vector2(float x, float y)
        {
            // Assign the x and y values to the fields
            this.x = x;
            this.y = y;
        }
    }
}
