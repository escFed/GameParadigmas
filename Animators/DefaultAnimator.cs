using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class DefaultAnimator : BulletAnimator, IAnimatable
    {
        public override void createAnimation()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 4; i++)
            {
                Image frame = Engine.LoadImage($"Assets/Bullet/Default/{i}.png");
                frames.Add(frame);
            }

            currentAnimation = new Animation("Default", 0.1f, frames, true);
        }
    }
}
