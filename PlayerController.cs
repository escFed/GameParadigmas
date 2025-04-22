using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PlayerController
    {
        private DateTime lastShotTime; // Time of the last shot
        private float shotCooldown = 0.5f; // Cooldown time between shots in seconds
        private float speed = 1.6f;

        private Transform transform;
        private Animation currentAnimation; // The current animation of the player

        public PlayerController(Transform transform)
        {
            this.transform = transform; // Assign the transform
        }

        public void Update()
        {
            if (Engine.GetKey(Engine.KEY_W))
            {
                if (transform.Position.y > 120)
                    transform.Translate(new Vector2(0, -1), speed); // Move up
            }

            if (Engine.GetKey(Engine.KEY_S))
            {
                if (transform.Position.y < 565)
                    transform.Translate(new Vector2(0, 1), speed); // Move down
            }

            if (Engine.GetKey(Engine.KEY_ESP))
            {
                Shoot();
            }
        }
        private void Shoot()
        {
            if ((DateTime.Now - lastShotTime).TotalSeconds > shotCooldown && !GameManager.Instance.LevelController.player.isShooting)
            {
                GameManager.Instance.LevelController.AddBullet (transform.Position.x, transform.Position.y); // Create a bullet at the player's position
                lastShotTime = DateTime.Now; // Update the last shot time
                GameManager.Instance.LevelController.player.shoot(); // Call the shoot method of the player
            }
        }
    
    }
}
