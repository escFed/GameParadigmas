using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class Collisions
    {
        public static void CheckCollisions(Bullet bullet)
        {
            for (int i = 0; i < GameManager.Instance.LevelController.Enemies.Count; i++)
            {
                Enemy enemy = GameManager.Instance.LevelController.Enemies[i];

                float DistanceX = Math.Abs((enemy.Transform.Position.x + enemy.Transform.Scale.x / 2) - bullet.PosX + (bullet.ScaleX / 2));
                float DistanceY = Math.Abs((enemy.Transform.Position.y + enemy.Transform.Scale.y / 2) - bullet.PosY + (bullet.ScaleY / 2));

                float sumHalfWidth = enemy.Transform.Scale.x / 2 + bullet.ScaleX / 2;
                float sumHalfHeight = enemy.Transform.Scale.y / 2 + bullet.ScaleY / 2;

                if (DistanceX < sumHalfWidth && DistanceY < sumHalfHeight)
                {
                    //enemy.GetDamage(100);
                    enemy.Spawn();
                    GameManager.Instance.LevelController.Bullets.Remove(bullet);
                    return; // Exit the loop after a collision is detected
                }
            }
        }
    }
}
