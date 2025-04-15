using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Tao.Sdl;



namespace MyGame
{

    class Program
    {
        static private List<Bullet> bullets = new List<Bullet>(); // Bullets list
        static private Image fondo = Engine.LoadImage("assets/fondoP.png");
        static private EnemySpawn enemySpawn;
        static private Enemy enemy;
        static private Player player1;
        static private float deltaTime;
        static private DateTime initialTime;
        static private float timeLastFrame;


        static public float DeltaTime => deltaTime;

        static void Main(string[] args)
        {
            Engine.Initialize();
            InizializeLevel();

            initialTime = DateTime.Now; // Get the initial time

            while (true)
            {
                float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds; // Calculate the current time
                deltaTime = currentTime - timeLastFrame; // Calculate the delta time
                timeLastFrame = currentTime; // Update the last frame time

                Update();
                Render();
            }
        }

        static public void InizializeLevel() // Initialize the level
        {
            player1 = new Player(0, 0); // Create a new player at position
        }


        static void Update()
        {
            player1.Upadate(); // Update the player

            for (int i = 0; i < bullets.Count; i++) // Update the bullets
            {
                bullets[i].Update(); 
            }
        }

        /// Render the game objects on the screen
        static void Render()
        {
            
            Engine.Clear(); // Clear the screen          
            Engine.Draw(fondo, 0, 0); // Draw the background image
            player1.Render(); // Render the player

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Render();
            }

            Engine.Show(); // Update the screen

        }

        static public void AddBullet(float posX, float posY) // Add a bullet to the game
        {
;           bullets.Add(new Bullet(posX + 48, posY)); // Add a new bullet to the list
        }
    }
}