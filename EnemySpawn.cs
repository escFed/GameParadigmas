using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemySpawn
    {
        private List<Enemy> enemyList = new List<Enemy>(); // List to store spawned enemies
        private Transform transform; // The enemy's transform component

        private float spawnTime = 0f; // Time between spawns
        private float spawnCooldown = 3f; // Cooldown timer

        public EnemySpawn(Transform transform)
        {
            this.transform = transform; // Initialize the transform component
        }

        public List<Enemy> EnemyList => enemyList; // Property to access the list of enemies
        public void Update()
        {
            spawnTime += Program.DeltaTime; // Update the spawn time
            if (spawnTime > spawnCooldown)
            {
                enemyList.Add(new Enemy(900, 150));
                enemyList.Add(new Enemy(900, 300));
                enemyList.Add(new Enemy(900, 450));
                enemyList.Add(new Enemy(900, 600));
                enemyList.Add(new Enemy(900, 750));
            }

            //if (Program.EnemyList.Count == 0)
           // {
              //  respawnTimer += Program.DeltaTime;

              //  if (respawnTimer >= respawnInterval)
               // {
               //     Program.EnemyList.Add(new Enemy(spawnPosition.x, spawnPosition.y));
               //     respawnTimer = 0f;
                //}
            //}

        }


    }
}
