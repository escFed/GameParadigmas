using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LvlOneController
    {
        private List<Bullet> bullets = new List<Bullet>(); // Bullets list
        private List<Enemy> enemies = new List<Enemy>(); // Enemies list
        private Image fondo = Engine.LoadImage("assets/Screens/castle.png");
        public Player player;
        private Hud hud;

        private Timer timer = new Timer(); // Timer for the level
        public Hud Hud => hud;

        public List<Bullet> Bullets => bullets; // Property to access the list of bullets
        public List<Enemy> Enemies => enemies; // Property to access the list of enemies

        public LvlOneController()
        {
            //InitializeLevel(); 
        }

        public void InitializeLevel()
        {
            timer.Start(); // Start the timer
            hud = new Hud(); // Initialize the HUD  

            player = new Player(30, 320); // Create a new player at position

            EnemyFactory.CreateEnemy(EnemyType.Slow, 1300, 110);
            EnemyFactory.CreateEnemy(EnemyType.Fast, 1100, 230);
            EnemyFactory.CreateEnemy(EnemyType.Fast, 1200, 370);
            EnemyFactory.CreateEnemy(EnemyType.Slow, 1400, 520);
        }

        public void ResetLevel()
        {
            bullets.Clear(); // Clear the bullets list
            enemies.Clear(); // Clear the enemies list
            InitializeLevel(); // Reinitialize the level

            timer = new Timer(); // Reset the timer
            timer.Start(); // Start the timer again
        }

        public void Update()
        {
            timer.Update();

            player.Update();

            for (int i = 0; i < bullets.Count; i++) // Update the bullets
            {
                bullets[i].Update();
            }

            for (int i = 0; i < enemies.Count; i++) // Update the enemies
            {
                enemies[i].Update();
            }

            hud.UpdateTime((int)timer.SurvivalTime);
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

            hud.Render(); // Render the HUD
            Engine.Show(); // Update the screen
        }

        public void AddBullet(Bullet bullet) // Add a bullet to the game
        {
            bullets.Add(bullet); // Add a new bullet to the list
        }
    }
}
