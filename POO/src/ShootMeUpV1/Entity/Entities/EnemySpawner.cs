using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class EnemySpawner : Entity
    {
        private float _spawnInterval;           // Time in seconds between spawns
        private float _timeSinceLastSpawn;

        public EnemySpawner(Vector2 position, float spawnInterval) : base(position)
        {
            _spawnInterval = spawnInterval;
            _timeSinceLastSpawn = 0f;

            AddComponent(new RenderComponent(Configs.EnemySpawner.Texture, Configs.EnemySpawner.Scale));

            AddComponent(new DebugComponent());
        }

        public override void Update(GameTime gameTime)
        {
            // Update the time since last spawn
            _timeSinceLastSpawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Check if it's time to spawn a new enemy
            if (_timeSinceLastSpawn >= _spawnInterval)
            {
                SpawnEnemy();
                _timeSinceLastSpawn = 0f; // Reset the timer
            }
        }

        public void SpawnEnemy()
        {
            EntityManager.Add(new Enemy(this.Position));
        }
    }
}
