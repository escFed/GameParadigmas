using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class BossAnimator : EnemyAnimator, IAnimatable
    {
        public override void createAnimation()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 3; i++)
            {
                Image frame = Engine.LoadImage($"Assets/Enemy/Boss/{i}.png");
                frames.Add(frame);
            }

            currentAnimation = new Animation("Boss", 0.3f, frames, true);
        }
    }
}
