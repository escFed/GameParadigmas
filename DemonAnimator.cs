using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class DemonAnimator : EnemyAnimator
    {
        public override void createAnimation()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 8; i++)
            {
                Image frame = Engine.LoadImage($"assets/Enemy/Demon/{i}.png");
                frames.Add(frame); // Add the frame to the list
            }

            currentAnimation = new Animation("Demon", 0.1f, frames, true); // Create a new animation with the frames
        }
    }
}
