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
        private DateTime lastShotTime; //last time the player shot
        private float shotCooldown = 1f; 
        private float speed = 1.5f;

        private Transform transform; 

        public PlayerController(Transform transform)
        {
            this.transform = transform; 
        }

        public void Update()
        {
            if (Engine.GetKey(Engine.KEY_W))
            {
                if (transform.Position.y > 120)
                    transform.Translate(new Vector2(0, -1), speed); 
            }

            if (Engine.GetKey(Engine.KEY_S))
            {
                if (transform.Position.y < 565)
                    transform.Translate(new Vector2(0, 1), speed); 
            }

            if (Engine.GetKey(Engine.KEY_ESP))
            {
                Shoot();
            }
        }
        private void Shoot()
        {
            if ((DateTime.Now - lastShotTime).TotalSeconds > shotCooldown) //check if the cooldown time has passed
            {
                GameManager.Instance.LevelController.AddBullet (transform.Position.x, transform.Position.y); //create a new bullet
                lastShotTime = DateTime.Now; //update the last shot time
                GameManager.Instance.LevelController.player.shoot(); //call the shoot method in the player class
            }
        }
    
    }
}
