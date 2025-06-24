using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class BossMovement : IEnemyMovement
    {
        private Transform transform;
        private float speed = 0.1f;

        public BossMovement(Transform transform)
        {
            this.transform = transform;
        }

        public void Update()
        {
            transform.Translate(new Vector2(-1, 0), speed);
            if (transform.Position.x <= 30)
            {            
                GameManager.Instance.ChangeState(gameState.gameOver);
            }
        }
    }
}
