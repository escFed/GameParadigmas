using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyMovement
    {
        private Transform transform; // The enemy's transform component
        private float speed = 0.1f; // Speed of the enemy

        // Property to access the transform component
        public EnemyMovement(Transform transform)
        {
            this.transform = transform; // Initialize the transform component
        }

        public void Update()
        {
            transform.Translate(new Vector2(-1, 0), speed); // Move the enemy left

            speed += 0.1f * Time.DeltaTime;
            speed = Math.Min(speed, 10f);
            if (transform.Position.x <= 50)
            {
                GameManager.Instance.ChangeState(gameState.youLose);
            }
        }
    }
}
