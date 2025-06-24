using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class BulletFast : Bullet
    {
        private float speed = 3f; 
        protected int damage = 75;

        public override int Damage => damage;

        public BulletFast(float positionX, float positionY) : base(positionX, positionY)
        {
            animator = new FastAnimator();
        }

        public override void Update()
        {
            posX += speed;
            Collisions.CheckCollisions(this);
            base.Update();

            if (posX > 1000)
            {
                Deactivate();
            }
        }

        public override void Activate(float positionX, float positionY)
        {
            base.Activate(positionX, positionY);
        }

        public override void Deactivate()
        {
            base.Deactivate(); 
        }
    }
}
