using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Animation
    {
        private string name; 
        private float speed;
        private List<Image> frames = new List<Image>();
        private bool isLoop; 

        private float currentAnimationTime; 
        private int currentFrame; 

        public Image CurrentImage => frames[currentFrame]; 

        public Animation(string name, float speed, List<Image> frames, bool isLoop) 
        {
            this.name = name; 
            this.speed = speed;
            this.frames = frames;
            this.isLoop = isLoop;
        }

        public void Update()
        {
            currentAnimationTime += Time.DeltaTime; // Update the animation time

            if (currentAnimationTime > speed) // check if the animation time exceeds the speed
            {
                if (!IsFinished()) // Check if the animation is not finished
                {
                    currentFrame++;  // Move to the next frame
                    currentAnimationTime = 0; // Reset the animation time
                }
            }
        }

        public bool IsFinished() 
        {
            return (currentFrame >= frames.Count -1); // Check if the animation is finished
        }

        public void Reset()
        {
            currentFrame = 0; // Reset the current frame to the first frame
            currentAnimationTime = 0; // Reset the animation time
        }
    }
}
