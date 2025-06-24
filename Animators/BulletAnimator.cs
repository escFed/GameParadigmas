using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class BulletAnimator : IAnimatable
    {
        protected Animation currentAnimation;

        public Image CurrentFrame => currentAnimation.CurrentImage;

        public BulletAnimator()
        {
            createAnimation();
        }

        public abstract void createAnimation();

        public void Update()
        {
            currentAnimation.Update();

            if (currentAnimation.IsFinished())
            {
                currentAnimation.Reset();
            }
        }
    }
}
