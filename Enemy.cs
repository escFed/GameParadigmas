using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class Enemy
    {
           
        protected Transform transform;        

        private Vector2 initial; // The initial position of the enemy
        //private int health = 1; // The enemy's health
        protected HealthController healthController;

        public Transform Transform => transform; // Property to access the transform component

        public Enemy(float positionX, float positionY, float speed) 
        {
            transform = new Transform(new Vector2(positionX, positionY), new Vector2(100, 100));
            initial = transform.Position; // Store the initial position of the enemy
            healthController = new HealthController(100);
            healthController.OnCollision += OnEnemyHit;
            healthController.OnDeath += () =>
            {
                GameManager.Instance.LevelController.Enemies.Remove(this);
            };
        }

        public abstract void Update();

        public abstract void Render();


        public void GetDamage(int damage)
        {
            //health -= damage; // Reduce the enemy's health by the damage amount
            healthController.GetDamage(damage);

           // if(health < 0) //check if the enemy's health is less than 0
            //{
              //  GameManager.Instance.LevelController.Enemies.Remove(this); // Remove the enemy from the list if health is less than 0
            //}
        }

        public void OnEnemyHit()
        {
            Console.WriteLine("enemyHit");
        }

        public void Spawn()
        {
            transform.Reposition(initial); //Reposition the enemy to its initial position
        }
    }
}
