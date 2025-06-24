using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static MyGame.EnemyMovement;

namespace MyGame
{
    public class EnemyMovement : IEnemyMovement
    {
        private Transform transform;
        private float speed;

        public EnemyMovement(Transform transform, float initialSpeed = 0.1f)
        {
            this.transform = transform;
            this.speed = initialSpeed;
        }

        public void Update()
        {
            transform.Translate(new Vector2(-1, 0), speed);
            speed += 0.02f * Time.DeltaTime;
            speed = Math.Min(speed, 5f);
            if (transform.Position.x <= 30)
            {
                GameManager.Instance.ChangeState(gameState.gameOver);
            }
        }
    }
}
