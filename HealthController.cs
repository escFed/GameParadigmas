using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class HealthController
    {
        public delegate void HealthDelegate();
        public delegate void DeathDelegate();
        public event DeathDelegate OnDeath;
        public HealthDelegate onCollision = null;

        public event HealthDelegate OnCollision
        {
            add { onCollision += value; }
            remove { onCollision -= value; }
        }

        private int health;

        public HealthController(int health)
        {
            this.health = health;
        }

        public void GetDamage(int damage)
        {
            onCollision.Invoke();
            health -= damage;

            if (health <= 0)
            {
                OnDeath?.Invoke();
            }
        }


    }
}
