using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Animators
{
    public class DeathAnimator : EnemyAnimator, IAnimatable
    {
        public override void createAnimation()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 3; i++)
            {
                Image frame = Engine.LoadImage($"Assets/Enemy/Death/{i}.png");
                frames.Add(frame);
            }

            currentAnimation = new Animation("Death", 0.3f, frames, true);
        }
    }
}
