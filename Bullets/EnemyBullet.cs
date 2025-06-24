using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyBullet : Bullet
    {
        private float speed = 1.5f;
        private int damage = 100;

        public override int Damage => damage;

        public EnemyBullet(float positionX, float positionY) : base(positionX, positionY)
        {
            animator = new EnemyBulletAnimator();
        }

        public override void Update()
        {
            posX -= speed;
            Collisions.CheckCollisions(this);
            base.Update();

            if (posX < 0)
            {
                Deactivate();
                return;
            }
        }

        public override void Activate(float positionX, float positionY)
        {
            base.Activate(positionX, positionY);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            GameManager.Instance.LevelController.Bullets.Remove(this);
        }
    }
}
