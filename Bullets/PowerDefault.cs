using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PowerDefault : IPower
    {
        private float defaultCooldown = 0.7f;
        private string currentBulletType = "default";
        private DateTime lastShot = DateTime.MinValue;
        private Player player;

        public PowerDefault(Player player)
        {
            this.player = player;
        }

        public void Shoot()
        {
            if ((DateTime.Now - lastShot).TotalSeconds >= defaultCooldown)
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
