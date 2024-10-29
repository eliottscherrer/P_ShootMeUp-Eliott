using Microsoft.Xna.Framework;

namespace ShootMeUpV1
{
    public class LocalPlayer : Entity
    {
        public LocalPlayer(Vector2 position) : base(position)
        {
            AddComponent(new MovementComponent(new PlayerMovementLogic(), 300f));   // Speed
            AddComponent(new RenderComponent(Visuals.Player, 0.25f));               // Player texture
            AddComponent(new CollisionComponent(50f));                              // Collision radius
            AddComponent(new HealthComponent(Configs.Enemy.BaseMaxHealth));

            // TODO: Health
            //       Debug infos
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.WasLeftButtonJustPressed())
            {
                FireBullet();
            }
        }

        private void FireBullet()
        {
            // TODO: Change the start position so it's not on top left
            Vector2 startPosition = Position;

            // Create and add the bullet entity
            Vector2 direction = Position.GetDirectionTo(InputManager.MousePosition);
            EntityManager.Add(new Bullet(startPosition, direction));
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
