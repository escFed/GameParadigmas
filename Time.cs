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
            initialTime = DateTime.Now; 
            timeLastFrame = 0f;
        }

        static public void Initialize()
        {
            initialTime = DateTime.Now;
            timeLastFrame = 0f;
        }

        public static void Update()
        {
            float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds;
            deltaTime = currentTime - timeLastFrame;
            Time.timeLastFrame = currentTime;
        }
    }
}
