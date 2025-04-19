using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemySpawn
    {
        private Transform transform; // The enemy's transform component

        private float spawnTime = 0f; // Time between spawns
        private float spawnCooldown = 3f; // Cooldown timer

        public EnemySpawn(Transform transform)
        {
            this.transform = transform; // Initialize the transform component
        }

        public void Update()
        {
            spawnTime += Time.DeltaTime; // Update the spawn time
            if (spawnTime > spawnCooldown)
            {

            }
        }
    }
}
