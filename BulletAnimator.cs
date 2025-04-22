using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class BulletAnimator
    {
        private Animation currentAnimation; 

        public Image CurrentFrame => currentAnimation.CurrentImage; //get the current frame of the animation

        public BulletAnimator()
        {
            createAnimation(); 
        }

        private void createAnimation()
        {
            List<Image> frames = new List<Image>(); // Create a list to hold the frames of the animation

            for (int i = 0; i < 4; i++) 
            {
                Image frame = Engine.LoadImage($"assets/Bullet/{i}.png"); 
                frames.Add(frame); // Add the frame to the list
            }

            currentAnimation = new Animation("Bullet", 0.1f, frames, true); 
        }

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
