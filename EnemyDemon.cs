using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyDemon : Enemy
    {
        private DemonAnimator demonAnimator; // Animator for the demon enemy
        private EnemyMovement enemyMovement;
        


        public EnemyDemon(float positionX, float positionY, float speed) : base(positionX, positionY, speed)
        {
            enemyMovement = new EnemyMovement(transform);
            demonAnimator = new DemonAnimator();
        }

        public override void Update()
        {
            enemyMovement.Update(); // Update the demon's movement
            demonAnimator.Update(); // Update the demon's animation
        }

        public override void Render()
        {
            Engine.Draw(demonAnimator.CurrentFrame, Transform.Position.x, Transform.Position.y); // Draw the demon image at its position
        }
    }
}
