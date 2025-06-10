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
        private Vector2 initial; // The initial position of the enemy
        protected HealthController healthController;

        public Transform Transform => transform; // Property to access the transform component

        public Enemy(float positionX, float positionY, float speed)
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(100, 100));
            initial = transform.Position; // Store the initial position of the enemy
            healthController = new HealthController(100);
            healthController.OnDeath += OnDeath;
        }

        public abstract void Update();

        public abstract void Render();

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
        }
    }
}
