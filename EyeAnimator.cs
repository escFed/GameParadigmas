using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EyeAnimator : EnemyAnimator, IAnimatable
    {
        public override void createAnimation()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 3; i++)
            {
                Image frame = Engine.LoadImage($"assets/Enemy/Eye/{i}.png");
                frames.Add(frame); // Add the frame to the list
            }

            currentAnimation = new Animation("Eye", 0.1f, frames, true); // Create a new animation with the frames
        }
    }
}
