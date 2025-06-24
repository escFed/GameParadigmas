using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class BulletDefault : Bullet
    {
        private float speed = 1.5f;
        protected int damage = 150;

        public override int Damage => damage;

        public BulletDefault(float positionX, float positionY) : base(positionX, positionY)
        {
            animator = new DefaultAnimator();
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
