using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Player
    {
        private IController playerController;
        private Transform transform;
        private PlayerAnimator playerAnimator;
        private HealthController healthController;

        private IPower power;
        private IPower fastPower;
        private IPower defaultPower;

        public Transform Transform => transform;
        public HealthController HealthController => healthController;

        public Player(float positionX, float positionY)
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(20, 100));
            playerAnimator = new PlayerAnimator();

            playerController = new PlayerController(transform, this);
            defaultPower = new PowerDefault(this);
            fastPower = new PowerFast(this);
            power = new PowerDefault(this);

            healthController = new HealthController(100);
            healthController.OnDeath += OnPlayerDeath;
        }

        public void Update()
        {
            playerController.Update();
            playerAnimator.Update();

            if (Engine.GetKey(Engine.KEY_ESP))
            {
                power.Shoot();
            }
        }

        public void Render()
        {
            Engine.Draw(playerAnimator.CurrentFrame, transform.Position.x, transform.Position.y);
        }

        public void Shot()
        {
            playerAnimator.AnimShoot();
        }

        public void ChangePower(string type)
        {
            if(type == "default")
            {
                power = defaultPower;
            }
            else if (type == "fast")
            {
                power = fastPower;
            }
        }

        public void GetDamage(int damage)
        {
            healthController.GetDamage(damage);
        }

        private void OnPlayerDeath()
        {
            GameManager.Instance.ChangeState(gameState.gameOver);
        }
    }
}
