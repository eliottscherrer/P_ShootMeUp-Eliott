using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootMeUpV1
{
    public class Enemy : Entity
    {
        private float shootingInterval;     // Intervalle en secondes entre chaque tir
        private float timeSinceLastShot;

        public Enemy(Vector2 position) : base(position)
        {
            AddComponent(new MovementComponent(new EnemyMovementLogic(), Configs.Enemy.BaseSpeed));
            AddComponent(new RenderComponent(Configs.Enemy.Texture, Configs.Enemy.Scale));
            AddComponent(new CollisionComponent(Configs.Enemy.CollisionRadius));
            AddComponent(new HealthComponent(Configs.Enemy.BaseMaxHealth));

            //AddComponent(new DebugComponent());

            shootingInterval = Configs.Enemy.BaseCooldown;
            timeSinceLastShot = 0f;
        }

        public override void Update(GameTime gameTime)
        {
            timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceLastShot >= shootingInterval + GlobalHelpers.Rand.Next(-5, 5) / 10)
            {
                FireBullet();
                timeSinceLastShot = 0.0f;
            }
        }

        private void FireBullet()
        {
            // TODO: Change the start position so it's not on top left
            Vector2 startPosition = Position;

            // Create and add the bullet entity
            Vector2 direction = Position.GetDirectionTo(EntityManager.LocalPlayer.Position);
            EntityManager.Add(new Bullet(startPosition, direction, Bullet.BulletType.Enemy));
        }

        public override void OnCollision(Entity other)
        {
            switch (other)
            {
                // Only take damage from the player's bullets
                case Bullet bullet when bullet.Type == Bullet.BulletType.LocalPlayer:
                    bullet.IsDestroyed = true;
                    GetComponent<HealthComponent>().TakeDamage(Configs.Player.BaseDamage); // TODO: Add variable damage amount depending on the weapon of the player etc.
                    break;

                default: break;
            }
        }
    }
}
