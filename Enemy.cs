using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy
    {
        private EnemyMovement enemyMovement; // The enemy's movement component
        private Transform transform; // The enemy's transform component
        private Animation currentAnimation; // The current animation of the enemy

        private Vector2 initial;
        private int health = 1; // The enemy's health

        public Transform Transform => transform; // Property to access the transform component

        public Enemy(float positionX, float positionY) // Constructor to initialize the enemy with a position
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(100, 100)); 
            enemyMovement = new EnemyMovement(transform); // Initialize the enemy's movement component
            initial = transform.Position; // Store the initial position of the enemy

            createAnimation(); // Create the enemy's animation
        }

        public void createAnimation()
        {
            List<Image> frames = new List<Image>();

            for (int i = 0; i < 8; i++)
            {
                Image frame = Engine.LoadImage($"assets/Enemy/Run/{i}.png");
                frames.Add(frame); // Add the frame to the list
            }

            currentAnimation = new Animation("Run", 0.1f, frames, true); // Create a new animation with the frames
        }

        public void Update() // Update the enemy's state
        {
            enemyMovement.Update(); // Update the enemy's movement 
            currentAnimation.Update(); // Update the current animation
            if (currentAnimation.IsFinished())
            {
                currentAnimation.Reset(); // Reset the animation if it is finished
            }
        }

        public void Render() // Render the enemy on the screen
        {
            Engine.Draw(currentAnimation.CurrentImage, transform.Position.x, transform.Position.y); // Draw the enemy image at its position
        }

        public void GetDamage(int damage)
        {
            health -= damage; // Reduce the enemy's health by the damage amount

            if(health < 0)
            {
                GameManager.Instance.LevelController.Enemies.Remove(this); // Remove the enemy from the list if health is less than 0
            }
        }

        public void Spawn()
        {
            transform.Reposition(initial);
        }
    }
}
