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
        private float speed = 0.5f; // Speed of the enemy

        public EnemyMovement(Transform transform) // Constructor to initialize the enemy's movement component
        {
            this.transform = transform; // Initialize the transform component
        }

        public void Update()
        {
            transform.Translate(new Vector2(-1, 0), speed); // Move the enemy left

            speed += 0.02f * Time.DeltaTime;
            speed = Math.Min(speed, 10f);
            if (transform.Position.x <= 30)
            {
                GameManager.Instance.ChangeState(gameState.youLose);
            }
        }
    }
}
