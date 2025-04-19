using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Bullet
    {
        private Image bulletImage = Engine.LoadImage("assets/bulletP.png"); // The bullet's image

        private float posX =0;
        private float posY = 0;

        private float scaleX = 4; // The bullet's width
        private float scaleY = 10; // The bullet's height

        private float speed = 3; // The bullet's speed

        public Bullet(float positionX, float positionY) // Constructor to initialize the bullet with a position
        {
            posX = positionX;
            posY = positionY;
            
        }

        public void Update()
        {
            posX += speed; // Move the bullet to the right
            CheckCollisions();
        }

        private void CheckCollisions()
        {
            for (int i = 0; i < GameManager.Instance.LevelController.Enemies.Count; i++)
            {
                Enemy enemy = GameManager.Instance.LevelController.Enemies[i];

                float DistanceX = Math.Abs((enemy.Transform.Position.x + enemy.Transform.Scale.x / 2) - posX + (scaleX / 2));
                float DistanceY = Math.Abs((enemy.Transform.Position.y + enemy.Transform.Scale.y / 2) - posY + (scaleY / 2));

                float sumHalfWidth = enemy.Transform.Scale.x / 2 + scaleX / 2;
                float sumHalfHeight = enemy.Transform.Scale.y / 2 + scaleY / 2;

                if (DistanceX < sumHalfWidth && DistanceY < sumHalfHeight)
                {
                    //Program.Enemies.Remove(enemy);
                    //enemy.GetDamage(100);
                    enemy.Spawn();
                    GameManager.Instance.LevelController.Bullets.Remove(this);
                }
            }
        }
        public void Render()
        {
            Engine.Draw(bulletImage, posX, posY); // Draw the bullet image at its position
        }
    }
}
