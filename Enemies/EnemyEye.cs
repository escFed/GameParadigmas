using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyEye : Enemy
    {
        public EnemyEye(float positionX, float positionY, float speed) : base(positionX, positionY, 0.02f)
        {
            animator = new EyeAnimator();
            healthController = new HealthController(50);
            healthController.OnDeath += OnDeath;
        }
    }
}
