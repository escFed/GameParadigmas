using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Player
    {
        private Transform transform;
        private PlayerController playerController;

        private Animation currentAnimation; 
        private Animation idleAnimation; 
        private Animation shootAnimation; 
        public bool isShooting; 

        public Player(float positionX, float positionY)
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(100, 100)); 
            playerController = new PlayerController(transform); 
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

            shootAnimation = new Animation("Shoot", 0.1f, framesShoot, false);

            currentAnimation = idleAnimation; 
        }

        public void Update()
        {
            playerController.Update();

            if ( currentAnimation.IsFinished())
            {
                isShooting = false; 
                currentAnimation = idleAnimation;
                currentAnimation.Reset(); 
            }

            currentAnimation.Update(); 
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentImage, transform.Position.x, transform.Position.y);
        }

       public void shoot()
        {
            currentAnimation = shootAnimation; 
            isShooting = true; 
            currentAnimation.Reset(); 
        }
        
    }
}
