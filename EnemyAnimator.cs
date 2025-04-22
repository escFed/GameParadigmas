using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyAnimator
    {
        private Animation currentAnimation; 

        public Image CurrentFrame => currentAnimation.CurrentImage; // get the current frame of the animation

        public EnemyAnimator() 
        {
            createAnimation(); // Create the enemy's animations
        }

        public void createAnimation()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 8; i++)
            {
                Image frame = Engine.LoadImage($"assets/Enemy/Run/{i}.png");
                frames.Add(frame); // Add the frame to the list
            }

            currentAnimation = new Animation("Run", 0.1f, frames, true); // Create a new animation with the frames
        }

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
