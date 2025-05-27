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
        private Player player; 
        private float speed = 1.5f;
        private string currentBulletType = "default";
        private DateTime lastShot = DateTime.MinValue;
        private float shotCooldown = 1f;

        private Transform transform; 

        public PlayerController(Transform transform, Player player)
        {
            this.transform = transform;
            this.player = player;

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
           
            if (Engine.GetKey(Engine.KEY_Q))
            {
                currentBulletType = "default";
            }

            if (Engine.GetKey(Engine.KEY_E))
            {
                currentBulletType = "fast";
            }

            if (Engine.GetKey(Engine.KEY_ESP))
            {
                if ((DateTime.Now - lastShot).TotalSeconds >= shotCooldown)
                {
                    float posX = transform.Position.x + 45;
                    float posY = transform.Position.y + 30;

                    Bullet bullet = BulletFactory.CreateBullet(currentBulletType, posX, posY, player);
                    GameManager.Instance.LevelController.AddBullet(bullet);
                    player.shoot();
                    lastShot = DateTime.Now;
                }
            }
        }   
    }
}
