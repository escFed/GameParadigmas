using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LevelController
    {
        private List<Bullet> bullets = new List<Bullet>(); // Bullets list
        private List<Enemy> enemies = new List<Enemy>(); // Enemies list
        private Image fondo = Engine.LoadImage("assets/Screens/castle.png");
        public Player player;
        
        private Timer timer = new Timer(); // Timer for the level

        public List<Bullet> Bullets => bullets; // Property to access the list of bullets
        public List<Enemy> Enemies => enemies; // Property to access the list of enemies

        public LevelController()
        {
            InitializeLevel(); // Initialize the level
        }

        public void InitializeLevel() 
        {
            timer.Start(); // Start the timer

            player = new Player(30, 320); // Create a new player at position

            enemies.Add(new Enemy(1100, 110));   
            enemies.Add(new Enemy(1100, 230)); 
            enemies.Add(new Enemy(1100, 370));
            enemies.Add(new Enemy(1100, 520));
        }

        public void ResetLevel() // Reset the level
        {
            bullets.Clear(); // Clear the bullets list
            enemies.Clear(); // Clear the enemies list
            InitializeLevel(); // Reinitialize the level

            timer = new Timer(); // Reset the timer
            timer.Start(); // Start the timer again
        }

        public void Update()
        {           
            timer.Update(); // Update the timer

            player.Update(); // Update the player

            for (int i = 0; i < bullets.Count; i++) // Update the bullets
            {
                bullets[i].Update();
            }

            for (int i = 0; i < enemies.Count; i++) // Update the enemies
            {
                enemies[i].Update();
            }
        }

        public void Render()
        {
            Engine.Clear(); // Clear the screen          
            Engine.Draw(fondo, 0, 0); // Draw the background image
            player.Render(); // Render the player

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Render();
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Render();
            }
            Engine.Show(); // Update the screen
        }

        public void AddBullet(float posX, float posY) // Add a bullet to the game
        {
           bullets.Add(new Bullet(posX + 48, posY)); // Add a new bullet to the list
        }
    }
}
