using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class EnemyAnimator: IAnimatable
    {
        protected Animation currentAnimation; 

        public Image CurrentFrame => currentAnimation.CurrentImage; // get the current frame of the animation

        public EnemyAnimator() 
        {
            createAnimation(); // Create the enemy's animations
        }

        public abstract void createAnimation();

        public void Update()
        {
            currentAnimation.Update(); 
            if (currentAnimation.IsFinished()) // Check if the animation is finished
            {
                currentAnimation.Reset(); // Reset the animation if it is finished
            }
        }
    }
}
