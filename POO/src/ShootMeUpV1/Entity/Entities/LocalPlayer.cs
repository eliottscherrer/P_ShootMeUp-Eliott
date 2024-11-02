using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class LocalPlayer : Entity
    {
        private float bulletCooldown;
        private float protectionCooldown;
        private float timeSinceLastBullet = 0f;
        private float timeSinceLastProtection = 0f;

        public LocalPlayer(Vector2 position) : base(position)
        {
            AddComponent(new MovementComponent(new PlayerMovementLogic(), Configs.Player.BaseSpeed));
            AddComponent(new RenderComponent(Configs.Player.Texture, scale: Configs.Player.BaseScale));
            AddComponent(new CollisionComponent(Configs.Player.BaseCollisionRadius));
            AddComponent(new HealthComponent(Configs.Enemy.BaseMaxHealth));

            //AddComponent(new DebugComponent());

            bulletCooldown = Configs.Player.BulletCooldown;
            protectionCooldown = Configs.Player.ProtectionCooldown;
        }

        public override void Update(GameTime gameTime)
        {
            // Update cooldown timers
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastBullet += deltaTime;
            timeSinceLastProtection += deltaTime;

            // Check cooldown for firing bullet
            if (InputManager.WasLeftButtonJustPressed() && timeSinceLastBullet >= bulletCooldown)
            {
                FireBullet();
                timeSinceLastBullet = 0f; // Reset cooldown timer
            }

            // Check cooldown for placing protection
            if (InputManager.WasRightButtonJustPressed() && timeSinceLastProtection >= protectionCooldown)
            {
                PlaceProtection();
                timeSinceLastProtection = 0f; // Reset cooldown timer
            }
        }

        private void FireBullet()
        {
            // TODO: Change the start position so it's not on top left
            Vector2 startPosition = Position;

            // Create and add the bullet entity
            Vector2 direction = Position.GetDirectionTo(InputManager.MousePosition);
            EntityManager.Add(new Bullet(startPosition, direction, Bullet.BulletType.LocalPlayer));
        }

        private void PlaceProtection()
        {
            // Create and add the protection with the center of the protection at mouse position 
            Vector2 position = InputManager.MousePosition - GetComponent<RenderComponent>().Size / 2;
            EntityManager.Add(new Protection(position));
        }

        public override void OnCollision(Entity other)
        {
            switch (other)
            {
                // When the player collides with a bullet from another entity
                case Bullet bullet when bullet.Type != Bullet.BulletType.LocalPlayer:
                    bullet.IsDestroyed = true;
                    GetComponent<HealthComponent>().TakeDamage(Configs.Enemy.BaseDamage); // TODO: Add variable damage amount depending on the enemy type etc.
                    break;

                default: break;
            }
        }
    }
}