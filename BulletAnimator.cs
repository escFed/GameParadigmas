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

        public Image CurrentFrame => currentAnimation.CurrentImage; //get the current frame of the animation

        public BulletAnimator()
        {
            createAnimation();
        }

        public abstract void createAnimation();

        public void Update()
        {
            currentAnimation.Update();

            if (currentAnimation.IsFinished()) // check if the animation is finished
            {
                currentAnimation.Reset();
            }
        }
    }
}
