using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Timer
    {
        public float currentTime = 0f; // The current time in the game
        public float survivalTime = 30f; // The time the player has to survive

        public void Start() 
        {
            currentTime = survivalTime; // Initialize the current time to the survival time
        }

        public void Update()
        {
            if (survivalTime > 0)
            {
                survivalTime -= Time.DeltaTime; // Decrease the survival time by the delta time

                //Console.Clear();
                Console.WriteLine($"Tiempo restante: {Math.Ceiling(survivalTime)} segundos");
            }

            else if (survivalTime < 0)
            {
                GameManager.Instance.ChangeState(gameState.youWin); // Change to the win state
                survivalTime = 0; // Ensure survival time doesn't go negative

            }
        }

    }
}
