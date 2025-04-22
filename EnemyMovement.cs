using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyMovement
    {
        private Transform transform; 
        private float speed = 0.2f; // Speed of the enemy

        public EnemyMovement(Transform transform) 
        {
            this.transform = transform; 
        }

        public void Update()
        {
            transform.Translate(new Vector2(-1, 0), speed); // Move the enemy left

            speed += 0.03f * Time.DeltaTime; // Increase the speed over time
            speed = Math.Min(speed, 5f); // Cap the speed to a maximum value
            if (transform.Position.x <= 30)
            {
                GameManager.Instance.ChangeState(gameState.youLose);
            }
        }
    }
}
