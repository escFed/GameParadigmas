using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PlayerAnimator
    {
        private Animation currentAnimation;
        private Animation idleAnimation;
        private Animation shootAnimation;
        public bool isShooting;

        public Image CurrentFrame => currentAnimation.CurrentImage;

        public PlayerAnimator()
        {
            isShooting = false;
            createAnimations();
        }

        private void createAnimations()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 9; i++)
            {
                Image frame = Engine.LoadImage($"assets/Player/Idle/{i}.png");
                frames.Add(frame);
            }

            idleAnimation = new Animation("Idle", 0.1f, frames, true);

            List<Image> framesShoot = new List<Image>();

            for (int i = 0; i < 5; i++)
            {
                Image shootFrame = Engine.LoadImage($"assets/Player/Shoot/{i}.png");
                framesShoot.Add(shootFrame);
            }

            shootAnimation = new Animation("Shoot", 0.1f, framesShoot, true);

            currentAnimation = idleAnimation;
        }

        public void Update()
        {
            currentAnimation.Update();

            if (currentAnimation.IsFinished())
            {
                isShooting = false;
                currentAnimation = idleAnimation;
                currentAnimation.Reset();
            }
        }

        public void AnimShoot()
        {
            currentAnimation = shootAnimation;
            isShooting = true;
            currentAnimation.Reset();
        }
    }
}
