using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyBoss : Enemy
    {
        private List<float> shootingLanes = new List<float> { 370f };
        private float shootCooldown = 3f;
        private float shootTimer = 0f;

        public EnemyBoss(float positionX, float positionY, float speed) : base(positionX, positionY, speed)
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(75, 400));
            Movement = new BossMovement(transform);
            animator = new BossAnimator();

            healthController = new HealthController(1200);
            healthController.OnDeath += OnBossDeath;
        }

        public override void Update()
        {          
            base.Update();
            shootTimer += Time.DeltaTime;
            if (shootTimer >= shootCooldown)
            {
                Shoot();
                shootTimer = 0f;
            }
        }
        public void OnBossDeath()
        {
            GameManager.Instance.ChangeState(gameState.youWin);
        }

        private void Shoot()
        {
            for (int i = 0; i < shootingLanes.Count; i++)
            {
                float laneY = shootingLanes[i];
                EnemyBullet bullet = new EnemyBullet(transform.Position.x, laneY);
                GameManager.Instance.LevelController.AddBullet(bullet);
            }
        }
    }
}
