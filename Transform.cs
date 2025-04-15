using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Transform
    {
        private Vector2 position; // The position of the object in 2D space

        public Vector2 Position => position; // Property to access the position

        public Transform(Vector2 position) 
        {
            this.position = position; // Assign the position

        }

        public void Translate(Vector2 direction, float speed) // Move the object in a specified direction
        {
            position.x += direction.x * speed; // Move in the x direction
            position.y += direction.y * speed; // Move in the y direction
        }
    }
}
