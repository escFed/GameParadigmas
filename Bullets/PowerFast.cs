using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PowerFast : IPower
    {
        private float fastCooldown = 0.4f;
        private string currentBulletType = "fast";
        private DateTime lastShot = DateTime.MinValue;
        private Player player;

        public PowerFast(Player player)
        {
            this.player = player;  
            
        }

        public void Shoot()
        {
            if ((DateTime.Now - lastShot).TotalSeconds >= fastCooldown)
            {
                float posX = player.Transform.Position.x + 45;
                float posY = player.Transform.Position.y + 30;

                Bullet newBullet = BulletFactory.CreateBullet(currentBulletType, posX, posY, player);
                GameManager.Instance.LevelController.AddBullet(newBullet);
                player.Shot();
                lastShot = DateTime.Now;
            }
        }

    }
}
