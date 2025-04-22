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
        private Transform transform;
        private PlayerController playerController;
        private PlayerAnimator playerAnimator;

        public Player(float positionX, float positionY)
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(100, 100)); // Create a new Transform object with the specified position and size
            playerController = new PlayerController(transform);
            playerAnimator = new PlayerAnimator();
        }       

        public void Update()
        {
            playerController.Update();
            playerAnimator.Update();

        }

        public void Render()
        {
            Engine.Draw(playerAnimator.CurrentFrame, transform.Position.x, transform.Position.y);
        }

       public void shoot()
        {
            playerAnimator.AnimShoot();
        }
        
    }
}
