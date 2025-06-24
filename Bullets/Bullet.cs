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
        protected bool isActive;
        protected IAnimatable animator;

        public event Action <Bullet> OnDeactivate;

        protected float scaleX;
        protected float scaleY;      

        public float PosX => posX;
        public float PosY => posY;
        public float ScaleX => scaleX;
        public float ScaleY => scaleY;

        public abstract int Damage { get; }

        public Bullet(float positionX, float positionY)
        {
            posX = positionX;
            posY = positionY;
        }

        public virtual void Update() 
        { 
            animator.Update();
        }

        public virtual void Render() 
        { 
            Engine.Draw(animator.CurrentFrame, posX, posY);
        }

        public virtual void Activate(float positionX, float positionY)
        {
            posX = positionX;
            posY = positionY;
            isActive = true;
        }

        public virtual void Deactivate()
        {
            isActive = false;
            OnDeactivate?.Invoke(this);
        }

    }
}
