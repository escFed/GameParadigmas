using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class Bullet
    {
        protected float posX;
        protected float posY;

        protected float scaleX; // The bullet's width
        protected float scaleY; // The bullet's height       

        public float PosX => posX; 
        public float PosY => posY; 
        public float ScaleX => scaleX; 
        public float ScaleY => scaleY; 

        public Bullet(float positionX, float positionY) 
        {
            posX = positionX; // Initialize the bullet's position
            posY = positionY; 
        }

        public abstract void Update();


        public abstract void Render();

    }
}
