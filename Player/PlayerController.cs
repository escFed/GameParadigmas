using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PlayerController : IController
    {
        private Player player;
        private float speed = 1.5f;

        private Transform transform;

        public PlayerController(Transform transform, Player player)
        {
            this.transform = transform;
            this.player = player;
        }

        public void Update()
        {
            if (Engine.GetKey(Engine.KEY_W))
            {
                if (transform.Position.y > 120)
                    transform.Translate(new Vector2(0, -1), speed);
            }

            if (Engine.GetKey(Engine.KEY_S))
            {
                if (transform.Position.y < 565)
                    transform.Translate(new Vector2(0, 1), speed);
            }

            if (Engine.GetKey(Engine.KEY_Q))
            {
                player.ChangePower("default");
            }

            if (Engine.GetKey(Engine.KEY_E))
            {
                player.ChangePower("fast");
            }
        }
    }
}
