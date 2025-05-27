using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyEye : Enemy
    {
        private EyeAnimator eyeAnimator;
        private EnemyMovement enemyMovement; // Movement component for the enemy

        public EnemyEye(float positionX, float positionY, float speed) : base(positionX, positionY, speed)
        {
            enemyMovement = new EnemyMovement(Transform); // Initialize the enemy's movement component
            eyeAnimator = new EyeAnimator(); // Initialize the eye's animation
        }

        public override void Update()
        {
            enemyMovement.Update(); // Update the enemy's movement
            eyeAnimator.Update(); // Update the eye's animation
        }

        public override void Render()
        {
            Engine.Draw(eyeAnimator.CurrentFrame, Transform.Position.x, Transform.Position.y); // Draw the eye image at its position
        }
    }
}
