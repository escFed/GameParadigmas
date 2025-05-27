using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class FastAnimator : BulletAnimator
    {
        public override void createAnimation()
        {
            List<Image> frames = new List<Image>(); // Create a list to hold the frames of the animation

            for (int i = 0; i < 4; i++)
            {
                Image frame = Engine.LoadImage($"assets/Bullet/Fast/{i}.png");
                frames.Add(frame); // Add the frame to the list
            }

            currentAnimation = new Animation("Fast", 0.1f, frames, true);
        }
    }
}
