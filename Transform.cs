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
        private Vector2 scale; // The scale of the object in 2D space

        public Vector2 Position => position; // Property to access the position
        public Vector2 Scale => scale; // Property to access the scale

        public Transform(Vector2 position, Vector2 scale)
        {
            this.position = position; // Assign the position
            this.scale = scale; // Assign the scale
        }

        public void Translate(Vector2 direction, float speed) // Move the object in a specified direction
        {
            position.x += direction.x * speed; // Move in the x direction
            position.y += direction.y * speed; // Move in the y direction
        }

        public void Reposition(Vector2 rePos)
        {
            position.x = rePos.x; // Set the new x position
            position.y = rePos.y; // Set the new y position
        }
    }
}
