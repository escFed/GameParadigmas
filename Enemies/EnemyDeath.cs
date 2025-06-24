using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.Animators;

namespace MyGame
{
    public class EnemyDeath : Enemy
    {
        public EnemyDeath(float positionX, float positionY, float speed) : base(positionX, positionY, 0.4f)
        {
            animator = new DeathAnimator();
            healthController = new HealthController(150);
            healthController.OnDeath += OnDeath;
        }
    }
}
