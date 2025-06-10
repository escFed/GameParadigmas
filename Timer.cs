using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Timer
    {
        private float currentTime = 0f; // The current time in the game
        private float survivalTime = 30f; // The time the player has to survive

        private float lastTime = 0f; // The last time the timer was updated

        public float SurvivalTime => survivalTime;

        public void Start()
        {
            currentTime = survivalTime; // Initialize the current time to the survival time
            lastTime = survivalTime; // Set the last time to the survival time
        }

        public void Update()
        {
            if (survivalTime > 0)
            {
                survivalTime -= Time.DeltaTime; // Decrease the survival time by the delta time

                if (lastTime - survivalTime >= 1)
                {
                    lastTime = survivalTime; // Update the last time to the current survival time
                    Console.Clear(); // Clear the console
                    Console.WriteLine($"Tiempo restante: {Math.Ceiling(survivalTime)} segundos");
                }
            }

            else if (survivalTime < 0)
            {
                GameManager.Instance.ChangeState(gameState.youWin); // Change to the win state
                survivalTime = 0; // Ensure survival time doesn't go negative
            }
        }
    }
}
