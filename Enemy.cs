using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy
    {
        private EnemyMovement enemyMovement; 
        private EnemyAnimator enemyAnimator; 
        private Transform transform;        

        private Vector2 initial; // The initial position of the enemy
        private int health = 1; // The enemy's health

        public Transform Transform => transform; // Property to access the transform component

        public Enemy(float positionX, float positionY) 
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(100, 100)); 
            enemyMovement = new EnemyMovement(transform); 
            enemyAnimator = new EnemyAnimator(); 
            initial = transform.Position; // Store the initial position of the enemy

        }       

        public void Update() 
        {
            enemyMovement.Update(); // Update the enemy's movement
            enemyAnimator.Update(); // Update the enemy's animation
        }

        public void Render() 
        {
            Engine.Draw(enemyAnimator.CurrentFrame, transform.Position.x, transform.Position.y); // Draw the enemy image at its position
        }

        public void GetDamage(int damage)
        {
            health -= damage; // Reduce the enemy's health by the damage amount

            if(health < 0) //check if the enemy's health is less than 0
            {
                GameManager.Instance.LevelController.Enemies.Remove(this); // Remove the enemy from the list if health is less than 0
            }
        }

        public void Spawn()
        {
            transform.Reposition(initial); //Reposition the enemy to its initial position
        }
    }
}
