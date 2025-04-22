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
                Enemy enemy = GameManager.Instance.LevelController.Enemies[i]; // Get the enemy from the list

                float DistanceX = Math.Abs((enemy.Transform.Position.x + enemy.Transform.Scale.x / 2) - bullet.PosX + (bullet.ScaleX / 2)); //calculate the distance in the x-axis
                float DistanceY = Math.Abs((enemy.Transform.Position.y + enemy.Transform.Scale.y / 2) - bullet.PosY + (bullet.ScaleY / 2)); //calculate the distance in the y-axis

                float sumHalfWidth = enemy.Transform.Scale.x / 2 + bullet.ScaleX / 2; //calculate the sum of half the width of the enemy and bullet
                float sumHalfHeight = enemy.Transform.Scale.y / 2 + bullet.ScaleY / 2; //calculate the sum of half the height of the enemy and bullet

                if (DistanceX < sumHalfWidth && DistanceY < sumHalfHeight) //check if the bullet and enemy are colliding
                {                   
                    enemy.Spawn(); 
                    GameManager.Instance.LevelController.Bullets.Remove(bullet); 
                    return;
                }
            }
        }
    }
}
