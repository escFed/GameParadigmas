using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy
    {
        private Image enemyImage = Engine.LoadImage("assets/enemyP.png"); // The enemy's image

        private EnemyMovement enemyMovement; // The enemy's movement component
        private EnemySpawn enemySpawn; // The enemy's spawn component
        private Transform transform; // The enemy's transform component

        public Transform Transform => transform; // Property to access the transform component

        public Enemy(float positionX, float positionY) // Constructor to initialize the enemy with a position
        {
            transform = new Transform(new Vector2(positionX, positionY)); 
            enemyMovement = new EnemyMovement(transform); // Initialize the enemy's movement component
        }

        public void Update() // Update the enemy's state
        {
            enemyMovement.Update(); // Update the enemy's movement
            enemySpawn.Update(); 
        }

        public void Render() // Render the enemy on the screen
        {
            Engine.Draw(enemyImage, transform.Position.x, transform.Position.y); // Draw the enemy image at its position
        }
    }
}
