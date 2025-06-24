using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyDemon : Enemy
    {
        public EnemyDemon(float positionX, float positionY, float speed) : base(positionX, positionY, 0.03f)
        {
            animator = new DemonAnimator();
            healthController = new HealthController(100);
            healthController.OnDeath += OnDeath;
        }
    }
}
