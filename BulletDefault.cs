using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class BulletDefault : Bullet, IPower
    {
        private DefaultAnimator defaultAnimator; // Animator for the default bullet
        private DateTime lastShotTime; //last time the player shot
        private float shotCooldown = 1f;
        private float speed = 1.5f; // The bullet's speed

        public BulletDefault(float positionX, float positionY) : base(positionX, positionY)
        {
            defaultAnimator = new DefaultAnimator(); // Initialize the default bullet's animation
        }

        public override void Update()
        {
            posX += speed; // Move the bullet to the right
            Collisions.CheckCollisions(this); // Check for collisions with enemies
            defaultAnimator.Update();
            if (posX > 1000)
            {
                GameManager.Instance.LevelController.Bullets.Remove(this); // Remove the bullet if it goes off screen
                return;
            }
        }

        public override void Render()
        {
            Engine.Draw(defaultAnimator.CurrentFrame, posX, posY); // Draw the default bullet at its position
        }

        public void Shoot(Bullet bullet)
        {
            if ((DateTime.Now - lastShotTime).TotalSeconds > shotCooldown) //check if the cooldown time has passed
            {
                GameManager.Instance.LevelController.AddBullet(bullet); //create a new bullet
                lastShotTime = DateTime.Now; //update the last shot time
                GameManager.Instance.LevelController.player.shoot(); //call the shoot method in the player class
            }
        }
    }
}
