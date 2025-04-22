using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Bullet
    {
        private Animation bulletAnimation; // The bullet's animation

        private float posX;
        private float posY;

        private float scaleX; // The bullet's width
        private float scaleY; // The bullet's height
        private float speed = 3; // The bullet's speed

        public float PosX => posX; // Property to get the bullet's X position
        public float PosY => posY; // Property to get the bullet's Y position
        public float ScaleX => scaleX; // Property to get the bullet's width
        public float ScaleY => scaleY; // Property to get the bullet's height

        public Bullet(float positionX, float positionY) // Constructor to initialize the bullet with a position
        {
            posX = positionX;
            posY = positionY;

            createAnimations(); // Create the bullet's animation
        }

        private void createAnimations()
        { 
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 4; i++)
            {
                Image frame = Engine.LoadImage($"assets/Bullet/{i}.png");
                frames.Add(frame); // Add the frame to the list
            }

            bulletAnimation = new Animation("Bullet", 0.1f, frames, true); // Create a new animation with the frames
        }

        public void Update()
        {
            posX += speed; // Move the bullet to the right
            Collisions.CheckCollisions(this);
            bulletAnimation.Update(); // Update the current animation
            if (bulletAnimation.IsFinished())
            {
                bulletAnimation.Reset(); // Reset the animation if it is finished
            }
        }

        public void Render()
        {
            Engine.Draw(bulletAnimation.CurrentImage, posX, posY); // Draw the bullet image at its position
        }
    }
}
