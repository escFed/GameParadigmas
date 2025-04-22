using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Bullet
    {
        private float posX;
        private float posY;

        private BulletAnimator bulletAnimation;

        private float scaleX; // The bullet's width
        private float scaleY; // The bullet's height
        private float speed = 2.5f; // The bullet's speed

        public float PosX => posX; 
        public float PosY => posY; 
        public float ScaleX => scaleX; 
        public float ScaleY => scaleY; 

        public Bullet(float positionX, float positionY) 
        {
            posX = positionX; // Initialize the bullet's position
            posY = positionY; 
            bulletAnimation = new BulletAnimator(); // Initialize the bullet's animation
        }

        public void Update()
        {
            posX += speed; // Move the bullet to the right
            Collisions.CheckCollisions(this); // Check for collisions with enemies
            bulletAnimation.Update();

            if (posX > 1000)
            {
                GameManager.Instance.LevelController.Bullets.Remove(this); // Remove the bullet if it goes off screen
                return;
            }
        }

        public void Render()
        {
            Engine.Draw(bulletAnimation.CurrentFrame, posX, posY); // Draw the bullet image at its position
        }
    }
}
