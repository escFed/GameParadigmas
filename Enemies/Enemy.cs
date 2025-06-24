using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class Enemy : IDamageable
    {
        protected Transform transform;
        private Vector2 initial;
        protected HealthController healthController;
        protected IAnimatable animator;
        protected IEnemyMovement Movement;

        public Transform Transform => transform;

        public Enemy(float positionX, float positionY, float speed)
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(100, 100));
            initial = transform.Position;
            Movement = new EnemyMovement(transform, speed);
        }

        public virtual void Update()
        {
            Movement.Update();
            animator.Update();
        }

        public virtual void Render() 
        {
            Engine.Draw(animator.CurrentFrame, transform.Position.x, transform.Position.y);
        }

        public void GetDamage(int damage)
        {
            healthController.GetDamage(damage);
        }

        public void OnDeath()
        {
            ScoreManager.AddScore(100);
            Spawn();
        }

        public void Spawn()
        {
            transform.Reposition(initial);
            healthController.ResetHealth();
        }
    }
}
