using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class DemonAnimator : EnemyAnimator, IAnimatable
    {
        public override void createAnimation()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 8; i++)
            {
                Image frame = Engine.LoadImage($"Assets/Enemy/Demon/{i}.png");
                frames.Add(frame);
            }

            currentAnimation = new Animation("Demon", 0.1f, frames, true);
        }
    }
}
