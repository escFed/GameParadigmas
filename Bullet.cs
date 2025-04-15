using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Bullet
    {
        private Image bulletImage = Engine.LoadImage("assets/bulletP.png"); // The bullet's image

        private float posX =0;
        private float posY = 0;
        private float speed = 3; // The bullet's speed

        public Bullet(float positionX, float positionY) // Constructor to initialize the bullet with a position
        {
            posX = positionX;
            posY = positionY;
        }

        public void Update()
        {
            posX += speed; // Move the bullet to the right
        }

        public void Render()
        {
            Engine.Draw(bulletImage, posX, posY); // Draw the bullet image at its position
        }
    }
}
