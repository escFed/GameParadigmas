using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Time
    {
        static private float deltaTime;
        static private DateTime initialTime;
        static private float timeLastFrame;

        static public float DeltaTime => deltaTime;

        public Time()
        {
            initialTime = DateTime.Now; // Get the initial time
            timeLastFrame = 0f; // Initialize the last frame time
        }

        static public void Initialize()
        {
            initialTime = DateTime.Now; // Get the initial time
            timeLastFrame = 0f; // Initialize the last frame time
        }

        public static void Update()
        {
            float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds; // Get the current time in seconds
            deltaTime = currentTime - timeLastFrame; // Calculate the delta time
            Time.timeLastFrame = currentTime; // Update the last frame time
        }
    }
}
