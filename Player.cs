using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Player
    {
        private Image playerImage = Engine.LoadImage("assets/playerP.png"); // The player's image

        private Transform transform;
        private PlayerController playerController;

        public Player(float positionX, float positionY)
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(100, 100)); // Initialize the player's transform component
            playerController = new PlayerController(transform); // Initialize the player's controller component
        }

        public void Upadate()
        {
            playerController.Update();
        }

        public void Render()
        {
            Engine.Draw(playerImage, transform.Position.x, transform.Position.y);
        }
    }
}
