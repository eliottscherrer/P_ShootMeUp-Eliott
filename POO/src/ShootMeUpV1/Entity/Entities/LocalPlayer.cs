using Microsoft.Xna.Framework;
using System;

namespace ShootMeUpV1
{
    public class LocalPlayer : Entity
    {
        public int Damage = 20;

        public LocalPlayer(Vector2 position) : base(position)
        {
            // TODO: Config files
            AddComponent(new MovementComponent(new PlayerMovementLogic(), 300f));   // Speed
            AddComponent(new RenderComponent(Visuals.Player, 0.25f));               // Player texture
            AddComponent(new CollisionComponent(50f));                              // Collision radius

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
            Vector2 aimDirection = GetAimDirection();
            Vector2 bulletStartPosition = Position;

            // Create and add the bullet entity
            EntityManager.Add(new Bullet(bulletStartPosition, aimDirection));
        }

        private Vector2 GetAimDirection()
        {
            // Get the direction from the player to the mouse position
            Vector2 direction = InputManager.MousePosition - Position;
            return direction != Vector2.Zero ? Vector2.Normalize(direction) : Vector2.Zero;
        }
    }
}
